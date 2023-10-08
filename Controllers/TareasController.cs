using Microsoft.AspNetCore.Mvc;
using EspacioTareas;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase{
    private readonly ILogger<TareasController> _logger;
    private ManejoTareas manejoTareas;
    public TareasController(ILogger<TareasController> logger){
        manejoTareas = ManejoTareas.GetInstance();

        _logger = logger;
    }

    [HttpPost]
    [Route("CrearTarea")]
    public ActionResult<Tarea> CrearTarea(Tarea nuevaTarea){
        return Ok(manejoTareas.CrearTarea(nuevaTarea));
    }


    [HttpGet]
    [Route("ObtenerTareaID")]
    public ActionResult<Tarea> ObtenerTareaID(int idTarea){
        return Ok(manejoTareas.ObtenerTareaID(idTarea));
    }

    [HttpPut]
    [Route("ActualizarUnaTarea")]
    public ActionResult<Tarea> ActualizarTarea(int idTarea, int nuevoEstado){
        return Ok(manejoTareas.ActualizarTarea(idTarea, nuevoEstado));
    }

    [HttpDelete]
    [Route("EliminarTarea")]
    public ActionResult<List<Tarea>> EliminarTarea(int idTarea){
        return Ok(manejoTareas.EliminarTarea(idTarea));
    }

    [HttpGet]
    [Route("ListarTareas")]
    public ActionResult<List<Tarea>> ListarTareas(){
        return Ok(manejoTareas.ListarTareas());
    }

    [HttpGet]
    [Route("ListarCompletadas")]
    public ActionResult<List<Tarea>> ListarCompletadas(){
        return Ok(manejoTareas.ListarCompletadas());
    }
    
}