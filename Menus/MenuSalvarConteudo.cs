using GoodSong.Models;
using System.Text.Json;
namespace GoodSong.Menus
{
    internal class MenuSalvarConteudo : Menu
    {
        MenuMostrarConteudo menuMostrarConteudo = new();
        int paginaAtual = 1;

        private void Menu(Banda banda, Dictionary<string, Banda> bandasRegistradas)
        {
            Console.Clear();
            Console.WriteLine("Qual música você deseja adicionar aos favoritos?");
            string musica = Console.ReadLine()!;
            Musica? musicaFavorita = CadeAMusica(musica, banda);
            string nomeArquivo = "musica-favoritas.json";
            if (musicaFavorita != null)
            {
                string path = SalvarMusica(musicaFavorita, nomeArquivo);
                Console.WriteLine($"Músicas salvas com sucesso! {path}");
                Thread.Sleep(4000);
            }
            else
            {
                Console.WriteLine("Música não encontrada");
                Thread.Sleep(1000);
                Executar(bandasRegistradas);
            }
        }
        public string SalvarMusica(Musica musica, string nomeArquivo)
        {
            
            Console.WriteLine("Salvando música...");
            List<Musica> listaMusicas = new List<Musica>();
            listaMusicas.Add(musica);
            string json = JsonSerializer.Serialize(new
            {
                nome = musica.Nome,
                artista = musica.Artista,
                genero = musica.Genero,
                duracao = musica.Duracao,
                chave = musica.Chave
            });
            string nomeDoArquivo = nomeArquivo;
            File.AppendAllText(nomeDoArquivo, json);
            return Path.GetFullPath(nomeDoArquivo);
    }

        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            Console.Clear();
            ExibirTituloOpcao("Salvar Conteúdo");
            menuMostrarConteudo.MostrarBandasRegistradas(bandasRegistradas, paginaAtual);
            Console.WriteLine("Digite o nome da banda que a música pertence para adicionar aos favoritos, digite um espaço vazio [ ] para a próxima página, digite um número para ir para uma página específica ou digite [0] para voltar ao menuOptions:");
            string resposta = Console.ReadLine()!;
            // voltar
            if (resposta == "0")
            {
                return;
            }
            // próxima página
            else if (resposta == " ")
            {
                Console.WriteLine("Próxima página");
                Thread.Sleep(500);
                paginaAtual++;
                Executar(bandasRegistradas);
            }
            //pagina específica
            else if (int.TryParse(resposta, out int numero))
            {
                Console.WriteLine("Página específica");
                Thread.Sleep(500);
                paginaAtual = numero;
                Executar(bandasRegistradas);
            }
            // salvar música
            else if (CadeEla(resposta, bandasRegistradas) != null)
            {
                Console.Clear();
                Console.WriteLine("Deseja limpar o arquivo de músicas favoritas? [limpar] ou adicionar uma nova música? ");
                string limpar = Console.ReadLine()!;
                if (limpar == "limpar")
                {
                    File.WriteAllText("musica-favoritas.json", "");
                    Console.WriteLine("Arquivo de músicas favoritas limpo.");
                    Thread.Sleep(1000);
                }
                Console.Clear();
                Banda banda = CadeEla(resposta, bandasRegistradas)!;
                menuMostrarConteudo.ExibirMusicas(banda);
                Console.WriteLine("\nDeseja adicionar uma musica específica [musica] ou todas desse artista? [todas] Para voltar digite [0]");
                string respostaMusica = Console.ReadLine()!;
                if(respostaMusica == "0")
                {
                    return;
                }
                else if(respostaMusica == "todas")
                {
                    string nomeArquivo = "musica-favoritas.json";
                    var lista = banda.Musicas!.Distinct().ToList();
                    Console.WriteLine($"Salvando todas as {lista.Count()} músicas...");
                    string path = "undefined";
                    foreach (Musica musica in lista)
                    {
                        path =  SalvarMusica(musica, nomeArquivo);
                    }
                    Console.WriteLine($"Músicas salvas com sucesso! {path}");
                    Thread.Sleep(4000);
                }
                else if(respostaMusica == "musica")
                {
                    Menu(banda, bandasRegistradas);
                }
            }
            else
            {
                Console.WriteLine("Banda não encontrada");
                Thread.Sleep(1000);
                Executar(bandasRegistradas);
            }
        }
    }
}
