using GestionEmpleadosBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionEmpleadosBlazor.Server.Data
{
    public class DatabaseContext: DbContext
    {
        //Constructor
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Empleado> Empleado { get; set; }
    }
}
