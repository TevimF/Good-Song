
using GoodSong.Menus;
using GoodSong.Models;
internal class Program
{
    private static void Main(string[] args)
    {
    Dictionary<string, Banda> bandasRegistradas = new();
    Banda teste = new("Banda teste");
    bandasRegistradas.Add("bandateste", teste);
    void Start()
    {
        MenuBoasVindas menuBoasVindas = new();
        menuBoasVindas.Executar();
        MenuOpcoes menuOpcoes = new();
        menuOpcoes.Executar(bandasRegistradas);
    }
    Start();
    }
}

