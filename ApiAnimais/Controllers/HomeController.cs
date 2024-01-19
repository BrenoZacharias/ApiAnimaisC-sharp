using ApiAnimais.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimais.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    public HomeController()
    {

    }

    [HttpGet]
    public HomeView Index()
    {
        return new HomeView
        {
            Mensagem = "Olá! Seja bem vindo a API de animais!!!",
            Documentacao = "/swagger"
        };
    }
}
