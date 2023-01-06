using ActionCommandGame.Model;
using ActionCommandGame.Repository.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandGame.Repository
{
    public class ActionCommandGameDbContext: IdentityDbContext
    {
        public ActionCommandGameDbContext(DbContextOptions<ActionCommandGameDbContext> options): base(options)
        {
            
        }

        public DbSet<PositiveGameEvent> PositiveGameEvents { get; set; }
        public DbSet<NegativeGameEvent> NegativeGameEvents { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerItem> PlayerItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();
            modelBuilder.ConfigureRelationships();

            base.OnModelCreating(modelBuilder);
        }

        public void Initialize()
        {
            var email = "bavo.ketels@vives.be";
            //Password Test123$
            var passwordHash = "AQAAAAEAACcQAAAAECp9VnV5jgDyqQqacxkrC+OcWFUM1+mavZ4+mxxhqtm/dg9UTVq1vhgAKFsblrEXDA==";
            var user = new IdentityUser
            {
                UserName = email,
                Email = email,
                NormalizedEmail = email.ToUpperInvariant(),
                NormalizedUserName = email.ToUpperInvariant(),
                PasswordHash = passwordHash
            };

            Users.Add(user);
            SaveChanges();

            GeneratePositiveGameEvents();
            GenerateNegativeGameEvents();
            GenerateAttackItems();
            GenerateDefenseItems();
            GenerateFoodItems();
            GenerateDecorativeItems();

            //God Mode Item
            Items.Add(new Item
            {
                Name = "GOD MODE",
                Description = "This is almost how a GOD must feel.",
                Attack = 1000000,
                Defense = 1000000,
                Fuel = 1000000,
                ActionCooldownSeconds = 1,
                Price = 10000000
            });

            Players.Add(new Player { UserId = user.Id, Name = "Frank Booze", Money = 100 });
            Players.Add(new Player { UserId = user.Id, Name = "Marie Shots", Money = 1000, Experience = 200 });
            Players.Add(new Player { UserId = user.Id, Name = "Jack Wasted", Money = 500, Experience = 5 });
            Players.Add(new Player { UserId = user.Id, Name = "Julie Baller", Money = 12345, Experience = 2000 });

            SaveChanges();
        }

        private void GeneratePositiveGameEvents()
        {
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Baileys", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Beerenburg", Description = "It slips out of your hands and rolls inside a crack in the floor. It is out of reach.", Probability = 500 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Campari", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Cointreau", Description = "You hold it to the light and warm it up to reveal secret texts, but it remains empty.", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Créme de Cassis", Description = "The water flows around your feet and creates a dirty puddle.", Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Galliano", Money = 1, Experience = 1, Probability = 2000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Jägermeister", Money = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Limoncello", Money = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Children's Treasure Map", Money = 1, Experience = 1, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Malibu", Money = 5, Experience = 3, Probability = 1000 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Passoa", Money = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Pisang Ambon", Money = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Rum", Money = 10, Experience = 5, Probability = 800 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Safari", Money = 12, Experience = 6, Probability = 700 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Sambuca", Money = 20, Experience = 8, Probability = 650 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Sherry", Money = 30, Experience = 10, Probability = 500 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Southern Comfort", Money = 50, Experience = 13, Probability = 400 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Tequila", Money = 60, Experience = 15, Probability = 400 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Tia Maria", Money = 100, Experience = 40, Probability = 350 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Triple Sec", Money = 140, Experience = 50, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Gin Tonic", Money = 160, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Kasteelbier Rouge", Money = 160, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Jupiler", Money = 180, Experience = 80, Probability = 300 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Apple Cider", Money = 300, Experience = 100, Probability = 110 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Single malt whiskey", Money = 300, Experience = 100, Probability = 80 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Fireman Shot", Money = 400, Experience = 150, Probability = 200 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Boswandeling", Money = 500, Experience = 150, Probability = 150 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Pornstar Martini", Money = 1000, Experience = 200, Probability = 100 });
            PositiveGameEvents.Add(new PositiveGameEvent { Name = "Calvados", Money = 60000, Experience = 1500, Probability = 5 });
        }

        public void GenerateNegativeGameEvents()
        {
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Unintelligible",
                Description = "When you address the bartender, he clearly does not want to serve you in this condition",
                DefenseWithGearDescription = "Luckily you built up some reputation, no one saw this embarrassing moment",
                DefenseWithoutGearDescription = "You hear people laughing at you behind your back. U lost some energy!",
                DefenseLoss = 2,
                Probability = 100
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Clumsy Clown",
                Description = "When you walk to the bartender to order your next random drink you fall over the barstool",
                DefenseWithGearDescription = "A sympathetic young lady helps you up, fortunately you have a high reputation",
                DefenseWithoutGearDescription = "No one wants to pick up someone with your reputation, you climb up on your own. U lost some energy!",
                DefenseLoss = 3,
                Probability = 50
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Bad Casanova",
                Description = "You're trying to treat a person at the bar, but this person doesn't want anything to do with you",
                DefenseWithGearDescription = "Someone with your reputation will not lose heart because of this and will look for the next victim",
                DefenseWithoutGearDescription = "the whole bar heard your blunder, this is embarrassing. U lost some energy!",
                DefenseLoss = 2,
                Probability = 100
            });
            NegativeGameEvents.Add(new NegativeGameEvent
            {
                Name = "Puke Warning",
                Description = "When you order a new drink from the bartender you feel something coming up from your stomach",
                DefenseWithGearDescription = "The bartender is quick enough to give you a bucket in time, so you make it to the toilets without anyone noticing",
                DefenseWithoutGearDescription = "You throw up on the bar, everyone looks at you and the party at the bar jumps off their bar stools. U lost some energy",
                DefenseLoss = 3,
                Probability = 50
            });
        }

        private void GenerateAttackItems()
        {
            Items.Add(new Item { Name = "Glass of water", Attack = 50, Price = 50 });
            Items.Add(new Item { Name = "Dafalgan Forte", Attack = 300, Price = 300 });
            Items.Add(new Item { Name = "Mocktail", Attack = 500, Price = 500 });
            Items.Add(new Item { Name = "Coca-Cola", Attack = 5000, Price = 15000 });
            Items.Add(new Item { Name = "Puke-break", Attack = 50, Price = 1000000 });
        }

        private void GenerateDefenseItems()
        {
            Items.Add(new Item { Name = "Golden Lighter", Defense = 20, Price = 20 });
            Items.Add(new Item { Name = "Louis Vuitton bag", Defense = 150, Price = 200 });
            Items.Add(new Item { Name = "Leather jacket", Defense = 500, Price = 1000 });
            Items.Add(new Item { Name = "Louboutin", Defense = 2000, Price = 10000 });
            Items.Add(new Item { Name = "Patek Philippe watch", Defense = 2000, Price = 10000 });
            Items.Add(new Item { Name = "Tournée Générale", Defense = 20000, Price = 10000 });
        }

        private void GenerateFoodItems()
        {
            Items.Add(new Item { Name = "Apple", ActionCooldownSeconds = 50, Fuel = 4, Price = 8 });
            Items.Add(new Item { Name = "Energy Bar", ActionCooldownSeconds = 45, Fuel = 5, Price = 10 });
            Items.Add(new Item { Name = "Bowl of nachos", ActionCooldownSeconds = 30, Fuel = 30, Price = 300 });
            Items.Add(new Item { Name = "Pizza", ActionCooldownSeconds = 25, Fuel = 100, Price = 500 });
            Items.Add(new Item { Name = "Pitta", ActionCooldownSeconds = 25, Fuel = 100, Price = 500 });
            Items.Add(new Item { Name = "Celestial Burrito", ActionCooldownSeconds = 15, Fuel = 500, Price = 10000 });
#if DEBUG
            Items.Add(new Item { Name = "Developer Food", ActionCooldownSeconds = 1, Fuel = 1000, Price = 1 });
#endif
        }

        private void GenerateDecorativeItems()
        {
            Items.Add(new Item { Name = "Pack of sigarettes", Description = "Kills you faster. Do you feel special now?", Price = 10 });
            Items.Add(new Item { Name = "Crown of Flexing", Description = "Yes, show everyone how much money you are willing to spend on something useless!", Price = 500000 });
        }

    }
}
