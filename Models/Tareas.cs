namespace EspacioTareas;

public class Tarea{

    private int id;
    private string titulo;
    private string descripcion;
    private Est estado;

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public Est Estado { get => estado; set => estado = value; }

    public Tarea(){}
    public Tarea(int id, string titulo, string descripcion, Est estado){
        this.id = id;
        this.titulo = titulo;
        this.descripcion = descripcion;
        this.estado = estado;
    }

}

public enum Est{
        Pendiente,
        EnProgreso,
        Completada
    }