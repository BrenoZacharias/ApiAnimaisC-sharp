namespace ApiAnimais.Dto;

using ApiAnimais.Enums;

public record AnimalDto
{
    public string Tipo { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public int Idade { get; set; }
    public GeneroAnimal Genero { get; set; }
}