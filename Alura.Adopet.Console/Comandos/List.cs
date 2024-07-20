using System.Net.Http.Headers;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(
        instrucao: "list",
        documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class List : IComando
    {
        private readonly HttpClientPet _clientPet;

        public List(HttpClientPet clientPet)
        {
            _clientPet = clientPet;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await ListaDadosPetsDaAPIAsync();
        }

        public async Task<Result> ListaDadosPetsDaAPIAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await _clientPet.ListPetsAsync();
                
                return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Listagem de Pets realizada com sucesso!"));
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Erro na listagem de Pets!").CausedBy(ex));
            }
        }
    }
}
