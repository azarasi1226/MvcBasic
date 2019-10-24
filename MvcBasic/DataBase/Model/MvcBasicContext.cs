namespace MvcBasic.DataBase.Model
{
    using MvcBasic.DataBase.Entity;
    using System.Data.Entity;

    public class MvcBasicContext : DbContext
    {
        public MvcBasicContext()
            : base("name=MvcBasicContext")
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
} 