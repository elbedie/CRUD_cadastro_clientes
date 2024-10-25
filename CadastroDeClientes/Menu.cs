using CadastroDeClientes.Banco;
using System.Linq;

namespace CadastroDeClientes
{
    public class Menu
    {
        static bool continuarExecucao = true; // Controlar o while do menu 

        public static void ExibirTitulo()
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("        CONTROLE DE CLIENTES        ");
            Console.WriteLine("=====================================");
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
                            VoltarOuSair();
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
            Console.Write("Insira 1 para voltar ao Menu ou 0 para sair: ");
            if (int.TryParse(Console.ReadLine(), out int voltarOuSair))
            {
                if (voltarOuSair == 1)
                {
                    Console.WriteLine("Voltando para o Menu...");
                    Console.Clear();
                }
                else if (voltarOuSair == 0)
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
            string nomeDoCliente = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nomeDoCliente))
            {
                Console.WriteLine("Nome do cliente não pode ser vazio. Tente novamente.");
                return;
            }

            Console.Write("Insira o e-mail do cliente: ");
            string emailDoCliente = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(emailDoCliente) || !emailDoCliente.Contains("@"))
            {
                Console.WriteLine("E-mail inválido. Tente novamente.");
                return;
            }

            try
            {
                var clienteDAL = new ClienteDAL();
                clienteDAL.AdicionarCliente(new Cliente(nomeDoCliente, emailDoCliente));
                Console.WriteLine("Cliente cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar cliente: {ex.Message}");
            }

            VoltarOuSair();
        }

        public static void ExibirCliente()
        {
            try
            {
                var clientes = new ClienteDAL();
                var listaDeClientes = clientes.Listar();

                if (!listaDeClientes.Any())
                {
                    Console.WriteLine("Nenhum cliente cadastrado.");
                    return;
                }

                foreach (var cliente in listaDeClientes)
                {
                    Console.WriteLine(cliente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exibir clientes: {ex.Message}");
            }
        }

        public static void AtualizarCliente()
        {
            Console.Clear();
            ExibirCliente();

            Console.WriteLine("Insira o ID do cliente que deseja atualizar os dados: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Tente novamente.");
                return;
            }

            Console.WriteLine("Insira o novo nome do cliente: ");
            string novoNome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(novoNome))
            {
                Console.WriteLine("Nome inválido. Tente novamente.");
                return;
            }

            Console.WriteLine("Insira o novo e-mail do cliente: ");
            string novoEmail = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(novoEmail) || !novoEmail.Contains("@"))
            {
                Console.WriteLine("E-mail inválido. Tente novamente.");
                return;
            }

            try
            {
                var clienteDAL = new ClienteDAL();
                var cliente = new Cliente(novoNome, novoEmail);
                clienteDAL.AtualizaCliente(id, cliente);
                Console.WriteLine("Cliente atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar cliente: {ex.Message}");
            }
        }

        public static void DeletarCliente()
        {
            Console.Clear();
            ExibirCliente();

            Console.WriteLine("Insira o Id do cliente que deseja deletar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido. Tente novamente.");
                return;
            }

            try
            {
                var clienteDAL = new ClienteDAL();
                int linhasAfetadas = clienteDAL.DeletaCliente(id);
                if (linhasAfetadas > 0)
                {
                    Console.WriteLine("Cliente deletado com sucesso.");
                }
                else
                {
                    Console.WriteLine("Nenhum cliente encontrado com o ID fornecido.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao deletar cliente: {ex.Message}");
            }
        }

    }
}
