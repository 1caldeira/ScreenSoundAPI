using ScreenSoundAPI.Model;

class LinqFilter {
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas) {
        List<string> todosOsGenerosMusicais = musicas.Select(musica => musica.Genero.Split(',','/')[0]).Distinct().ToList();
        todosOsGenerosMusicais.ForEach(g => Console.WriteLine(g));
    }

    public static void FiltrarArtistasPorGeneroMusical(List<Musica> musicas, string genero) { 
        var artistasPorGeneroMusical = musicas.Where(musica => musica.Genero!.Contains(genero)).Select(musica => musica.Artista).Distinct().OrderBy(a => a).ToList();
        Console.WriteLine("Artistas do genero " + genero + ":");
        artistasPorGeneroMusical.ForEach(a => Console.WriteLine(a));
    }

    public static List<Musica> FiltrarMusicasPorArtista(List<Musica> musicas, params string[] artistas)
    {
        var musicasFiltradas = musicas
            .Where(musica => artistas.Contains(musica.Artista!))
            .ToList();

        return musicasFiltradas;
    }

    public static void FiltrarMusicasPorAno(List<Musica> musicas, string ano) {
        var musicasPorAno = musicas.Where(musica => musica.Ano!.Equals(ano)).OrderBy(musica => musica.Nome).ToList();
        Console.WriteLine("Mostrando musicas do ano "+ano);
        musicasPorAno.ForEach(m => Console.WriteLine(m.Nome + " - " + m.Artista));
    }
}