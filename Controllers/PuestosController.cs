using Microsoft.AspNetCore.Mvc;

namespace Empleados;

public class PuestosController : Controller
{
    private readonly ApplicationDBContext _context;
    public PuestosController(ApplicationDBContext context)
    {
        _context = context;
    }

    public ActionResult PuestosList()
    {
        List<Puestos> PuestosList = _context.Puestos.Select(e => new Puestos()
        {
            idPuestos = e.idPuestos,
            nombrePuestos = e.nombrePuestos
        }).ToList();
        return View(PuestosList);
    }

    [HttpGet]
    public IActionResult PuestosAdd(Guid idPuestos)
    {
        PuestosModel puestosNew = new PuestosModel();
        puestosNew.idPuestos = Guid.NewGuid();
        return View(puestosNew);
    }


    [HttpPost]
    public async Task<IActionResult> PuestosAdd(Puestos puestos)
    {
        if (ModelState.IsValid)
        {
            _context.Add(puestos);
            await _context.SaveChangesAsync();
            return RedirectToAction("PuestosList", "Puestos");
        }
        return View(puestos);
    }

    public IActionResult PuestosUpdate (Guid idPuestos)
    {
        Puestos? puestos = this._context.Puestos
        .Where(p=> p.idPuestos == idPuestos).FirstOrDefault();

        if (puestos == null)
        {
            return RedirectToAction("PuestosList", "Puestos");
        }

        

        PuestosModel puestosUpdate = new PuestosModel();
        puestosUpdate.idPuestos = puestos.idPuestos;
        puestosUpdate.nombrePuestos = puestos.nombrePuestos;
        return View(puestosUpdate);
    }

    [HttpPost]
    public IActionResult PuestosUpdate (PuestosModel puestos)
    {
        Puestos puestosEntidad = this._context.Puestos
        .Where(p=> p.idPuestos == puestos.idPuestos).First();

        if (puestosEntidad == null)
        {
            return View(puestos);
        }

        puestosEntidad.nombrePuestos = puestos.nombrePuestos;
        
        

        this._context.Puestos.Update(puestosEntidad);
        this._context.SaveChanges();
        return RedirectToAction("PuestosList", "Puestos");


    }

    public IActionResult PuestosDelete (Guid idPuestos)
    {
        Puestos? puestos = this._context.Puestos
        .Where(p=> p.idPuestos == idPuestos).FirstOrDefault();

        if (puestos == null)
        {
            return RedirectToAction("PuestosList", "Puestos");
        }

        PuestosModel puestosDelete = new PuestosModel();
        puestosDelete.idPuestos = puestos.idPuestos;
        puestosDelete.nombrePuestos = puestos.nombrePuestos;
        return View(puestosDelete);
    }
    
    [HttpPost]
    public IActionResult PuestosDelete (PuestosModel puestos)
    {


        bool existe = this._context.Puestos.Any(p => p.idPuestos == puestos.idPuestos);
        if (!existe)
        {
            return View(puestos);
        }

        Puestos puestosEntidad = this._context.Puestos
        .Where(p=> p.idPuestos == puestos.idPuestos).First();

        this._context.Puestos.Remove(puestosEntidad);
        this._context.SaveChanges();
        return RedirectToAction("PuestosList", "Puestos");


    }
}