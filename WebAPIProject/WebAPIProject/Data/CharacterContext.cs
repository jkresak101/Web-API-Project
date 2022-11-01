using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIProject.Models;

    public class CharacterContext : DbContext
    {
        public CharacterContext (DbContextOptions<CharacterContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPIProject.Models.Character> Character { get; set; } = default!;
    }
