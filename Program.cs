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
            "JAY-Z", "Drake", "Kanye West", "Daft Punk", "Michael Jackson", "Linkin Park");

        var musicas2010 = LinqFilter.FiltrarMusicasPorAno(musicas, "2010");

        Usuario usuario = new Usuario("Gabriel Caldeira");
        Console.WriteLine("Adicionando musicas favoritas para o usuário " + usuario.Nome + ". ID: " + usuario.Id);

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

        Console.WriteLine("Exibindo playlists do usuario " + usuario.Nome + "\n");
        foreach (var playlist in usuario.Playlists)
        {
            Console.WriteLine($" ******* Playlist: {playlist.Nome} *******");
        }

        var playlistDoUsuario = usuario.ObterPlaylistPeloNome("Rap");


        Console.WriteLine("Tocando a playlist " + playlistDoUsuario.Nome);

        playlistDoUsuario.ForEach(musica => Console.WriteLine("Tocando musica: " + musica.Nome + " - " + musica.Artista));

        var buscaPeloTitulo = playlistDoUsuario.ObterPeloTitulo("Trap Queen");
        if (buscaPeloTitulo != null)
        {
            Console.WriteLine($"Musica encontrada na playlist '{playlistDoUsuario.Nome}' do usuario {usuario.Nome}: {buscaPeloTitulo.Nome} - {buscaPeloTitulo.Artista}");
        }
        else
        {
            Console.WriteLine("Musica não encontrada na playlist.");
        }

        Console.WriteLine($"Tocando musica aleatoria da playlist '{playlistDoUsuario.Nome}'");
        Console.WriteLine(playlistDoUsuario.TocarMusicaAleatoria());

        Console.WriteLine("Removendo musica da playlist");
        string musicaParaRemover = "Too Good";
        Musica musicaRemovida = playlistDoUsuario.RemoverPeloTitulo(musicaParaRemover);
        if (musicaRemovida != null)
        {
            Console.WriteLine($"Musica '{musicaParaRemover}' removida com sucesso!\n" +
                $"Detalhes da musica removida:\n" + musicaRemovida);
        }
        else
        {
            Console.WriteLine($"Musica '{musicaParaRemover}' não encontrada na playlist!");
        }

        var musicasMaisTocadas = LinqFilter.AsMaisTocadas(usuario.Playlists);
        Console.WriteLine("----------------AS MAIS TOCADAS----------------");
        musicasMaisTocadas.ForEach(mais => Console.WriteLine(mais));


        //Console.WriteLine("Tocando musicas");
        //var player = new PlayerDeMusica();
        //player.AdicionarNaFila(playlist2010);
        //player.AdicionarNaFila(playlistFavoritos);
        //player.ExibirFila();

        //while (player.TemMusica)
        //{
        //    Console.WriteLine("TOCANDO MUSICA: " + player.ProximaDaFila());
        //}


        //Console.WriteLine("\nExibindo as ultimas 5 musicas tocadas: ");
        //foreach (var musica in player.Historico().Take(5))
        //{
        //    Console.WriteLine($"\t - {musica.Nome} - {musica.Artista}");
        //}
        //Console.WriteLine("\nTocando a musica anterior: ");
        //Console.WriteLine(player.TocarMusicaAnterior());

        Console.WriteLine("Duracao total playlist de musicas favoritas: " + playlistFavoritos.DuracaoTotal);
        Console.WriteLine("Media de duracao das musicas: "+ playlistFavoritos.MediaDuracaoMusicas);

        Console.WriteLine("------------ARTISTAS MAIS POPULARES------------");
        var artistasMaisPopulares = LinqFilter.ArtistasMaisPopulares(usuario.Playlists);

        artistasMaisPopulares.ForEach(a => Console.WriteLine(a));
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }
}

