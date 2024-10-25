using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Banco
{
    internal class Connection
    {
        const string connectionString = "Server=localhost,1433;Database=SistemaClientes;User ID=sa;Password=Numero_107;TrustServerCertificate=True";

        public SqlConnection ObterConexao()
        { 
            return new SqlConnection(connectionString);
        }
    }
}
