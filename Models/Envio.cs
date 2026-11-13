using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Envio
{
    public int Id { get; set; }
    public string Empresa { get; set; } = string.Empty;
    public DateTime FechaEnvio { get; set; } = DateTime.Now;
    public decimal Coste { get; set; }
    public bool Entregado { get; set; } = false;

    public int PedidoId { get; set; }

    [ForeignKey("PedidoId")]
    public Pedido? Pedido { get; set; }
}
