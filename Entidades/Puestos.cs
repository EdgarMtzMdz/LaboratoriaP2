using System.ComponentModel.DataAnnotations;

namespace Empleados;

public class Puestos
{
    public Puestos ()
    {
    }

   
   [Key]
    public Guid idPuestos { get; set; }
    public string nombrePuestos { get; set; }

    

    

}