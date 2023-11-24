using HealHub.Models;
using Microsoft.EntityFrameworkCore;

namespace HealHub.Persistence
{
    public class OracleDBContext : DbContext
    {
        public DbSet<Form> FormList { get; set; }
        public DbSet<Prognosis> PrognosisList { get; set; }
        public DbSet<User> userList { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public OracleDBContext(DbContextOptions<OracleDBContext> options) : base(options)
        {

        }
    }
}
