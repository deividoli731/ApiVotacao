using ApiVotacao.Models;

nusing ApiVotacao.Models;

namespace ApiVotacao.Repositories.Interfaces
{
    public interface ICandidatoRepository
    {
        bool AdicionarCandidato(Candidato candidato);

        List<Candidato> ListarCandidatos();

        bool RegistrarVoto(Voto voto);

        List<Voto> ConsultarVotos(int numero);
    }
}