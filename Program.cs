
using GoodSong.Menus;
using GoodSong.Models;
using GoodSong.Filter;
using System.Text.Json;

Dictionary<string, Banda> bandasRegistradas = new();
Banda teste = new("Banda teste");
bandasRegistradas.Add(teste.Nome, teste);
teste.AdicionarAlbum(new Album("Álbum teste"));
 List < Musica > musicasJson = new();

using (HttpClient client = new())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta);
        int quantidade = musicas?.Count ?? 0;
        if (quantidade == 0)
        {
            Console.WriteLine("Nenhuma música encontrada.");
            return;
        }
        musicasJson = musicas!;
    }
    catch (Exception excecao)
    {
        Console.WriteLine($"Erro ao acessar a API: {excecao.Message}");
    }
}

void Start()
{
    // Adiciona as bandas e músicas do JSON
    foreach (var musica in musicasJson)
    {
        if (musica.Artista != null)
        {
            if (!bandasRegistradas.ContainsKey(musica.Artista))
            {
                bandasRegistradas[musica.Artista] = new Banda(musica.Artista);
            }
            bandasRegistradas[musica.Artista].AdicionarMusica(musica);
        }
    }
    MenuBoasVindas menuBoasVindas = new();
    menuBoasVindas.Executar();
   
    MenuOpcoes menuOpcoes = new();
    menuOpcoes.Executar(bandasRegistradas);
}
Start();