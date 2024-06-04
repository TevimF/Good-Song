

using GoodSong.Models;
using GoodSong.Menus;

namespace GoodSong.Menus
{
    internal class MenuOpcoes : Menu
    {
        Dictionary<int, Menu> opcoes = new()
        {
            {1, new MenuRegistro()},
            {2, new MenuMostrarConteudo()},
            {3, new MenuAvaliarConteudo()},
            {4, new MenuExcluirConteudo()},
            {5, new MenuSalvarConteudo()},
        };
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            ExibirOpcoesMenu();
            void ExibirOpcoesMenu()
            {
                base.Executar(bandasRegistradas);
                ExibirTituloOpcao("- - - MENU INICIAL - - -");
                Console.WriteLine("\nDigite 1 para registrar um conteúdo");
                Console.WriteLine("Digite 2 para mostrar um conteúdo");
                Console.WriteLine("Digite 3 para avaliar um conteúdo");
                Console.WriteLine("Digite 4 para excluir um conteúdo");
                Console.WriteLine("Digite 5 para salvar seus favoritos");
                Console.WriteLine("Digite 0 para sair");

                Console.WriteLine("\nDigite a sua opção");

                string opcaoEscolhida = Console.ReadLine()!;
                if (opcaoEscolhida == "0")
                {
                    Console.WriteLine("Tchau!");
                    Thread.Sleep(1000);
                    return;
                }
                else if (int.TryParse(opcaoEscolhida, out int numero) && opcoes.Count() >= numero)
                {
                    Menu menu = opcoes[numero];
                    menu.Executar(bandasRegistradas);
                    ExibirOpcoesMenu();
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(1000);
                    ExibirOpcoesMenu();
                }
            }
        }
    }
}
