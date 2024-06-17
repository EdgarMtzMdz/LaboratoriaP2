using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Empleados;

public class EmpleadosController : Controller
{

    private readonly ApplicationDBContext _context;
    public EmpleadosController(ApplicationDBContext context)
    {
        _context = context;
    }
    
    
    public IActionResult EmpleadosList()
    {
       List<Empleados> EmpleadosList = _context.Empleados.Select(e => new Empleados()
        {
            IdEmpleados = e.IdEmpleados,
            Nombre = e.Nombre,
            Edad = e.Edad,
            FechaEntrada = e.FechaEntrada,
            Salario = e.Salario
        }).ToList();

        List<Puestos> PuestosList = _context.Puestos.Select(p => new Puestos()
        {
            idPuestos = p.idPuestos,
            nombrePuestos = p.nombrePuestos
        }).ToList();

        

        return View(EmpleadosList);
    }

    [HttpGet]
    public IActionResult EmpleadosAdd (Guid IdEmpleados, DateTime FechaEntrada)
    {
        EmpleadosModel empleadosNew = new EmpleadosModel();
        empleadosNew.IdEmpleados = Guid.NewGuid();
        empleadosNew.FechaEntrada = DateTime.Now;
        
        empleadosNew.PuestosList =
            _context.Puestos.Select(p => new SelectListItem()
            { Value = p.idPuestos.ToString(), Text = p.nombrePuestos }
            ).ToList();

        return View(empleadosNew);
    }


    [HttpPost]
    public async Task<IActionResult> EmpleadosAdd (Empleados empleados)
    {
        
        if (ModelState.IsValid)
        {
            _context.Add(empleados);
            await _context.SaveChangesAsync();
            await _context.SaveChangesAsync();

            return RedirectToAction("EmpleadosList", "Empleados");
        }


         return View(empleados);

    }

    public IActionResult EmpleadosUpdate (Guid IdEmpleados)
    {
        Empleados? empleados = this._context.Empleados
        .Where(p=> p.IdEmpleados == IdEmpleados).FirstOrDefault();

        if (empleados == null)
        {
            return RedirectToAction("EmpleadosList", "Empleados");
        }

        

        EmpleadosModel empleadosUpdate = new EmpleadosModel();
        empleadosUpdate.IdEmpleados = empleados.IdEmpleados;
        empleadosUpdate.Nombre = empleados.Nombre;
        
        empleadosUpdate.Edad = empleados.Edad;
        empleadosUpdate.FechaEntrada = empleados.FechaEntrada;
        empleadosUpdate.Salario = empleados.Salario;
        
        return View(empleadosUpdate);
    }

    [HttpPost]
    public IActionResult EmpleadosUpdate (EmpleadosModel empleados)
    {
        Empleados empleadosEntity = this._context.Empleados
        .Where(p=> p.IdEmpleados == empleados.IdEmpleados).First();

        if (empleadosEntity == null)
        {
            return View(empleados);
        }

        empleadosEntity.Nombre = empleados.Nombre;
        
        empleadosEntity.Salario = empleados.Salario;

        this._context.Empleados.Update(empleadosEntity);
        this._context.SaveChanges();
        return RedirectToAction("EmpleadosList", "Empleados");


    }

    public IActionResult EmpleadosDelete (Guid IdEmpleados)
    {
        Empleados? empleados = this._context.Empleados
        .Where(p=> p.IdEmpleados == IdEmpleados).FirstOrDefault();

        if (empleados == null)
        {
            return RedirectToAction("EmpleadosList", "Empleados");
        }

        EmpleadosModel empleadosDelete = new EmpleadosModel();
        empleadosDelete.IdEmpleados = empleados.IdEmpleados;
        empleadosDelete.Nombre = empleados.Nombre;
        
        empleadosDelete.Edad = empleados.Edad;
        empleadosDelete.FechaEntrada = empleados.FechaEntrada;
        empleadosDelete.Salario = empleados.Salario;
        return View(empleadosDelete);
    }
    
    [HttpPost]
    public IActionResult EmpleadosDelete (EmpleadosModel empleados)
    {


        bool existe = this._context.Empleados.Any(p => p.IdEmpleados == empleados.IdEmpleados);
        if (!existe)
        {
            return View(empleados);
        }

        Empleados empleadosEntity = this._context.Empleados
        .Where(p=> p.IdEmpleados == empleados.IdEmpleados).First();

        this._context.Empleados.Remove(empleadosEntity);
        this._context.SaveChanges();
        return RedirectToAction("EmpleadosList", "Empleados");


    }

    
}