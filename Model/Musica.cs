using System.Text.Json.Serialization;
using System.ComponentModel;
using ScreenSoundAPI.Extensions;

namespace ScreenSoundAPI.Model;

public enum Tom
{
    C,
    [Description("C#")] Csharp,
    D,
    [Description("D#")] Dsharp,
    E,
    F,
    [Description("F#")] Fsharp,
    G,
    [Description("G#")] Gsharp,
    A,
    [Description("A#")] Asharp,
    B
}

public class Musica
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
    [JsonPropertyName("key")]
    public int KeyInt { get; set; }

    public Tom Tonalidade { get => (Tom)KeyInt;}

    public override string ToString()
    {
        return $"Nome: {Nome} \n" +
            $"Artista: {Artista} \n" +
            $"Tom: {Tonalidade.GetDescription()} \n" +
            $"Duração (s): {Duracao / 1000} \n" +
            $"Gênero musical: {Genero} \n" +
            $"Ano: {Ano}\n";
    }

}
