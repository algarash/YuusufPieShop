namespace YuusufPieShop.Models
{
    public static class DbIntializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            YuusufPieShopDbContext context = 
                applicationBuilder.ApplicationServices.CreateScope
                ().ServiceProvider.GetRequiredService<YuusufPieShopDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Pies.Any())
            {
                context.AddRange
                    (
                  
                    new Pie
                    {
                        Name = "Mock",
                        PiePrice = 15.15M,
                        PieDescription = "ddm",
                        IsPieOftheWeek = true,
                        Category = Categories["Cake Fruit"],
                        ImageThumbnailUri = "https://extension.colostate.edu/wp-content/uploads/2021/04/07000-fig1.jpg",
                    },
                 new Pie
                 {
                     Name = "Cakc",
                     PiePrice = 15.15M,
                     PieDescription = "ddm",
                     IsPieOftheWeek = true,
                     Category = Categories["Cake Fruit"],
                     ImageThumbnailUri = "https://extension.colostate.edu/wp-content/uploads/2021/04/07000-fig1.jpg",
                 },
                 new Pie
                 {
                     Name = "SSamic",
                     PiePrice = 15.15M,
                     PieDescription = "ddm",
                     IsPieOftheWeek = true,
                     Category = Categories["Cake Fruit"],
                     ImageThumbnailUri = "https://extension.colostate.edu/wp-content/uploads/2021/04/07000-fig1.jpg",
                 });

            }

            context.SaveChanges();
            // Retrieve the Pies from the database
            var piesToUpdate = context.Pies.ToList(); // You might want to filter this based on some condition

            // Update the LongDesic and ShortDesic properties for each Pie
            foreach (var pie in piesToUpdate)
            {
                // Modify the LongDesic and ShortDesic properties as needed
                pie.ShortDesic = "So, in essence, going long is a strategy based on the belief that the asset's value will increase";
                pie.LongDesic = "On the other hand, when someone takes a short position, they're essentially betting that the value of an asset will decrease. In a short sale, the investor borrows the asset from a broker, sells it at the current market price, and then hopes to buy it back later at a lower price. The difference between the selling price and the buying price is their profit.";
                     
            }

            // Save the changes to the database
            context.SaveChanges();

        }

        private static Dictionary<string, Category>? categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genersList = new Category[]
                    {
                        new Category{CategoryName = "Cake Fruit"},
                        new Category{CategoryName = "Cheese Fruit"},
                        new Category{CategoryName = "Seasonal Pies"},
                    };
                    categories = new Dictionary<string, Category>();
                    foreach ( Category genre in genersList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }
                return categories;
            }
        }


    }
}
