using Desafio_Psychometrika.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Desafio_Psychometrika.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ProvaSimulado> ProvaSimulados { get; set; }
        public DbSet<Questoes> Questoes { get; set; }
        public DbSet<Gabarito> Gabaritos { get; set; }

    }
}
