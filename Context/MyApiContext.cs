using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNetAPI.Models;

namespace MyNetAPI.Context
{
    public class MyApiContext : DbContext
    {
        public MyApiContext(DbContextOptions<MyApiContext> options ) : base(options){}

        public DbSet<Login> Logins {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}

        public DbSet<Perfil> Perfis {get; set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração do relacionamento 1-para-1 entre Usuario e Login
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Login)
                .WithOne(l => l.Usuario)
                .HasForeignKey<Login>(l => l.Id); // Login usa 'Id' como FK


            modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Perfil)
            .WithMany(p => p.Usuarios)
            .HasForeignKey(u => u.PerfilId)
            .OnDelete(DeleteBehavior.Restrict); //Evita exclusão em cascata

            base.OnModelCreating(modelBuilder);
        }

    }
}