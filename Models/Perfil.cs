using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetAPI.Models
{
    public class Perfil
    {
        [Key]
        public int Id {get; set;}

        [Required]
        public string Nome {get;set;}

        public ICollection<Usuario> Usuarios {get; set;} = new List<Usuario>();
    }
}