using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNetAPI.Context;
using MyNetAPI.Models;
using MyNetAPI.Models.DTO.Login;
using MyNetAPI.Services;
using Newtonsoft.Json.Linq;

namespace MyNetAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly MyApiContext _context;
        private LoginService _loginService;
        private JwtService _jwtService;


        public LoginController(MyApiContext context,LoginService loginService,JwtService jwtService){
            _context = context;
            _loginService = loginService;
            _jwtService = jwtService;
        }

        [HttpPost]
        public ActionResult Autenticar(LoginDTO dto){
            var login = _loginService.RealizarLogin(dto);
            if(login == null) return NotFound(new {Message = "Email ou Senha incorretos."});
            var token = _jwtService.GenerateToken(login);
            return Ok(new {Token = token});
        }
        
    }
}