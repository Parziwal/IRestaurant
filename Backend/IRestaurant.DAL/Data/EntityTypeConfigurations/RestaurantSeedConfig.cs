using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class RestaurantSeedConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "Trófea Grill Étterem - Király",
                    ShortDescription = "Olasz, Pizza, Hamburger, Amerikai, Magyaros",
                    DetailedDescription = "KING'S BUFFET Kft. Fix áron fogyaszthat a több mint 100 féle ételt felvonultató svédasztalunkról és ihat finom borokat, pezsgőt, csapolt sört, szénsavas és rostos üdítőket, ásványvizet és kávét. Használja ki a svédasztalos rendszer előnyeit és válogasson saját ízlése szerint a különböző ínyencségek között! Bőséges kínálatunkban a hideg és meleg előételektől kezdve levesek és főételek sokaságán át a desszertekig számtalan fogás megtalálható. A hagyományos magyaros ételek kedvelői éppúgy megtalálják kedvenceiket, mint a reformkonyha hívei és a vegetáriánusok. A svédasztal részeként tizenkét különböző pácban friss nyers húsok és zöldségek találhatók, amelyeket szakácsaink az Ön választása alapján látványkonyhánkban készítenek el. Kellemes hangulatban rendezhetik meg családi, baráti és céges összejöveteleiket vagy tölthetnek el egy egyszerű hétköznapi ebédet is. Várjuk Önöket szeretettel!",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "512dac39-94d2-429a-a258-7740ca64c50f",
                    ImagePath = "https://images.unsplash.com/photo-1555396273-367ea4eb4db5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI2ODY1ODM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 2,
                    Name = "Princess Bakery&Bistro Örs vezér tér",
                    ShortDescription = "Pizza, Pékség",
                    DetailedDescription = "Mindig friss péksütemények, gondos kezek által, minőségi alapanyagokból! Inditsd nálunk napjaidat, mert egy Princess mindig útba esik!",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "bc803e89-e8c0-4c5a-9467-e94cd5dd0300",
                    ImagePath = "https://images.unsplash.com/photo-1543007631-283050bb3e8c?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI2ODcwNDE&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 3,
                    Name = "Twentysix Budapest",
                    ShortDescription = "Mediterrán, Olasz , Nemzetközi, Közép Keleti",
                    DetailedDescription = "A Twentysix Budapest egy hatalmas ősoázis tele növénnyel a belváros szívében, egy nagyon zöld, botanikus, tér, ahol a gasztronómia, a természet és a felelős vendéglátás filozófiája találkozik és kel életre a különböző terekben: GARDEN° – mediterrán étterem, SHOP° – no waste kávézó és csomagolásmentes delikátesz bolt, STUDIO° – jógastúdió és HOUSE° – lakásstúdió és rendezvényterem. Budapest legzöldebb kertje, ahol nincsenek évszakok, csak az igazi, mediterrán nyár, az év minden napján. Egy hely, ahol a természet, a gasztronómia és a tudatos lét találkozik.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "8480bf9e-9553-47b7-a57b-474715139a83",
                    ImagePath = "https://images.unsplash.com/photo-1551632436-cbf8dd35adfa?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjMxNzc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600",
                },
                new Restaurant
                {
                    Id = 4,
                    Name = "Csokonai Étterem",
                    ShortDescription = "Terasz és kert, Privát helyiség, Gyermekbarát, Elvitel",
                    DetailedDescription = "A söröző-étterem a Csokonai Színházzal szemben található, klimatizált pincehelyiség, ahol különböző méretű és hangulatú termek állnak rendelkezésre csoportok fogadsára, rendezvények lebonyolítására. Elkülönített, nemdohányzó helyiség is szolgálja a vendégek kényelmét. Az ételválasztékban nemzetközi, és hagyományos magyaros ételspecialitások gazdag kínálatát vonultatja fel az étterem. ",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "95810441-4970-488c-afc7-d91a07256c76",
                    ImagePath = "https://images.unsplash.com/photo-1514933651103-005eec06c04b?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjM1MDM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 5,
                    Name = "IKON Restaurant Debrecen",
                    ShortDescription = "Fúziós konyha, Terasz és kert, Gyermekbarát",
                    DetailedDescription = "Aki ismer minket, tudja, hogy órákig tudunk mesélni az IKON-ról. De ha csak egy mondatunk van rá, tömören így fogalmazunk: fanatikus gasztro-műhely. Nálunk mindenki őrült egy kicsit, és bár különbözünk, a minőség iránti elkötelezettségünk eggyé kovácsol minket. Nem elégszünk meg a jóval, a tökéletességre törekszünk, hogy a legjobb helyi alapanyagokból, a legnagyobb szakértelemmel és állandó minőségben kerüljenek vendégeink elé az ételek. A friss nyersanyagokra, a modern technológiára helyezzük a hangsúlyt, és miközben rehabilitáljuk az elfeledett vagy mellőzött alapanyagokat, engedjük, hogy távoli országok hatásai is megérintsenek. Így kerülhet vörös márna, lazac és kagyló az étlapunkra. Az étterem berendezésének koncepciója is ezen alapul, ahol a hagyományos eleganciát ötvözzük otthonos, trendi elemekkel.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "c5e189f0-7656-4304-b963-1581f5ecf4fb",
                    ImagePath = "https://images.unsplash.com/photo-1587574293340-e0011c4e8ecf?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjM4MzY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 6,
                    Name = "Kulacs Csárda",
                    ShortDescription = "Élőzene, Ebéd, Csoportos rendezvény, Üzleti ebéd, Vacsora",
                    DetailedDescription = "A Kulacs Csárda Panzió Egerben, a tufába vájt borospincék sokaságáról híres Szépasszonyvölgy szívében helyezkedik el. Pince mulatót 1986-ban nyitották, melyet igazi magyaros ízei és jó borai miatt egyre többen kerestek meg az elmúlt évek alatt, így folyamatosan újabb és újabb pinceágakkal kellett bővíteni csárdát. A történelmi hangulatú pincemulató befogadóképessége 350 fő. Öt boltíves terme légkondicionált, hagyományőrzőén, ízlésesen berendezett, kitűnően alkalmas egyéni és csoportos vendégek kulturált kiszolgálására. Tavasztól őszig az országban egyedülálló 150 fő befogadására alkalmas szőlőlugassal fedett kerthelyiség is megkóstolhatják hal, vad, szárnyas ételeinken túl magyaros ételkülönlegességeinket is. Az egri borvidék legjobb borászainak széles kínálata mellett megízlelhetik kimért termelői borokat is. A vendégek jó hangulatáról a csárda virtuóz cigányzenekara gondoskodik.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "3eba4364-6a33-459c-9871-5823a9aee62a",
                    ImagePath = "https://images.unsplash.com/photo-1569096651661-820d0de8b4ab?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI3NjU1OTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 7,
                    Name = "Macok Bisztró és Borbár",
                    ShortDescription = "Borbár, Étterem, Terasz és kert",
                    DetailedDescription = "A Macok Bisztró és Borbár könnyed és fiatalos lendületű hely, ahol kulináris élményt kínálunk igényes bisztró stílusban, helyi borászok bemutatásával és olyan borkülönlegességekkel, amelyek már csak a gyűjtők pincéjében találhatók meg. Az étterem a történelmi belvárosban az egri Vár bejáratánál helyezkedik el, a teraszon üldögélve a megelevenedő történelem részeseivé válhatunk.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "765c13fb-7f8c-4474-afb5-d3a9e72feef3",
                    ImagePath = "https://images.unsplash.com/photo-1416453072034-c8dbfa2856b5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjI3ODk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 8,
                    Name = "Szegedi rostlaposok",
                    ShortDescription = "Burgerek, 5000 Ft alatt",
                    DetailedDescription = "Hamburgerező Szegeden, a Kálvária téren. Ha bármilyen kérdésed van rendelés menetével, a kiszállítással vagy a termékeinkkel kapcsolatban, kérlek, keress minket a lenti elérhetőségeinken!",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "7236dae3-7bad-4fe6-bb18-d13ff391939d",
                    ImagePath = "https://images.unsplash.com/photo-1516062423079-7ca13cdc7f5a?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjMzNTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 9,
                    Name = "Vendéglő A Régi Hídhoz",
                    ShortDescription = "Magyar konyha, Terasz és kert, Fizető parkoló, Gyermekbarát, Elvitel",
                    DetailedDescription = "Ha Szegeden járva egy igazi magyaros kulináris kalandozásban szeretnénk részt venni, akkor bizony a Vendéglő a Régi Hídhoz ránk vár. Az étteremben magyar népies dekoráció, a szegedi paprikafüzérek és a kedves személyzet biztosít minket arról, hogy jó helyen járunk. Az étterem belsőhöz és a magyar tradicionális ételekhez illő kreatív teríték is megfűszerezi a hangulatot. Fenséges ízek, csodálatos adagokban, gusztusos terítéssel, baráti árakon.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "5075d4b9-0ba6-4811-84ff-fed147c9c09a",
                    ImagePath = "https://images.unsplash.com/photo-1544609499-d9b16fe50243?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjMzOTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 10,
                    Name = "Mazel Tov",
                    ShortDescription = "Zsidó konyha, Bár ételek, Angolul beszélünk, WIFI, Gyermekbarát, Elvitel",
                    DetailedDescription = "A mazel tov étterem és bár 2014. Július végén nyitott egy igazi mediterrán hangulatú helyként, melyet évszaktól függetlenül szeretnénk megőrizni nyáron nyitott, télen pedig fűtött kerthelységgel. A mazel tov célja működése óta egy nyitott szemléletű, gasztrónómiai és kulturális szempontból meghatározó, fesztelen hangulatú origó megteremtése, ahol délutántól zárásig várnak szeretettel mindenkit, aki betér és kikapcsolódni vágyik, legyen szó kulturális vagy kulináris élvezetekről, vagy épp baráti fröccsözésekről. A mazel tov ötlete az adottságok és a számunkra fontos gondolatok kiemélésén alapszik; a hangulatos, városi kertek, a nyitott szemlélet valamint a sokszínű mediterrán konyha összekapcsolásán, ötvözetén. Az akácfa utcában nemrég nyílt mazel tov az első olyan szórakozókert, amely az ötödik kerületi magas szintű gasztro-vendéglátó infrastruktúrát az autentikus, romkocsmaközeli hetedik kerületbe hivatott beültetni, így erősítve a sokszínűséget és az új színt a budapesti palettán.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "e1eaafad-b9f7-4668-9efd-d8c4418c39ca",
                    ImagePath = "https://images.unsplash.com/photo-1603055021980-7a6e8abd9bd5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjM2MjQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 11,
                    Name = "High Note SkyBar",
                    ShortDescription = "Bár ételek, Tapas, Sütemények, Terasz és kert, Angolul beszélünk, Fűtött terasz, Közel tömegközlekedéshez, Légkondicionálás",
                    DetailedDescription = "A High Note SkyBar Budapest egyik legexkluzívabb helyszíne és egyben a város egyetlen, egész évben nyitva tartó tetőterasza. A friss, laza, új szemlélet a garancia rá, hogy itt nem csak a körpanoráma nyújt feledhetetlen élményt. Vendégeinket évszakonként megújuló koktélkínálattal és barfood-választékkal várjuk! Amennyiben szeretne ellátogatni hozzánk, kérjük, minél hamarabb foglalja le asztalát, hogy garantálni tudjuk az ülőhelyet Önöknek!",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "5f7e27c3-9398-4cd3-977d-dae625124808",
                    ImagePath = "https://images.unsplash.com/photo-1555396273-367ea4eb4db5?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjU4NzY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 12,
                    Name = "Tereza",
                    ShortDescription = "Mexikói konyha, Terasz és kert, Angolul beszélünk",
                    DetailedDescription = "Borús idő, derűs dél-amerikai hangulat - esténként már az étterem belső terében terítjük az asztalokat, öt órától ma is Tiétek a hacienda! ",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "93f49281-b3a5-41b5-972c-ff5910f26e56",
                    ImagePath = "https://images.unsplash.com/photo-1533777419517-3e4017e2e15a?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjYwNTc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 13,
                    Name = "Stand25 Bisztró",
                    ShortDescription = "Magyar konyha, Bisztró, Ebéd, Alkalmas üzleti tárgyalásokra, Vacsora",
                    DetailedDescription = "A Stand25 Szulló Szabina és Széll Tamás lehető legkomolyabban vett örömkonyhája a a város budai oldalán, sétatávolságra a Lánchídtól és a Váralagúttól. A Stand25 alig egy évvel a nyitása után Bib Gourmand minősítést szerzett. Izgalmas kitérő a séfek számára a fine dining világából, ahol csupán egyetlen szabály van: a minőségben és az alapanyagban nem ismerni kompromisszumot. Szabad magyar konyha, egy laza, barátságos hangulatú bisztróban, ahol a Csahók Ibolya vezette szervíz ugyanolyan törődéssel kíséri végig a vendéget, mint egy csúcsétteremben, csak sokkal közvetlenebb stílusban.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "4e0a018f-ca12-448e-bda9-67ac1fce5a53",
                    ImagePath = "https://images.unsplash.com/photo-1485686531765-ba63b07845a7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjYyMjc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 14,
                    Name = "Trattoria Pomo D'Oro",
                    ShortDescription = "Mediterrán, Olasz, Halételek, Pizza, Tengeri ételek, Tészta, Hús ételek",
                    DetailedDescription = "Egy gasztronómiai szakember 1839-ben elhangzott mondatát idézve, az olasz konyha meghatározó alapanyaga a paradicsom. A zseniális ötlet, hogy a paradicsomot hozzáadják a tésztához és a pizzához, nemcsak a nápolyiak több generációját tette boldoggá, hanem mindenkit, aki szereti és értékeli az olasz konyhát. Ezért is lett az étterem neve a Pomo D'oro, amely ebben a formában aranyalmát egyben írva, pedig paradicsomot jelent. Az étterem konyhafőnöke, Rosario az igazi tradicionális ételek mellett saját receptgyűjteményéből is rengeteg fogást elkészít. Híresek a vendégtérben készülő ételek, melyek nemcsak látványban nyűgözik le a vendégeket, de aki egyszer megkóstolta, az ízükre is sokáig emlékszik. Nap mint nap új ételekkel várja az étterem a vendégeit, hiszen valami érdekességet, kuriózumot mindig rejt a kínálatuk. Legyenek azok ritkán fellelhető gombák, friss halkülönlegességek vagy akár az évszakhoz igazodó idény zöldségek.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "77d8c466-d2a0-44cb-8a22-a228b6218f23",
                    ImagePath = "https://images.unsplash.com/photo-1543007630-9710e4a00a20?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjY0NjY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 15,
                    Name = "Byblos Budapest",
                    ShortDescription = "Arab, Libanoni, Halal, Tengeri ételek, Barbeque",
                    DetailedDescription = "A Byblos Budapest egy libanoni étterem, mely a keleti és a mediterrán konyha házasságát képviseli. Erősen támaszkodik mind a hagyományos, mind a helyi alapanyagokra. A klasszikus és modern módszerek alkalmazásával ételeink bemutatják a Levantine-i konyha különlegességeit és ízét. A menü igazi utazás a mediterrán és a keleti ízek között. Byblos Budapest családias légkörben kínálja széles választékát a vegán ételeknek, melyek kizárólagosan halal forrásból származnak.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "5b944a67-5751-423f-89fb-f0c4f0ace3fb",
                    ImagePath = "https://images.unsplash.com/photo-1581954548122-4dff8989c0f7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjY3OTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 16,
                    Name = "A KERT Bisztro",
                    ShortDescription = "Magyar, Nemzetközi, Halételek, Tatár steak, Egészséges, Hús ételek",
                    DetailedDescription = "68 év után ismét megnyílt az egykori kertvendéglő Zuglóban. A múlt században Borház néven működő családi vendéglő, ma újra családi vállalkozás. Mint akkor, ma is az ősfák árnyékában hűsölhetünk, italozhatunk, falatozhatunk és megfeledkezhetünk a rohanó mindennapokról. Élvezhetjük a díjnyertes olasz kézműves kávéból készült különlegességeket, magyar kézműves csapolt söröket és a bisztró konyha remekeit.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "96494a5b-f58d-44dd-8428-6543ef5e5bd7",
                    ImagePath = "https://images.unsplash.com/photo-1613274554329-70f997f5789f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjY5Mzk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 17,
                    Name = "Franziska",
                    ShortDescription = "Kávézó, Étterem, Rendelhető ételek, Egészséges, Sütemények",
                    DetailedDescription = "A magányos sütés és a titkos kísérletezés ideje lejárt, Franziska csodálatos otthonra lelt.\nTermészetes továbblépés ez, hiszen Franziska szerint a vendéglátásban rejtőzik valami igazi varázslat: a hozzávalók aprólékos kiválasztásában, egy hangulat térbe való átültetésében, egy maradandó íz létrehozásában, a régi könyvekből merített inspirációkban és természetesen egy közösség megteremtésében. \nMert azt szeretnénk, ha nálunk kapnátok fel reggel egy gőzölgő specialty kávét vagy egy friss életerő turmixot, harapnátok egyet mellé a még melegen roppanó szendvicsből, vagy ha végre egyszer igazán hosszan tarthatna a reggeli, kiélvezve a legcsodásabb étkezés minden percét...\nPersze minden a megszokott Franziska desszertekkel körítve, örökre belefeledkezve a kókusz, a datolya, a mandula vagy a pisztácia aromáinak bonyolult árnyalataiba. \nGyertek és legyetek a vendégeink, szeretettel várunk!",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "5c55f164-cb41-4453-a473-120af44e3493",
                    ImagePath = "https://images.unsplash.com/photo-1414235077428-338989a2e8c0?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4MjczNjU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 18,
                    Name = "Riso Ristorante & Terrace",
                    ShortDescription = "Mediterrán, Terasz és kert, Ingyenes parkolás, WIFI, Gyermekbarát, Elvitel",
                    DetailedDescription = "2008-ban épült fel egy új szálloda (Hotel Castle Garden) a Budai Vár tövében a Bécsi Kapu lábánál, melynek részeként megnyílt a Bonfini Kert Étterem. \nAz akkori üzemeltetők szemlélete eltért a mi elképzelésünktől, amit 2011 nyara óta próbálunk eljuttatni a köztudatba, immáron Riso Ristorante & Terrace néven. A ’Terrace’ szó nem hiába került bele az elnevezésbe, hiszen a vendégek valóban úgy érezhetik, hogy egy másik világba, idilli környezetbe csöppentek, elég helyet foglalni a buja zöld növényzettel körülölelt terasz asztalainál. A kerthelyiség szinteltolásos építészeti kialakítása, a felső részen helyet kapott grillkonyha, a kényelmesen és tágasan elhelyezett bútorzat és a minden igényt kielégítő gyermekjátszótér intim és egyben otthonos hangulatot teremt. \nTermészetesen a szép terasz és a vidám friss érzést keltő belső tér kevés lenne a vendégek megnyeréséhez, de a nagy részt tradicionális olasz és hazai ízek mellett széles rizottóválaszték, házi tészták és kemencében sült pizza is szerepel a kínálatban!",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "27410ef4-fa83-45cd-872d-d350042dd8e4",
                    ImagePath = "https://images.unsplash.com/photo-1554118811-1e0d58224f24?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4Mjc1NTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 19,
                    Name = "Akademia Italia",
                    ShortDescription = "Olasz, Bár ételek, Halételek, Pizza, Tengeri ételek, Tészta",
                    DetailedDescription = "Akademia Italia egy itáliai gasztronómiai központ Budapest szívében, a Szent István Bazilika tövében. Három az egyben: minőségi olasz étterem, autentikus delikátesz bolt és főzőiskola egy helyen. Az étterem várja mindazokat, akik az olasz konyha minőségi, kizárólag eredetvédett alapanyagaiból készülő fogásait keresik; azokat is, akik egy darab focacciáért érkeznek; de azokat is, akik autentikus olasz hozzávalókat vásárolnának egy nagyszabású, többfogásos családi vacsorához. Várják a munka előtt csak úgy betérő vendégeket egy tökéletes olasz espressóra, hogy jól induljon a napjuk; valamint azokat is, akik esetleg szeretnének belemélyedni a tortelloni-készítés rejtelmeibe a főzőiskola keretein belül.",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "acd5d503-90e3-475c-b700-8e96fbea9e60",
                    ImagePath = "https://images.unsplash.com/photo-1602748828300-2843df3b3923?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4Mjc2NjU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                },
                new Restaurant
                {
                    Id = 20,
                    Name = "Pavillon de Paris Francia Étterem",
                    ShortDescription = "Angol, Francia, Terasz és kert, Angolul beszélünk, Fűtött terasz, Németül beszélünk, WIFI, Ebéd menü",
                    DetailedDescription = "Egy cseppnyi hangulat Budapest szívében. Hangulat egy kávéra, egy finom pohár borra, egy könnyű ebédre, vagy egy vacsorára. A legfrissebb minőségi alapanyagok,gazdag íz választék, igazi vendégszeretet. Budapest legszebb kertjében, mely a téli hidegben fűtött pavillonban idézi fel bennűnk egy meghitt télikert hangulatát",
                    ShowForUsers = true,
                    IsOrderAvailable = true,
                    OwnerId = "4422d2ba-934c-4899-9195-d9872d1b4c63",
                    ImagePath = "https://images.unsplash.com/photo-1600184894885-4066d2b92fda?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=900&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudHx8fHx8fDE2MzI4Mjc4OTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=1600"
                }
            );

            builder.OwnsOne(r => r.Address).HasData(
                new
                {
                    RestaurantId = 1,
                    City = "Budapest",
                    ZipCode = 1061,
                    Street = "Király utca 30",
                    PhoneNumber = "06301234567"
                },
                new
                {
                    RestaurantId = 2,
                    City = "Budapest",
                    ZipCode = 1148,
                    Street = "Örs vezér tere 1",
                    PhoneNumber = "06305412567"
                },
                new
                {
                    RestaurantId = 3,
                    City = "Budapest",
                    ZipCode = 1011,
                    Street = "Király utca 26",
                    PhoneNumber = "06301233456"
                },
                new
                {
                    RestaurantId = 4,
                    City = "Debrecen",
                    ZipCode = 4025,
                    Street = "Kossuth utca 21",
                    PhoneNumber = "06203433499"
                },
                new
                {
                    RestaurantId = 5,
                    City = "Debrecen",
                    ZipCode = 4028,
                    Street = "Piac u. 23",
                    PhoneNumber = "06202933472"
                },
                new
                {
                    RestaurantId = 6,
                    City = "Eger",
                    ZipCode = 3300,
                    Street = "Szépasszonyvölgy 1",
                    PhoneNumber = "06301933174"
                },
                new
                {
                    RestaurantId = 7,
                    City = "Eger",
                    ZipCode = 3300,
                    Street = "Tinódi Sebestyén tér 4",
                    PhoneNumber = "06201944175"
                },
                new
                {
                    RestaurantId = 8,
                    City = "Szeged",
                    ZipCode = 6725,
                    Street = "Kálvária tér 25.",
                    PhoneNumber = "06302932179"
                },
                new
                {
                    RestaurantId = 9,
                    City = "Szeged",
                    ZipCode = 6725,
                    Street = "Oskola utca 4",
                    PhoneNumber = "06204933175"
                },
                new
                {
                    RestaurantId = 10,
                    City = "Budapest",
                    ZipCode = 1017,
                    Street = "Akácfa utca 47",
                    PhoneNumber = "06201733274"
                },
                new
                {
                    RestaurantId = 11,
                    City = "Budapest",
                    ZipCode = 1007,
                    Street = "Hercegprímás utca 5",
                    PhoneNumber = "06203369867"
                },
                new
                {
                    RestaurantId = 12,
                    City = "Budapest",
                    ZipCode = 1021,
                    Street = "Nagymező utca 3",
                    PhoneNumber = "06301876756"
                },
                new
                {
                    RestaurantId = 13,
                    City = "Budapest",
                    ZipCode = 1025,
                    Street = "Attila út 10",
                    PhoneNumber = "06209977645"
                },
                new
                {
                    RestaurantId = 14,
                    City = "Debrecen",
                    ZipCode = 4014,
                    Street = "Arany János utca 9",
                    PhoneNumber = "06209972364"
                },
                new
                {
                    RestaurantId = 15,
                    City = "Budapest",
                    ZipCode = 1028,
                    Street = "Semmelweis utca 1-3",
                    PhoneNumber = "06307789631"
                },
                new
                {
                    RestaurantId = 16,
                    City = "Szeged",
                    ZipCode = 6721,
                    Street = "Thököly út 57/b",
                    PhoneNumber = "06208765698"
                },
                new
                {
                    RestaurantId = 17,
                    City = "Szeged",
                    ZipCode = 6711,
                    Street = "Iskola u. 29",
                    PhoneNumber = "06208761985"
                },
                new
                {
                    RestaurantId = 18,
                    City = "Debrecen",
                    ZipCode = 4007,
                    Street = "Lovas út 41",
                    PhoneNumber = "06205872956"
                },
                new
                {
                    RestaurantId = 19,
                    City = "Debrecen",
                    ZipCode = 4001,
                    Street = "Szent István tér 12",
                    PhoneNumber = "06308173984"
                },
                new
                {
                    RestaurantId = 20,
                    City = "Budapest",
                    ZipCode = 1015,
                    Street = "Fő utca 20",
                    PhoneNumber = "06208133946"
                }
            );
        }
    }
}
