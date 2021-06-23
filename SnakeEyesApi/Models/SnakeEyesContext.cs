using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SnakeEyesApi.Models
{
    public class SnakeEyesContext : DbContext
    {
        public SnakeEyesContext(DbContextOptions<SnakeEyesContext> options)
    : base(options)
        {
        }
        public DbSet<SnakeEyesRoll> SnakeEyesRolls { get; set; }
    }
}
