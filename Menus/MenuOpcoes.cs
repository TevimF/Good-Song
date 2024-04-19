

using GoodSong.Models;

namespace GoodSong.Menus
{
    internal class MenuOpcoes : Menu
    {
        Dictionary<int, Menu> opcoes = new()
        {
            {1, new MenuRegistro()},
            {2, new MenuMostrarConteudo()},
            {3, new MenuAvaliarBanda()},
            {4, new MenuExcluirConteudo()}
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
                Console.WriteLine("Digite 3 para avaliar uma banda");
                Console.WriteLine("Digite 4 para excluir uma banda");
                Console.WriteLine("Digite 0 para sair");

                Console.WriteLine("\nDigite a sua opção");
                string opcaoEscolhida = Console.ReadLine()!;
                int opcaoNumerica = int.Parse(opcaoEscolhida);
                if (opcaoNumerica == 0)
                {
                    Console.WriteLine("Tchau!");
                    Thread.Sleep(1000);
                    return;
                }
                else if (opcoes.ContainsKey(opcaoNumerica))
                {
                    Menu menu = opcoes[opcaoNumerica];
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
