using AfigoControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;


namespace AfigoControl.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("workstation id=Afigo_control.mssql.somee.com;packet size=4096;user id=compartidoDev_SQLLogin_1;pwd=47489168ny;data source=Afigo_control.mssql.somee.com;persist security info=False;initial catalog=Afigo_control");
        }
    }
}

