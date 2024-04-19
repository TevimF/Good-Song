
using GoodSong.Models;

namespace GoodSong.Menus;

internal class Menu
{
    public void ExibirTituloOpcao(string titulo)
    {
        int quantidadeCaracteres = titulo.Length;
        string asteriscos = string.Empty.PadLeft(quantidadeCaracteres, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(titulo);
        Console.WriteLine(asteriscos + "\n");
    }
    public string NormatizarNome(string banda)
    {
        banda = banda.ToLower();
        banda = banda.ReplaceLineEndings("");
        banda = banda.Replace(" ", "");
        // tirar acentos
        string[] comAcento = { "á", "é", "í", "ó", "ú", "â", "ê", "î", "ô", "û", "ã", "õ", "ç" };
        string[] semAcento = { "a", "e", "i", "o", "u", "a", "e", "i", "o", "u", "a", "o", "c" };
        for (int i = 0; i < comAcento.Length; i++)
        {
            banda = banda.Replace(comAcento[i], semAcento[i]);
        }
        return banda;
    }
    public Banda? CadeEla(string banda, Dictionary<string, Banda> bandasRegistradas)
    {
        foreach (string bandaContida in bandasRegistradas.Keys)
        {
            if (NormatizarNome(banda) == NormatizarNome(bandaContida))
            {
                return bandasRegistradas[bandaContida];
            }
        }
        return null;
    }

    public virtual void Executar(Dictionary<string, Banda> bandasRegistradas)
    {
        Console.Clear();
    }
}
