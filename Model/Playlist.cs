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
