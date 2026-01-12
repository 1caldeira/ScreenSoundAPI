using ScreenSoundAPI.Filter;
using ScreenSoundAPI.Model;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);

        //Console.WriteLine("\n");

        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);

        //Console.WriteLine("\n");

        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "hip hop");

        List<Musica> musicasFavoritas = LinqFilter.FiltrarMusicasPorArtista(musicas, "Kendrick Lamar", "Tyler, The Creator", 
            "JAY-Z","Drake","Kanye West","Daft Punk","Michael Jackson","Linkin Park");

        //LinqFilter.FiltrarMusicasPorAno(musicas, "2010");

        Usuario usuario = new Usuario("Gabriel Caldeira");
        Console.WriteLine("Adicionando musicas favoritas para o usuário "+usuario.Nome+". ID: "+usuario.Id);
        musicasFavoritas.ForEach(musica => usuario.AdicionarMusicaFavorita(musica));
        usuario.ExibirMusicasFavoritas();

        Console.WriteLine("Testando params: buscando musicas de um único artista (Eminem)");
        var eminem = LinqFilter.FiltrarMusicasPorArtista(musicas, "Eminem");
        eminem.ForEach(e => Console.WriteLine(e));

        //usuario.GerarJson();
        var musicasEmFa = LinqFilter.FiltrarMusicasPeloTom(musicasFavoritas, Tom.F);
        musicasEmFa.ForEach(e => Console.WriteLine(e));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}

