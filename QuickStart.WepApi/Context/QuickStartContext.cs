using Microsoft.EntityFrameworkCore;
using QuickStart.WepApi.Entity;

namespace QuickStart.WepApi.Context
{
    public class QuickStartContext:DbContext
    {
        //sql bağlantı adresimiz tutar.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-NH5EP7F\\YUNUSSQLSERVER; initial catalog=DbQuickStartAkademiq; integrated security=true ; TrustServerCertificate=True");
        }

        public DbSet<Service> Services { get; set; }

        public DbSet<Testimonial> Testimonials { get; set;}
    }
}
