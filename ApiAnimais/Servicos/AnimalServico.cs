namespace ApiAnimais.Servicos;
using ApiAnimais.Database;
using ApiAnimais.Dto;
using ApiAnimais.Models;
using ApiAnimais.Models.Erros;
using ApiAnimais.Servicos.Interfaces;

public class AnimalServico : IAnimalServico
{
    public AnimalServico(AnimaisContext db)
    {
        _db = db;
    }
    private AnimaisContext _db;

    public List<Animal> Lista(int page = 1)
    {
        if(page < 1) page = 1;
        int limit = 10;
        int offset = (page - 1) * limit;
        return _db.Animais.Skip(offset).Take(limit).ToList();
    }

    public Animal Incluir(AnimalDto animalDto)
    {
        string MensagemErro = validaErros(animalDto);
        
        if(!string.IsNullOrEmpty(MensagemErro))
            throw new AnimalErro(MensagemErro); 

        var animal = new Animal
        {
            Tipo = animalDto.Tipo,
            Nome = animalDto.Nome,
            Idade = animalDto.Idade,
            Genero = animalDto.Genero
        };

        _db.Animais.Add(animal);
        _db.SaveChanges();
        return animal;
    }

    public Animal Update(int id, AnimalDto animalDto)
    {
        string MensagemErro = validaErros(animalDto);
        
        if(!string.IsNullOrEmpty(MensagemErro))
            throw new AnimalErro(MensagemErro); 

        var animalDb = _db.Animais.Find(id);
        if(animalDb == null)
            throw new AnimalErro($"Id {id} não foi encontrado na lista de Animais");

        animalDb.Tipo = animalDto.Tipo;
        animalDb.Nome = animalDto.Nome;
        animalDb.Idade = animalDto.Idade;
        animalDb.Genero = animalDto.Genero;
        
        _db.Animais.Update(animalDb);
        _db.SaveChanges();
        return animalDb;
    }

    public Animal BuscaPorId(int id)
    {
        var animalDb = _db.Animais.Find(id);
        if(animalDb == null)
            throw new AnimalErro($"Id {id} não foi encontrado na lista de Animais");

        return animalDb;
    }

    public void Delete(int id)
    {
        var animalDb = _db.Animais.Find(id);
        if(animalDb == null)
            throw new AnimalErro($"Id {id} não foi encontrado na lista de Animais");

        _db.Animais.Remove(animalDb);
        _db.SaveChanges();
    }


    private string validaErros(AnimalDto animalDto)
    {
        string MensagemErro = "";
        if(string.IsNullOrEmpty(animalDto.Tipo)||(animalDto.Tipo.Length > 40))
            MensagemErro+="O campo Tipo não pode ser vazio e nem possuir mais de 40 caracteres | ";

        if(string.IsNullOrEmpty(animalDto.Nome)||(animalDto.Nome.Length > 50))
            MensagemErro+="O campo Nome não pode ser vazio e nem possuir mais de 50 caracteres | ";
        

        if((animalDto.Idade < 0)||(animalDto.Idade > 150))
            MensagemErro+="O campo Idade deve ser um valor entre 0 e 150 | ";

        if((!animalDto.Genero.ToString().Equals("Macho"))&&(!animalDto.Genero.ToString().Equals("Femea")))
            MensagemErro+="O campo Genero deve ser '1' para 'Femea' e '2' para 'Macho' | ";
        
        return MensagemErro;
    }
}