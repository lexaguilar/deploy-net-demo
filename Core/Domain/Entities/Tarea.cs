namespace TaskManagerAPI.Core.Domain.Entities;

public class Tarea
{
    public int Id { get; set; }
     /*
    public string OldTitle { get; set; } // Código obsoleto comentado
    public DateTime? OldDate { get; set; } // SonarQube: S125 - Sections of code should not be commented out
    */
    public string Titulo { get; set; }
    public string Descripcion { get; set; } = string.Empty;
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    public DateTime? FechaVencimiento { get; set; }
    public bool Completada { get; set; } = false;
    
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
}