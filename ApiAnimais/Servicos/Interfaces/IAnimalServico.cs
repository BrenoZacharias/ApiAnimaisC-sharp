namespace ApiAnimais.Servicos.Interfaces;

using ApiAnimais.Models;
using ApiAnimais.Dto;


public interface IAnimalServico
{
    List<Animal> Lista(int page);
    Animal Incluir(AnimalDto animalDto);
    Animal Update(int id, AnimalDto animalDto);
    Animal BuscaPorId(int id);
    void Delete(int id);
}