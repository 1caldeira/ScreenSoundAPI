using ScreenSoundAPI.Model;

class LinqFilter {
    public static void FiltrarTodosOsGenerosMusicais(List<Musica> musicas) {
        List<string> todosOsGenerosMusicais = musicas.Select(musica => musica.Genero.Split(',','/')[0]).Distinct().ToList();
        todosOsGenerosMusicais.ForEach(g => Console.WriteLine(g));
    }
}