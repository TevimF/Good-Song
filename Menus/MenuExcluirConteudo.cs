
using GoodSong.Models;

namespace GoodSong.Menus;

internal class MenuExcluirConteudo : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {

        ExcluirConteudo();
        void ExcluirConteudo()
        {
            base.Executar(bandasRegistradas);
            ExibirTituloOpcao("Exclusão de Conteúdo");
            MenuMostrarConteudo menuMostrarConteudo = new();
            menuMostrarConteudo.MostrarBandasRegistradas(bandasRegistradas);
            Console.WriteLine("\nQuer exluir uma banda, um conteúdo da banda ou voltar ao menu?");
            Console.WriteLine("[banda] [conteudo] [menu]");
            string exclusao = Console.ReadLine()!;
            if (NormatizarNome(exclusao) == NormatizarNome("banda"))
            {
                Console.WriteLine("Insira o nome da banda que deseja excluir");
                exclusao = Console.ReadLine()!;
                if (CadeEla(exclusao, bandasRegistradas) == null)
                {
                    Console.WriteLine("Banda não encontrada");
                    Thread.Sleep(1000);
                    ExcluirConteudo();
                }
                else
                {
                    ExcluirBanda(CadeEla(exclusao, bandasRegistradas)!);
                }
            }
            else if (exclusao == "conteudo")
            {
                ExcluirConteudoDaBanda();
            }
            else if (exclusao == "menu")
            {
                return;
            }
            else
            {
                Console.WriteLine("Opção inválida");
                Thread.Sleep(1000);
                ExcluirConteudo();
            }
        }
        void ExcluirBanda(Banda foiComDeus)
        {
            Console.WriteLine("Você deseja excluir a banda {0}? [s] [n]", foiComDeus.Nome);
            string resposta = Console.ReadLine()!;
            if (resposta == "n")
            {
                ExcluirConteudo();
            }
            else
            {
                bandasRegistradas.Remove(foiComDeus.Nome);
            }
            ExcluirConteudo();
        }
        void ExcluirConteudoDaBanda()
        {
            Console.Clear();
            ExibirTituloOpcao("Exclusão de Conteúdo");
            MenuMostrarConteudo menuMostrarConteudo = new();
            menuMostrarConteudo.MostrarBandasRegistradas(bandasRegistradas);
            Console.WriteLine("Insira o nome da banda que voce deseja deletar o conteudo");
            string nomeBanda = Console.ReadLine()!;
            if (CadeEla(nomeBanda, bandasRegistradas) == null)
            {
                Console.WriteLine("Banda não encontrada");
                Thread.Sleep(1000);
                ExcluirConteudo();
            }
            else
            {
                Banda banda = CadeEla(nomeBanda, bandasRegistradas)!;
                banda.ExibirDiscografia();
                banda.ExibirMusicasDaBanda();
                Console.WriteLine("Insira o nome da musica ou album que deseja deletar");
                string selecao = Console.ReadLine()!;
                if (CadeAMusica(selecao, banda)!= null)
                {
                    Musica musica = CadeAMusica(selecao, banda)!;
                    banda.Musicas.Remove(musica);
                    Console.WriteLine($"Musica {musica.Nome} deletada com sucesso");
                    Thread.Sleep(1000);
                    ExcluirConteudo();
                }
                else if (CadeOAlbum(selecao, banda) == null)
                {
                    Console.WriteLine("Album não encontrado");
                    Thread.Sleep(1000);
                    ExcluirConteudo();
                }
                else
                {
                    Album album = CadeOAlbum(selecao, banda)!;
                    banda.Albuns.Remove(album);
                    Console.WriteLine("Album deletado com sucesso");
                    Thread.Sleep(1000);
                    ExcluirConteudo();
                }
            }
        }
    }
}
