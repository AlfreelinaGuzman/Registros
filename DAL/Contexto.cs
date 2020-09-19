using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Registros.Entidades;

namespace Registros.DAL
{
public class Contexto:DbContext
{
   public DbSet<Personas> Personas { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
       optionsBuilder.UseSqlite(@"Data Source= DATA\Clase2.db");
   }

}
}