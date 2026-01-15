/// <summary>
/// Representa uma playlist de músicas.
/// Implementa IEnumerable para permitir iteração e uso de LINQ,
/// mas mantém a lista interna encapsulada para garantir a integridade dos dados.
/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ScreenSoundAPI.Model
{
    class Playlist : IEnumerable<Musica>
    {
        public string Nome { get; set; }
        private List<Musica> _musicas = [];
        public IReadOnlyList<Musica> Musicas => _musicas.AsReadOnly();

        public IReadOnlyList<Musica> ordenarPorDuracao() => Musicas.OrderBy(musica => musica.Duracao).ToList();

        public void AdicionarMusica(Musica musica)
        {
            if (musica == null)
            {
                throw new ArgumentNullException(nameof(musica), "A música não pode ser nula.");
            }
            if (_musicas.Contains(musica))
            {
                Console.WriteLine("A musica ja está na playlist!");
                return;
            }
            _musicas.Add(musica);
        }

        public Musica? ObterPeloTitulo(string titulo)
        {
            foreach (var musica in _musicas)
            {
                if (musica.Nome!.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return musica;
                }
            }
            return null;
        }

        public Musica RemoverPeloTitulo(string titulo)
        {
            var musica = ObterPeloTitulo(titulo);
            if (musica != null)
            {
                _musicas.Remove(musica);
                return musica;
            }
            return null;
        }

        public Musica TocarMusicaAleatoria()
        {
            if (_musicas.Count == 0) return null;

            int indiceAleatorio = Random.Shared.Next(_musicas.Count);

            return _musicas[indiceAleatorio];
        }

        public IEnumerator<Musica> GetEnumerator() => Musicas.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
