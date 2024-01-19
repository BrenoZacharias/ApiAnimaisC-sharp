using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApiAnimais.Enums;
using Newtonsoft.Json;

namespace ApiAnimais.Models;

[Table(name: "animais")]
public class Animal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [StringLength(40)]
    public string Tipo { get; set; } = default!;
    [Required]
    [StringLength(50)]
    public string Nome { get; set; } = default!;
    [Required]
    public int Idade { get; set; }
    [Required]
    [EnumDataType(typeof(GeneroAnimal))]
    public GeneroAnimal Genero { get; set; }
}