namespace GoodSong.Models;

internal class Avaliacao
{
    public Avaliacao(float nota)
    {
        if(nota< 0) // verifica se a avaliação está dentro do intervalo
        {
            nota = 0;
        }
        else if (nota > 10)
        {
            nota = 10;
        }
        Nota = nota;
    }
    public float Nota { get; }
    static public Avaliacao Parse(string str)
    {
        float notaFloat = float.Parse(str); // o método Parse converte uma string em um float
        return new Avaliacao(notaFloat);
    }
}
