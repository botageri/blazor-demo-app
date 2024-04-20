1. ASP.NET MVC felhasználó menedzsment alkalmazás létrehozása (C#, .Net Core 6+)
2. Fájl alapú ‘adatbázis’, amelyben felhasználó adatok vannak tárolva (pl. pontosvesszővel tagoltan): Azonosító, Felh.név, Jelszó, Vezetéknév, Keresztnév, Szül. idő, Szül. hely, Lakhely (város)
3. Első nézet: beléptetés az ‘adatbázis’ alapján (Felhasználónév / Jelszó)
4. Második oldal: a felhasználók adatainak listázása táblázatos formában. A táblázatot töredékes keresővel lehessen filterezni (min. 3 gomb lenyomás után azok a sorok maradjanak a gridben, amelyek tartalmazzák töredékesen a beírt szöveget). A táblázatot XML formátumba lehessen menteni egy gomb segítségével.
   A táblázat adott sorának kiválasztását követően egy módosítás gomb megnyomását követően a harmadik, detail oldalra jussunk el.
5. Harmadik oldal: az előző oldalon kiválasztott felhasználó rekord adatait lehessen szerkeszteni megfelelő input mezőkkel (legyen dátumválasztás, lenyíló, maszkolt input is), majd menteni file -ba!
   Validációt követően, sikeres mentés esetén kerüljünk vissza a második, listázó ablakra, ahol a frissített adattartalom látszódjon.

Amennyiben lehetséges, használj Telerik Kendo UI (trial elérhető) komponenseket.
Megfelelő szervezéssel, komponensekben gondolkodva, saját interfészek bevezetésével dolgozz!
