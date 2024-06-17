using Microsoft.EntityFrameworkCore;

namespace Empleados;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Empleados> Empleados { get; set; }
    public DbSet<Cuentas> Cuentas { get; set; }
    public DbSet<Puestos> Puestos { get; set; }
}