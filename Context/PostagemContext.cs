using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Postagem.Models;

namespace Postagem.Context
{
    public class PostagemContext:  DbContext
    {
        
            public PostagemContext(DbContextOptions <PostagemContext> options): base(options) {



            }

            public DbSet<Carta> Cartas { get; set; }

            public DbSet<Territorio> Territorios { get; set; }

              public DbSet<Entrega> Entregas{ get; set; }

    }
}