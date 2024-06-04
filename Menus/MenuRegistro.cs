
using GoodSong.Models;

namespace GoodSong.Menus
{
    internal class MenuRegistro : Menu
    {
        public override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            Registro();
            void Registro()
            {
                base.Executar(bandasRegistradas);
                ExibirTituloOpcao("Opçoes de Registro");
                Console.WriteLine("O que você deseja registrar?");
                Console.WriteLine("[banda] [album] [voltar]");
                string resposta = NormatizarNome(Console.ReadLine()!);
                if (resposta == NormatizarNome("banda"))
                {
                    RegistrarBanda();
                }
                else if (resposta == NormatizarNome("album"))
                {
                    RegistrarAlbum();
                }
                else if (resposta == NormatizarNome("voltar"))
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                    Thread.Sleep(1000);
                    Registro();
                }

            }
            void RegistrarBanda()
            {
                Console.Clear();
                ExibirTituloOpcao("Registro de Bandas");
                Console.WriteLine("Digite o nome da banda a ser registrada ou digite [0] para sair: ");
                string nomeBanda = Console.ReadLine()!;
                Banda banda = new(nomeBanda); //cria uma banda com a entrada do usuário
                if (nomeBanda == "0")
                {
                    Console.WriteLine("Voltando ao menu...");
                    Thread.Sleep(1000); // esperar um tempo até dar a resposta
                    Console.Clear();
                    return;
                }
                else if (CadeEla(nomeBanda, bandasRegistradas) != null) // verifica se a banda já foi registrada
                {
                    Console.WriteLine("Banda semelhante já registrada, digite novamente");
                    Thread.Sleep(1000);
                    RegistrarBanda();
                }
                else if (nomeBanda != null)
                {
                    bandasRegistradas.Add(nomeBanda, banda);
                    Console.WriteLine("A banda {0} foi registrada com Sucesso!", nomeBanda);
                }
                Thread.Sleep(1000);
                RegistrarBanda();
            }
            void RegistrarAlbum()
            {
                Console.Clear();
                ExibirTituloOpcao("Registro de Álbuns");
                MenuMostrarConteudo menuMostrarConteudo = new();
                menuMostrarConteudo.MostrarBandasRegistradas(bandasRegistradas);
                Console.WriteLine("Digite o nome da banda que o álbum pertence ou digite [0] para voltar ao menu: ");
                string nomeBanda = Console.ReadLine()!;
                if (nomeBanda == "0")
                {
                    Console.WriteLine("Voltando ao menu...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                }
                else
                if (CadeEla(nomeBanda, bandasRegistradas) == null)
                {
                    Console.WriteLine("Banda não registrada, digite novamente");
                    Thread.Sleep(1000);
                    RegistrarAlbum();
                }
                else
                {
                    Banda banda = CadeEla(nomeBanda, bandasRegistradas)!;
                    Console.WriteLine("Agora, digite o nome do álbum: ");
                    string nomeAlbum = Console.ReadLine()!;
                    Album album = new(nomeAlbum);
                    banda.AdicionarAlbum(album);
                    Console.WriteLine("Álbum adicionado com sucesso!");
                    Thread.Sleep(1000);
                    RegistrarAlbum();
                }
            }
        }
    }
}
