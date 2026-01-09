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

        LinqFilter.FiltrarMusicasPorArtista(musicas, "Kendrick Lamar");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}

