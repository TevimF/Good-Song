using System.Text.Json.Serialization;

namespace GoodSong.Models;
internal class Musica
{
    private string[] Tonalidades = new string[] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
    public Musica(Banda banda, string nome)
    {
        Banda = banda;
        Nome = nome;
    }
    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    public Banda? Banda { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("key")]
    public int Chave { get; set; }
    public bool Disponivel { get; set; }
    public string DescricaoResumida => $"A música {Nome} pertence à banda {Banda}";
    public string Tonalidade => Tonalidades[Chave];

    public void ExibirFichaTecnica()
    {
        Console.WriteLine($"Nome: {Nome}");
        if (Banda != null)
        {
            Console.WriteLine($"Artista: {Banda.Nome}");
        }
        Console.WriteLine($"Gênero: {Genero}");
        Console.WriteLine($"Tonalidade: {Tonalidade}");
        Console.WriteLine($"Duração: {(float)Duracao/1000} segundos");
        if (Disponivel)
        {
            Console.WriteLine("Disponível no plano.");
        } else
        {
            Console.WriteLine("Adquira o plano Plus+");
        }
    }
}