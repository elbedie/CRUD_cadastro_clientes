using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeClientes
{
    public class Menu
    {
        static List<Cliente> clientes = new List<Cliente>();
        static bool continuarExecucao = true; // Controlar o while do menu 
        public static void ExibirTitulo()
        {
            string titulo = "CADASTRO DE CLIENTES!";
            int numLetras = titulo.Length;
            Console.WriteLine(titulo);
            Console.WriteLine(new string('-', numLetras ));

        }

        public static void OpcaoDesejada ()
        {
            
        }
        public static void ExibirMenu()
        {
            
            while (continuarExecucao)
            {            
                Console.WriteLine("Selecione a opção desejada:");
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Exibir clientes");
                Console.WriteLine("3 - Atualizar clientes");
                Console.WriteLine("4 - Deletar clientes");
                Console.WriteLine("0 - Sair do programa.");
                Console.WriteLine("---------------------");
                Console.Write("Insira a opção desejada: ");

                if (int.TryParse(Console.ReadLine(), out int opcaoDesejada))
                {
                    switch (opcaoDesejada)
                    {

                        case 1:
                            CadastrarCliente();
                            break;
                        case 2:
                            ExibirCliente();
                            break;
                        case 3:
                            AtualizarCliente();
                            break;
                        case 4:
                            DeletarCliente();
                            break;
                        case 0:
                            EncerrarPrograma();
                            break;
                        default:
                            Console.WriteLine("---------------------");
                            Console.WriteLine(">>> Opção inválida. <<<");
                            Console.WriteLine("---------------------");
                            break;

                    }

                }
                else 
                {
                    Console.WriteLine("Opção não é válida. Insira um número válido.");                   
                }

            }

        }

        public static void EncerrarPrograma()
        {
            Console.WriteLine("Encerrando o programa. Até mais!");
            continuarExecucao = false;
        }

        public static void VoltarOuSair()
        {
            int voltarOuSair;
            Console.Write("Insira 1 para voltar ao Menu ou 0 para sair: ");           
            if(int.TryParse(Console.ReadLine(), out voltarOuSair)){
                if (voltarOuSair == 1)
                {
                    Console.WriteLine("Voltando para o Menu...");
                    Console.Clear();
                }else if(voltarOuSair == 0)
                {                    
                    EncerrarPrograma();
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente!");
                    VoltarOuSair();
                }
            }
            else 
            {
                Console.WriteLine("Opção inválida. Insira um número válido (1 ou 0):");
                VoltarOuSair();
            }
          
        }

        public static void CadastrarCliente()
        {
            Console.Clear();

            Console.Write("Insira o nome do cliente: ");           
            string nomeDoCliente = Console.ReadLine()!;
            Cliente nomeRepetido = clientes.Find(c => c.Nome == nomeDoCliente);

            if (nomeRepetido != null) 
            {
                Console.Write("Atenção: Já existe um cliente no sistema com esse nome.\nDeseja cadastrar um novo cliente com o mesmo nome? [S]/[N]:");
                string opcaoCadastrarNovo = Console.ReadLine()!;
                if (opcaoCadastrarNovo.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Cadastrando nome...");
                }
                else
                {
                    VoltarOuSair();
                    return;
                }
            }

            Console.Write("Insira o e-mail do cliente: ");
            string emailDoCliente = Console.ReadLine()!;

            Cliente emailRepetido = clientes.Find(c => c.Email == emailDoCliente); // conferir se existe um e-mail igual na lista e atribuir o valor para o objeto emailRepetido            
            if (emailRepetido != null) 
            {
                Console.WriteLine("Esse e-mail já existe no sistema. Cadastre outro.");
            }
            else
            {
                Cliente cliente = new Cliente (nomeDoCliente, emailDoCliente); // crie um objeto chamado cliente do tipo Cliente (classe)
                clientes.Add(cliente); // adiciona o objeto criado (cliente) à lista clientes.

                Console.WriteLine("Cliente adicionado com sucesso!");     
            
            }

            VoltarOuSair();
        }

        public static void ExibirCliente()
        {
            Console.Clear();

            foreach (Cliente cliente in clientes) { 
                Console.WriteLine($"Nome do cliente: {cliente.Nome}"); 
                Console.WriteLine($"E-mail do cliente: {cliente.Email}");
                Console.WriteLine(new string('-', cliente.Email.Length));                
            }
            VoltarOuSair();
        }

        public static void AtualizarCliente()
        {
            Console.Write("Digite o nome do cliente que deseja editar: ");
            string nomeDoCliente = Console.ReadLine()!;

            Cliente cliente = clientes.Find(c => c.Nome == nomeDoCliente);

            if (cliente != null)
            {
                Console.Write("Insira o novo nome do cliente: ");
                string clienteNovoNome = Console.ReadLine()!;

                Console.Write("Insira o novo e-mail do cliente: ");
                string clienteNovoEmail = Console.ReadLine()!;

                cliente.Nome = clienteNovoNome;
                cliente.Email = clienteNovoEmail;

                Console.WriteLine("Cliente editado com sucesso!");

                VoltarOuSair();

            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
                VoltarOuSair();
            }    
        }

        public static void DeletarCliente()
        {
            Console.Write("Insira o nome do cliente que deseja apagar o cadastro: ");
            string nomeDoCliente = Console.ReadLine()!;
            
            Cliente cliente = clientes.Find(c => c.Nome == nomeDoCliente);

            if (cliente != null)
            {
                clientes.Remove(cliente);
                Console.WriteLine("Cliente removido do sistema!");
                VoltarOuSair() ;
            }
            else 
            {
                Console.WriteLine("Cliente não encontrado.");
                VoltarOuSair();
            }
        }
    }   
}
