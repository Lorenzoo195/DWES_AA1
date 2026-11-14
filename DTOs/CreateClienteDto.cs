using System.ComponentModel.DataAnnotations;

namespace DTOs;

public class CreateClienteDto
{
    [Required]  [StringLength(100)]
    public string Nombre { get; set; }
    
    [Required]  [EmailAddress]
    public string Email { get; set; }
    public bool EsSocioClub { get; set; }
}