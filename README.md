# IRestaurant
A webalkalmazás lényege, hogy a felhasználók házhoz tudják rendelni kedvenc helyi éttermeik ételeit, valamint az oldalon keresztül az értékelések alapján újabb helyeket is felfedezhetnek. Az éttermek pedig az oldalon keresztül tudják reklámozni üzleteiket, és egyben házhoz szállítást is tudnak biztosítani vendégeik számára.

## Technológiák
- Frontend: Angular
- Backend: ASP.NET Core, Entity Framework

## Az alkalmazás struktúrája

A projekt egy három rétegű webalkalmazás:

- `IRestaurant.Web`: ASP.NET Core webalkalmazás; ez a belépési pont, ami kiszolgálja a web szervert
  - Tartalmaz egy Angulat kliens alkalmazást
  - És kiszolgálja a REST kéréseket
- `IRestaurant.BL`: Az üzleti logikai réteg, kezeli az üzleti folyamatokat
- `IRestaurant.DAL`: Az adatelérési réteg
  - Enity Framework Core használ az adateléréshez
  - De becsomagolja a műveleteket _repository_ tervezési minta segítségével
 
## Az alkalmazás funkcionalitásának leírása
A weboldalra kétféle szerepkörben lehet beregisztrálni: „vendégként” és „étteremként”.
- A vendégeknek lehetőségük van böngészni az éttermek között, és a nevük alapján szűrni rájuk.
- Miután kiválasztották a megfelelő éttermet a listából részletesebben is tájékozhatnak róla, megtekinthetik az étteremhez tartozó étlapot, és házhoz rendelhetik a kiválasztott ételeket.
- A rendelés éttermekként van, vagyis miután a vendég kiválasztotta az ételeket egy étterem étlapjáról, mielőtt tovább haladna véglegesíteni kell a rendelését.
- A vendégek folyamatban lévő rendelésüket az oldalon nyomon követhetik, illetve a korábbiakat is megtekinthetik.
- A vendégnek lehetősége van a rendelés lemondására.
- A vendégek megjelölhetik kedvenc éttermeiket.
- A vendégek értékelhetik az éttermeket egy ötös skálán és véleményezhetik azt.
- Az alapvető felhasználói adatok beállítására is lehetőségük van, mint név, cím, email, jelszó stb.
- Az éttermek, mint speciális felhasználók esetében a regisztráció után lehetőség van a személyes oldal szerkesztésére, mint az étterem neve, egy rövid ismertető/leírása az étteremről, az étterem címe, valamint egy étlap, amin a kiszállítandó ételek listája szerepel stb.
- Az éttermek az oldalon nyomon tudják követni a beérkező rendeléseket, és ez alapján jóvá tudják őket hagyni és a rendelési fázis következő szakaszába mozgatni, vagy akár el is tudják azt utasítani.
- Az éttermeknek lehetőségük van a rendelési opció kikapcsolására, illetve az étterem levételére a kereshető listából.
- Az étterem csak akkor jelenhet meg a keresési listában, ha megadta a rá vonatkozó kötelező adatokat.
- Az éttermek nem rendelhetnek más étteremből, illetve nem véleményezhetnek más éttermeket.
