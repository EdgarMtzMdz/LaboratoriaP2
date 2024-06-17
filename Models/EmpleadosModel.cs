using Microsoft.AspNetCore.Mvc.Rendering;

namespace Empleados;

public class EmpleadosModel
{
    public EmpleadosModel()
    {
    }

    public Guid IdEmpleados { get; set; } 
    public string Nombre { get; set; }
    
    public int Edad { get; set; }
    public DateTime FechaEntrada { get; set; }
    public decimal Salario { get; set; }

    public List<Empleados> Empleados{ get; set; }

    public Guid? idPuestos { get; set; }
    public PuestosModel? PuestosModel { get; set;}
    public string nombrePuestos { get; set; }
    public List<Puestos> Puestos { get; set; }
    public List<SelectListItem> PuestosList { get; set; }
}