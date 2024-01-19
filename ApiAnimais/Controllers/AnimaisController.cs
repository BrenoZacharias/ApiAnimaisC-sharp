using System.Data.Common;
using ApiAnimais.Database;
using ApiAnimais.Dto;
using ApiAnimais.Models;
using ApiAnimais.Models.Erros;
using ApiAnimais.ModelViews;
using ApiAnimais.Servicos.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace ApiAnimais.Controllers;

[ApiController]
[Route("/animais")]
public class AnimaisController : ControllerBase
{
    public AnimaisController(IAnimalServico servico)
    {
        _servico = servico;
    }

    private IAnimalServico _servico;

    [HttpGet]
    public IActionResult Index(int page = 1)
    {
        var animais = _servico.Lista(page);
        return StatusCode(200, animais);
    }

    [HttpGet("{id}")]
    public IActionResult Show([FromRoute] int id)
    {
        try
        {
            var animalDb = _servico.BuscaPorId(id);
            return StatusCode(200, animalDb);
        }
        catch(AnimalErro erro)
        {
            return StatusCode(404, new ErroView { Mensagem = erro.Message });
        }   
    }

    [HttpPost]
    public IActionResult Create([FromBody] AnimalDto animalDto)
    {
        try
        {
            var animal = _servico.Incluir(animalDto);
            return StatusCode(201, animal);
        }
        catch(AnimalErro erro)
        {
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }
        
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] AnimalDto animalDto)
    {
        try
        {
            var animalDb = _servico.Update(id, animalDto);
            return StatusCode(200, animalDb);
        }
        catch(AnimalErro erro)
        {     
            return StatusCode(400, new ErroView { Mensagem = erro.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        try
        {
            _servico.Delete(id);
            return StatusCode(204);
        }
        catch(AnimalErro erro)
        {
            return StatusCode(404, new ErroView { Mensagem = erro.Message });
        }
    }
}