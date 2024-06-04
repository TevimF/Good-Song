 using System;
using System.Collections.Generic;
using System.Linq;
using GoodSong.Models;

namespace GoodSong.Filter
{
    internal class LinqFilter
    {
        public static void FiltrarGeneros(Dictionary<string, Banda> bandas)
        {
            // seleciona todos os generos musicais e remove duplicatas
            var todosGeneros = bandas.Select(banda => banda.Value.Musicas!.Select(musica => musica.Genero)).Distinct().ToList();
            foreach (var genero in todosGeneros)
            {
                Console.WriteLine(genero);
            }
        }
        public static void FiltrarArtistasPorGenero(List<Musica> musicas, string genero)
        {
            var artistasPorGeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().ToList();
            Console.WriteLine($"Exibindo os artistas por gênero musical >>> {genero}");
            foreach (var artista in artistasPorGeneroMusical)
            {
                Console.WriteLine($"- {artista}");
            }
        }
        public static void FiltrarMusicasPorArtista(List<Musica> musicas, string artista)
        {
            var musicasPorArtista = musicas.Where(musica => musica.Artista!.ToLower().Contains(artista.ToLower())).ToList();
            Console.WriteLine($"Exibindo as músicas do artista >>> {artista}");
            foreach (var musica in musicasPorArtista)
            {
                Console.WriteLine($"- {musica.Nome}");
            }
        }
    }
}



