using BethanysPieShop.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Pie> Pies { get; set; }
        public DbSet<PieRecipe> PieRecipes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pie>().HasData(
                new Pie
                {
                    Id = 1,
                    Name = "Caramel Popcorn Cheese Cake",
                    Price = 22.95M,
                    ShortDescription = "A delightful fusion of caramel popcorn and cheesecake.",
                    LongDescription = "Experience the perfect balance of rich cheesecake and the nostalgic crunch of caramel popcorn. This unique combination will have your taste buds dancing with joy.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/caramelpopcorncheesecake.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 2,
                    Name = "Chocolate Cheese Cake",
                    Price = 18.95M,
                    ShortDescription = "A heavenly blend of chocolate and cheesecake.",
                    LongDescription = "Indulge in the creamy, rich taste of our Chocolate Cheese Cake, where smooth cheesecake meets luscious layers of chocolate. Perfect for chocolate lovers!",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/chocolatecheesecake.jpg",
                    IsPieOfTheWeek = true
                },
                new Pie
                {
                    Id = 3,
                    Name = "Pistache Cheese Cake",
                    Price = 17.95M,
                    ShortDescription = "A nutty delight with a cheesecake twist.",
                    LongDescription = "Our Pistache Cheese Cake is a delicate blend of creamy cheesecake with a hint of pistachio flavor, offering a smooth and nutty experience in every bite.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/pistachecheesecake.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 4,
                    Name = "Pecan Pie",
                    Price = 14.95M,
                    ShortDescription = "A classic American favorite, rich with pecans.",
                    LongDescription = "Savor the traditional taste of Pecan Pie with its rich, buttery filling topped with crunchy pecans. It's the perfect dessert for any occasion.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/pecanpie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 5,
                    Name = "Birthday Pie",
                    Price = 15.95M,
                    ShortDescription = "Celebrate with our festive Birthday Pie!",
                    LongDescription = "Make any birthday special with our Birthday Pie, featuring colorful sprinkles, a sweet crust, and a deliciously creamy filling that's perfect for any celebration.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/birthdaypie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 6,
                    Name = "Apple Pie",
                    Price = 12.95M,
                    ShortDescription = "Our famous apple pies!",
                    LongDescription = "Enjoy a slice of comfort with our Apple Pie, filled with fresh, juicy apples and a hint of cinnamon, all wrapped in a golden, flaky crust.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/applepie.jpg",
                    IsPieOfTheWeek = true
                },
                new Pie
                {
                    Id = 7,
                    Name = "Cheese Cake",
                    Price = 13.95M,
                    ShortDescription = "Classic and creamy cheesecake.",
                    LongDescription = "Delight in the rich and creamy texture of our traditional Cheese Cake, a timeless dessert that's perfect for any sweet tooth craving.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/cheesecake.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 8,
                    Name = "Cherry Pie",
                    Price = 14.95M,
                    ShortDescription = "A tart and sweet cherry delight.",
                    LongDescription = "Our Cherry Pie is packed with juicy cherries in a flaky crust, delivering a perfect balance of tartness and sweetness in every bite.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/cherrypie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 9,
                    Name = "Christmas Apple Pie",
                    Price = 16.95M,
                    ShortDescription = "A festive twist on the classic apple pie.",
                    LongDescription = "Enjoy the warmth of the holidays with our Christmas Apple Pie, featuring spiced apples, a hint of nutmeg, and a buttery crust, perfect for winter celebrations.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/christmasapplepie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 10,
                    Name = "Cranberry Pie",
                    Price = 13.95M,
                    ShortDescription = "A tart treat with a cranberry kick.",
                    LongDescription = "Our Cranberry Pie offers a refreshing burst of tart cranberries balanced with a sweet filling, making it a unique and flavorful dessert.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/cranberrypie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 11,
                    Name = "Peach Pie",
                    Price = 14.95M,
                    ShortDescription = "A sweet slice of summer.",
                    LongDescription = "Savor the taste of summer with our Peach Pie, made with fresh, ripe peaches and a golden, buttery crust that melts in your mouth.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/peachpie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 12,
                    Name = "Pumpkin Pie",
                    Price = 12.95M,
                    ShortDescription = "A seasonal favorite, perfect for autumn.",
                    LongDescription = "Enjoy the flavors of fall with our Pumpkin Pie, featuring a spiced pumpkin filling in a flaky crust. It's a must-have for any autumn gathering.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/pumpkinpie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 13,
                    Name = "Rhubarb Pie",
                    Price = 14.95M,
                    ShortDescription = "A tangy twist on a traditional pie.",
                    LongDescription = "Our Rhubarb Pie combines a tangy filling with a sweet, buttery crust, creating a delightful contrast of flavors that's sure to please.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/rhubarbpie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 14,
                    Name = "Strawberry Pie",
                    Price = 14.95M,
                    ShortDescription = "A burst of fresh strawberry flavor.",
                    LongDescription = "Taste the freshness of summer with our Strawberry Pie, featuring a luscious filling made from ripe strawberries, all encased in a flaky crust.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/strawberrypie.jpg",
                    IsPieOfTheWeek = false
                },
                new Pie
                {
                    Id = 15,
                    Name = "Strawberry Cheese Cake",
                    Price = 15.95M,
                    ShortDescription = "A delicious blend of strawberries and cheesecake.",
                    LongDescription = "Indulge in the creamy goodness of our Strawberry Cheese Cake, combining the rich flavors of cheesecake with the fresh, sweet taste of strawberries.",
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/ai/strawberrycheesecake.jpg",
                    IsPieOfTheWeek = false
                }
            );

            modelBuilder.Entity<PieRecipe>().HasData(
                new PieRecipe
                {
                    Id = 1,
                    Name = "Classic Apple Pie",
                    Steps = "1. Preheat oven to 425°F (220°C). Prepare a 9-inch pie dish with a bottom crust. 2. Peel, core, and slice 6 cups of apples (a mix of Granny Smith and Honeycrisp recommended). 3. In a bowl, mix apples with 1/2 cup sugar, 1/4 cup brown sugar, 1/4 cup flour, 1 tsp cinnamon, 1/4 tsp nutmeg, and a pinch of salt. 4. Pour the apple mixture into the prepared pie crust. Dot with 2 tbsp of butter. 5. Cover with top crust, seal edges, and make a few slits for steam to escape. 6. Bake for 45-50 minutes or until the crust is golden and filling is bubbly. Let it cool before serving.",
                    Ingredients = "6 cups apples, 1/2 cup sugar, 1/4 cup brown sugar, 1/4 cup flour, 1 tsp cinnamon, 1/4 tsp nutmeg, pinch of salt, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 2,
                    Name = "Pumpkin Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 1 can (15 oz) of pumpkin puree, 3/4 cup sugar, 1/2 tsp salt, 1 tsp cinnamon, 1/2 tsp ginger, 1/4 tsp cloves, and 2 eggs. 3. Gradually stir in 1 can (12 oz) evaporated milk. 4. Pour the mixture into the pie crust. 5. Bake for 55-60 minutes or until a knife inserted near the center comes out clean. Cool on a wire rack for 2 hours.",
                    Ingredients = "1 can (15 oz) pumpkin puree, 3/4 cup sugar, 1/2 tsp salt, 1 tsp cinnamon, 1/2 tsp ginger, 1/4 tsp cloves, 2 eggs, 1 can (12 oz) evaporated milk, pie crust"
                },

                new PieRecipe
                {
                    Id = 3,
                    Name = "Cherry Pie",
                    Steps = "1. Preheat oven to 400°F (200°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups pitted tart cherries, 1 cup sugar, 1/4 cup cornstarch, 1/4 tsp almond extract, and a pinch of salt. 3. Pour the cherry mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust and crimp the edges. 5. Bake for 45-50 minutes until the filling is bubbly and the crust is golden. Cool before serving.",
                    Ingredients = "4 cups pitted tart cherries, 1 cup sugar, 1/4 cup cornstarch, 1/4 tsp almond extract, pinch of salt, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 4,
                    Name = "Pecan Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup corn syrup, 1 cup sugar, 2 tbsp melted butter, and 1 tsp vanilla extract. 3. Stir in 1 1/2 cups pecan halves. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing.",
                    Ingredients = "3 eggs, 1 cup corn syrup, 1 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, 1 1/2 cups pecan halves, pie crust"
                },

                new PieRecipe
                {
                    Id = 5,
                    Name = "Key Lime Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a 9-inch graham cracker crust. 2. In a bowl, mix 3 egg yolks and 1 can (14 oz) sweetened condensed milk until smooth. 3. Stir in 1/2 cup fresh key lime juice and 1 tsp lime zest. 4. Pour the filling into the crust. 5. Bake for 15-20 minutes or until the filling is set. Cool, then chill in the refrigerator for at least 2 hours before serving.",
                    Ingredients = "3 egg yolks, 1 can (14 oz) sweetened condensed milk, 1/2 cup fresh key lime juice, 1 tsp lime zest, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 6,
                    Name = "Chocolate Silk Pie",
                    Steps = "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. Melt 4 oz semisweet chocolate and let it cool slightly. 3. In a bowl, cream 1 cup softened butter with 1 cup sugar until light and fluffy. Mix in the cooled chocolate. 4. Add 3 eggs one at a time, beating on high speed for 5 minutes each time. 5. Pour the mixture into the cooled pie crust. 6. Refrigerate for at least 4 hours or until set. Top with whipped cream before serving.",
                    Ingredients = "4 oz semisweet chocolate, 1 cup softened butter, 1 cup sugar, 3 eggs, pie crust"
                },

                new PieRecipe
                {
                    Id = 7,
                    Name = "Peach Pie",
                    Steps = "1. Preheat oven to 425°F (220°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 6 cups sliced peaches, 3/4 cup sugar, 1/4 cup flour, 1/2 tsp cinnamon, and a pinch of nutmeg. 3. Pour the peach mixture into the pie crust. Dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 45-50 minutes until golden brown and bubbly. Cool slightly before serving.",
                    Ingredients = "6 cups sliced peaches, 3/4 cup sugar, 1/4 cup flour, 1/2 tsp cinnamon, pinch of nutmeg, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 8,
                    Name = "Lemon Meringue Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pre-baked pie crust. 2. In a saucepan, mix 1 cup sugar, 2 tbsp flour, 3 tbsp cornstarch, and a pinch of salt. Gradually stir in 1 1/2 cups water, 2 tbsp butter, and 1/4 cup lemon juice. Cook over medium heat until thickened. 3. Whisk 3 egg yolks in a bowl, then slowly add a portion of the hot mixture, stirring constantly. Return to the pan and cook for 2 more minutes. 4. Pour filling into the pie crust. 5. Beat 3 egg whites with 6 tbsp sugar until stiff peaks form. Spread over the pie. 6. Bake for 10-12 minutes until meringue is golden. Cool before serving.",
                    Ingredients = "1 cup sugar, 2 tbsp flour, 3 tbsp cornstarch, pinch of salt, 1 1/2 cups water, 2 tbsp butter, 1/4 cup lemon juice, 3 egg yolks, 3 egg whites, 6 tbsp sugar, pie crust"
                },

                new PieRecipe
                {
                    Id = 9,
                    Name = "Blueberry Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups fresh blueberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "4 cups fresh blueberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, pinch of salt, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 10,
                    Name = "Banana Cream Pie",
                    Steps = "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, combine 3/4 cup sugar, 1/3 cup flour, and a pinch of salt. Gradually whisk in 2 1/2 cups milk. 3. Cook over medium heat, stirring constantly until thickened. Remove from heat. 4. In a bowl, beat 3 egg yolks. Slowly whisk in a portion of the hot milk mixture, then return to the saucepan and cook for 2 more minutes. 5. Remove from heat and stir in 2 tbsp butter and 1 tsp vanilla extract. Let it cool slightly. 6. Slice 2-3 bananas and arrange them on the pie crust. Pour the custard over bananas. 7. Chill in the refrigerator for at least 2 hours before serving. Top with whipped cream.",
                    Ingredients = "3/4 cup sugar, 1/3 cup flour, pinch of salt, 2 1/2 cups milk, 3 egg yolks, 2 tbsp butter, 1 tsp vanilla extract, 2-3 bananas, pie crust"
                },
                new PieRecipe
                {
                    Id = 11,
                    Name = "French Silk Pie",
                    Steps = "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. Melt 4 oz unsweetened chocolate and let it cool slightly. 3. In a bowl, cream 1 cup softened butter with 1 cup sugar until light and fluffy. Mix in the cooled chocolate. 4. Add 4 eggs one at a time, beating on high speed for 5 minutes each time. 5. Pour the mixture into the cooled pie crust. 6. Refrigerate for at least 4 hours or until set. Top with whipped cream and chocolate shavings before serving.",
                    Ingredients = "4 oz unsweetened chocolate, 1 cup softened butter, 1 cup sugar, 4 eggs, pie crust, whipped cream, chocolate shavings"
                },

                new PieRecipe
                {
                    Id = 12,
                    Name = "Sweet Potato Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 2 cups mashed sweet potatoes, 1 cup sugar, 1/2 cup milk, 2 eggs, 1/2 tsp ground cinnamon, 1/4 tsp ground nutmeg, 1/4 tsp ground ginger, and 1/2 tsp vanilla extract. 3. Pour the mixture into the pie crust. 4. Bake for 55-60 minutes or until a knife inserted near the center comes out clean. Let it cool before serving.",
                    Ingredients = "2 cups mashed sweet potatoes, 1 cup sugar, 1/2 cup milk, 2 eggs, 1/2 tsp ground cinnamon, 1/4 tsp ground nutmeg, 1/4 tsp ground ginger, 1/2 tsp vanilla extract, pie crust"
                },

                new PieRecipe
                {
                    Id = 13,
                    Name = "Coconut Cream Pie",
                    Steps = "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, combine 1/2 cup sugar, 1/4 cup cornstarch, and a pinch of salt. Gradually whisk in 2 cups milk. 3. Cook over medium heat, stirring constantly until thickened. 4. In a bowl, beat 3 egg yolks. Slowly whisk in a portion of the hot milk mixture, then return to the saucepan and cook for 2 more minutes. 5. Remove from heat and stir in 1 tbsp butter and 1 tsp vanilla extract. Fold in 1 cup shredded coconut. 6. Pour the mixture into the cooled pie crust. Chill for at least 4 hours before serving. Top with whipped cream and toasted coconut.",
                    Ingredients = "1/2 cup sugar, 1/4 cup cornstarch, pinch of salt, 2 cups milk, 3 egg yolks, 1 tbsp butter, 1 tsp vanilla extract, 1 cup shredded coconut, pie crust, whipped cream, toasted coconut"
                },

                new PieRecipe
                {
                    Id = 14,
                    Name = "Strawberry Rhubarb Pie",
                    Steps = "1. Preheat oven to 400°F (200°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 2 1/2 cups sliced strawberries, 2 1/2 cups chopped rhubarb, 1 cup sugar, 1/4 cup cornstarch, and 1/4 tsp cinnamon. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 45-50 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "2 1/2 cups sliced strawberries, 2 1/2 cups chopped rhubarb, 1 cup sugar, 1/4 cup cornstarch, 1/4 tsp cinnamon, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 15,
                    Name = "Maple Pecan Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup pure maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 1/2 cups pecan halves. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing.",
                    Ingredients = "3 eggs, 1 cup pure maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 1/2 cups pecan halves, pie crust"
                },

                new PieRecipe
                {
                    Id = 16,
                    Name = "Butterscotch Pie",
                    Steps = "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, melt 1/2 cup butter over medium heat. Stir in 1 cup brown sugar and cook for 2 minutes. 3. Gradually stir in 1/4 cup cornstarch and 2 cups milk, whisking constantly until thickened. 4. In a bowl, beat 3 egg yolks. Slowly whisk in a portion of the hot mixture, then return to the saucepan and cook for 2 more minutes. 5. Remove from heat and stir in 1 tsp vanilla extract. 6. Pour the mixture into the cooled pie crust. Chill for at least 4 hours before serving. Top with whipped cream and butterscotch chips.",
                    Ingredients = "1/2 cup butter, 1 cup brown sugar, 1/4 cup cornstarch, 2 cups milk, 3 egg yolks, 1 tsp vanilla extract, pie crust, whipped cream, butterscotch chips"
                },

                new PieRecipe
                {
                    Id = 17,
                    Name = "Blackberry Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups blackberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "4 cups blackberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, pinch of salt, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 18,
                    Name = "Chocolate Cream Pie",
                    Steps = "1. Bake a pie crust according to package instructions; let it cool. 2. In a saucepan, combine 3/4 cup sugar, 1/4 cup cornstarch, and a pinch of salt. Gradually whisk in 2 cups milk. 3. Cook over medium heat, stirring constantly until thickened. 4. Stir in 4 oz chopped chocolate and 1 tsp vanilla extract until smooth. 5. Pour the mixture into the cooled pie crust. Chill for at least 4 hours before serving. Top with whipped cream and chocolate shavings.",
                    Ingredients = "3/4 cup sugar, 1/4 cup cornstarch, pinch of salt, 2 cups milk, 4 oz chopped chocolate, 1 tsp vanilla extract, pie crust, whipped cream, chocolate shavings"
                },

                new PieRecipe
                {
                    Id = 19,
                    Name = "Custard Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 3/4 cup sugar, 1/4 tsp salt, 1 tsp vanilla extract, and 2 cups whole milk. 3. Pour the mixture into the pie crust. 4. Bake for 45-50 minutes or until a knife inserted near the center comes out clean. Let it cool before serving.",
                    Ingredients = "3 eggs, 3/4 cup sugar, 1/4 tsp salt, 1 tsp vanilla extract, 2 cups whole milk, pie crust"
                },

                new PieRecipe
                {
                    Id = 20,
                    Name = "Raspberry Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups raspberries, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "4 cups raspberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, 2 tbsp butter, pie crust"
                },
                new PieRecipe
                {
                    Id = 21,
                    Name = "Mince Pie",
                    Steps = "1. Preheat oven to 400°F (200°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 2 cups minced meat, 1/2 cup raisins, 1/4 cup currants, 1/4 cup chopped apples, 1/4 cup brown sugar, 1/4 cup brandy, 1 tsp cinnamon, 1/2 tsp allspice, 1/4 tsp nutmeg, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 30-35 minutes until golden brown and bubbly. Let it cool before serving.",
                    Ingredients = "2 cups minced meat, 1/2 cup raisins, 1/4 cup currants, 1/4 cup chopped apples, 1/4 cup brown sugar, 1/4 cup brandy, 1 tsp cinnamon, 1/2 tsp allspice, 1/4 tsp nutmeg, pinch of salt, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 22,
                    Name = "Pineapple Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 3 cups chopped pineapple, 1 cup sugar, 1/4 cup cornstarch, and 1 tsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 45-50 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "3 cups chopped pineapple, 1 cup sugar, 1/4 cup cornstarch, 1 tsp lemon juice, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 23,
                    Name = "Chocolate Pecan Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup corn syrup, 1/2 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 cup chopped pecans and 1/2 cup chocolate chips. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing.",
                    Ingredients = "3 eggs, 1 cup corn syrup, 1/2 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 cup chopped pecans, 1/2 cup chocolate chips, pie crust"
                },

                new PieRecipe
                {
                    Id = 24,
                    Name = "Mango Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups sliced mangoes, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lime juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "4 cups sliced mangoes, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lime juice, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 25,
                    Name = "Pear and Almond Tart",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a tart pan with a bottom crust. 2. In a bowl, mix 1 cup ground almonds, 1/2 cup sugar, 1/4 cup butter, 1 egg, and 1/2 tsp almond extract. 3. Spread the almond mixture over the crust. 4. Arrange 3 sliced pears over the almond mixture. 5. Bake for 40-45 minutes or until the tart is golden and the pears are tender. Let it cool before serving.",
                    Ingredients = "1 cup ground almonds, 1/2 cup sugar, 1/4 cup butter, 1 egg, 1/2 tsp almond extract, 3 pears, tart crust"
                },

                new PieRecipe
                {
                    Id = 26,
                    Name = "Lemon Chess Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 1 1/2 cups sugar, 2 tbsp cornmeal, 1 tbsp flour, 1/4 tsp salt, 1/2 cup melted butter, 3/4 cup lemon juice, and 4 eggs. 3. Pour the mixture into the pie crust. 4. Bake for 40-45 minutes or until the filling is set and golden. Let it cool before serving.",
                    Ingredients = "1 1/2 cups sugar, 2 tbsp cornmeal, 1 tbsp flour, 1/4 tsp salt, 1/2 cup melted butter, 3/4 cup lemon juice, 4 eggs, pie crust"
                },

                new PieRecipe
                {
                    Id = 27,
                    Name = "Vanilla Custard Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a saucepan, heat 2 cups milk until just simmering. 3. In a bowl, whisk together 3 eggs, 3/4 cup sugar, 1 tbsp cornstarch, and 1 tbsp vanilla extract. 4. Slowly pour the hot milk into the egg mixture, whisking constantly. 5. Pour the mixture into the pie crust. 6. Bake for 40-45 minutes or until the filling is set. Let it cool before serving.",
                    Ingredients = "2 cups milk, 3 eggs, 3/4 cup sugar, 1 tbsp cornstarch, 1 tbsp vanilla extract, pie crust"
                },

                new PieRecipe
                {
                    Id = 28,
                    Name = "Pumpkin Cream Pie",
                    Steps = "1. Bake a graham cracker crust according to package instructions; let it cool. 2. In a bowl, whisk together 1 cup pumpkin puree, 1/2 cup sugar, 1/2 tsp cinnamon, 1/4 tsp nutmeg, 1/4 tsp ginger, and 1 cup whipped cream. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with additional whipped cream.",
                    Ingredients = "1 cup pumpkin puree, 1/2 cup sugar, 1/2 tsp cinnamon, 1/4 tsp nutmeg, 1/4 tsp ginger, 1 cup whipped cream, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 29,
                    Name = "Cranberry Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups fresh cranberries, 1 1/2 cups sugar, 1/4 cup flour, 1/4 tsp salt, and 1/2 tsp cinnamon. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-55 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "4 cups fresh cranberries, 1 1/2 cups sugar, 1/4 cup flour, 1/4 tsp salt, 1/2 tsp cinnamon, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 30,
                    Name = "Hazelnut Chocolate Pie",
                    Steps = "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. In a saucepan, melt 1 cup chocolate chips with 1/2 cup hazelnut spread over low heat, stirring until smooth. 3. Pour the mixture into the cooled pie crust. 4. Chill in the refrigerator for at least 4 hours or until set. Top with whipped cream and chopped hazelnuts before serving.",
                    Ingredients = "1 cup chocolate chips, 1/2 cup hazelnut spread, pie crust, whipped cream, chopped hazelnuts"
                },

                new PieRecipe
                {
                    Id = 31,
                    Name = "Apricot Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups sliced apricots, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "4 cups sliced apricots, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 32,
                    Name = "Caramel Apple Pie",
                    Steps = "1. Preheat oven to 425°F (220°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 6 cups sliced apples, 1/2 cup caramel sauce, 1/4 cup sugar, 1/4 cup flour, and 1/2 tsp cinnamon. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 45-50 minutes until golden brown and bubbly. Let it cool before serving.",
                    Ingredients = "6 cups sliced apples, 1/2 cup caramel sauce, 1/4 cup sugar, 1/4 cup flour, 1/2 tsp cinnamon, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 33,
                    Name = "Peanut Butter Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 cup creamy peanut butter, 8 oz cream cheese, 1 cup powdered sugar, and 1 cup whipped cream until smooth. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with whipped cream and chocolate drizzle.",
                    Ingredients = "1 cup creamy peanut butter, 8 oz cream cheese, 1 cup powdered sugar, 1 cup whipped cream, graham cracker crust, whipped cream, chocolate drizzle"
                },

                new PieRecipe
                {
                    Id = 34,
                    Name = "Black Bottom Pie",
                    Steps = "1. Prepare a pie crust and bake according to package instructions; let it cool. 2. In a saucepan, melt 4 oz semisweet chocolate with 1 tbsp butter over low heat, stirring until smooth. 3. Pour the chocolate mixture into the cooled pie crust and chill until set. 4. In a bowl, whisk together 1/2 cup sugar, 3 tbsp cornstarch, and a pinch of salt. Gradually whisk in 2 cups milk and 3 egg yolks. 5. Cook over medium heat, stirring constantly until thickened. 6. Remove from heat and stir in 1 tsp vanilla extract. 7. Pour the custard over the chocolate layer. Chill for at least 4 hours before serving. Top with whipped cream.",
                    Ingredients = "4 oz semisweet chocolate, 1 tbsp butter, 1/2 cup sugar, 3 tbsp cornstarch, pinch of salt, 2 cups milk, 3 egg yolks, 1 tsp vanilla extract, pie crust, whipped cream"
                },

                new PieRecipe
                {
                    Id = 35,
                    Name = "Chiffon Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, dissolve 1 envelope unflavored gelatin in 1/4 cup cold water. 3. In a saucepan, whisk together 1/2 cup sugar, 3 egg yolks, and 1/2 cup fruit juice (lemon, orange, or lime). 4. Cook over low heat, stirring constantly until thickened. 5. Remove from heat and stir in the dissolved gelatin until fully incorporated. 6. Fold in 1 cup whipped cream. 7. Pour the mixture into the cooled crust. Chill for at least 4 hours before serving. Top with additional whipped cream.",
                    Ingredients = "1 envelope unflavored gelatin, 1/4 cup cold water, 1/2 cup sugar, 3 egg yolks, 1/2 cup fruit juice (lemon, orange, or lime), 1 cup whipped cream, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 36,
                    Name = "Rum Raisin Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 1 cup raisins with 1/4 cup rum and let it sit for 30 minutes. 3. In another bowl, whisk together 3 eggs, 1 cup sugar, 1/2 cup melted butter, 1/4 cup flour, and 1 tsp vanilla extract. 4. Stir in the rum-soaked raisins. 5. Pour the mixture into the pie crust. 6. Bake for 40-45 minutes or until the filling is set. Let it cool before serving.",
                    Ingredients = "1 cup raisins, 1/4 cup rum, 3 eggs, 1 cup sugar, 1/2 cup melted butter, 1/4 cup flour, 1 tsp vanilla extract, pie crust"
                },

                new PieRecipe
                {
                    Id = 37,
                    Name = "Cherry Almond Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups pitted cherries, 3/4 cup sugar, 1/4 cup cornstarch, 1/2 tsp almond extract, and a pinch of salt. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "4 cups pitted cherries, 3/4 cup sugar, 1/4 cup cornstarch, 1/2 tsp almond extract, pinch of salt, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 38,
                    Name = "Macadamia Nut Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup light corn syrup, 1 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 1/2 cups chopped macadamia nuts. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing.",
                    Ingredients = "3 eggs, 1 cup light corn syrup, 1 cup sugar, 2 tbsp melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 1/2 cups chopped macadamia nuts, pie crust"
                },

                new PieRecipe
                {
                    Id = 39,
                    Name = "Buttermilk Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 1/2 cups sugar, 1/4 cup melted butter, 3 tbsp flour, 1 cup buttermilk, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Pour the mixture into the pie crust. 4. Bake for 40-45 minutes or until the filling is set. Let it cool before serving.",
                    Ingredients = "3 eggs, 1 1/2 cups sugar, 1/4 cup melted butter, 3 tbsp flour, 1 cup buttermilk, 1 tsp vanilla extract, 1/4 tsp salt, pie crust"
                },

                new PieRecipe
                {
                    Id = 40,
                    Name = "Blackberry Custard Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups blackberries, 3/4 cup sugar, and 1 tbsp lemon juice. 3. In another bowl, whisk together 3/4 cup sugar, 1/4 cup flour, 1/4 tsp salt, and 2 eggs. 4. Pour the blackberry mixture into the pie crust. 5. Pour the custard mixture over the blackberries. 6. Bake for 50-55 minutes or until the filling is set. Let it cool before serving.",
                    Ingredients = "4 cups blackberries, 3/4 cup sugar, 1 tbsp lemon juice, 3/4 cup sugar, 1/4 cup flour, 1/4 tsp salt, 2 eggs, pie crust"
                }, new PieRecipe
                {
                    Id = 41,
                    Name = "Chocolate Peanut Butter Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, beat 8 oz cream cheese, 1 cup powdered sugar, 1/2 cup creamy peanut butter, and 1/4 cup milk until smooth. 3. Fold in 1 cup whipped cream. 4. Pour the mixture into the cooled crust. 5. Melt 1/2 cup chocolate chips and drizzle over the pie. 6. Chill in the refrigerator for at least 4 hours before serving.",
                    Ingredients = "8 oz cream cheese, 1 cup powdered sugar, 1/2 cup creamy peanut butter, 1/4 cup milk, 1 cup whipped cream, 1/2 cup chocolate chips, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 42,
                    Name = "Lemon Icebox Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, whisk together 1 can (14 oz) sweetened condensed milk, 1/2 cup lemon juice, 1 tbsp lemon zest, and 2 egg yolks. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with whipped cream.",
                    Ingredients = "1 can (14 oz) sweetened condensed milk, 1/2 cup lemon juice, 1 tbsp lemon zest, 2 egg yolks, graham cracker crust, whipped cream"
                },

                new PieRecipe
                {
                    Id = 43,
                    Name = "Tropical Coconut Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 1 1/2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, 1/2 cup milk, and 1 tsp vanilla extract. 3. Pour the mixture into the pie crust. 4. Bake for 45-50 minutes or until the filling is set and golden. Let it cool before serving.",
                    Ingredients = "1 1/2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, 1/2 cup milk, 1 tsp vanilla extract, pie crust"
                },

                new PieRecipe
                {
                    Id = 44,
                    Name = "Apple Cranberry Pie",
                    Steps = "1. Preheat oven to 425°F (220°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 4 cups sliced apples, 2 cups fresh cranberries, 1 cup sugar, 1/4 cup flour, 1 tsp cinnamon, and 1/4 tsp nutmeg. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with top crust, seal, and cut slits for steam. 5. Bake for 45-50 minutes until golden brown and bubbly. Let it cool before serving.",
                    Ingredients = "4 cups sliced apples, 2 cups fresh cranberries, 1 cup sugar, 1/4 cup flour, 1 tsp cinnamon, 1/4 tsp nutmeg, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 45,
                    Name = "S'mores Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. Melt 1 cup chocolate chips with 1/2 cup heavy cream over low heat, stirring until smooth. 3. Pour the chocolate mixture into the cooled crust. 4. Top with 2 cups mini marshmallows. 5. Broil for 1-2 minutes until the marshmallows are toasted. Chill before serving.",
                    Ingredients = "1 cup chocolate chips, 1/2 cup heavy cream, 2 cups mini marshmallows, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 46,
                    Name = "Almond Joy Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 1/2 cups shredded coconut, 1/2 cup sugar, 2 eggs, 1/4 cup melted butter, and 1 tsp almond extract. 3. Pour the mixture into the cooled crust. 4. Top with 1/2 cup chocolate chips and 1/2 cup chopped almonds. 5. Bake at 350°F (175°C) for 30-35 minutes until set. Let it cool before serving.",
                    Ingredients = "1 1/2 cups shredded coconut, 1/2 cup sugar, 2 eggs, 1/4 cup melted butter, 1 tsp almond extract, 1/2 cup chocolate chips, 1/2 cup chopped almonds, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 47,
                    Name = "Coconut Macaroon Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, mix 2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, and 1 tsp vanilla extract. 3. Pour the mixture into the pie crust. 4. Bake for 40-45 minutes or until the filling is set and golden. Let it cool before serving.",
                    Ingredients = "2 cups shredded coconut, 1/2 cup sugar, 1/4 cup melted butter, 2 eggs, 1 tsp vanilla extract, pie crust"
                },

                new PieRecipe
                {
                    Id = 48,
                    Name = "Key Lime Coconut Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a graham cracker crust. 2. In a bowl, mix 1 can (14 oz) sweetened condensed milk, 1/2 cup key lime juice, 1/2 cup shredded coconut, and 2 egg yolks. 3. Pour the mixture into the crust. 4. Bake for 15-20 minutes until the filling is set. Let it cool, then chill in the refrigerator for at least 2 hours before serving. Top with whipped cream and toasted coconut.",
                    Ingredients = "1 can (14 oz) sweetened condensed milk, 1/2 cup key lime juice, 1/2 cup shredded coconut, 2 egg yolks, graham cracker crust, whipped cream, toasted coconut"
                },

                new PieRecipe
                {
                    Id = 49,
                    Name = "Cinnamon Roll Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Roll out pie crust into a 9-inch pie dish. 2. In a bowl, mix 1/4 cup softened butter, 1/2 cup brown sugar, 2 tsp cinnamon, and 1/4 cup chopped pecans. 3. Spread the mixture over the pie crust. 4. Roll up the crust and cut into 1-inch slices. Arrange the slices in the pie dish. 5. Bake for 25-30 minutes until golden brown. Let it cool slightly before serving.",
                    Ingredients = "1 pie crust, 1/4 cup softened butter, 1/2 cup brown sugar, 2 tsp cinnamon, 1/4 cup chopped pecans"
                },

                new PieRecipe
                {
                    Id = 50,
                    Name = "Blueberry Cream Pie",
                    Steps = "1. Bake a graham cracker crust according to package instructions; let it cool. 2. In a saucepan, cook 2 cups blueberries with 1/2 cup sugar and 1 tbsp lemon juice over medium heat until thickened. 3. Pour the mixture into the crust. 4. In a bowl, mix 1 cup whipped cream with 1/2 cup cream cheese. Spread over the blueberry mixture. 5. Chill in the refrigerator for at least 4 hours before serving.",
                    Ingredients = "2 cups blueberries, 1/2 cup sugar, 1 tbsp lemon juice, 1 cup whipped cream, 1/2 cup cream cheese, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 51,
                    Name = "Strawberry Pretzel Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a pretzel crust. 2. In a bowl, mix 2 cups sliced strawberries, 1/2 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust. 4. Bake for 30-35 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "2 cups sliced strawberries, 1/2 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, pretzel crust"
                },

                new PieRecipe
                {
                    Id = 52,
                    Name = "Maple Walnut Pie",
                    Steps = "1. Preheat oven to 350°F (175°C). Prepare a pie dish with a single crust. 2. In a bowl, whisk together 3 eggs, 1 cup maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, and 1/4 tsp salt. 3. Stir in 1 1/2 cups chopped walnuts. 4. Pour the mixture into the pie crust. 5. Bake for 50-55 minutes or until the filling is set. Cool completely before slicing.",
                    Ingredients = "3 eggs, 1 cup maple syrup, 1/2 cup brown sugar, 1/4 cup melted butter, 1 tsp vanilla extract, 1/4 tsp salt, 1 1/2 cups chopped walnuts, pie crust"
                },

                new PieRecipe
                {
                    Id = 53,
                    Name = "Banana Split Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1/2 cup sliced bananas, 1/2 cup chopped strawberries, 1/2 cup crushed pineapple, and 1 cup whipped cream. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with chocolate sauce and chopped nuts.",
                    Ingredients = "1/2 cup sliced bananas, 1/2 cup chopped strawberries, 1/2 cup crushed pineapple, 1 cup whipped cream, graham cracker crust, chocolate sauce, chopped nuts"
                },

                new PieRecipe
                {
                    Id = 54,
                    Name = "Butterscotch Pudding Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a saucepan, melt 1/4 cup butter over medium heat. Stir in 1/2 cup brown sugar and cook for 2 minutes. 3. Gradually stir in 1/4 cup cornstarch and 2 cups milk, whisking constantly until thickened. 4. Remove from heat and stir in 1 tsp vanilla extract. 5. Pour the mixture into the cooled crust. Chill for at least 4 hours before serving. Top with whipped cream.",
                    Ingredients = "1/4 cup butter, 1/2 cup brown sugar, 1/4 cup cornstarch, 2 cups milk, 1 tsp vanilla extract, graham cracker crust, whipped cream"
                },

                new PieRecipe
                {
                    Id = 55,
                    Name = "Mocha Cream Pie",
                    Steps = "1. Prepare a chocolate cookie crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 cup whipped cream, 1/2 cup coffee-flavored liqueur, and 1/2 cup chocolate pudding mix. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with chocolate shavings.",
                    Ingredients = "1 cup whipped cream, 1/2 cup coffee-flavored liqueur, 1/2 cup chocolate pudding mix, chocolate cookie crust, chocolate shavings"
                },

                new PieRecipe
                {
                    Id = 56,
                    Name = "Peach Melba Pie",
                    Steps = "1. Preheat oven to 375°F (190°C). Prepare a pie dish with a bottom crust. 2. In a bowl, mix 3 cups sliced peaches, 1 cup raspberries, 3/4 cup sugar, 1/4 cup cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust and dot with 2 tbsp butter. 4. Cover with a lattice top crust, seal, and crimp edges. 5. Bake for 50-60 minutes until the filling is bubbly and the crust is golden. Let it cool before serving.",
                    Ingredients = "3 cups sliced peaches, 1 cup raspberries, 3/4 cup sugar, 1/4 cup cornstarch, 1 tbsp lemon juice, 2 tbsp butter, pie crust"
                },

                new PieRecipe
                {
                    Id = 57,
                    Name = "Raspberry Cream Pie",
                    Steps = "1. Bake a graham cracker crust according to package instructions; let it cool. 2. In a bowl, mix 2 cups fresh raspberries, 1/2 cup sugar, 1 tbsp cornstarch, and 1 tbsp lemon juice. 3. Pour the mixture into the pie crust. 4. In another bowl, mix 1 cup whipped cream with 1/2 cup cream cheese. Spread over the raspberry mixture. 5. Chill in the refrigerator for at least 4 hours before serving.",
                    Ingredients = "2 cups fresh raspberries, 1/2 cup sugar, 1 tbsp cornstarch, 1 tbsp lemon juice, 1 cup whipped cream, 1/2 cup cream cheese, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 58,
                    Name = "Turtle Pie",
                    Steps = "1. Prepare a chocolate cookie crust and bake according to package instructions; let it cool. 2. In a bowl, mix 1 cup caramel sauce, 1 cup chopped pecans, and 1 cup whipped cream. 3. Pour the mixture into the cooled crust. 4. Top with chocolate ganache and chill in the refrigerator for at least 4 hours before serving.",
                    Ingredients = "1 cup caramel sauce, 1 cup chopped pecans, 1 cup whipped cream, chocolate cookie crust, chocolate ganache"
                },

                new PieRecipe
                {
                    Id = 59,
                    Name = "White Chocolate Raspberry Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. Melt 6 oz white chocolate and let it cool slightly. 3. In a bowl, mix 1 cup whipped cream with the cooled white chocolate. 4. Pour the mixture into the crust. 5. Top with 1/2 cup fresh raspberries. Chill in the refrigerator for at least 4 hours before serving.",
                    Ingredients = "6 oz white chocolate, 1 cup whipped cream, 1/2 cup fresh raspberries, graham cracker crust"
                },

                new PieRecipe
                {
                    Id = 60,
                    Name = "Orange Cream Pie",
                    Steps = "1. Prepare a graham cracker crust and bake according to package instructions; let it cool. 2. In a bowl, whisk together 1 can (14 oz) sweetened condensed milk, 1/2 cup orange juice concentrate, and 2 egg yolks. 3. Pour the mixture into the cooled crust. 4. Chill in the refrigerator for at least 4 hours before serving. Top with whipped cream.",
                    Ingredients = "1 can (14 oz) sweetened condensed milk, 1/2 cup orange juice concentrate, 2 egg yolks, graham cracker crust, whipped cream"
                }


                );

            modelBuilder.Entity<Order>().HasData(
        new Order
        {
            OrderId = 1,

            CustomerId = 342,
            OrderPlaced = new DateTime(2025, 5, 15)
        },
        new Order
        {
            OrderId = 2,
            CustomerId = 721,
            OrderPlaced = new DateTime(2025, 6, 15)
        },
        new Order
        {
            OrderId = 3,
            CustomerId = 104,
            OrderPlaced = new DateTime(2025, 12, 27)
        },
        new Order
        {
            OrderId = 4,
            CustomerId = 587,
            OrderPlaced = new DateTime(2025, 11, 11)
        },
        new Order
        {
            OrderId = 5,
            CustomerId = 913,
            OrderPlaced = new DateTime(2024, 8, 8)
        },
        new Order
        {
            OrderId = 6,
            CustomerId = 482,
            OrderPlaced = new DateTime(2024, 5, 15)
        },
        new Order
        {
            OrderId = 7,
            CustomerId = 951,
            OrderPlaced = new DateTime(2025, 3, 22)
        },
        new Order
        {
            OrderId = 8,
            CustomerId = 215,
            OrderPlaced = new DateTime(2024, 8, 30)
        },
        new Order
        {
            OrderId = 9,
            CustomerId = 692,
            OrderPlaced = new DateTime(2025, 6, 18)
        },
        new Order
        {
            OrderId = 10,
            CustomerId = 812,
            OrderPlaced = new DateTime(2024, 11, 10)
        },
        new Order
        {
            OrderId = 11,
            CustomerId = 523,
            OrderPlaced = new DateTime(2024, 2, 12)
        },
        new Order
        {
            OrderId = 12,
            CustomerId = 341,
            OrderPlaced = new DateTime(2025, 4, 25)
        },
        new Order
        {
            OrderId = 13,
            CustomerId = 782,
            OrderPlaced = new DateTime(2024, 7, 19)
        },
        new Order
        {
            OrderId = 14,
            CustomerId = 699,
            OrderPlaced = new DateTime(2025, 1, 3)
        },
        new Order
        {
            OrderId = 15,
            CustomerId = 208,
            OrderPlaced = new DateTime(2025, 8, 14)
        },
        new Order
        {
            OrderId = 16,
            CustomerId = 945,
            OrderPlaced = new DateTime(2024, 9, 23)
        },
        new Order
        {
            OrderId = 17,
            CustomerId = 134,
            OrderPlaced = new DateTime(2025, 5, 27)
        },
        new Order
        {
            OrderId = 18,
            CustomerId = 673,
            OrderPlaced = new DateTime(2024, 11, 7)
        },
        new Order
        {
            OrderId = 19,
            CustomerId = 287,
            OrderPlaced = new DateTime(2025, 6, 2)
        },
        new Order
        {
            OrderId = 20,
            CustomerId = 495,
            OrderPlaced = new DateTime(2024, 3, 15)
        },
        new Order
        {
            OrderId = 21,
            CustomerId = 219,
            OrderPlaced = new DateTime(2025, 9, 9)
        },
        new Order
        {
            OrderId = 22,
            CustomerId = 327,
            OrderPlaced = new DateTime(2024, 12, 30)
        },
        new Order
        {
            OrderId = 23,
            CustomerId = 721,
            OrderPlaced = new DateTime(2025, 2, 18)
        },
        new Order
        {
            OrderId = 24,
            CustomerId = 589,
            OrderPlaced = new DateTime(2024, 4, 21)
        },
        new Order
        {
            OrderId = 25,
            CustomerId = 814,
            OrderPlaced = new DateTime(2025, 7, 4)
        },
        new Order
        {
            OrderId = 26,
            CustomerId = 312,
            OrderPlaced = new DateTime(2024, 10, 8)
        },
        new Order
        {
            OrderId = 27,
            CustomerId = 637,
            OrderPlaced = new DateTime(2025, 10, 27)
        },
        new Order
        {
            OrderId = 28,
            CustomerId = 476,
            OrderPlaced = new DateTime(2024, 5, 2)
        },
        new Order
        {
            OrderId = 29,
            CustomerId = 589,
            OrderPlaced = new DateTime(2025, 11, 6)
        },
        new Order
        {
            OrderId = 30,
            CustomerId = 971,
            OrderPlaced = new DateTime(2024, 8, 15)
        },
        new Order
        {
            OrderId = 31,
            CustomerId = 742,
            OrderPlaced = new DateTime(2025, 1, 29)
        },
        new Order
        {
            OrderId = 32,
            CustomerId = 145,
            OrderPlaced = new DateTime(2024, 6, 10)
        },
        new Order
        {
            OrderId = 33,
            CustomerId = 634,
            OrderPlaced = new DateTime(2025, 7, 15)
        },
        new Order
        {
            OrderId = 34,
            CustomerId = 958,
            OrderPlaced = new DateTime(2024, 11, 22)
        },
        new Order
        {
            OrderId = 35,
            CustomerId = 281,
            OrderPlaced = new DateTime(2025, 4, 9)
        },
        new Order
        {
            OrderId = 36,
            CustomerId = 374,
            OrderPlaced = new DateTime(2024, 2, 25)
        },
        new Order
        {
            OrderId = 37,
            CustomerId = 543,
            OrderPlaced = new DateTime(2025, 3, 5)
        },
        new Order
        {
            OrderId = 38,
            CustomerId = 189,
            OrderPlaced = new DateTime(2024, 9, 12)
        },
        new Order
        {
            OrderId = 39,
            CustomerId = 624,
            OrderPlaced = new DateTime(2025, 10, 11)
        },
        new Order
        {
            OrderId = 40,
            CustomerId = 731,
            OrderPlaced = new DateTime(2024, 6, 6)
        },
        new Order
        {
            OrderId = 41,
            CustomerId = 441,
            OrderPlaced = new DateTime(2025, 5, 22)
        },
        new Order
        {
            OrderId = 42,
            CustomerId = 368,
            OrderPlaced = new DateTime(2024, 8, 27)
        },
        new Order
        {
            OrderId = 43,
            CustomerId = 984,
            OrderPlaced = new DateTime(2025, 2, 28)
        },
        new Order
        {
            OrderId = 44,
            CustomerId = 591,
            OrderPlaced = new DateTime(2024, 10, 14)
        },
        new Order
        {
            OrderId = 45,
            CustomerId = 347,
            OrderPlaced = new DateTime(2025, 12, 20)
        },
        new Order
        {
            OrderId = 46,
            CustomerId = 862,
            OrderPlaced = new DateTime(2024, 1, 8)
        },
        new Order
        {
            OrderId = 47,
            CustomerId = 539,
            OrderPlaced = new DateTime(2025, 8, 3)
        },
        new Order
        {
            OrderId = 48,
            CustomerId = 281,
            OrderPlaced = new DateTime(2024, 3, 9)
        },
        new Order
        {
            OrderId = 49,
            CustomerId = 104,
            OrderPlaced = new DateTime(2025, 6, 19)
        },
        new Order
        {
            OrderId = 50,
            CustomerId = 413,
            OrderPlaced = new DateTime(2024, 12, 3)
        },
        new Order
        {
            OrderId = 51,
            CustomerId = 632,
            OrderPlaced = new DateTime(2025, 5, 10)
        },
        new Order
        {
            OrderId = 52,
            CustomerId = 891,
            OrderPlaced = new DateTime(2024, 4, 13)
        },
        new Order
        {
            OrderId = 53,
            CustomerId = 356,
            OrderPlaced = new DateTime(2025, 11, 14)
        },
        new Order
        {
            OrderId = 54,
            CustomerId = 531,
            OrderPlaced = new DateTime(2024, 1, 4)
        },
        new Order
        {
            OrderId = 55,
            CustomerId = 289,
            OrderPlaced = new DateTime(2025, 9, 23)
        },
        new Order
        {
            OrderId = 56,
            CustomerId = 613,
            OrderPlaced = new DateTime(2024, 6, 14)
        },
        new Order
        {
            OrderId = 57,
            CustomerId = 746,
            OrderPlaced = new DateTime(2025, 12, 1)
        },
        new Order
        {
            OrderId = 58,
            CustomerId = 294,
            OrderPlaced = new DateTime(2024, 8, 1)
        },
        new Order
        {
            OrderId = 59,
            CustomerId = 729,
            OrderPlaced = new DateTime(2025, 7, 31)
        },
        new Order
        {
            OrderId = 60,
            CustomerId = 882,
            OrderPlaced = new DateTime(2024, 11, 19)
        },
        new Order
        {
            OrderId = 61,
            CustomerId = 549,
            OrderPlaced = new DateTime(2025, 3, 18)
        },
        new Order
        {
            OrderId = 62,
            CustomerId = 412,
            OrderPlaced = new DateTime(2024, 5, 5)
        },
        new Order
        {
            OrderId = 63,
            CustomerId = 101,
            OrderPlaced = new DateTime(2025, 9, 25)
        },
        new Order
        {
            OrderId = 64,
            CustomerId = 908,
            OrderPlaced = new DateTime(2024, 3, 21)
        },
        new Order
        {
            OrderId = 65,
            CustomerId = 305,
            OrderPlaced = new DateTime(2025, 10, 2)
        },
        new Order
        {
            OrderId = 66,
            CustomerId = 479,
            OrderPlaced = new DateTime(2024, 7, 16)
        },
        new Order
        {
            OrderId = 67,
            CustomerId = 226,
            OrderPlaced = new DateTime(2025, 1, 1)
        },
        new Order
        {
            OrderId = 68,
            CustomerId = 347,
            OrderPlaced = new DateTime(2024, 10, 24)
        },
        new Order
        {
            OrderId = 69,
            CustomerId = 688,
            OrderPlaced = new DateTime(2025, 4, 14)
        },
        new Order
        {
            OrderId = 70,
            CustomerId = 351,
            OrderPlaced = new DateTime(2024, 11, 12)
        },
        new Order
        {
            OrderId = 71,
            CustomerId = 978,
            OrderPlaced = new DateTime(2025, 5, 15)
        },
        new Order
        {
            OrderId = 72,
            CustomerId = 715,
            OrderPlaced = new DateTime(2024, 2, 7)
        },
        new Order
        {
            OrderId = 73,
            CustomerId = 813,
            OrderPlaced = new DateTime(2025, 8, 9)
        },
        new Order
        {
            OrderId = 74,
            CustomerId = 147,
            OrderPlaced = new DateTime(2024, 9, 5)
        },
        new Order
        {
            OrderId = 75,
            CustomerId = 624,
            OrderPlaced = new DateTime(2025, 7, 28)
        },
        new Order
        {
            OrderId = 76,
            CustomerId = 912,
            OrderPlaced = new DateTime(2024, 12, 26)
        },
        new Order
        {
            OrderId = 77,
            CustomerId = 739,
            OrderPlaced = new DateTime(2025, 6, 22)
        },
        new Order
        {
            OrderId = 78,
            CustomerId = 332,
            OrderPlaced = new DateTime(2024, 3, 17)
        },
        new Order
        {
            OrderId = 79,
            CustomerId = 831,
            OrderPlaced = new DateTime(2025, 11, 4)
        },
        new Order
        {
            OrderId = 80,
            CustomerId = 521,
            OrderPlaced = new DateTime(2024, 5, 30)
        },
        new Order
        {
            OrderId = 81,
            CustomerId = 488,
            OrderPlaced = new DateTime(2025, 1, 21)
        },
        new Order
        {
            OrderId = 82,
            CustomerId = 607,
            OrderPlaced = new DateTime(2024, 10, 17)
        },
        new Order
        {
            OrderId = 83,
            CustomerId = 879,
            OrderPlaced = new DateTime(2025, 8, 19)
        },
        new Order
        {
            OrderId = 84,
            CustomerId = 734,
            OrderPlaced = new DateTime(2024, 6, 20)
        },
        new Order
        {
            OrderId = 85,
            CustomerId = 188,
            OrderPlaced = new DateTime(2025, 12, 25)
        },
        new Order
        {
            OrderId = 86,
            CustomerId = 297,
            OrderPlaced = new DateTime(2024, 2, 4)
        },
        new Order
        {
            OrderId = 87,
            CustomerId = 698,
            OrderPlaced = new DateTime(2025, 7, 1)
        },
        new Order
        {
            OrderId = 88,
            CustomerId = 846,
            OrderPlaced = new DateTime(2024, 11, 29)
        },
        new Order
        {
            OrderId = 89,
            CustomerId = 193,
            OrderPlaced = new DateTime(2025, 10, 13)
        },
        new Order
        {
            OrderId = 90,
            CustomerId = 657,
            OrderPlaced = new DateTime(2024, 1, 30)
        },
        new Order
        {
            OrderId = 91,
            CustomerId = 321,
            OrderPlaced = new DateTime(2025, 3, 2)
        },
        new Order
        {
            OrderId = 92,
            CustomerId = 829,
            OrderPlaced = new DateTime(2024, 9, 27)
        },
        new Order
        {
            OrderId = 93,
            CustomerId = 551,
            OrderPlaced = new DateTime(2025, 6, 27)
        },
        new Order
        {
            OrderId = 94,
            CustomerId = 399,
            OrderPlaced = new DateTime(2024, 8, 8)
        },
        new Order
        {
            OrderId = 95,
            CustomerId = 664,
            OrderPlaced = new DateTime(2025, 12, 8)
        },
        new Order
        {
            OrderId = 96,
            CustomerId = 257,
            OrderPlaced = new DateTime(2024, 7, 11)
        },
        new Order
        {
            OrderId = 97,
            CustomerId = 498,
            OrderPlaced = new DateTime(2025, 4, 20)
        },
        new Order
        {
            OrderId = 98,
            CustomerId = 144,
            OrderPlaced = new DateTime(2024, 5, 23)
        },
        new Order
        {
            OrderId = 99,
            CustomerId = 796,
            OrderPlaced = new DateTime(2025, 11, 17)
        },
        new Order
        {
            OrderId = 100,
            CustomerId = 216,
            OrderPlaced = new DateTime(2024, 4, 1)
        });

            modelBuilder.Entity<OrderDetail>().HasData(

                    new OrderDetail { OrderDetailId = 1, PieId = 2, Amount = 1, OrderId = 1 },
                    new OrderDetail { OrderDetailId = 2, PieId = 5, Amount = 2, OrderId = 1 },
                    new OrderDetail { OrderDetailId = 3, PieId = 8, Amount = 1, OrderId = 1 },
                    new OrderDetail { OrderDetailId = 4, PieId = 3, Amount = 3, OrderId = 2 },
                    new OrderDetail { OrderDetailId = 5, PieId = 7, Amount = 1, OrderId = 2 },
                    new OrderDetail { OrderDetailId = 6, PieId = 12, Amount = 2, OrderId = 2 },
                    new OrderDetail { OrderDetailId = 7, PieId = 14, Amount = 1, OrderId = 2 },

                    new OrderDetail { OrderDetailId = 8, PieId = 1, Amount = 2, OrderId = 3 },
                    new OrderDetail { OrderDetailId = 9, PieId = 4, Amount = 1, OrderId = 3 },
                    new OrderDetail { OrderDetailId = 10, PieId = 11, Amount = 1, OrderId = 3 },
                    new OrderDetail { OrderDetailId = 11, PieId = 15, Amount = 2, OrderId = 3 },

                    new OrderDetail { OrderDetailId = 12, PieId = 6, Amount = 1, OrderId = 4 },
                    new OrderDetail { OrderDetailId = 13, PieId = 9, Amount = 2, OrderId = 4 },

                    new OrderDetail { OrderDetailId = 14, PieId = 10, Amount = 1, OrderId = 5 },
                    new OrderDetail { OrderDetailId = 15, PieId = 13, Amount = 3, OrderId = 5 },
                    new OrderDetail { OrderDetailId = 16, PieId = 2, Amount = 2, OrderId = 5 },

                    new OrderDetail { OrderDetailId = 17, PieId = 3, Amount = 2, OrderId = 6 },
                    new OrderDetail { OrderDetailId = 18, PieId = 1, Amount = 1, OrderId = 6 },

                    new OrderDetail { OrderDetailId = 19, PieId = 5, Amount = 2, OrderId = 7 },
                    new OrderDetail { OrderDetailId = 20, PieId = 6, Amount = 1, OrderId = 7 },
                    new OrderDetail { OrderDetailId = 21, PieId = 8, Amount = 1, OrderId = 7 },
                    new OrderDetail { OrderDetailId = 22, PieId = 12, Amount = 1, OrderId = 7 },

                    new OrderDetail { OrderDetailId = 23, PieId = 7, Amount = 4, OrderId = 8 },
                    new OrderDetail { OrderDetailId = 24, PieId = 14, Amount = 1, OrderId = 8 },

                    new OrderDetail { OrderDetailId = 25, PieId = 11, Amount = 1, OrderId = 9 },
                    new OrderDetail { OrderDetailId = 26, PieId = 10, Amount = 3, OrderId = 9 },
                    new OrderDetail { OrderDetailId = 27, PieId = 4, Amount = 2, OrderId = 9 },

                    new OrderDetail { OrderDetailId = 28, PieId = 9, Amount = 1, OrderId = 10 },
                    new OrderDetail { OrderDetailId = 29, PieId = 13, Amount = 2, OrderId = 10 },
                    new OrderDetail { OrderDetailId = 30, PieId = 2, Amount = 1, OrderId = 10 },
                    new OrderDetail { OrderDetailId = 31, PieId = 15, Amount = 1, OrderId = 10 },
                    new OrderDetail { OrderDetailId = 32, PieId = 3, Amount = 1, OrderId = 10 },

                    new OrderDetail { OrderDetailId = 33, PieId = 5, Amount = 2, OrderId = 11 },
                    new OrderDetail { OrderDetailId = 34, PieId = 7, Amount = 1, OrderId = 11 },

                    new OrderDetail { OrderDetailId = 35, PieId = 1, Amount = 1, OrderId = 12 },
                    new OrderDetail { OrderDetailId = 36, PieId = 3, Amount = 2, OrderId = 12 },
                    new OrderDetail { OrderDetailId = 37, PieId = 6, Amount = 1, OrderId = 12 },

                    new OrderDetail { OrderDetailId = 38, PieId = 8, Amount = 1, OrderId = 13 },
                    new OrderDetail { OrderDetailId = 39, PieId = 12, Amount = 3, OrderId = 13 },

                    new OrderDetail { OrderDetailId = 40, PieId = 2, Amount = 2, OrderId = 14 },
                    new OrderDetail { OrderDetailId = 41, PieId = 11, Amount = 1, OrderId = 14 },
                    new OrderDetail { OrderDetailId = 42, PieId = 14, Amount = 2, OrderId = 14 },
                    new OrderDetail { OrderDetailId = 43, PieId = 9, Amount = 1, OrderId = 14 },

                    new OrderDetail { OrderDetailId = 44, PieId = 10, Amount = 1, OrderId = 15 },
                    new OrderDetail { OrderDetailId = 45, PieId = 5, Amount = 2, OrderId = 15 },
                    new OrderDetail { OrderDetailId = 46, PieId = 15, Amount = 1, OrderId = 15 },
                    new OrderDetail { OrderDetailId = 47, PieId = 13, Amount = 3, OrderId = 15 },

                    new OrderDetail { OrderDetailId = 48, PieId = 4, Amount = 2, OrderId = 16 },

                    new OrderDetail { OrderDetailId = 49, PieId = 9, Amount = 1, OrderId = 17 },
                    new OrderDetail { OrderDetailId = 50, PieId = 7, Amount = 3, OrderId = 17 },

                    new OrderDetail { OrderDetailId = 51, PieId = 6, Amount = 1, OrderId = 18 },
                    new OrderDetail { OrderDetailId = 52, PieId = 8, Amount = 2, OrderId = 18 },
                    new OrderDetail { OrderDetailId = 53, PieId = 12, Amount = 1, OrderId = 18 },

                    new OrderDetail { OrderDetailId = 54, PieId = 14, Amount = 2, OrderId = 19 },
                    new OrderDetail { OrderDetailId = 55, PieId = 3, Amount = 1, OrderId = 19 },
                    new OrderDetail { OrderDetailId = 56, PieId = 1, Amount = 1, OrderId = 19 },
                    new OrderDetail { OrderDetailId = 57, PieId = 13, Amount = 2, OrderId = 19 },

                    new OrderDetail { OrderDetailId = 58, PieId = 11, Amount = 3, OrderId = 20 },

                    new OrderDetail { OrderDetailId = 59, PieId = 13, Amount = 1, OrderId = 21 },
                    new OrderDetail { OrderDetailId = 60, PieId = 2, Amount = 2, OrderId = 21 },

                    new OrderDetail { OrderDetailId = 61, PieId = 5, Amount = 1, OrderId = 22 },
                    new OrderDetail { OrderDetailId = 62, PieId = 6, Amount = 1, OrderId = 22 },
                    new OrderDetail { OrderDetailId = 63, PieId = 8, Amount = 3, OrderId = 22 },

                    new OrderDetail { OrderDetailId = 64, PieId = 10, Amount = 2, OrderId = 23 },
                    new OrderDetail { OrderDetailId = 65, PieId = 15, Amount = 1, OrderId = 23 },

                    new OrderDetail { OrderDetailId = 66, PieId = 3, Amount = 3, OrderId = 24 },
                    new OrderDetail { OrderDetailId = 67, PieId = 9, Amount = 1, OrderId = 24 },
                    new OrderDetail { OrderDetailId = 68, PieId = 12, Amount = 1, OrderId = 24 },

                    new OrderDetail { OrderDetailId = 69, PieId = 14, Amount = 2, OrderId = 25 },
                    new OrderDetail { OrderDetailId = 70, PieId = 11, Amount = 1, OrderId = 25 },
                    new OrderDetail { OrderDetailId = 71, PieId = 8, Amount = 2, OrderId = 25 },

                    new OrderDetail { OrderDetailId = 72, PieId = 2, Amount = 1, OrderId = 26 },
                    new OrderDetail { OrderDetailId = 73, PieId = 4, Amount = 3, OrderId = 26 },
                    new OrderDetail { OrderDetailId = 74, PieId = 13, Amount = 1, OrderId = 26 },

                    new OrderDetail { OrderDetailId = 75, PieId = 7, Amount = 2, OrderId = 27 },
                    new OrderDetail { OrderDetailId = 76, PieId = 14, Amount = 1, OrderId = 27 },
                    new OrderDetail { OrderDetailId = 77, PieId = 9, Amount = 2, OrderId = 27 },
                    new OrderDetail { OrderDetailId = 78, PieId = 5, Amount = 1, OrderId = 27 },

                    new OrderDetail { OrderDetailId = 79, PieId = 8, Amount = 2, OrderId = 28 },
                    new OrderDetail { OrderDetailId = 80, PieId = 15, Amount = 1, OrderId = 28 },

                    new OrderDetail { OrderDetailId = 81, PieId = 10, Amount = 1, OrderId = 29 },
                    new OrderDetail { OrderDetailId = 82, PieId = 13, Amount = 2, OrderId = 29 },
                    new OrderDetail { OrderDetailId = 83, PieId = 1, Amount = 3, OrderId = 29 },

                    new OrderDetail { OrderDetailId = 84, PieId = 6, Amount = 1, OrderId = 30 },
                    new OrderDetail { OrderDetailId = 85, PieId = 4, Amount = 2, OrderId = 30 },
                    new OrderDetail { OrderDetailId = 86, PieId = 12, Amount = 2, OrderId = 30 },
                    new OrderDetail { OrderDetailId = 87, PieId = 3, Amount = 1, OrderId = 30 },

                    new OrderDetail { OrderDetailId = 88, PieId = 11, Amount = 1, OrderId = 31 },
                    new OrderDetail { OrderDetailId = 89, PieId = 9, Amount = 2, OrderId = 31 },
                    new OrderDetail { OrderDetailId = 90, PieId = 7, Amount = 3, OrderId = 31 },

                    new OrderDetail { OrderDetailId = 91, PieId = 2, Amount = 1, OrderId = 32 },
                    new OrderDetail { OrderDetailId = 92, PieId = 5, Amount = 2, OrderId = 32 },

                    new OrderDetail { OrderDetailId = 93, PieId = 10, Amount = 3, OrderId = 33 },
                    new OrderDetail { OrderDetailId = 94, PieId = 15, Amount = 1, OrderId = 33 },
                    new OrderDetail { OrderDetailId = 95, PieId = 8, Amount = 2, OrderId = 33 },

                    new OrderDetail { OrderDetailId = 96, PieId = 3, Amount = 1, OrderId = 34 },
                    new OrderDetail { OrderDetailId = 97, PieId = 14, Amount = 2, OrderId = 34 },

                    new OrderDetail { OrderDetailId = 98, PieId = 5, Amount = 2, OrderId = 35 },
                    new OrderDetail { OrderDetailId = 99, PieId = 7, Amount = 1, OrderId = 35 },
                    new OrderDetail { OrderDetailId = 100, PieId = 6, Amount = 3, OrderId = 35 },
                    new OrderDetail { OrderDetailId = 101, PieId = 13, Amount = 1, OrderId = 35 },

                    new OrderDetail { OrderDetailId = 102, PieId = 2, Amount = 1, OrderId = 36 },
                    new OrderDetail { OrderDetailId = 103, PieId = 4, Amount = 2, OrderId = 36 },

                    new OrderDetail { OrderDetailId = 104, PieId = 11, Amount = 3, OrderId = 37 },
                    new OrderDetail { OrderDetailId = 105, PieId = 3, Amount = 1, OrderId = 37 },

                    new OrderDetail { OrderDetailId = 106, PieId = 9, Amount = 2, OrderId = 38 },
                    new OrderDetail { OrderDetailId = 107, PieId = 10, Amount = 1, OrderId = 38 },
                    new OrderDetail { OrderDetailId = 108, PieId = 8, Amount = 1, OrderId = 38 },

                    new OrderDetail { OrderDetailId = 109, PieId = 12, Amount = 2, OrderId = 39 },
                    new OrderDetail { OrderDetailId = 110, PieId = 5, Amount = 1, OrderId = 39 },

                    new OrderDetail { OrderDetailId = 111, PieId = 1, Amount = 1, OrderId = 40 },
                    new OrderDetail { OrderDetailId = 112, PieId = 2, Amount = 2, OrderId = 40 },
                    new OrderDetail { OrderDetailId = 113, PieId = 15, Amount = 1, OrderId = 40 },
                    new OrderDetail { OrderDetailId = 114, PieId = 13, Amount = 3, OrderId = 40 },

                    new OrderDetail { OrderDetailId = 115, PieId = 14, Amount = 1, OrderId = 41 },
                    new OrderDetail { OrderDetailId = 116, PieId = 7, Amount = 2, OrderId = 41 },

                    new OrderDetail { OrderDetailId = 117, PieId = 6, Amount = 3, OrderId = 42 },
                    new OrderDetail { OrderDetailId = 118, PieId = 12, Amount = 1, OrderId = 42 },
                    new OrderDetail { OrderDetailId = 119, PieId = 8, Amount = 2, OrderId = 42 },

                    new OrderDetail { OrderDetailId = 120, PieId = 9, Amount = 1, OrderId = 43 },
                    new OrderDetail { OrderDetailId = 121, PieId = 14, Amount = 2, OrderId = 43 },
                    new OrderDetail { OrderDetailId = 122, PieId = 3, Amount = 1, OrderId = 43 },

                    new OrderDetail { OrderDetailId = 123, PieId = 4, Amount = 1, OrderId = 44 },
                    new OrderDetail { OrderDetailId = 124, PieId = 11, Amount = 1, OrderId = 44 },
                    new OrderDetail { OrderDetailId = 125, PieId = 5, Amount = 2, OrderId = 44 },
                    new OrderDetail { OrderDetailId = 126, PieId = 13, Amount = 3, OrderId = 44 },

                    new OrderDetail { OrderDetailId = 127, PieId = 2, Amount = 1, OrderId = 45 },
                    new OrderDetail { OrderDetailId = 128, PieId = 1, Amount = 2, OrderId = 45 },

                    new OrderDetail { OrderDetailId = 129, PieId = 7, Amount = 3, OrderId = 46 },
                    new OrderDetail { OrderDetailId = 130, PieId = 6, Amount = 1, OrderId = 46 },
                    new OrderDetail { OrderDetailId = 131, PieId = 10, Amount = 2, OrderId = 46 },

                    new OrderDetail { OrderDetailId = 132, PieId = 15, Amount = 1, OrderId = 47 },
                    new OrderDetail { OrderDetailId = 133, PieId = 9, Amount = 2, OrderId = 47 },
                    new OrderDetail { OrderDetailId = 134, PieId = 3, Amount = 1, OrderId = 47 },

                    new OrderDetail { OrderDetailId = 135, PieId = 13, Amount = 1, OrderId = 48 },
                    new OrderDetail { OrderDetailId = 136, PieId = 8, Amount = 1, OrderId = 48 },
                    new OrderDetail { OrderDetailId = 137, PieId = 12, Amount = 3, OrderId = 48 },

                    new OrderDetail { OrderDetailId = 138, PieId = 5, Amount = 2, OrderId = 49 },
                    new OrderDetail { OrderDetailId = 139, PieId = 4, Amount = 1, OrderId = 49 },
                    new OrderDetail { OrderDetailId = 140, PieId = 2, Amount = 1, OrderId = 49 },
                    new OrderDetail { OrderDetailId = 141, PieId = 7, Amount = 2, OrderId = 49 },

                    new OrderDetail { OrderDetailId = 142, PieId = 9, Amount = 3, OrderId = 50 },

                    new OrderDetail { OrderDetailId = 143, PieId = 14, Amount = 1, OrderId = 51 },
                    new OrderDetail { OrderDetailId = 144, PieId = 6, Amount = 2, OrderId = 51 },
                    new OrderDetail { OrderDetailId = 145, PieId = 12, Amount = 1, OrderId = 51 },

                    new OrderDetail { OrderDetailId = 146, PieId = 1, Amount = 2, OrderId = 52 },
                    new OrderDetail { OrderDetailId = 147, PieId = 4, Amount = 1, OrderId = 52 },

                    new OrderDetail { OrderDetailId = 148, PieId = 5, Amount = 1, OrderId = 53 },
                    new OrderDetail { OrderDetailId = 149, PieId = 7, Amount = 2, OrderId = 53 },
                    new OrderDetail { OrderDetailId = 150, PieId = 10, Amount = 1, OrderId = 53 },
                    new OrderDetail { OrderDetailId = 151, PieId = 14, Amount = 2, OrderId = 53 },

                    new OrderDetail { OrderDetailId = 152, PieId = 8, Amount = 1, OrderId = 54 },
                    new OrderDetail { OrderDetailId = 153, PieId = 3, Amount = 1, OrderId = 54 },

                    new OrderDetail { OrderDetailId = 154, PieId = 11, Amount = 3, OrderId = 55 },
                    new OrderDetail { OrderDetailId = 155, PieId = 15, Amount = 2, OrderId = 55 },

                    new OrderDetail { OrderDetailId = 156, PieId = 13, Amount = 1, OrderId = 56 },
                    new OrderDetail { OrderDetailId = 157, PieId = 9, Amount = 1, OrderId = 56 },
                    new OrderDetail { OrderDetailId = 158, PieId = 4, Amount = 3, OrderId = 56 },

                    new OrderDetail { OrderDetailId = 159, PieId = 6, Amount = 1, OrderId = 57 },
                    new OrderDetail { OrderDetailId = 160, PieId = 2, Amount = 2, OrderId = 57 },
                    new OrderDetail { OrderDetailId = 161, PieId = 14, Amount = 1, OrderId = 57 },

                    new OrderDetail { OrderDetailId = 162, PieId = 7, Amount = 3, OrderId = 58 },
                    new OrderDetail { OrderDetailId = 163, PieId = 5, Amount = 1, OrderId = 58 },

                    new OrderDetail { OrderDetailId = 164, PieId = 8, Amount = 2, OrderId = 59 },
                    new OrderDetail { OrderDetailId = 165, PieId = 12, Amount = 1, OrderId = 59 },
                    new OrderDetail { OrderDetailId = 166, PieId = 3, Amount = 1, OrderId = 59 },

                    new OrderDetail { OrderDetailId = 167, PieId = 4, Amount = 1, OrderId = 60 },
                    new OrderDetail { OrderDetailId = 168, PieId = 10, Amount = 3, OrderId = 60 },
                    new OrderDetail { OrderDetailId = 169, PieId = 6, Amount = 2, OrderId = 60 },
                    new OrderDetail { OrderDetailId = 170, PieId = 15, Amount = 1, OrderId = 60 },

                    new OrderDetail { OrderDetailId = 171, PieId = 13, Amount = 1, OrderId = 61 },
                    new OrderDetail { OrderDetailId = 172, PieId = 11, Amount = 2, OrderId = 61 },

                    new OrderDetail { OrderDetailId = 173, PieId = 5, Amount = 2, OrderId = 62 },
                    new OrderDetail { OrderDetailId = 174, PieId = 2, Amount = 1, OrderId = 62 },
                    new OrderDetail { OrderDetailId = 175, PieId = 3, Amount = 1, OrderId = 62 },

                    new OrderDetail { OrderDetailId = 176, PieId = 9, Amount = 1, OrderId = 63 },
                    new OrderDetail { OrderDetailId = 177, PieId = 7, Amount = 3, OrderId = 63 },

                    new OrderDetail { OrderDetailId = 178, PieId = 1, Amount = 2, OrderId = 64 },
                    new OrderDetail { OrderDetailId = 179, PieId = 4, Amount = 1, OrderId = 64 },

                    new OrderDetail { OrderDetailId = 180, PieId = 12, Amount = 1, OrderId = 65 },
                    new OrderDetail { OrderDetailId = 181, PieId = 15, Amount = 2, OrderId = 65 },
                    new OrderDetail { OrderDetailId = 182, PieId = 10, Amount = 1, OrderId = 65 },

                    new OrderDetail { OrderDetailId = 183, PieId = 13, Amount = 3, OrderId = 66 },
                    new OrderDetail { OrderDetailId = 184, PieId = 11, Amount = 1, OrderId = 66 },
                    new OrderDetail { OrderDetailId = 185, PieId = 8, Amount = 1, OrderId = 66 },

                    new OrderDetail { OrderDetailId = 186, PieId = 6, Amount = 2, OrderId = 67 },
                    new OrderDetail { OrderDetailId = 187, PieId = 14, Amount = 1, OrderId = 67 },

                    new OrderDetail { OrderDetailId = 188, PieId = 2, Amount = 1, OrderId = 68 },
                    new OrderDetail { OrderDetailId = 189, PieId = 5, Amount = 3, OrderId = 68 },
                    new OrderDetail { OrderDetailId = 190, PieId = 3, Amount = 2, OrderId = 68 },

                    new OrderDetail { OrderDetailId = 191, PieId = 9, Amount = 2, OrderId = 69 },
                    new OrderDetail { OrderDetailId = 192, PieId = 7, Amount = 1, OrderId = 69 },
                    new OrderDetail { OrderDetailId = 193, PieId = 12, Amount = 1, OrderId = 69 },

                    new OrderDetail { OrderDetailId = 194, PieId = 10, Amount = 3, OrderId = 70 },
                    new OrderDetail { OrderDetailId = 195, PieId = 15, Amount = 1, OrderId = 70 },
                    new OrderDetail { OrderDetailId = 196, PieId = 14, Amount = 2, OrderId = 70 },
                    new OrderDetail { OrderDetailId = 197, PieId = 6, Amount = 1, OrderId = 70 },

                    new OrderDetail { OrderDetailId = 198, PieId = 8, Amount = 2, OrderId = 71 },
                    new OrderDetail { OrderDetailId = 199, PieId = 4, Amount = 1, OrderId = 71 },

                    new OrderDetail { OrderDetailId = 200, PieId = 11, Amount = 1, OrderId = 72 },
                    new OrderDetail { OrderDetailId = 201, PieId = 3, Amount = 3, OrderId = 72 },
                    new OrderDetail { OrderDetailId = 202, PieId = 1, Amount = 1, OrderId = 72 },

                    new OrderDetail { OrderDetailId = 203, PieId = 5, Amount = 2, OrderId = 73 },
                    new OrderDetail { OrderDetailId = 204, PieId = 13, Amount = 1, OrderId = 73 },
                    new OrderDetail { OrderDetailId = 205, PieId = 9, Amount = 1, OrderId = 73 },
                    new OrderDetail { OrderDetailId = 206, PieId = 2, Amount = 1, OrderId = 73 },

                    new OrderDetail { OrderDetailId = 207, PieId = 4, Amount = 1, OrderId = 74 },
                    new OrderDetail { OrderDetailId = 208, PieId = 7, Amount = 2, OrderId = 74 },

                    new OrderDetail { OrderDetailId = 209, PieId = 12, Amount = 2, OrderId = 75 },
                    new OrderDetail { OrderDetailId = 210, PieId = 14, Amount = 1, OrderId = 75 },
                    new OrderDetail { OrderDetailId = 211, PieId = 6, Amount = 3, OrderId = 75 },

                    new OrderDetail { OrderDetailId = 212, PieId = 10, Amount = 1, OrderId = 76 },
                    new OrderDetail { OrderDetailId = 213, PieId = 13, Amount = 2, OrderId = 76 },

                    new OrderDetail { OrderDetailId = 214, PieId = 15, Amount = 1, OrderId = 77 },
                    new OrderDetail { OrderDetailId = 215, PieId = 9, Amount = 2, OrderId = 77 },
                    new OrderDetail { OrderDetailId = 216, PieId = 3, Amount = 1, OrderId = 77 },

                    new OrderDetail { OrderDetailId = 217, PieId = 8, Amount = 3, OrderId = 78 },

                    new OrderDetail { OrderDetailId = 218, PieId = 1, Amount = 1, OrderId = 79 },
                    new OrderDetail { OrderDetailId = 219, PieId = 6, Amount = 2, OrderId = 79 },
                    new OrderDetail { OrderDetailId = 220, PieId = 12, Amount = 1, OrderId = 79 },
                    new OrderDetail { OrderDetailId = 221, PieId = 5, Amount = 2, OrderId = 79 },

                    new OrderDetail { OrderDetailId = 222, PieId = 9, Amount = 2, OrderId = 80 },
                    new OrderDetail { OrderDetailId = 223, PieId = 14, Amount = 1, OrderId = 80 },

                    new OrderDetail { OrderDetailId = 224, PieId = 11, Amount = 1, OrderId = 81 },
                    new OrderDetail { OrderDetailId = 225, PieId = 13, Amount = 2, OrderId = 81 },
                    new OrderDetail { OrderDetailId = 226, PieId = 7, Amount = 1, OrderId = 81 },
                    new OrderDetail { OrderDetailId = 227, PieId = 10, Amount = 3, OrderId = 81 },

                    new OrderDetail { OrderDetailId = 228, PieId = 2, Amount = 1, OrderId = 82 },
                    new OrderDetail { OrderDetailId = 229, PieId = 5, Amount = 2, OrderId = 82 },

                    new OrderDetail { OrderDetailId = 230, PieId = 8, Amount = 1, OrderId = 83 },
                    new OrderDetail { OrderDetailId = 231, PieId = 12, Amount = 3, OrderId = 83 },
                    new OrderDetail { OrderDetailId = 232, PieId = 3, Amount = 2, OrderId = 83 },

                    new OrderDetail { OrderDetailId = 233, PieId = 14, Amount = 1, OrderId = 84 },
                    new OrderDetail { OrderDetailId = 234, PieId = 6, Amount = 1, OrderId = 84 },
                    new OrderDetail { OrderDetailId = 235, PieId = 1, Amount = 2, OrderId = 84 },

                    new OrderDetail { OrderDetailId = 236, PieId = 5, Amount = 2, OrderId = 85 },
                    new OrderDetail { OrderDetailId = 237, PieId = 13, Amount = 1, OrderId = 85 },
                    new OrderDetail { OrderDetailId = 238, PieId = 4, Amount = 3, OrderId = 85 },

                    new OrderDetail { OrderDetailId = 239, PieId = 3, Amount = 1, OrderId = 86 },
                    new OrderDetail { OrderDetailId = 240, PieId = 15, Amount = 1, OrderId = 86 },
                    new OrderDetail { OrderDetailId = 241, PieId = 9, Amount = 1, OrderId = 86 },
                    new OrderDetail { OrderDetailId = 242, PieId = 10, Amount = 2, OrderId = 86 },

                    new OrderDetail { OrderDetailId = 243, PieId = 8, Amount = 1, OrderId = 87 },
                    new OrderDetail { OrderDetailId = 244, PieId = 12, Amount = 2, OrderId = 87 },
                    new OrderDetail { OrderDetailId = 245, PieId = 7, Amount = 1, OrderId = 87 },

                    new OrderDetail { OrderDetailId = 246, PieId = 6, Amount = 2, OrderId = 88 },
                    new OrderDetail { OrderDetailId = 247, PieId = 11, Amount = 1, OrderId = 88 },

                    new OrderDetail { OrderDetailId = 248, PieId = 14, Amount = 1, OrderId = 89 },
                    new OrderDetail { OrderDetailId = 249, PieId = 5, Amount = 2, OrderId = 89 },
                    new OrderDetail { OrderDetailId = 250, PieId = 1, Amount = 3, OrderId = 89 },

                    new OrderDetail { OrderDetailId = 251, PieId = 3, Amount = 1, OrderId = 90 },
                    new OrderDetail { OrderDetailId = 252, PieId = 15, Amount = 2, OrderId = 90 },

                    new OrderDetail { OrderDetailId = 253, PieId = 9, Amount = 1, OrderId = 91 },
                    new OrderDetail { OrderDetailId = 254, PieId = 12, Amount = 2, OrderId = 91 },
                    new OrderDetail { OrderDetailId = 255, PieId = 4, Amount = 3, OrderId = 91 },

                    new OrderDetail { OrderDetailId = 256, PieId = 8, Amount = 1, OrderId = 92 },
                    new OrderDetail { OrderDetailId = 257, PieId = 5, Amount = 1, OrderId = 92 },

                    new OrderDetail { OrderDetailId = 258, PieId = 2, Amount = 2, OrderId = 93 },
                    new OrderDetail { OrderDetailId = 259, PieId = 7, Amount = 1, OrderId = 93 },
                    new OrderDetail { OrderDetailId = 260, PieId = 11, Amount = 1, OrderId = 93 },

                    new OrderDetail { OrderDetailId = 261, PieId = 13, Amount = 3, OrderId = 94 },
                    new OrderDetail { OrderDetailId = 262, PieId = 15, Amount = 1, OrderId = 94 },
                    new OrderDetail { OrderDetailId = 263, PieId = 9, Amount = 1, OrderId = 94 },

                    new OrderDetail { OrderDetailId = 264, PieId = 4, Amount = 1, OrderId = 95 },
                    new OrderDetail { OrderDetailId = 265, PieId = 10, Amount = 2, OrderId = 95 },

                    new OrderDetail { OrderDetailId = 266, PieId = 6, Amount = 2, OrderId = 96 },
                    new OrderDetail { OrderDetailId = 267, PieId = 1, Amount = 1, OrderId = 96 },
                    new OrderDetail { OrderDetailId = 268, PieId = 3, Amount = 1, OrderId = 96 },
                    new OrderDetail { OrderDetailId = 269, PieId = 5, Amount = 2, OrderId = 96 },

                    new OrderDetail { OrderDetailId = 270, PieId = 14, Amount = 1, OrderId = 97 },
                    new OrderDetail { OrderDetailId = 271, PieId = 9, Amount = 1, OrderId = 97 },
                    new OrderDetail { OrderDetailId = 272, PieId = 7, Amount = 3, OrderId = 97 },

                    new OrderDetail { OrderDetailId = 273, PieId = 2, Amount = 1, OrderId = 98 },
                    new OrderDetail { OrderDetailId = 274, PieId = 12, Amount = 1, OrderId = 98 },
                    new OrderDetail { OrderDetailId = 275, PieId = 11, Amount = 2, OrderId = 98 },

                    new OrderDetail { OrderDetailId = 276, PieId = 5, Amount = 3, OrderId = 99 },
                    new OrderDetail { OrderDetailId = 277, PieId = 8, Amount = 1, OrderId = 99 },

                    new OrderDetail { OrderDetailId = 278, PieId = 3, Amount = 1, OrderId = 100 },
                    new OrderDetail { OrderDetailId = 279, PieId = 10, Amount = 2, OrderId = 100 },
                    new OrderDetail { OrderDetailId = 280, PieId = 15, Amount = 1, OrderId = 100 }
                );
        }
    }
}
