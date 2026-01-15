using ScreenSoundAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ScreenSoundAPI.Model
{
    class PlayerDeMusica
    {
        private Queue<Musica> fila = [];
        private Stack<Musica> pilha = [];
        public bool TemMusica => fila.Count > 0;
        public void AdicionarNaFila(Musica musica)
        {
            fila.Enqueue(musica);
        }
        public void AdicionarNaFila(List<Musica> musicas)
        {
            musicas.ForEach(musica => AdicionarNaFila(musica));
        }
        public void AdicionarNaFila(Playlist playlist) {
            playlist.Musicas.ForEach(musica => AdicionarNaFila(musica));
        }

        public IEnumerable<Musica> Fila() {
            foreach (var musica in fila)
            {
                yield return musica;
            }
        }

        public void ExibirFila() {
            foreach (var musica in fila)
            {
                Console.WriteLine($"\t - {musica.Nome} de {musica.Artista}");
            }
        }

        public Musica? ProximaDaFila() {
            if (fila.Count == 0) return null;
            var musica = fila.Dequeue();
            pilha.Push(musica);
            return musica;
        }

        public IEnumerable<Musica> Historico() {
            foreach (Musica musica in pilha)
            {
                yield return musica;
            }
        }

        public Musica? TocarMusicaAnterior() { 
            if(pilha.Count == 0) return null;
            return pilha.Pop();
        }
    }
}