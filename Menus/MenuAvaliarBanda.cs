
using GoodSong.Models;

namespace GoodSong.Menus;

internal class MenuAvaliarBanda : Menu
{
    public override void Executar(Dictionary<string, Banda> bandasRegistradas) // sobrescreve o método Executar da classe pai
    {
        
        AvaliacaoDeBandas();   // chama o método AvaliacaoDeBandas
        void AvaliacaoDeBandas()
        {
            base.Executar(bandasRegistradas); // o base serve para chamar o método da classe pai
            ExibirTituloOpcao("Avaliação de Bandas");
            Console.WriteLine("Insira o nome da banda que deseja avaliar ou digite [0] para voltar ao menu de opções: ");
            string selecionada = Console.ReadLine()!;
            Thread.Sleep(1000);
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
            AvaliacaoDeBandas();
        }
    }
}
