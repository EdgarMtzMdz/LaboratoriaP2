using System.ComponentModel.DataAnnotations;

namespace Empleados;

public class Empleados
{
    public Empleados()
    {
    }

    [Key]
    public Guid IdEmpleados { get; set; } 
    public string Nombre { get; set; }
    public Puestos? Puestos { get; set; }
    public int Edad { get; set; }
    public DateTime FechaEntrada { get; set; }
    public decimal Salario { get; set; }
    public Cuentas? Cuentas { get; set; }

    

}