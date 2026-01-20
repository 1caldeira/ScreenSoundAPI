using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using ScreenSoundAPI.Extensions;

namespace ScreenSoundAPI.Model;
    internal class Usuario
    {
    public int Id { get;}
    public string Nome { get; set; }
    private string Senha { get; set; }
    private List<Musica> _musicasFavoritas = new List<Musica>();
    public IReadOnlyList<Musica> MusicasFavoritas => _musicasFavoritas.AsReadOnly();
    private List<Playlist> _playlists = new List<Playlist>();
    public IReadOnlyList<Playlist> Playlists => _playlists.AsReadOnly();

    public void AdicionarPlaylist(Playlist playlist) {
        _playlists.Add(playlist);
    }
    public Playlist ObterPlaylistPeloNome(string nome)
    {
        foreach (var playlist in Playlists)
        {
            if (playlist.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                return playlist;
            }
        }
        return null;
    }

    public Usuario(string nome, string senha)
    {
        Id = GerarId();
        Nome = nome;
        Senha = ValidarSenha(senha);
    }

    private string ValidarSenha(string senha)
    {
        var totalCaracteres = senha.Length;
        var totalLetrasMaiusculas = senha.Count(c => char.IsUpper(c));
        var totalLetrasMinusculas = senha.Count(c => char.IsLower(c));
        var totalNumeros = senha.Count(c => char.IsDigit(c));
        var totalSimbolos = senha.Count(c => !char.IsLetterOrDigit(c));
        if (totalCaracteres >= 8 && totalLetrasMaiusculas > 0 && totalLetrasMinusculas > 0 && totalNumeros > 0 && totalSimbolos > 0)
        {
            return senha;
        }
        else {
            throw new ArgumentException("A senha deve conter no mínimo 8 caracteres, incluindo letras maiúsculas, minúsculas, números e símbolos.");
        }
    }

    private int GerarId()
    {
        return Random.Shared.Next(100000, 1_000_000);
    }

    public void AdicionarMusicaFavorita(Musica musica) { 
        _musicasFavoritas.Add(musica);
    }

    public void ExibirMusicasFavoritas() {
        Console.WriteLine("Exibindo musicas favoritas de "+Nome);
        MusicasFavoritas.ForEach(musica => Console.WriteLine(musica));
    }

    public void GerarJson()
    {
        string json = JsonSerializer.Serialize(new
        {
            nome = Nome,
            id=Id,
            musicasFavoritas = MusicasFavoritas
        });
        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";
        File.WriteAllText(nomeDoArquivo, json);
        Console.WriteLine($"O arquivo JSON foi criado com sucesso no caminho {Path.GetFullPath(nomeDoArquivo)}");
    }
}

