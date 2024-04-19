
using GoodSong.Menus;
using GoodSong.Models;

Dictionary<string, Banda> bandasRegistradas = new();
Banda teste = new("Banda teste");
bandasRegistradas.Add(teste.Nome, teste);
teste.AdicionarAlbum(new Album("Álbum teste"));
void Start()
{
    MenuBoasVindas menuBoasVindas = new();
    menuBoasVindas.Executar();
   
    MenuOpcoes menuOpcoes = new();
    menuOpcoes.Executar(bandasRegistradas);
}
Start();