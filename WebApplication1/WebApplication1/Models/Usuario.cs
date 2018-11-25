using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Privilegio { get; set; }
        public String Email { get; set; }
        public String Pass { get; set; }
        public String Phone { get; set; }
    }
}