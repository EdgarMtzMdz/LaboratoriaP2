namespace Empleados;

public class PuestosModel
{
    public PuestosModel ()
    {
    }

   
  
    public Guid idPuestos { get; set; }
    public string nombrePuestos { get; set; }

    public List<Empleados> Empleados{ get; set; }

}