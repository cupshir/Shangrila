namespace ShangriLa
{
    using global::ShangriLa.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShangriLaContext : DbContext
    {
        // Your context has been configured to use a 'ShangriLaContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ShangriLa.ShangriLaContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShangriLaContext' 
        // connection string in the application configuration file.
        public ShangriLaContext()
            : base("name=ShangriLaContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GamePlayer> GamePlayers { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}