using BCryptSample.API.Models;
using BCryptSample.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BCryptSample.API.Controllers;

[ApiController]
[Route("v1/users")]
public sealed class UserController : ControllerBase
{
    private readonly IUserServices _userServices;

	public UserController(IUserServices userServices)
	{
        _userServices = userServices;
    }

    [HttpGet]
    public IActionResult Get() => Ok(_userServices.GetAll());

    [HttpPost]
    [Route("sign-up")]
    public IActionResult SignUp([FromBody] User user)
    {
        var result = _userServices.SignUp(user);

        if (result is null)
            return BadRequest("Erro ao criar usuário");

        return Ok($"O usuário {result.Username} foi criado com sucesso!");
    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] User user)
    {
        var result = _userServices.Login(user);

        if (result is null)
            return BadRequest("Erro ao logar o usuário");

        return Ok($"{result.Username} logado com sucesso!");
    }
}