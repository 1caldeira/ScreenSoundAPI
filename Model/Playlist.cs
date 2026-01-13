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

        public void AdicionarMusica(Musica musica)
        {
            if (musica == null)
            {
                throw new ArgumentNullException(nameof(musica), "A música não pode ser nula.");
            }
            _musicas.Add(musica);
        }

        public IEnumerator<Musica> GetEnumerator()
        {
            return Musicas.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
