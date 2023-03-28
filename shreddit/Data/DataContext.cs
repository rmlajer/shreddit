using Microsoft.EntityFrameworkCore;
using shreddit.Model;

namespace shreddit.Data
{
    public class DataContext : DbContext
    {
        //Repræsenterer 2 attributes hhv. Posts og Comments. Disse oprettes som tables af EF.
        //Vi tror at vi definerer hvordan EF skal lave DB 
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Comment> Comments => Set<Comment>();


        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}
