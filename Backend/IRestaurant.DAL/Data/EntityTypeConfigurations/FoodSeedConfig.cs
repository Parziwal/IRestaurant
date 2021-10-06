using IRestaurant.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IRestaurant.DAL.Data.EntityTypeConfigurations
{
    public class FoodSeedConfig : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasData(
                new Food
                {
                    Id = 1,
                    Name = "Libamáj pástétom házi lila hagyma lekvárral",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 4750,
                    ImagePath = "https://images.unsplash.com/photo-1524081684693-1519036f3449?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxyZXN0YXVyYW50fHx8fHx8MTYzMjY5MDM4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 2,
                    Name = "Burgundi szarvasszelet",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 3650,
                    ImagePath = "https://images.unsplash.com/photo-1518290943012-2c2bec0e54d2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxtZWF0fHx8fHx8MTYzMjY5MDUwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 3,
                    Name = "Ropogós kacsacomb",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 3700,
                    ImagePath = "https://images.unsplash.com/photo-1562847961-8f766d774a28?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdHx8fHx8fDE2MzI2OTA1Njg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 4,
                    Name = "Trófea burgonyafánk",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 900,
                    ImagePath = "https://images.unsplash.com/photo-1583182332473-b31ba08929c8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZG9udXR8fHx8fHwxNjMyNjkwNzA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 5,
                    Name = "Trófea Burger",
                    Description = "marhahús (medium), ezersziget öntet, karamellizált hagyma, csemegeuborka A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1090,
                    ImagePath = "https://images.unsplash.com/photo-1618219877887-442767be5d68?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDc2MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 6,
                    Name = "Trófea Cheese Burger",
                    Description = "10dkg marhahús (medium), karamellizált hagyma, csemegeuborka, cheddar sajt, ezersziget öntet A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1250,
                    ImagePath = "https://images.unsplash.com/photo-1624348754836-743503fe9445?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDgwOA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 7,
                    Name = "Trófea BBQ burger",
                    Description = "marhahús (medium), grillezett cheddar sajt, karamellizált hagyma, csemegeuborka, bacon, BBQ szósz A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1400,
                    ImagePath = "https://images.unsplash.com/photo-1491960693564-421771d727d6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg0Ng&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 8,
                    Name = "Trófea Burger vegán pogácsával",
                    Description = "ketchup, karamellizált hagyma, vegán pogácsa, uborka, mustár A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1250,
                    ImagePath = "https://images.unsplash.com/photo-1470053053191-43e7bd267838?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 1
                },
                new Food
                {
                    Id = 9,
                    Name = "BBQ pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, füstölt sajt, BBQ csirkehús, paradicsom, lila hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2490,
                    ImagePath = "https://images.unsplash.com/photo-1618213957768-7789409b9dd8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTEy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 2
                },
                new Food
                {
                    Id = 10,
                    Name = "Bruschetta pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, feta sajt, hagyma, rukkola, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2390,
                    ImagePath = "https://images.unsplash.com/photo-1516697073-419b2bd079db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTQ0&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 2
                },
                new Food
                {
                    Id = 11,
                    Name = "Margherita pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2190,
                    ImagePath = "https://images.unsplash.com/photo-1585505008861-a5c378857dcc?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTc4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 2
                },
                new Food
                {
                    Id = 12,
                    Name = "Olívás margarita pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, zöld olívabogyó, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2190,
                    ImagePath = "https://images.unsplash.com/photo-1589375890993-7b568c0b8b1c?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDA4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 2
                },
                new Food
                {
                    Id = 13,
                    Name = "Sonkás-gombás pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, sonka, kukorica, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2290,
                    ImagePath = "https://images.unsplash.com/photo-1605478371310-a9f1e96b4ff4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDM4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 2
                },
                new Food
                {
                    Id = 14,
                    Name = "Szalámis pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, szalámi, pepperoni, hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2290,
                    ImagePath = "https://images.unsplash.com/photo-1589906493606-a6ca2a06078b?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDgy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 2
                },
                new Food
                {
                    Id = 15,
                    Name = "Balzsamecetben marinált csirke",
                    Description = "zöldfűszeres gnocchi, zeller, kurkuma, shallot",
                    Price = 3550,
                    ImagePath = "https://images.unsplash.com/photo-1501200291289-c5a76c232e5f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Y2hpY2tlbnx8fHx8fDE2MzI3NjQzNzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 3
                },
                new Food
                {
                    Id = 16,
                    Name = "Lazac steak",
                    Description = "brokkoli, beluga lencse, édes-savanyú redukció, friss zöldfűszerek",
                    Price = 4950,
                    ImagePath = "https://images.unsplash.com/photo-1485704686097-ed47f7263ca4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0NDYw&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 3
                },
                new Food
                {
                    Id = 17,
                    Name = "Vegán csőben sült kaliforniai paprika",
                    Description = "grillezett füge, szója emulzió, retek",
                    Price = 2950,
                    ImagePath = "https://images.unsplash.com/photo-1601565960311-8a7f4e1ab709?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFwcmlrYXx8fHx8fDE2MzI3NjQ2ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 3
                },
                new Food
                {
                    Id = 18,
                    Name = "Rib-eye",
                    Description = "(220 g), rukkola, grana padano d.o.p., koktélparadicsom",
                    Price = 7650,
                    ImagePath = "https://images.unsplash.com/photo-1607198179219-cd8b835fdda7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0ODA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 3
                },
                new Food
                {
                    Id = 19,
                    Name = "Füstölt padlizsán tortelli",
                    Description = "menta, spárga ragu, pecorino, narancs",
                    Price = 3250,
                    ImagePath = "https://images.unsplash.com/photo-1613478881426-deeadee06d78?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZWdncGxhbnR8fHx8fHwxNjMyNzY0OTg1&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 3
                },
                new Food
                {
                    Id = 20,
                    Name = "Beluga steak limoncelloval flambírozva",
                    Description = "pirított pisztáciával, citromhéjas tejszínes udon tésztával",
                    Price = 4390,
                    ImagePath = "https://images.unsplash.com/photo-1556269923-e4ef51d69638?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzcwNjYx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 4
                },
                new Food
                {
                    Id = 21,
                    Name = "Bivaly",
                    Description = "konyakos-libamájas mártással, tepertős burgonyapürével, szőlővel",
                    Price = 3790,
                    ImagePath = "https://images.unsplash.com/photo-1504472607343-a7fac413b524?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGxhdGV8fHx8fHwxNjMyNzcwNzkx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 4
                },
                new Food
                {
                    Id = 22,
                    Name = "Csirkemellből készült paella",
                    Description = "Ahogy katalán chef barátunktól tanultuk",
                    Price = 2990,
                    ImagePath = "https://images.unsplash.com/photo-1575932444877-5106bee2a599?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Q2hpY2tlbiBicmVhc3R8fHx8fHwxNjMyNzcwOTk4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 4
                },
                new Food
                {
                    Id = 23,
                    Name = "Narancsos kacsa",
                    Description = "rózsaborsos-citrusos mangó pürével, savoyai burgonyával",
                    Price = 3690,
                    ImagePath = "https://images.unsplash.com/photo-1505253668822-42074d58a7c6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZHVjayxmb29kfHx8fHx8MTYzMjc3MTEzNA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 4
                },
                new Food
                {
                    Id = 24,
                    Name = "Vasvári zoltán féle konfitált báránycsülök",
                    Description = "ruccolás burgonyapürével, mentás mártással, toszkán zöldbabbal",
                    Price = 3990,
                    ImagePath = "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI3NzEyNzk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 4
                },
                new Food
                {
                    Id = 25,
                    Name = "Szarvasgerinc",
                    Description = "vadas, szalvétagombóc",
                    Price = 6990,
                    ImagePath = "https://images.unsplash.com/photo-1516685125522-3c528b8046ee?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4NjY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 5
                },
                new Food
                {
                    Id = 26,
                    Name = "Paradicsom rizottó",
                    Description = "bazsalikom, stracciatella (V)",
                    Price = 4490,
                    ImagePath = "https://images.unsplash.com/photo-1460667450797-d71a56692010?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4OTI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 5
                },
                new Food
                {
                    Id = 27,
                    Name = "Házi tagliatelle",
                    Description = "szarvasgomba, tanyasi csirke/garnéla/bélszín",
                    Price = 4690,
                    ImagePath = "https://images.unsplash.com/photo-1482049016688-2d3e1b311543?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjc3MTY4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 5
                },
                new Food
                {
                    Id = 28,
                    Name = "Tanyasi csirke",
                    Description = "füstölt saláta, boquerones",
                    Price = 4990,
                    ImagePath = "https://images.unsplash.com/photo-1504973960431-1c467e159aa4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE5NzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 5
                },
                new Food
                {
                    Id = 29,
                    Name = "Legényfogó leves",
                    Description = "ertéscomb, csirkemáj, gomba,zöldségek - tejszínes-kapros habarással készül",
                    Price = 1660,
                    ImagePath = "https://images.unsplash.com/photo-1574484284002-952d92456975?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI3NzIzOTc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 6
                },
                new Food
                {
                    Id = 30,
                    Name = "Magyaros hidegtál",
                    Description = "sonka, főtt-füstölt tarja, téli szalámi és paprikás szalámi, baconszalonna, parasztmájas, füstölt kolbász, sajtok, főtt tojás, friss zöldségek ",
                    Price = 3000,
                    ImagePath = "https://images.unsplash.com/photo-1432139509613-5c4255815697?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxmb29kfHx8fHx8MTYzMjc3MjY1OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 6
                },
                new Food
                {
                    Id = 31,
                    Name = "Lávakövön sült pulykamell",
                    Description = "grillezett libamájjal és gyümölcsökkel",
                    Price = 3700,
                    ImagePath = "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzI0ODA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 6
                },
                new Food
                {
                    Id = 32,
                    Name = "Erdélyi fatányéros",
                    Description = "roston bélszín, serpenyős cigánypecsenye, rántott csirkemell, kakastaréj, sült kockaburgonya, házi csalamádé",
                    Price = 4200,
                    ImagePath = "https://images.unsplash.com/photo-1611315764615-3e788573f31e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZGlzaHx8fHx8fDE2MzI3NzI5ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 6
                },
                new Food
                {
                    Id = 33,
                    Name = "Bikavéres marhapofa",
                    Description = "üstölt zellerpüré, padron paprika, vargányagomba",
                    Price = 4250,
                    ImagePath = "https://images.unsplash.com/photo-1626509653291-18d9a934b9db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI4MjM5MzM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 7
                },
                new Food
                {
                    Id = 34,
                    Name = "Kacsamáj befőtt",
                    Description = "szőlő chutney-val, dióval, házi brioche-sal",
                    Price = 2890,
                    ImagePath = "https://images.unsplash.com/photo-1626200419199-391ae4be7a41?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjQwMTE&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 7
                },
                new Food
                {
                    Id = 35,
                    Name = "Angus marhatatár",
                    Description = "füstös velőmajonézzel, savanyított hagymákkal",
                    Price = 2890,
                    ImagePath = "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8dGF0YXIsbWVhdHx8fHx8fDE2MzI4MjQwOTU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 7
                },
                new Food
                {
                    Id = 36,
                    Name = "Házi hosszúmetélt",
                    Description = "parajlevél pestóval és sós dióval, aszalt paradicsommal",
                    Price = 2490,
                    ImagePath = "https://images.unsplash.com/photo-1618163633808-dbd8a9f658ce?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFzdGF8fHx8fHwxNjMyODI0MTUz&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 7
                },
                new Food
                {
                    Id = 37,
                    Name = "Taxi burger",
                    Description = "szezámmagos buci, marhahúspogácsa 1 db (13 dkg), hamburgerszósz, jégsaláta, csemege uborka, trappista sajt, pirított hagyma, bacon",
                    Price = 1399,
                    ImagePath = "https://images.unsplash.com/photo-1623945359564-b8d01dd5cfe2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDMyNQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 8
                },
                new Food
                {
                    Id = 38,
                    Name = "Erős Anna",
                    Description = "szezámmagos buci, marhahús pogácsa 1 db (13 dkg), ketchup, jégsaláta, kígyóuborka, pirított hagyma, bacon, jalapeno",
                    Price = 1399,
                    ImagePath = "https://images.unsplash.com/photo-1585238341267-1cfec2046a55?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDQxOQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 8
                },
                new Food
                {
                    Id = 39,
                    Name = "Rosti Burger",
                    Description = "szezámmagos buci, marhahúspogácsa (13 dkg-os), BBQ szósz, jégsaláta, paradicsom, füstölt sajtchips, cheddar sajt, bacon, jalapeno",
                    Price = 1599,
                    ImagePath = "https://images.unsplash.com/photo-1572802419224-296b0aeee0d9?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDUwMg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 8
                },
                new Food
                {
                    Id = 40,
                    Name = "Zátony Burger",
                    Description = "szezámmagos buci, marhahúspogácsa 2 db (13 dkg-os), BBQ szósz, lila hagyma, paradicsom, kígyóuborka, cheddar sajt, füstölt sajt, trappista sajt, bacon, jalapeno",
                    Price = 1899,
                    ImagePath = "https://images.unsplash.com/photo-1561043433-9265f73e685f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDYwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 8
                },
                new Food
                {
                    Id = 41,
                    Name = "Favágó karaj",
                    Description = "vaslapon sült pácolt karaj tejfölös, füstölt tarjás, savanyú uborkás, szalonnás raguval",
                    Price = 2800,
                    ImagePath = "https://images.unsplash.com/photo-1605209971703-73c7ed7c923e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4NzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 9
                },
                new Food
                {
                    Id = 42,
                    Name = "Kishuszáros karaj",
                    Description = "szaftos, vaslapon sült karaj fokhagymával, sült szalonnával",
                    Price = 2800,
                    ImagePath = "https://images.unsplash.com/photo-1624174503860-478619028ab3?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4OTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 9
                },
                new Food
                {
                    Id = 43,
                    Name = "Bádogos csülök",
                    Description = "pirított kolbász, füstölt tarja, füstölt szalonna, vöröshagyma, savanyú uborka, tejföl",
                    Price = 2900,
                    ImagePath = "https://images.unsplash.com/photo-1584932901306-a19fdf291cec?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ5ODQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 9
                },
                new Food
                {
                    Id = 44,
                    Name = "Besütött harcsa főszakács-módra",
                    Description = "spenót, spárga, sajt",
                    Price = 3600,
                    ImagePath = "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZmlzaCxwbGF0ZXx8fHx8fDE2MzI4MjUwOTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 9
                },
                new Food
                {
                    Id = 45,
                    Name = "Bélszínjava egri módra",
                    Description = "roston sült libamáj, gomba, egri barnamártás",
                    Price = 5800,
                    ImagePath = "https://images.unsplash.com/photo-1598511726623-d2e9996892f0?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bG9pbnx8fHx8fDE2MzI4MjUxMzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 9
                },
                new Food
                {
                    Id = 46,
                    Name = "Labane",
                    Description = "Joghurtból készült házi krémsajt, marinált paprikával és sült articsókával, friss pitával tálalva",
                    Price = 1890,
                    ImagePath = "https://images.unsplash.com/photo-1565720490528-48e5be3d6a1f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjgyNTI2OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 10
                },
                new Food
                {
                    Id = 47,
                    Name = "Jemeni Csirkeleves",
                    Description = "Jemeni fűszerekkel főtt csirkeleves tépett csirkecombbal, citrommal és friss korianderrel",
                    Price = 1690,
                    ImagePath = "https://images.unsplash.com/photo-1469307517101-0b99d8fb0c33?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU0OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 10
                },
                new Food
                {
                    Id = 48,
                    Name = "Humusz Tahini tál",
                    Description = "Minden hummusz tálat friss, házi hummusszal, csicseriborsóval, tahinivel, petrezselyemmel és olívaolajjal tálalunk, mellé friss grillezett pitát adunk. Kérheted zhug csipős szósszal is!",
                    Price = 1890,
                    ImagePath = "https://images.unsplash.com/photo-1622040806062-27ae4deb4a40?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aHVtdXN8fHx8fHwxNjMyODI1NTcy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 10
                },
                new Food
                {
                    Id = 49,
                    Name = "Vegán lencsekrémleves",
                    Description = "Két fajta lencséből készült krémleves, sült padlizsán kockákkal és lime-chili mogyoróval",
                    Price = 1590,
                    ImagePath = "https://images.unsplash.com/photo-1547308283-b74183c15032?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU1MTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 10
                },
                new Food
                {
                    Id = 50,
                    Name = "Bárányzsíron sült petrezselymes marha kebab",
                    Description = "Házi recept alapján készített, darált marha pogácsa",
                    Price = 3590,
                    ImagePath = "https://images.unsplash.com/photo-1625937282844-4a0cb4665820?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YmVlZnx8fHx8fDE2MzI4MjU1OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 10
                },

                //Az előző ételek megismételve
                new Food
                {
                    Id = 51,
                    Name = "Libamáj pástétom házi lila hagyma lekvárral",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 4750,
                    ImagePath = "https://images.unsplash.com/photo-1524081684693-1519036f3449?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxyZXN0YXVyYW50fHx8fHx8MTYzMjY5MDM4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 52,
                    Name = "Burgundi szarvasszelet",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 3650,
                    ImagePath = "https://images.unsplash.com/photo-1518290943012-2c2bec0e54d2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxtZWF0fHx8fHx8MTYzMjY5MDUwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 53,
                    Name = "Ropogós kacsacomb",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 3700,
                    ImagePath = "https://images.unsplash.com/photo-1562847961-8f766d774a28?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdHx8fHx8fDE2MzI2OTA1Njg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 54,
                    Name = "Trófea burgonyafánk",
                    Description = "További kérdés esetén, rendelésed leadása előtt keresd az ügyfélszolgálatunkat bizalommal.",
                    Price = 900,
                    ImagePath = "https://images.unsplash.com/photo-1583182332473-b31ba08929c8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZG9udXR8fHx8fHwxNjMyNjkwNzA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 55,
                    Name = "Trófea Burger",
                    Description = "marhahús (medium), ezersziget öntet, karamellizált hagyma, csemegeuborka A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1090,
                    ImagePath = "https://images.unsplash.com/photo-1618219877887-442767be5d68?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDc2MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 56,
                    Name = "Trófea Cheese Burger",
                    Description = "10dkg marhahús (medium), karamellizált hagyma, csemegeuborka, cheddar sajt, ezersziget öntet A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1250,
                    ImagePath = "https://images.unsplash.com/photo-1624348754836-743503fe9445?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDgwOA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 57,
                    Name = "Trófea BBQ burger",
                    Description = "marhahús (medium), grillezett cheddar sajt, karamellizált hagyma, csemegeuborka, bacon, BBQ szósz A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1400,
                    ImagePath = "https://images.unsplash.com/photo-1491960693564-421771d727d6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg0Ng&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 58,
                    Name = "Trófea Burger vegán pogácsával",
                    Description = "ketchup, karamellizált hagyma, vegán pogácsa, uborka, mustár A hamburger húspogácsák és a bucik nem tartalmaznak adalékanyagot és tartósítószert!",
                    Price = 1250,
                    ImagePath = "https://images.unsplash.com/photo-1470053053191-43e7bd267838?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aGFtYnVyZ2VyfHx8fHx8MTYzMjY5MDg4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 11
                },
                new Food
                {
                    Id = 59,
                    Name = "BBQ pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, füstölt sajt, BBQ csirkehús, paradicsom, lila hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2490,
                    ImagePath = "https://images.unsplash.com/photo-1618213957768-7789409b9dd8?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTEy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 12
                },
                new Food
                {
                    Id = 60,
                    Name = "Bruschetta pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, feta sajt, hagyma, rukkola, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2390,
                    ImagePath = "https://images.unsplash.com/photo-1516697073-419b2bd079db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTQ0&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 12
                },
                new Food
                {
                    Id = 61,
                    Name = "Margherita pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2190,
                    ImagePath = "https://images.unsplash.com/photo-1585505008861-a5c378857dcc?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkwOTc4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 12
                },
                new Food
                {
                    Id = 62,
                    Name = "Olívás margarita pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, zöld olívabogyó, paradicsom, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2190,
                    ImagePath = "https://images.unsplash.com/photo-1589375890993-7b568c0b8b1c?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDA4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 12
                },
                new Food
                {
                    Id = 63,
                    Name = "Sonkás-gombás pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, sonka, kukorica, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2290,
                    ImagePath = "https://images.unsplash.com/photo-1605478371310-a9f1e96b4ff4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDM4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 12
                },
                new Food
                {
                    Id = 64,
                    Name = "Szalámis pizza (32cm)",
                    Description = "paradicsomszósz, mozzarella sajt, szalámi, pepperoni, hagyma, Ajándék Xixo mojitoval (Pizzáink 100%-ban olasz alapanyagokból készülnek.)",
                    Price = 2290,
                    ImagePath = "https://images.unsplash.com/photo-1589906493606-a6ca2a06078b?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGl6emF8fHx8fHwxNjMyNjkxMDgy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 12
                },
                new Food
                {
                    Id = 65,
                    Name = "Balzsamecetben marinált csirke",
                    Description = "zöldfűszeres gnocchi, zeller, kurkuma, shallot",
                    Price = 3550,
                    ImagePath = "https://images.unsplash.com/photo-1501200291289-c5a76c232e5f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Y2hpY2tlbnx8fHx8fDE2MzI3NjQzNzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 13
                },
                new Food
                {
                    Id = 66,
                    Name = "Lazac steak",
                    Description = "brokkoli, beluga lencse, édes-savanyú redukció, friss zöldfűszerek",
                    Price = 4950,
                    ImagePath = "https://images.unsplash.com/photo-1485704686097-ed47f7263ca4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0NDYw&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 13
                },
                new Food
                {
                    Id = 67,
                    Name = "Vegán csőben sült kaliforniai paprika",
                    Description = "grillezett füge, szója emulzió, retek",
                    Price = 2950,
                    ImagePath = "https://images.unsplash.com/photo-1601565960311-8a7f4e1ab709?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFwcmlrYXx8fHx8fDE2MzI3NjQ2ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 13
                },
                new Food
                {
                    Id = 68,
                    Name = "Rib-eye",
                    Description = "(220 g), rukkola, grana padano d.o.p., koktélparadicsom",
                    Price = 7650,
                    ImagePath = "https://images.unsplash.com/photo-1607198179219-cd8b835fdda7?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzY0ODA2&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 13
                },
                new Food
                {
                    Id = 69,
                    Name = "Füstölt padlizsán tortelli",
                    Description = "menta, spárga ragu, pecorino, narancs",
                    Price = 3250,
                    ImagePath = "https://images.unsplash.com/photo-1613478881426-deeadee06d78?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZWdncGxhbnR8fHx8fHwxNjMyNzY0OTg1&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 13
                },
                new Food
                {
                    Id = 70,
                    Name = "Beluga steak limoncelloval flambírozva",
                    Description = "pirított pisztáciával, citromhéjas tejszínes udon tésztával",
                    Price = 4390,
                    ImagePath = "https://images.unsplash.com/photo-1556269923-e4ef51d69638?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c3RlYWt8fHx8fHwxNjMyNzcwNjYx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 14
                },
                new Food
                {
                    Id = 71,
                    Name = "Bivaly",
                    Description = "konyakos-libamájas mártással, tepertős burgonyapürével, szőlővel",
                    Price = 3790,
                    ImagePath = "https://images.unsplash.com/photo-1504472607343-a7fac413b524?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGxhdGV8fHx8fHwxNjMyNzcwNzkx&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 14
                },
                new Food
                {
                    Id = 72,
                    Name = "Csirkemellből készült paella",
                    Description = "Ahogy katalán chef barátunktól tanultuk",
                    Price = 2990,
                    ImagePath = "https://images.unsplash.com/photo-1575932444877-5106bee2a599?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Q2hpY2tlbiBicmVhc3R8fHx8fHwxNjMyNzcwOTk4&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 14
                },
                new Food
                {
                    Id = 73,
                    Name = "Narancsos kacsa",
                    Description = "rózsaborsos-citrusos mangó pürével, savoyai burgonyával",
                    Price = 3690,
                    ImagePath = "https://images.unsplash.com/photo-1505253668822-42074d58a7c6?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZHVjayxmb29kfHx8fHx8MTYzMjc3MTEzNA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 14
                },
                new Food
                {
                    Id = 74,
                    Name = "Vasvári zoltán féle konfitált báránycsülök",
                    Description = "ruccolás burgonyapürével, mentás mártással, toszkán zöldbabbal",
                    Price = 3990,
                    ImagePath = "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI3NzEyNzk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 14
                },
                new Food
                {
                    Id = 75,
                    Name = "Szarvasgerinc",
                    Description = "vadas, szalvétagombóc",
                    Price = 6990,
                    ImagePath = "https://images.unsplash.com/photo-1516685125522-3c528b8046ee?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4NjY&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 15
                },
                new Food
                {
                    Id = 76,
                    Name = "Paradicsom rizottó",
                    Description = "bazsalikom, stracciatella (V)",
                    Price = 4490,
                    ImagePath = "https://images.unsplash.com/photo-1460667450797-d71a56692010?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE4OTI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 15
                },
                new Food
                {
                    Id = 77,
                    Name = "Házi tagliatelle",
                    Description = "szarvasgomba, tanyasi csirke/garnéla/bélszín",
                    Price = 4690,
                    ImagePath = "https://images.unsplash.com/photo-1482049016688-2d3e1b311543?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjc3MTY4MA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 15
                },
                new Food
                {
                    Id = 78,
                    Name = "Tanyasi csirke",
                    Description = "füstölt saláta, boquerones",
                    Price = 4990,
                    ImagePath = "https://images.unsplash.com/photo-1504973960431-1c467e159aa4?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzE5NzU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 15
                },
                new Food
                {
                    Id = 79,
                    Name = "Legényfogó leves",
                    Description = "ertéscomb, csirkemáj, gomba,zöldségek - tejszínes-kapros habarással készül",
                    Price = 1660,
                    ImagePath = "https://images.unsplash.com/photo-1574484284002-952d92456975?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI3NzIzOTc&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 16
                },
                new Food
                {
                    Id = 80,
                    Name = "Magyaros hidegtál",
                    Description = "sonka, főtt-füstölt tarja, téli szalámi és paprikás szalámi, baconszalonna, parasztmájas, füstölt kolbász, sajtok, főtt tojás, friss zöldségek ",
                    Price = 3000,
                    ImagePath = "https://images.unsplash.com/photo-1432139509613-5c4255815697?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxmb29kfHx8fHx8MTYzMjc3MjY1OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 16
                },
                new Food
                {
                    Id = 81,
                    Name = "Lávakövön sült pulykamell",
                    Description = "grillezett libamájjal és gyümölcsökkel",
                    Price = 3700,
                    ImagePath = "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8Zm9vZCxwbGF0ZXx8fHx8fDE2MzI3NzI0ODA&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 16
                },
                new Food
                {
                    Id = 82,
                    Name = "Erdélyi fatányéros",
                    Description = "roston bélszín, serpenyős cigánypecsenye, rántott csirkemell, kakastaréj, sült kockaburgonya, házi csalamádé",
                    Price = 4200,
                    ImagePath = "https://images.unsplash.com/photo-1611315764615-3e788573f31e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZGlzaHx8fHx8fDE2MzI3NzI5ODg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 16
                },
                new Food
                {
                    Id = 83,
                    Name = "Bikavéres marhapofa",
                    Description = "üstölt zellerpüré, padron paprika, vargányagomba",
                    Price = 4250,
                    ImagePath = "https://images.unsplash.com/photo-1626509653291-18d9a934b9db?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bWVhdCxwbGF0ZXx8fHx8fDE2MzI4MjM5MzM&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 17
                },
                new Food
                {
                    Id = 84,
                    Name = "Kacsamáj befőtt",
                    Description = "szőlő chutney-val, dióval, házi brioche-sal",
                    Price = 2890,
                    ImagePath = "https://images.unsplash.com/photo-1626200419199-391ae4be7a41?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjQwMTE&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 17
                },
                new Food
                {
                    Id = 85,
                    Name = "Angus marhatatár",
                    Description = "füstös velőmajonézzel, savanyított hagymákkal",
                    Price = 2890,
                    ImagePath = "https://images.unsplash.com/photo-1514516345957-556ca7d90a29?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8dGF0YXIsbWVhdHx8fHx8fDE2MzI4MjQwOTU&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 17
                },
                new Food
                {
                    Id = 86,
                    Name = "Házi hosszúmetélt",
                    Description = "parajlevél pestóval és sós dióval, aszalt paradicsommal",
                    Price = 2490,
                    ImagePath = "https://images.unsplash.com/photo-1618163633808-dbd8a9f658ce?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cGFzdGF8fHx8fHwxNjMyODI0MTUz&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 17
                },
                new Food
                {
                    Id = 87,
                    Name = "Taxi burger",
                    Description = "szezámmagos buci, marhahúspogácsa 1 db (13 dkg), hamburgerszósz, jégsaláta, csemege uborka, trappista sajt, pirított hagyma, bacon",
                    Price = 1399,
                    ImagePath = "https://images.unsplash.com/photo-1623945359564-b8d01dd5cfe2?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDMyNQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 18
                },
                new Food
                {
                    Id = 88,
                    Name = "Erős Anna",
                    Description = "szezámmagos buci, marhahús pogácsa 1 db (13 dkg), ketchup, jégsaláta, kígyóuborka, pirított hagyma, bacon, jalapeno",
                    Price = 1399,
                    ImagePath = "https://images.unsplash.com/photo-1585238341267-1cfec2046a55?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDQxOQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 18
                },
                new Food
                {
                    Id = 89,
                    Name = "Rosti Burger",
                    Description = "szezámmagos buci, marhahúspogácsa (13 dkg-os), BBQ szósz, jégsaláta, paradicsom, füstölt sajtchips, cheddar sajt, bacon, jalapeno",
                    Price = 1599,
                    ImagePath = "https://images.unsplash.com/photo-1572802419224-296b0aeee0d9?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDUwMg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 18
                },
                new Food
                {
                    Id = 90,
                    Name = "Zátony Burger",
                    Description = "szezámmagos buci, marhahúspogácsa 2 db (13 dkg-os), BBQ szósz, lila hagyma, paradicsom, kígyóuborka, cheddar sajt, füstölt sajt, trappista sajt, bacon, jalapeno",
                    Price = 1899,
                    ImagePath = "https://images.unsplash.com/photo-1561043433-9265f73e685f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YnVyZ2VyfHx8fHx8MTYzMjgyNDYwMQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 18
                },
                new Food
                {
                    Id = 91,
                    Name = "Favágó karaj",
                    Description = "vaslapon sült pácolt karaj tejfölös, füstölt tarjás, savanyú uborkás, szalonnás raguval",
                    Price = 2800,
                    ImagePath = "https://images.unsplash.com/photo-1605209971703-73c7ed7c923e?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4NzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 19
                },
                new Food
                {
                    Id = 92,
                    Name = "Kishuszáros karaj",
                    Description = "szaftos, vaslapon sült karaj fokhagymával, sült szalonnával",
                    Price = 2800,
                    ImagePath = "https://images.unsplash.com/photo-1624174503860-478619028ab3?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ4OTQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 19
                },
                new Food
                {
                    Id = 93,
                    Name = "Bádogos csülök",
                    Description = "pirított kolbász, füstölt tarja, füstölt szalonna, vöröshagyma, savanyú uborka, tejföl",
                    Price = 2900,
                    ImagePath = "https://images.unsplash.com/photo-1584932901306-a19fdf291cec?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cG9ya3x8fHx8fDE2MzI4MjQ5ODQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 19
                },
                new Food
                {
                    Id = 94,
                    Name = "Besütött harcsa főszakács-módra",
                    Description = "spenót, spárga, sajt",
                    Price = 3600,
                    ImagePath = "https://images.unsplash.com/photo-1467003909585-2f8a72700288?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8ZmlzaCxwbGF0ZXx8fHx8fDE2MzI4MjUwOTg&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 19
                },
                new Food
                {
                    Id = 95,
                    Name = "Bélszínjava egri módra",
                    Description = "roston sült libamáj, gomba, egri barnamártás",
                    Price = 5800,
                    ImagePath = "https://images.unsplash.com/photo-1598511726623-d2e9996892f0?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8bG9pbnx8fHx8fDE2MzI4MjUxMzI&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 19
                },
                new Food
                {
                    Id = 96,
                    Name = "Labane",
                    Description = "Joghurtból készült házi krémsajt, marinált paprikával és sült articsókával, friss pitával tálalva",
                    Price = 1890,
                    ImagePath = "https://images.unsplash.com/photo-1565720490528-48e5be3d6a1f?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8cmVzdGF1cmFudCxmb29kfHx8fHx8MTYzMjgyNTI2OQ&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 20
                },
                new Food
                {
                    Id = 97,
                    Name = "Jemeni Csirkeleves",
                    Description = "Jemeni fűszerekkel főtt csirkeleves tépett csirkecombbal, citrommal és friss korianderrel",
                    Price = 1690,
                    ImagePath = "https://images.unsplash.com/photo-1469307517101-0b99d8fb0c33?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU0OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 20
                },
                new Food
                {
                    Id = 98,
                    Name = "Humusz Tahini tál",
                    Description = "Minden hummusz tálat friss, házi hummusszal, csicseriborsóval, tahinivel, petrezselyemmel és olívaolajjal tálalunk, mellé friss grillezett pitát adunk. Kérheted zhug csipős szósszal is!",
                    Price = 1890,
                    ImagePath = "https://images.unsplash.com/photo-1622040806062-27ae4deb4a40?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8aHVtdXN8fHx8fHwxNjMyODI1NTcy&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 20
                },
                new Food
                {
                    Id = 99,
                    Name = "Vegán lencsekrémleves",
                    Description = "Két fajta lencséből készült krémleves, sült padlizsán kockákkal és lime-chili mogyoróval",
                    Price = 1590,
                    ImagePath = "https://images.unsplash.com/photo-1547308283-b74183c15032?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8c291cHx8fHx8fDE2MzI4MjU1MTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 20
                },
                new Food
                {
                    Id = 100,
                    Name = "Bárányzsíron sült petrezselymes marha kebab",
                    Description = "Házi recept alapján készített, darált marha pogácsa",
                    Price = 3590,
                    ImagePath = "https://images.unsplash.com/photo-1625937282844-4a0cb4665820?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=800&ixid=MnwxfDB8MXxyYW5kb218MHx8YmVlZnx8fHx8fDE2MzI4MjU1OTk&ixlib=rb-1.2.1&q=80&utm_campaign=api-credit&utm_medium=referral&utm_source=unsplash_source&w=800",
                    RestaurantId = 20
                }
            );
        }
    }
}
