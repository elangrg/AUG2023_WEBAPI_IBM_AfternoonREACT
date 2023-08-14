using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWithMigration.Models
{
    public class Candidate
    {
        public int CandidateID { get; set; }
        public string CandidateName { get; set; }

        public string Address
        { get; set; }





    }

    public class CandidateContext : DbContext
    {

        public DbSet<Candidate> Candidates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Candidate>().HasKey(c => c.CandidateID);
            modelBuilder.Entity<Candidate>().Property(c => c.CandidateID).ValueGeneratedOnAdd();

            modelBuilder.Entity<Candidate>().Property(c => c.CandidateName).IsRequired().HasMaxLength(50).IsUnicode(false);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=tmpIBMREactCFDb;Integrated Security=True;");

        }



    }
    


}
