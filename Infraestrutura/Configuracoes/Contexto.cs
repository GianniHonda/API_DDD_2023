using Entidades.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Configuracoes
{
    public class Contexto : IdentityDbContext<ApplicationUser>
    {
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

        public Contexto() { } // Construtor sem parâmetros adicionado aqui

        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ObterStringConexao());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
             .Build();

            // Obter a Connection String do appsettings.json
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            // Use a Connection String como necessário no seu script
            Console.WriteLine($"Connection String: {connectionString}");
            return connectionString;
        }
    }
}