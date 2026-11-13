using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class LineaPedido
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public decimal PrecioUnitario { get; set; }

    public int PedidoId { get; set; }

    [ForeignKey("PedidoId")]
    public Pedido? Pedido { get; set; }

    public int PrendaId { get; set; }

    [ForeignKey("PrendaId")]
    public Prenda? Prenda { get; set; }
}
