using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Pedido
{
    public int Id { get; set; }
    public string Codigo { get; set; } = string.Empty;
    public DateTime Fecha { get; set; } = DateTime.Now;
    public decimal Total { get; set; } = 0m;
    public bool Pagado { get; set; } = false;

    public int ClienteId { get; set; }

    [ForeignKey("ClienteId")]
    public Cliente? Cliente { get; set; }

    public List<LineaPedido> Lineas { get; set; } = new();
    public List<Envio> Envios { get; set; } = new();
}
