using ScreenSoundAPI.Model;

class LinqFilter
{
    public static List<string> FiltrarTodosOsGenerosMusicais(List<Musica> musicas)
    {
        List<string> todosOsGenerosMusicais = musicas.Select(musica => musica.Genero.Split(',', '/')[0]).Distinct().ToList();
        return todosOsGenerosMusicais;
    }

    public static List<string> FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero)
    {
        var artistasPorGeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero, StringComparison.OrdinalIgnoreCase)).Select(musica => musica.Artista).Distinct().OrderBy(a => a).ToList();
        return artistasPorGeneroMusical;
    }

    public static List<Musica> FiltrarMusicasPorArtista(List<Musica> musicas, params string[] artistas)
    {
        var musicasFiltradas = musicas
            .Where(musica => artistas.Contains(musica.Artista!))
            .ToList();

        return musicasFiltradas;
    }

    public static List<Musica> FiltrarMusicasPorAno(List<Musica> musicas, string ano)
    {
        var musicasPorAno = musicas.Where(musica => musica.Ano!.Equals(ano)).OrderBy(musica => musica.Nome).ToList();
        return musicasPorAno;
    }

    public static List<Musica> FiltrarMusicasPeloTom(List<Musica> musicas, Tom tom)
    {
        var musicasPorTom = musicas.Where(musica => musica.Tonalidade.Equals(tom)).ToList();
        return musicasPorTom;
    }

    public static List<Musica> FiltrarMusicasPeloGenero(List<Musica> musicas, string genero)
    {
        var musicasPorGenero = musicas.Where(musica => musica.Genero!.Contains(genero, StringComparison.OrdinalIgnoreCase)).ToList();
        return musicasPorGenero;
    }

    public static List<KeyValuePair<Musica, int>> AsMaisTocadas(IReadOnlyList<Playlist> playlists)
    {
        Dictionary<Musica, int> ranking = [];
        foreach (var playlist in playlists)
        {
            foreach (var musica in playlist)
            {
                ranking[musica] = ranking.GetValueOrDefault(musica) + 1;
            }
        }
         return ranking
        .OrderByDescending(x => x.Value)
        .Take(10)                        
        .ToList();
    }

    public static List<KeyValuePair<string, int>> ArtistasMaisPopulares(IReadOnlyList<Playlist> playlists)
    {
        Dictionary<string, int> ranking = [];
        foreach (var playlist in playlists)
        {
            foreach (var musica in playlist)
            {
                ranking[musica.Artista!] = ranking!.GetValueOrDefault(musica.Artista) + 1;
            }
        }
        return ranking
       .OrderByDescending(x => x.Value)
       .Take(10)
       .ToList();
    }

    public static Dictionary<string, List<Musica>> ArtistasComMusicasLongas(IReadOnlyList<Playlist> playlists)
    {
        Dictionary<string, List<Musica>> artistasComMusicasMaioresQueCincoMinutos = [];
        foreach (var playlist in playlists)
        {
            foreach (var musica in playlist)
            {
                if (musica.Duracao >= 300) { //maior que 5minutos
                    if(!artistasComMusicasMaioresQueCincoMinutos.ContainsKey(musica.Artista!)) {
                        artistasComMusicasMaioresQueCincoMinutos[musica.Artista!] = new List<Musica>();
                    }
                    artistasComMusicasMaioresQueCincoMinutos[musica.Artista!].Add(musica);
                } 
            }
        }
        return artistasComMusicasMaioresQueCincoMinutos;
    }
}