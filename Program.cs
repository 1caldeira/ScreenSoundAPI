using ScreenSoundAPI.Extensions;
using ScreenSoundAPI.Filter;
using ScreenSoundAPI.Model;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
        string resposta = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musicas = JsonSerializer.Deserialize<List<Musica>>(resposta)!;

        List<Musica> musicasFavoritas = LinqFilter.FiltrarMusicasPorArtista(musicas, "Kendrick Lamar", "Tyler, The Creator", 
            "JAY-Z","Drake","Kanye West","Daft Punk","Michael Jackson","Linkin Park");

        var musicas2010 = LinqFilter.FiltrarMusicasPorAno(musicas, "2010");

        Usuario usuario = new Usuario("Gabriel Caldeira");
        Console.WriteLine("Adicionando musicas favoritas para o usuário "+usuario.Nome+". ID: "+usuario.Id);

        musicasFavoritas.ForEach(m => usuario.AdicionarMusicaFavorita(m)); 
        var eminem = LinqFilter.FiltrarMusicasPorArtista(musicas, "Eminem");

        var musicasDeHipHop = LinqFilter.FiltrarMusicasPeloGenero(musicas, "Hip Hop");

        //Criando playlists para o usuario
        Playlist playlistFavoritos = new Playlist() { Nome = "Minhas Favoritas" };
        musicasFavoritas.ForEach(musica => playlistFavoritos.AdicionarMusica(musica));
        usuario.AdicionarPlaylist(playlistFavoritos);

        Playlist playlist2010 = new Playlist() { Nome = "Musicas de 2010" };
        musicas2010.ForEach(musica => playlist2010.AdicionarMusica(musica));
        usuario.AdicionarPlaylist(playlist2010);

        Playlist playlistRap = new Playlist() { Nome = "Rap" };
        musicasDeHipHop.ForEach(musica => playlistRap.AdicionarMusica(musica));
        usuario.AdicionarPlaylist(playlistRap);
        Console.WriteLine(musicasDeHipHop.Count);

        Console.WriteLine("Exibindo playlists do usuario "+usuario.Nome+"\n");
        foreach (var playlist in usuario.Playlists)
        {
            Console.WriteLine($" ******* Playlist: {playlist.Nome} *******");
        }

        Console.WriteLine("Tocando a playlist " + usuario.Playlists[2].Nome);

        usuario.Playlists[2].ForEach(musica => Console.WriteLine("Tocando musica: " + musica.Nome + " - " + musica.Artista));

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}

