using BlazorDemo.Application.Users.GetAll;
using BlazorDemo.Domain.Users;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UserManagerMVC.Models;
using Newtonsoft.Json;
using UserManagerMVC.Models.Users;
using BlazorDemo.Domain.Addresses;
using Microsoft.AspNetCore.Http;
using BlazorDemo.Application.Users.Save;
using Microsoft.AspNetCore.Components;

namespace UserManagerMVC.Controllers;

[Authorize]
public class UsersController : Controller
{
    const string GRID_STATE_KEY = "GridState";
    private readonly IMediator _mediator;

    List<City> _cities = new List<City>()
    {
        new City("5000", "Szolnok"),
        new City("1000", "Budapest"),
        new City("5052", "Újszász"),
    };

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult EditUser()
    {
        return View();
    }

    public async Task<ActionResult> GetAllUsers([DataSourceRequest] DataSourceRequest request)
    {
        var userList = await _mediator.Send(new GetAllUserQuery());
        var vmList = userList.Select(x => new UserViewModel(x)).ToList().AsEnumerable();
        var dsResult = vmList.ToDataSourceResult(request);

        SaveGridStateToTempData((IEnumerable<UserViewModel>)dsResult.Data);

        return Json(dsResult);
    }

    public  IActionResult ExportGridData()
    {
        var gridState = GetGridStateFromTempData();

        if (gridState != null)
        {
            var serializer = new XmlSerializer(typeof(List<UserViewModel>));
            var memoryStream = new MemoryStream();
            serializer.Serialize(memoryStream, gridState);
            memoryStream.Position = 0;

            var fileName = "grid_data.xml";

            return File(memoryStream, "application/xml", fileName);
        }

        // Ha nincs grid állapota, akkor csak a gombot megjelenítjük
        return View();
    }

    [HttpGet("Users/{userId:int}")]
    public async Task<IActionResult> Edit([FromRoute] int userId)
    {
        var user = await _mediator.Send(new GetUserQuery(userId));

        if (user == null)
        {
            return NotFound();
        }
        var editUserVM = new EditUserViewModel(user);

        return View("EditUser", editUserVM);
    }

    public IActionResult Cities()
    {
        return Json(_cities);
    }

    public async Task<IActionResult> Save(EditUserViewModel userVm)
    {
        var city = _cities.FirstOrDefault(x => x.PostCode == userVm.PostCode);
        var user = userVm.ToUser(city);

        await _mediator.Send(new SaveUserCommand(user));

        return RedirectToAction("Index");
    }

    private void SaveGridStateToTempData(IEnumerable<UserViewModel> data)
    {
        var jsonData = JsonConvert.SerializeObject(data);
        TempData[GRID_STATE_KEY] = jsonData;
    }

    private List<UserViewModel> GetGridStateFromTempData()
    {
        if(TempData.TryGetValue(GRID_STATE_KEY, out var value))
        {
            var data = JsonConvert.DeserializeObject<List<UserViewModel>>((string)value);
            return data;
        }

        return null;
    }
}
