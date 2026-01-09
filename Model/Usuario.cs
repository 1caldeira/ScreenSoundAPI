using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace ScreenSoundAPI.Model;
    internal class Usuario
    {
    public int Id { get;}
    public string Nome { get; set; }
    private List<Musica> _musicasFavoritas = new List<Musica>();
    public IReadOnlyList<Musica> MusicasFavoritas => _musicasFavoritas.AsReadOnly();

    public Usuario(string nome)
    {
        Id = GerarId();
        Nome = nome;
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

