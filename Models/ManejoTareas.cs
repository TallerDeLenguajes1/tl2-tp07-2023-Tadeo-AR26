namespace EspacioTareas;

public class ManejoTareas{

    private static ManejoTareas instance;
    private AccesoADatos accesoADatos = new AccesoADatos();
    private List<Tarea> listaTareas = new List<Tarea>();

    public static ManejoTareas Instance { get => instance; set => instance = value; }
    public AccesoADatos AccesoADatos { get => accesoADatos; set => accesoADatos = value; }
    public List<Tarea> ListaTareas { get => listaTareas; set => listaTareas = value; }

    public ManejoTareas(){}

    public void CargarTareas(){
        listaTareas = accesoADatos.obtenerTareas();
    }

    public void GuardarTareas(){
        accesoADatos.guardarTareas(listaTareas);
    }
    public static ManejoTareas GetInstance(){
        if(instance == null){
            instance = new ManejoTareas();
            instance.CargarTareas();
        }
        return instance;
    }


    public Tarea CrearTarea(Tarea nuevaTarea){
        listaTareas.Add(nuevaTarea);
        accesoADatos.guardarTareas(listaTareas);
        return nuevaTarea;
    }

    public Tarea ObtenerTareaID(int idTarea){
        Tarea tareaEncontrada;
        tareaEncontrada = listaTareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        return tareaEncontrada;
    }

    public Tarea ActualizarTarea(int idTarea, int Estado){
        Tarea tareaEncontrada;
        tareaEncontrada = listaTareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        if(tareaEncontrada != null){
            tareaEncontrada.Estado = (Est)Estado;
            AccesoADatos.guardarTareas(listaTareas);
        }
        return tareaEncontrada;
    }

    public List<Tarea> EliminarTarea(int idTarea){
        Tarea tareaEncontrada;
        tareaEncontrada = listaTareas.FirstOrDefault(tarea => tarea.Id == idTarea);
        listaTareas.Remove(tareaEncontrada);
        AccesoADatos.guardarTareas(listaTareas);
        return listaTareas;
    }

    public List<Tarea> ListarTareas(){
        return listaTareas;
    }

    public List<Tarea> ListarCompletadas(){
        List<Tarea> ListaCompletas;
        ListaCompletas = listaTareas.FindAll(tarea => tarea.Estado == (Est)2);
        return ListaCompletas;
    }

}