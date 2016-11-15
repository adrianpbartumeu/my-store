namespace StoreAPB.Migrations
{
    using StoreAPB.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StoreAPB.Models.StoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StoreAPB.Models.StoreDbContext";
        }

        protected override void Seed(StoreAPB.Models.StoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            List<Category> categories = CreateCategories(context);
            CreateElectricalDevices(context, categories);
            CreateMeat(context, categories);
        }

        private List<Category> CreateCategories(StoreDbContext context)
        {
            var category = new List<Category>{
                new Category{categoryid=1, name="c"},
                new Category{categoryid=2, name="d"}            
            };
            category.ForEach(c => context.Category.Add(c));
            context.SaveChanges();

            return category;
        }

        private void CreateElectricalDevices(StoreDbContext context, List<Category> category)
        {
            var electrical = new List<Electrical_Appliance>{
                new Electrical_Appliance{ productid=1,name_p="Sony CD Recorder",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                    reduce=0,amount=67,brand="Sony",type="CD Recorder",image="cd recorder1.jpg",description="Weight: 2kg, Height:20cm  Lenght: 20cm, Width:40cm"},
                new Electrical_Appliance{ productid=2,name_p="TEAC CD Recorder",categoryid=category.Single(n=>n.name=="d").categoryid,price=decimal.Parse("56.25"),
                    reduce=10,amount=888,brand="TEAC",type="CD Recorder",image="cd recorder2.jpg",description="Weight: 2.5kg, Height: 25cm , Lenght: 22cm, Width:43cm"},
                 new Electrical_Appliance{ productid=3,name_p="Philips CD Recorder",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                     reduce=0,amount=67,brand="Philips",type="CD Recorder",image="cd recorder3.jpg",description="Weight: 2.8kg, Height: 28cm , Lenght: 25cm, Width:47cm"},

                new Electrical_Appliance{ productid=4,name_p="Sony Mixer",categoryid=category.Single(n=>n.name=="d").categoryid,price=56,
                    reduce=0,amount=888,brand="Sony",type="Mixer",image="Mixer1.jpg",description="Weight: 3kg, Height: 28cm , Lenght: 10cm, Width:15cm"},
                 new Electrical_Appliance{ productid=5,name_p="Sansung Mixer",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                    reduce=10, amount=67,brand="Sansung",type="Mixer",image="Mixer2.jpg",description="Weight: 2.8kg, Height: 25cm , Lenght: 12cm, Width:10cm"},
                new Electrical_Appliance{ productid=6,name_p="Philips Mixer",categoryid=category.Single(n=>n.name=="d").categoryid,price=56,
                   reduce=0,amount=888,brand="Philips",type="Mixer",image="Mixer3.jpg",description="Weight: 3.2kg, Height: 28cm , Lenght: 15cm, Width:10cm"},

                 new Electrical_Appliance{ productid=7,name_p="SPC Internet Radio",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                     reduce=0,amount=67,brand="SPC Internet",type="Radio",image="radio1.jpg",description="Weight: 2.8kg, Height: 20cm , Lenght: 15cm, Width:20cm"},
                new Electrical_Appliance{ productid=8,name_p="Sony Radio",categoryid=category.Single(n=>n.name=="d").categoryid,price=56,
                    reduce=10,amount=888,brand="Sony",type="Radio",image="radio2.jpg",description="Weight: 2.9kg, Height: 21cm , Lenght: 16cm, Width:22cm"},
                 new Electrical_Appliance{ productid=9,name_p="Sansung Radio",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                    reduce=0, amount=67,brand="Sansung",type="Radio",image="radio3.jpg",description="Weight: 3kg, Height: 23cm , Lenght: 18cm, Width:23cm"},

                new Electrical_Appliance{ productid=10,name_p="Sony Tape Recorder",categoryid=category.Single(n=>n.name=="d").categoryid,price=56,
                    reduce=0,amount=888,brand="Sony",type="Tape Recorder",image="tape recorder1.jpg",description="Weight: 4kg, Height: 20cm , Lenght: 25cm, Width:35cm"},
                 new Electrical_Appliance{ productid=11,name_p="Sansung Tape Recorder",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                     reduce=10,amount=67,brand="Sansung",type="Tape Recorder",image="tape recorder2.jpg",description="Weight: 4.2kg, Height: 22cm , Lenght: 28cm, Width:47cm"},
                new Electrical_Appliance{ productid=12,name_p="Philips Tape Recorder",categoryid=category.Single(n=>n.name=="d").categoryid,price=56,
                    reduce=0,amount=888,brand="Philips",type="Tape Recorder",image="tape recorder3.jpg",description="Weight: 5kg, Height: 25cm , Lenght: 29cm, Width:50cm"},

                 new Electrical_Appliance{ productid=13,name_p="Sansung TV",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                     reduce=0,amount=67,brand="Sansung",type="TV",image="tv1.jpg",description="Weight: 2kg, Height: 28cm , Lenght: 2cm, Width:40cm"},
                new Electrical_Appliance{ productid=14,name_p="Sony TV",categoryid=category.Single(n=>n.name=="d").categoryid,price=56,
                    reduce=10,amount=888,brand="Sony",type="TV",image="tv2.jpg",description="Weight: 1.8kg, Height: 28cm , Lenght: 2cm, Width:47cm"},
                 new Electrical_Appliance{ productid=15,name_p="Philips TV",categoryid=category.Single(n=>n.name=="c").categoryid, price=23,
                     reduce=0,amount=67,brand="Philips",type="TV",image="tv3.jpg",description="Weight: 1.5kg, Height: 28cm , Lenght: 2cm, Width:55cm"}
                };

            electrical.ForEach(c => context.Product.Add(c));
            context.SaveChanges();
        }

        private void CreateMeat(StoreDbContext context, List<Category> category)
        {
            var meat = new List<Meat>{
                new Meat{ productid=16,name_p="Beef",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company1",type="Beef",image="beef.jpg",description="From Miami"},
                new Meat{ productid=17,name_p="Beef",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=10,amount=67,provider="Company1",type="Beef",image="beef2.jpg",description="From Nebraska"},
                new Meat{ productid=18,name_p="Beef",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company1",type="Beef",image="beef3.jpg",description="From Cuba"},

                new Meat{ productid=19,name_p="Chicken",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company2",type="Chicken",image="chicken.jpg",description="From Canada"},
                new Meat{ productid=20,name_p="Chicken",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=10,amount=67,provider="Company2",type="Chicken",image="chicken2.jpg",description="From China"},
                new Meat{ productid=21,name_p="Chicken",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company2",type="Chicken",image="chicken3.jpg",description="From Puerto Rico"},

                new Meat{ productid=22,name_p="Mutton",price=56,categoryid=category.Single(n=>n.name=="d").categoryid,
                    reduce=0,amount=888,provider="Company3",type="Mutton",image="mutton.jpg",description="From India"},            
                new Meat{ productid=23,name_p="Mutton",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=10,amount=67,provider="Company3",type="Mutton",image="mutton2.jpg",description="From Korea"},
                new Meat{ productid=24,name_p="Mutton",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company3",type="Mutton",image="mutton3.jpg",description="From Atlanta"},

                new Meat{ productid=25,name_p="Pork",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company4",type="Pork",image="pork.jpg",description="From New York"},
                new Meat{ productid=26,name_p="Pork",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=10,amount=67,provider="Company4",type="Pork",image="pork2.jpg",description="From China"},
                new Meat{ productid=27,name_p="Pork",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company4",type="Pork",image="pork3.jpg",description="From Japan"},
                new Meat{ productid=28,name_p="Pork",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=10,amount=67,provider="Company4",type="Pork",image="pork4.jpg",description="From Cuba"},
                new Meat{ productid=29,name_p="Pork",price=56,categoryid=category.Single(n=>n.name=="d").categoryid,
                    reduce=0,amount=888,provider="Company4",type="Pork",image="pork5.jpg",description="From India"},
            
                new Meat{ productid=30,name_p="Veal",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company5",type="Veal",image="veal.jpg",description="From Miami"},
                new Meat{ productid=31,name_p="Veal",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=10,amount=67,provider="Company5",type="Veal",image="veal2.jpg",description="From Tampa"},
                new Meat{ productid=32,name_p="Veal",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=0,amount=67,provider="Company5",type="Veal",image="veal3.jpg",description="From Canada"},
                new Meat{ productid=33,name_p="Veal",price=23,categoryid=category.Single(n=>n.name=="c").categoryid,
                    reduce=10,amount=67,provider="Company5",type="Veal",image="veal4.jpg",description="From Dominican Republic"}
               };
            meat.ForEach(c => context.Product.Add(c));
            context.SaveChanges();
        }
    }
}
