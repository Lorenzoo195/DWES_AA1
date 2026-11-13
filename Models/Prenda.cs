namespace Models;

public class Prenda
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Stock { get; set; }
    public bool EsImpermeable { get; set; } = false;

    public List<LineaPedido> LineasPedido { get; set; } = new();
}
