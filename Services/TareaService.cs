using Platzi___API_Rest.Models;

namespace Platzi___API_Rest.Services;
public class TareaService : ITareaService
{
    TareasContext context;

    public TareaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea Tarea)
    {
        Tarea.FechaCreacion = DateTime.Now;
        context.Add(Tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea Tarea)
    {
        var TareaActual = context.Tareas.Find(id);

        if (TareaActual != null)
        {
            TareaActual.Titulo = Tarea.Titulo;
            Tarea.Descripcion = Tarea.Descripcion;
            Tarea.PrioridadTarea = Tarea.PrioridadTarea;
            Tarea.CategoriaId = Tarea.CategoriaId;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var TareaActual = context.Tareas.Find(id);

        if (TareaActual != null)
        {
            context.Remove(TareaActual);
            await context.SaveChangesAsync();
        }
    }

}

public interface ITareaService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea Tarea);

    Task Update(Guid id, Tarea Tarea);

    Task Delete(Guid id);
}