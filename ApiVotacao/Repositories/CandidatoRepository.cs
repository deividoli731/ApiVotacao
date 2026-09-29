using ApiVotacao.Models;
using ApiVotacao.Repositories.Interfaces;

namespace ApiVotacao.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private static List<Candidato> candidatos = new();
        private static List<Voto> votos = new();

        public bool AdicionarCandidato(Candidato candidato)
        {
            bool existe = candidatos.Any(c =>
                c.Numero == candidato.Numero);

            if (existe)
            {
                return false;
            }

            candidatos.Add(candidato);

            return true;
        }

        public List<Candidato> ListarCandidatos()
        {
            return candidatos;
        }

        public bool RegistrarVoto(Voto voto)
        {
            bool existe = candidatos.Any(c =>
                c.Numero == voto.NumeroCandidato);

            if (!existe)
            {
                return false;
            }

            votos.Add(voto);

            return true;
        }

        public List<Voto> ConsultarVotos(int numero)
        {
            return votos
                .Where(v => v.NumeroCandidato == numero)
                .ToList();
        }
    }
}