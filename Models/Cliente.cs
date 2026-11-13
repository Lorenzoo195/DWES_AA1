namespace Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public bool EsSocioClub { get; set; } = false;

    public List<Pedido> Pedidos { get; set; } = new();
}
