﻿using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CatalagoContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        /// <summary>
        /// Método para fazer configurações com o banco de dados.
        /// </summary>
        /// <param name="optionsBuilder"></param>

        public CatalagoContext(DbContextOptions<CatalagoContext> options)
        : base(options) {}
                
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-3D7BIP0\SQLEXPRESS;Database=dbCatalogo;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
