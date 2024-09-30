using AppointmentManagementUserApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentManagementUserApi.DataAccess
{
    public class AppointmentUserDBContext : DbContext
    {
        public AppointmentUserDBContext(DbContextOptions<AppointmentUserDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }


       

    }
}
