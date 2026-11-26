using System.ComponentModel.DataAnnotations;

namespace DTOs;

public class CreatePedidoDto
{
    [Required]  [StringLength(20)]
    public string Codigo {get;set;}
    [Range(0.0, 999999.99)]
    public decimal Total { get; set; }

    public bool Pagado { get; set; }

    [Range(1, int.MaxValue)]
    public int ClienteId { get; set; }
        
}