/// <summary>
/// Representa uma playlist de músicas.
/// Implementa ICollection para fins de estudo
/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ScreenSoundAPI.Model
{
    class Playlist : ICollection<Musica>
    {
        public string Nome { get; set; }
        private List<Musica> _musicas = [];

        public int Count => _musicas.Count;

        public bool IsReadOnly => false;

        public Musica? ObterPeloTitulo(string titulo) {
            foreach(var musica in _musicas)
            {
                if(musica.Nome!.Equals(titulo, StringComparison.OrdinalIgnoreCase))
                {
                    return musica;
                }
            }
            return null;
        }

        public Musica RemoverPeloTitulo(string titulo) {
            var musica = ObterPeloTitulo(titulo);
            if(musica != null) {
                _musicas.Remove(musica);
                return musica;
            }
            return null;
        }

        public Musica TocarMusicaAleatoria() {
            if (_musicas.Count == 0) return null;

            int indiceAleatorio = Random.Shared.Next(_musicas.Count);

            return _musicas[indiceAleatorio];
        }

        public IEnumerator<Musica> GetEnumerator()
        {
            return _musicas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Musica musica)
        {
            if (musica == null)
            {
                throw new ArgumentNullException(nameof(musica), "A música não pode ser nula.");
            }
            _musicas.Add(musica);
        }

        public void Clear()
        {
            _musicas.Clear();
        }

        public bool Contains(Musica item)
        {
            return _musicas.Contains(item);
        }

        public void CopyTo(Musica[] array, int arrayIndex)
        {
            _musicas.CopyTo(array, arrayIndex);
        }

        public bool Remove(Musica item)
        {
            return _musicas.Remove(item);
        }
    }
}
