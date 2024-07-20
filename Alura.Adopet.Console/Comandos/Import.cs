using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;
using System;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(
        instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {
        private readonly HttpClientPet _clientPet;
        private readonly LeitorDeArquivo _leitorDeArquivo;

        public Import(HttpClientPet clientPet, LeitorDeArquivo leitorDeArquivo)
        {
            _clientPet = clientPet;
            _leitorDeArquivo = leitorDeArquivo;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePets = _leitorDeArquivo.RealizaLeitura();

                foreach (var pet in listaDePets)
                {
                    try
                    {
                        var resposta = await _clientPet.CreatePetAsync(pet);
                    }
                    catch (Exception ex)
                    {
                        return Result.Fail(new Error(ex.Message).CausedBy(ex));
                    }
                }

                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Importação realizada com sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}
