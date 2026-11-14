using System.ComponentModel.DataAnnotations;

namespace DTOs;

public class CreatePrendaDto
{
    [Required]
    public string Nombre { get; set; }

    [Required]
    public string Categoria { get; set; }

    [Range(0.01, 9999.99)]
    public decimal Precio { get; set; }
    
    [Range(0, 10000)]
    public int Stock { get; set; }
    public bool EsImpermeable { get; set; }
}