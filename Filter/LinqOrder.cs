using System;
using System.Collections.Generic;
using System.Linq;
using GoodSong.Models;


namespace GoodSong.Filter
{
    internal class LinqOrder
    {
        public static void OrdenarPorNome(List<Musica> musicas)
        {
            var artistasOrdenados = musicas.OrderBy(musica => musica.Artista).Select(musica => musica.Artista).Distinct().ToList();
            //foreach (var artista in artistasOrdenados)
            //{
            //	Console.WriteLine(artista);
            //}
        }
        public static Dictionary<string, Banda> OrdenarPorNome(Dictionary<string, Banda> bandas)
        {
            var bandasOrdenadas = bandas.OrderBy(banda => banda.Value.Nome).ToDictionary(banda => banda.Key, banda => banda.Value);
            return bandasOrdenadas;
        }
    }
}

