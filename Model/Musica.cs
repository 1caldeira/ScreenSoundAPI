using System.Text.Json.Serialization;

namespace ScreenSoundAPI.Model;
class Musica
{
    [JsonPropertyName("song")]
    public string? Nome { get; set; }
    [JsonPropertyName("artist")]
    public string? Artista { get; set; }
    [JsonPropertyName("duration_ms")]
    public int Duracao { get; set; }
    [JsonPropertyName("genre")]
    public string? Genero { get; set; }
    [JsonPropertyName("year")]
    public string? Ano { get; set; }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Artista: {Artista}");
        Console.WriteLine($"Duração (s): {Duracao/1000}");
        Console.WriteLine($"Gênero musical: {Genero}");
        Console.WriteLine($"Ano: {Ano}");
        Console.WriteLine("---------------------------------------------");
    }
}
