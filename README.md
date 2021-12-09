[![ASP.NET backend test](https://github.com/Parziwal/IRestaurant/actions/workflows/backend-test.yml/badge.svg)](https://github.com/Parziwal/IRestaurant/actions/workflows/backend-test.yml)
[![ASP.NET backend deploy](https://github.com/Parziwal/IRestaurant/actions/workflows/backend-deploy.yml/badge.svg)](https://github.com/Parziwal/IRestaurant/actions/workflows/backend-deploy.yml)
[![Angular frontend deploy](https://github.com/Parziwal/IRestaurant/actions/workflows/frontend-deploy.yml/badge.svg)](https://github.com/Parziwal/IRestaurant/actions/workflows/frontend-deploy.yml)

# IRestaurant

Az **IRestaurant** egy étteremkezelő webalkalmazás, amit szakdolgozatomhoz készítettem. Az alkalmazás szerver oldala `ASP.NET Core` és a kliens oldala `Angular` keretrendszerrel készült.

## Cél

A kisebb vendéglátó egységektől általában nem rendelkeznek megfelelő webes felülettel, ahol tájékozódhatnánk az étterem aktuális kínálatáról és rendeléseket adhatnánk le. Házszállítás esetén általában csak a hagyományos telefonos rendelési opció érhető el.

A probléma megoldására egy olyan webalkalmazás készítése volt a célom, ami a kisebb éttermek számára nyújt megoldást kínálatuk hirdetésében és a rendeléssel kapcsolatos folyamatok kezelésében. Továbbá azt is szerettem volna biztosítani a felhasználók számára, hogy az oldalon kifejezhessék véleményüket az egyes éttermekkel kapcsolatban, ezzel is segítve a többi felhasználót a tájékozódásaban.

## Az alkalmazás futtatása

### Szerver oldal

1. A projekt `Backend` részét Visual Studio-val kell megnyitni. Fontos, hogy a Visual Studio-ban telepítve legyenek az `ASP.NET and web development` és a `Python development` csomagok. Ezt a `Tools` -> `Get Tools and Features...` menüpontban tudjuk leellenőrizni.
2. Az alkalmazás működéséhez szükséges egy Microsoft SQL Server. Az adatbázis lérehozásához a Visual Studio-ban nyissunk egy `Package Manager Console` ablakot (`Tools` -> `NuGet Package Manager` -> `Package Manager Console`), majd ott adjuk ki a `Update-Database -P IRestaurant.DAL`.
3. A szerver oldal elindításához először ki kell választani a futtatandó projekteket. Ehhez a `Solution Explorer` ablakban jobb klikk a `Solution IRestaurant` projektre, majd válasszuk a `Properties` lehetőséget. A felugró ablakban `Multiple startup projects` opciót kell beállítani, és ezen belül az `IRestaurant.Auth` és `IRestaurant.WebAPI` projektek `Action` lehetőségét kell `Start` módra állítani.
4. Végül a Visual Studio-ban az F5 vagy a toolbarban található zöld nyílra kattintva lehet az Auth és WebAPI projekteket lefordítani és elindítani.
5. A böngészőben a `https://localhost:5001/swagger` címen érhetők el a Swagger UI, ami a Web API egyes végpontjai írja le. A `https://localhost:5000/Identity/Account/Login` címen pedig az Auth szerver bejelentkezési felülete.

_Megjegyzés:_ A webalkalmazásban az email küldő szolgáltatás alapból nem fog működni, így a regisztráció, elfelejtett jelszó és az email változtatási funkciók nem lesznek elérhetők. Ennek megoldására két lehetőség van:

- SendGrid fiók létrehozása, és az API kulcs lokális elmentése az alábbi parancsal: `dotnet user-secrets set SendGridKey <API kulcs>`
- Az Auth projekt Startup fájlában a `RequireConfirmedAccount` változót `false` értékre kell állítani és az alábbi sort kitörölni `services.AddTransient<IEmailSender, EmailSender>()`, de ezzel viszont csak a regisztráció válik működőképessé.

### Kliens oldal

1. Az Angular kliens futtatásának feltétele, hogy a `Node.js` csomagkezelő és az `Angular CLI` telepítve legyen, valamint, hogy a szerver oldal már fusson.
2. Ezután parancssorból a kliens alkalmazás mappájában (`Frontend\irestaurant-angular-client`) adjuk ki az `ng serve --open`
parancsot, melynek hatására elindul a szerver és a böngészőben megnyitásra kerül a kliens a `http://localhost:4200/` címen.

## Főbb technológiák

- **Angular** Frontend: , Angular Material, angular-oauth2-oidc
- **ASP.NET Core** Backend: Identity Core, Microsodt SQL Server, Entity Framework Core, IdentityServer, Razor Pages, ProblemDetails middleware, xUnit
- **Azure** felhőszolgáltatás: Azure App Service, Azure SQL Database, Azure Key Vault, SendGrid

## Az alkalmazás struktúrája

A webalkalmazás a többrétegű architektúrát követi:

- `IRestaurant.DAL`: Az adatelérési réteg, ami az elemi adatszolgáltatási műveletekért felelős.
  - Enity Framework Core használ az adateléréshez
  - De becsomagolja a műveleteket _Repository_ tervezési minta segítségével
- `IRestaurant.BL`: Az üzleti logikai réteg, kezeli az üzleti folyamatokat és összetettebb adatmódosítási feladatokat valósít meg.
- `IRestaurant.Auth`: Az alkalmazás hitelesítésével és a felhasználók érzékenyebb adaitnak kezelésével kapcsolatos feladatokat lát el.
  - Razor Pages oldalakat használ a bejelentkezéshez, regisztrációhoz és érzékenyebb adatok kezeléséhez.
- `IRestaurant.WebAPI`: A Web API az Auth szerver egy védett erőforrása, ami a webalkalmazás szolgáltatásaihoz biztosít hozzáférést az arra jogosult felhasználóknak.
  - Swagger API leíró segítségével dokumentált
- `irestaurant-angular-client`: Az Angular kliens alkalmazás, ami az Auth szerver segítségével hitelesíti a felhasználót és a Web API szerveren keresztül éri el a szolgáltatásokat.
 
## Az alkalmazás funkcionalitásának leírása

A weboldalra kétféle szerepkörben lehet beregisztrálni:
- Vendégként
- Étteremként

Az oldalon mindenkinek, a regisztrálatlan felhasználóknak is lehetősége van az éttermek között böngészni. Emellett megtekinthetik az étterem részletes oldalát, a fontosabb információkat, részletes leírást, az étlapot és az értékeléseket.

### Vendégi jogkörrel rendelkező felhasználók

- A vendégek rendelhetnek az egyes éttermektől. A rendelés éttermekként van, vagyis ha több étteremtől is szeretne rendelni azt külön-külön kell megtennie.
- A rendelés leadása után egy külön oldalon a vendégek nyomon tudják követni rendeléseik állapotát, illetve a korábbiakat is megtekinthetik.
- Minden rendeléshez elérhető egy részletes oldal, ami a számlázással kapcsolatos adatokat tartalmazza.
- A vendégeknek lehetőségük van a feldolgozási fázisban lévő rendeléseik visszavonására.
- A vendégeknek lehetőségük van kedvenc éttermeik elmentésére, vagy a későbbiek során azok törlésére a listából.
- A vendégek értékeléseket írhatnak az egyes éttermekhez, egy 1-tól 5-ig terjed skálán értékelhetik azt és egy bővebb leírást is hozzáadhatnak. Az értékeléseket csak az azt publikáló felhasználó törölheti.
- Az alapvető felhasználói adatok beállítására is lehetőség van, mint a felhasználónév, vezeték és keresztnév, email, jelszó, valamint a lakcímek.

### Étterem jogkörrel rendelkező felhasználók

- Az étteremként regisztrált felhasználók étterme regisztráció után még nem elérhetőek az oldalon, ehhez a kötelező adataikat meg kell adniuk.
- Az éttermek egy külön oldalon tudják szerkeszteni adataikat, mint: név, rövid ismertető, részletes leírás, cím, illetve egy kép az étteremről.
- Minden étteremhez tartozik egy étlap oldal, ahol lehetőség van új étel felvételére, egy meglévő módosítására vagy törlésére. Az ételek esetén lehetőség van kép feltöltésére.
- A láthatóságuk és a rendelési opciók ki és be kapcsolására is lehetőségük van. Ha az éttermet leveszik az oldalról, tehát kikapcsolják a láthatóságát, akkor a rendelési opció is automatikusan kikapacsolásra kerül. Az étterem láthatóságának bekapcsolására csak akkor van lehetőségük, ha a kötelező adatok ki vannak töltve. A rendelési opció bekapcsolására pedig, ha legalább egy étel szerepel az étlapon és az étterem látható.
- Az éttermekhez tartozik egy rendelés oldal is, ahol a vendégektől beérkező rendeléseket lehet nyomonkövetni.
- A beérkező rendeléseket lehetőség van a következő fázisba mozgatni, illetve visszamondani.
- Minden rendeléshez tartozik egy részletes oldal, ami a számlázási adatokat tartalmazza.
- Az alapvető felhasználói adatok beállítására is lehetőség van, mint a felhasználónév, vezeték és keresztnév, email és jelszó.
