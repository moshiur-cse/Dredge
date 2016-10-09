using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DredgingCodeFastApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DredgeDbContext")
        {
        }
        public DbSet<DredgInformationModels> DredgInformations { get; set; }
        public DbSet<DivisionModels> Divisions { get; set; }
        public DbSet<DistrictModels> Districts { get; set; }
        public DbSet<UnionModels> Unions { get; set; }
        public DbSet<UpazilaModels> Upazilas { get; set; }
        public DbSet<MauzaModels> Mauzas { get; set; }
        public DbSet<DredgeModels> Dredges{ get; set; } 

        

        //SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
    }
}