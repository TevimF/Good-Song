
using GoodSong.Models;

namespace GoodSong.Menus;

internal class MenuAvaliarConteudo : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas) // sobrescreve o método Executar da classe pai
    {
        
        AvaliacaoDeConteudo();   // chama o método AvaliacaoDeBandas
        void AvaliacaoDeConteudo()
        {
            base.Executar(bandasRegistradas); // o base serve para chamar o método da classe pai
            ExibirTituloOpcao("Avaliação de Conteudo");
            MenuMostrarConteudo menuMostrarConteudo = new();
            menuMostrarConteudo.MostrarBandasRegistradas(bandasRegistradas); // chama o método MostrarBandasRegistradas da classe MenuMostrarConteudo
            Console.WriteLine("Insira o que voce deseja avaliar ou digite voltar ao menu de opções: ");
            Console.WriteLine("[banda] [album] [menu]");
            string selecionada = Console.ReadLine()!;


            if (NormatizarNome(selecionada) == NormatizarNome("banda"))
            {
                AvaliarBanda(selecionada);
            }
            else if (NormatizarNome(selecionada) == NormatizarNome("album"))
            {
                Console.WriteLine("Digite o nome da banda a qual o album pertence");
                string banda = Console.ReadLine()!;
                Banda? bandaSelecionada = CadeEla(banda, bandasRegistradas);
                if (bandaSelecionada != null)
                {
                    AvaliarAlbum(bandaSelecionada);
                }
                else
                {
                    Console.WriteLine("Banda não registrada, tente novamente");
                    Thread.Sleep(1000);
                    AvaliacaoDeConteudo();
                }
            }
            else if (NormatizarNome(selecionada) == NormatizarNome("menu"))
            {
                return;
            }
            else
            {
                Console.WriteLine("Opção inválida");
                Thread.Sleep(1000);
                AvaliacaoDeConteudo();
            }
        }
        void AvaliarAlbum(Banda bandaSelecionada)
        {
            Console.Clear();
            ExibirTituloOpcao("Avaliação de Albuns");
            bandaSelecionada.ExibirDiscografia();
            Console.WriteLine("Digite o nome do album que deseja avaliar ou digite [0] para voltar ao menuOptions: ");
            string albumSelecionado = Console.ReadLine()!;
            if (albumSelecionado == "0")
            {
                return;
            }
            if (CadeOAlbum(albumSelecionado, bandaSelecionada) != null)
            {
                Album albumEncontrado = CadeOAlbum(albumSelecionado, bandaSelecionada)!;
                Console.WriteLine("Insira a sua avaliação para o album {0} de [0] a [10] ", albumEncontrado.Nome);
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!); // converte a entrada do usuário para float
                albumEncontrado.AdicionarNota(nota);
                Console.WriteLine("O album {0} foi avaliado!", albumEncontrado.Nome);
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("Album não registrado,tente novamente");
                Thread.Sleep(1000);
                AvaliacaoDeConteudo();
            }
        }
        void AvaliarBanda(string selecionada)
        {
            if (selecionada == "0")
            {
                Console.Clear();
                return;
            }
            else if (CadeEla(selecionada, bandasRegistradas) != null)
            {
                Banda banda = CadeEla(selecionada, bandasRegistradas)!; // pega a banda selecionada pelo usuário
                Console.WriteLine("Insira a sua avaliação para a banda {0} de [0] a [10] ", banda.Nome);
                Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!); // converte a entrada do usuário para float
                foreach (string nome in bandasRegistradas.Keys)
                {
                    if (NormatizarNome(nome) == NormatizarNome(selecionada))
                    {

                        banda.AdicionarNota(nota); // adiciona a avaliação à banda
                        break;
                    }
                }
                Console.WriteLine("A banda {0} foi avaliada!", banda.Nome);
                Thread.Sleep(1500);
            }
            else
            {
                Console.WriteLine("\nBanda não registrada, digite novamente");
                Thread.Sleep(1000);
            }
            AvaliacaoDeConteudo();
        }
    }
}
