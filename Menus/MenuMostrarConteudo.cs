
using GoodSong.Models;

namespace GoodSong.Menus;

internal class MenuMostrarConteudo : Menu
{
    public void MostrarBandasRegistradas(Dictionary<string, Banda> bandasRegistradas)
    {
        if (bandasRegistradas.Count <= 0) // verifica se há bandas registradas
        {
            ExibirTituloOpcao("Nenhuma banda registrada");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {

            ExibirTituloOpcao("Mostrar Bandas adicionadas");
            Console.WriteLine("Estas são as bandas adicionadas: \n");
            foreach (Banda banda in bandasRegistradas.Values)
            {
                int espacos = 30 - banda.Nome.Length;
                string ocupaEspacos = string.Empty.PadLeft(espacos, ' ');
                Console.WriteLine(banda.Nome.ToUpper() + ocupaEspacos + $" Avaliação: {ExibirMediaAvaliacoes(banda)}");
            }
            Console.WriteLine("\n");
        }
    }
    void ExibirAlbuns(Banda banda)
    {
        Console.Clear();
        if (banda.Albuns.Count <= 0) // verifica se há albuns
        {
            ExibirTituloOpcao($"Nenhum Album registrado para {banda.Nome}");
            Thread.Sleep(2000);
            Console.Clear();
        }
        else
        {
            ExibirTituloOpcao($"Discografia da banda {banda.Nome}:");
            banda.ExibirDiscografia();
            Console.WriteLine("Pressione qualquer tecla para voltar ao menuOptions");
            Console.ReadKey();
        }
    }
    float ExibirMediaAvaliacoes(Banda banda)
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
            MostrarBandasRegistradas(bandasRegistradas);
            Console.WriteLine("Digite o nome de uma banda que deseja ver ou digite [0] para voltar ao menuOptions:");
            string resposta = Console.ReadLine()!;
            if (resposta == "0")
            {
            }
            else if (CadeEla(resposta, bandasRegistradas) != null)
            {
                Banda banda = CadeEla(resposta, bandasRegistradas)!;
                ExibirAlbuns(banda);
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
