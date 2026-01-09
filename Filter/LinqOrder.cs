using System;
using System.Collections.Generic;
using System.Text;
using ScreenSoundAPI.Model;
namespace ScreenSoundAPI.Filter
{
    internal class LinqOrder
    {
        public static void ExibirListaDeArtistasOrdenados(List<Musica>musicas) {
            var artistasOrdenados = musicas.Select(musica => musica.Artista).Distinct().OrderBy(artista => artista).ToList();
            artistasOrdenados.ForEach(artista => Console.WriteLine(artista));
        }
    }
}
