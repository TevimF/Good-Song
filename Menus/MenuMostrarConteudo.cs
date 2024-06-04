
using GoodSong.Models;

namespace GoodSong.Menus;
using GoodSong.Filter;

internal class MenuMostrarConteudo : Menu
{
    int? paginaAtual = 0;
    public void MostrarBandasRegistradas(Dictionary<string, Banda> bandasRegistradas, int? pagina = 1)
    {
        if (bandasRegistradas.Count <= 0) // verifica se há bandas registradas
        {
            ExibirTituloOpcao("Nenhuma banda registrada");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("Estas são as bandas adicionadas: \n");
            var listaBandas = LinqOrder.OrdenarPorNome(bandasRegistradas);
            int itensPorPagina = 15;
            int totalPaginas = (int)(listaBandas.Count / itensPorPagina);
            if (pagina == null || pagina <= 0 || pagina! > totalPaginas)
            {
                pagina = 1;
            }
            paginaAtual = pagina;
            Console.WriteLine(paginaAtual + "/" + totalPaginas);
            for (int i = 0; i < itensPorPagina; i++)
            {
                var banda = listaBandas.ElementAt(i + (pagina - 1).Value * itensPorPagina).Value;
                int espacos = 30 - banda.Nome.Length;
                string ocupaEspacos = string.Empty.PadLeft(espacos, ' ');
                Console.WriteLine(banda.Nome.ToUpper() + ocupaEspacos + $" Avaliação: {ExibirMediaAvaliacoes(banda)}");
            }
            Console.WriteLine("\n");
        }
    }
    public void ExibirAlbuns(Banda banda)
    {
        Console.Clear();
        if (banda.Albuns.Count <= 0) // verifica se há albuns
        {
            Console.WriteLine($"Nenhum Album registrado para {banda.Nome}\n");
        }
        else
        {
            ExibirTituloOpcao($"Discografia da banda {banda.Nome}:");
            banda.ExibirDiscografia();
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }
    }
    public void ExibirMusicas(Banda banda)
    {
        if (banda.Musicas == null)
        {
            Console.WriteLine("Nenhuma música registrada para essa banda");
            Thread.Sleep(2000);
            return;
        }
        ExibirTituloOpcao($"Músicas da banda {banda.Nome}:");
        banda.ExibirMusicasDaBanda();
        Console.WriteLine("Deseja saber mais sobre alguma música? Pode digitar a ordem dela numericamente, o nome para acessar ou digitar [0] para voltar!");
        string resposta = Console.ReadLine()!;
        if (int.TryParse(resposta, out int numero) && numero <= banda.Musicas.Count && numero != 0)
        {
            Musica musica = banda.Musicas[numero - 1];
            Console.Clear();
            ExibirTituloOpcao($"Música {musica.Nome}");
            Console.WriteLine("Informações sobre a música:");
            musica.ExibirFichaTecnica();
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }
        else if (CadeAMusica(resposta, banda) != null)
        {
            Musica musica = CadeAMusica(resposta, banda)!;
            Console.Clear();
            ExibirTituloOpcao($"Música {musica.Nome}");
            Console.WriteLine("Informações sobre a música:");
            musica.ExibirFichaTecnica();
            Console.WriteLine("Pressione qualquer tecla para voltar");
            Console.ReadKey();
        }
        else if (resposta == "0")
        {
            return;
        }
        else
        {
            Console.WriteLine("Música não encontrada");
            Thread.Sleep(1000);
            ExibirMusicas(banda);
        }
    }
    public float ExibirMediaAvaliacoes(Banda banda)
    {
        if (banda.Media == null)
        {
            return 0;
        }
        return (float)banda.Media; // exibe a média de avaliações da banda
    }
    public override void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        MostrarConteudo();
        void MostrarConteudo()
        {
            base.Executar(bandasRegistradas);
            ExibirTituloOpcao("Mostrar Bandas adicionadas");
            MostrarBandasRegistradas(bandasRegistradas, paginaAtual);
            Console.WriteLine("Digite o nome de uma banda que deseja ver, digite um espaço vazio [ ] para a próxima página, digite um numero para ir para uma pagina especifica, digite [filtrar] para filtrar musicas ou digite [0] para voltar ao menuOptions:");
            string resposta = Console.ReadLine()!;
            if (resposta == "0")
            {
            }
            else if (resposta == " ")
            {
                Console.WriteLine("Próxima página");
                Thread.Sleep(500);
                paginaAtual++;
                MostrarConteudo();
            }
            else if (resposta == "filtrar")
            {
                Console.Clear();
                ExibirTituloOpcao("Filtro de músicas");
                LinqFilter.FiltrarGeneros(bandasRegistradas);
                Console.WriteLine("\nDigite o diretamente o gênero que deseja filtrar:");
                string genero = Console.ReadLine()!;
                LinqFilter.FiltrarArtistasPorGenero(bandasRegistradas.Values.SelectMany(banda => banda.Musicas!).ToList(), genero);
                Console.WriteLine("Aperte qualquer tecla para voltar");
                Console.ReadKey();
            }
            else if (CadeEla(resposta, bandasRegistradas) != null)
            {
                Banda banda = CadeEla(resposta, bandasRegistradas)!;
                ExibirAlbuns(banda);
                ExibirMusicas(banda);
                MostrarConteudo();
            }
            else if (int.TryParse(resposta, out int numero))
            {
                Console.WriteLine("Página específica");
                Thread.Sleep(500);
                paginaAtual = numero;
                MostrarConteudo();
            }
            else
            {
                Console.WriteLine("Banda não encontrada");
                Thread.Sleep(1000);
                MostrarConteudo();
            }
        }
    }
}
