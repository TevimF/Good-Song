namespace GoodSong.Models;

internal class Banda : IAvaliavel
{
    private List<Musica> musicas = new List<Musica>();
    private List<Album> albuns = new List<Album>();
    private List<Avaliacao> notas = new List<Avaliacao>();

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public float? Media
    {
        get
        {
            if (notas.Count <= 0)
            {
                return null;
            }
            return notas.Average(a => a.Nota);  // o => é uma expressão lambda
            //aqui diz que para cada avaliação a, pegue a nota dela
        }
    }
    public List<Album> Albuns => albuns;
    public List<Musica>? Musicas => musicas;

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }
    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }
    public void ExibirDiscografia()
    {
        if (albuns.Count <= 0)
        {
            Console.WriteLine("Nenhum álbum registrado.");
            return;
        }
        foreach (Album album in albuns)
        {
            Console.WriteLine();
            int espacos = 25 - album.Nome.Length;
            string ocupaEspacos = string.Empty.PadLeft(espacos, ' ');
            Console.WriteLine($"Álbum: {album.Nome} {ocupaEspacos} Avaliação: {album.Media} \nDuração:({album.DuracaoTotal}) min");
            Console.WriteLine();
        }
    }
    public void ExibirMusicasDaBanda()
    {
        if (musicas.Count <= 0)
        {
            Console.WriteLine("Nenhuma música registrada.");
            return;
        }
        for (int i = 0; i < musicas.Count; i++)
        {
            Musica musica = musicas[i];
            Console.WriteLine($"{i + 1} - Música: {musica.Nome} ({(float)musica.Duracao/1000} segundos)");
        }
    }
}