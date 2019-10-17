using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectReceitas.Domain.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
