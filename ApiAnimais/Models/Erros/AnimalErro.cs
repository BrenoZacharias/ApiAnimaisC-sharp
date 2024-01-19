namespace ApiAnimais.Models.Erros;

public class AnimalErro : Exception
{
    public AnimalErro(string message) : base(message){}
}