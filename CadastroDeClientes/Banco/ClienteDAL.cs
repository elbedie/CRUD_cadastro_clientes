using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes.Banco;

public class ClienteDAL
{
    public IEnumerable<Cliente> Listar()
    {
        var listaDeClientes = new List<Cliente>();

        using var connection = new Connection().ObterConexao();
        connection.Open();

        string consultaSql = "SELECT * FROM Cliente";
        SqlCommand command = new SqlCommand(consultaSql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            int idCliente = Convert.ToInt32(dataReader["Id"]);
            string nomeCliente = Convert.ToString(dataReader["Nome"]) ?? string.Empty;
            string emailCliente = Convert.ToString(dataReader["Email"]) ?? string.Empty;
            Cliente cliente = new(nomeCliente, emailCliente) { Id = idCliente };

            listaDeClientes.Add(cliente);

        }

        return listaDeClientes;

    }

    public void AdicionarCliente(Cliente cliente)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        
        string consultaSql = "INSERT INTO Cliente (Nome, Email) VALUES (@nome, @email)";
        SqlCommand command = new SqlCommand(@consultaSql, connection);
        command.Parameters.AddWithValue("@nome", cliente.Nome);
        command.Parameters.AddWithValue("@email", cliente.Email);

        int retorno = command.ExecuteNonQuery();
        Console.WriteLine($"linhas afetadas: {retorno}.");
    }

    public void AtualizaCliente(int id, Cliente cliente)
    {
        try
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string consultaSql = "UPDATE Cliente SET Nome = @nome, Email = @email WHERE Id = @id";
            using var command = new SqlCommand(consultaSql, connection);
            command.Parameters.AddWithValue("@nome", cliente.Nome);
            command.Parameters.AddWithValue("@email", cliente.Email);
            command.Parameters.AddWithValue("@id", id);

            int retorno = command.ExecuteNonQuery();
            if (retorno > 0)
            {
                Console.WriteLine("Cliente atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Nenhum cliente foi encontrado com o ID fornecido.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
        }
    }

    public int DeletaCliente(int id)
    {
        try
        {
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string consultaSql = "DELETE FROM Cliente WHERE Id = @id";
            using var command = new SqlCommand(consultaSql, connection);
            command.Parameters.AddWithValue("@id", id);

            int linhasAfetadas = command.ExecuteNonQuery();
            return linhasAfetadas;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
            return 0; // Retorna 0 se ocorrer um erro
        }
    }

}
