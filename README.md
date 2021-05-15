# IRestaurant
Az alkalmazás lényege, hogy a felhasználók, azaz a vendégek házhoz tudják rendelni kedvenc helyi éttermeik ételeit egy online felületen keresztül. Az éttermeket elégedettségük szerint értékelhetik is, valamint mások értékelési alapján tovább tájékozódhatnak, és újabb helyeket is felfedezhetnek. Az éttermek pedig az oldalon keresztül tudják reklámozni üzleteiket, illetve házhoz szállítási lehetőséget is tudnak biztosítani vendégeik számára.

## Az alkalmazás futtatása

- Szükséges egy Microsoft SQL Server, az adatbázis az alkalmazás elindulása, majd létrejön és inicializálja magát.
- A projektet Visual Studio-val kell megnyitni, és jobb klikk az `IRestaurant.Web` projekten, majd "Set as Startup Project lehetőséget kell kiválasztani.
- Elöszőr az Angular kliens alkalmazást érdemes elindítani, ehhez a ClienApp mappában kell kiadni az "ng serve" parancsot.
- Végül a Visual Studio-ban az F5 vagy a toolbarban található zöld nyílra kattintva lehet a projektet lefordítani és elindítani.

## Technológiák
- Frontend: Angular
- Backend: ASP.NET Core, Entity Framework

## Az alkalmazás struktúrája

A projekt egy három rétegű webalkalmazás:

- `IRestaurant.Web`: ASP.NET Core webalkalmazás, az alkalmazás belépési pontja
  - Tartalmaz egy Angulat kliens alkalmazást
  - És kiszolgálja a REST kéréseket
- `IRestaurant.BL`: Az üzleti logikai réteg, kezeli az üzleti folyamatokat és összetettebb adatmódosítási feladatokat valósít meg
- `IRestaurant.DAL`: Az adatelérési réteg
  - Enity Framework Core használ az adateléréshez
  - De becsomagolja a műveleteket _Repository_ tervezési minta segítségével
 
## Az alkalmazás funkcionalitásának leírása

A weboldalra kétféle szerepkörben lehet beregisztrálni:
- Vendégként
- Étteremként

Az oldalon mindenkinek, a regisztrálatlan felhasználóknak is lehetősége van az éttermek között böngészni, az étterem neve alapján. Emellett megtekinthetik az étterem részletes oldalát, a fontosabb információkat, részletes leírást, az étlapot és az értékeléseket. De rendelni és értékeléseket írni csak vendégként regisztrált felhasználók tudnak.

### Vendégi jogkörrel rendelkező felhasználók

- A vendégek értékeléseket írhatnak az egyes éttermekhez, egy 1-tól 5-ig terjed skálán értékelhetik azt és egy bővebb leírást is hozzáadhatnak. Az értékeléseket csak az azt  publikáló felhasználó törölheti.
- A vendégek rendelhetnek az egyes éttermektől. A rendelés éttermekként van, vagyis miután a vendég kiválasztotta az ételeket egy étterem étlapjáról, és megadta az adatait, mielőtt tovább haladna véglegesíteni kell a rendelését.
- A rendelés leadása után egy külön oldalon a vendégek nyomon tudják követni rendeléseik állapotát, illetve a korábbiakat is megtekinthetik. Egy részletes oldalon a rendelésről bővebben is tájékozódhatnak. A rendelés kezdeti, feldolgozási fázisába akár ezt vissza is vonhatják.
- A vendégeknek lehetőségük van kedvenc éttermeik elmentésére, vagy a későbbiek során azok törlésére a listából.
- Az alapvető felhasználói adatok beállítására is lehetőség van, mint a felhasználónév, vezeték és keresztnév, email, jelszó, valamint a lakcímek, amit rendelés során adtak meg.

### Étterem jogkörrel rendelkező felhasználók

- Az éttermek regisztráció után még nem elérhetőek az oldalon, ehhez a kötelező adataikat meg kell adniuk.
- Az éttermek egy külön oldalon tudják szerkeszteni adataikat, mint: név, rövid ismertető, részletes leírás, cím, illetve egy kép az étteremről.
- Minden étteremhez tartozik egy étlap oldal, ahol lehetőség van új étel felvételére, egy meglévő módosítására vagy törlésére, illetve egy kép feltöltésére.
- A láthatóságuk és a rendelési opciók ki és be kapcsolására is lehetőségük van. Ha az éttermet leveszik az oldalról, tehát kikapcsolják a láthatóságát, akkor a rendelési opció is automatikusan kikapacsolásra kerül. Az étterem láthatóságának bekapcsolására csak akkor van lehetőségük, ha a kötelező adatok ki vannak töltve. A rendelési opció bekapcsolására pedig, ha legalább egy étel szerepel az étlapon és az étterem látható.
- Az éttermekhez tartozik egy rendelés oldal is, ahol a vendégektől beérkező rendeléseket lehet nyomon követni. Lehetőség van a rendelést a következő fázisba mozgatni, illetve visszamondani. Egy részletes oldalon a rendelésről bővebben is tájékozódhatnak.
- Az alapvető felhasználói adatok beállítására is lehetőség van, mint a felhasználónév, vezeték és keresztnév, email és jelszó.
- Az éttermek nem rendelhetnek, nem is véleményezhetnek más éttermeket és nem menthetik el kedvenc éttermeiket.
