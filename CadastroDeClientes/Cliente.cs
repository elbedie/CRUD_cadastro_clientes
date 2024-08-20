using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Cliente (string nome, string email)
        {
            Nome = nome;
            Email = email;

        }
    }
}
