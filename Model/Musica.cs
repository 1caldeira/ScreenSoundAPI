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

    public override string ToString()
    {
        return $"Nome: {Nome} \n" +
            $"Artista: {Artista} \n" +
            $"Duração (s): {Duracao / 1000} \n" +
            $"Gênero musical: {Genero} \n" +
            $"Ano: {Ano}\n";
    }
}
