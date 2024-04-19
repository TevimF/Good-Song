namespace GoodSong.Models;
internal class Banda : IAvaliavel
{
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

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        foreach (Album album in albuns)
        {
            Console.WriteLine();
            int espacos = 25 - album.Nome.Length;
            string ocupaEspacos = string.Empty.PadLeft(espacos, ' ');
            Console.WriteLine($"Álbum: {album.Nome} {ocupaEspacos} Avaliação: {album.Media} \nDuração:({album.DuracaoTotal}) min");
            Console.WriteLine();
        }
    }
}