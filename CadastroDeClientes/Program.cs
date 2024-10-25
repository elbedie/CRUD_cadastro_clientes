using CadastroDeClientes.Banco;
using System;
using System.Collections.Generic;


namespace CadastroDeClientes;

class Program
{        

    static void Main()
    {
        /*try
        {
            var clienteDAL = new ClienteDAL();
            clienteDAL.AdicionarCliente(new Cliente("Julia Alves", "juuh.alves@gmail.com"));
            
            var listaClientes = clienteDAL.Listar();

            foreach (var cliente in listaClientes)
            {
                Console.WriteLine(cliente);
            }
            
           
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return;*/

        Menu.ExibirTitulo();
        Menu.ExibirMenu();
    }
}