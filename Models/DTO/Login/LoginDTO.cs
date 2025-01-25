using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetAPI.Models.DTO.Login
{
    public record LoginDTO
    {
        public string Email {get;set;}
        public string Senha {get;set;}
    }
}