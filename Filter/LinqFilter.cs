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
}