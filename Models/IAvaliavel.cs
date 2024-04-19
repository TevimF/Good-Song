
namespace GoodSong.Models;

internal interface IAvaliavel
{
    // nao é um executavel, é um contrato
    // isso diz se uma classe implementa essa interface, ela deve ter esses métodos
    void AdicionarNota(Avaliacao nota);
    float? Media { get; }
}
