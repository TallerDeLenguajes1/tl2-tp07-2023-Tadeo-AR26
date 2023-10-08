using System.Text.Json;

namespace EspacioTareas;

public class AccesoADatos{
    public AccesoADatos(){}
    public List<Tarea> obtenerTareas(){
        string archivo = "Tareas.Json";
        List<Tarea> tareas = new List<Tarea>();
        try{
            string jsonText = File.ReadAllText(archivo);
            tareas = JsonSerializer.Deserialize<List<Tarea>>(jsonText);
            return tareas;
        }
        catch(Exception ex){
            Console.WriteLine("Error al cargar");
            return null;
        }
    }

    public void guardarTareas(List<Tarea> tareas){
        string archivo = "Tareas.Json";
        string jsonText = JsonSerializer.Serialize(tareas);
        using(var nuevoArchivo = new FileStream(archivo, FileMode.Create)){
            using(var strWriter = new StreamWriter(nuevoArchivo)){
                strWriter.WriteLine("{0}", jsonText);
                strWriter.Close();
            }
        }
    }
}