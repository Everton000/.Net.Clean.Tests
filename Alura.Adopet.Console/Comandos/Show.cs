using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(
        instrucao: "show",
        documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly LeitorDeArquivo _leitorDeArquivo;

        public Show(LeitorDeArquivo leitorDeArquivo)
        {
            _leitorDeArquivo = leitorDeArquivo;
        }

        public Task<Result> ExecutarAsync()
        {
            var resultado = ExibeConteudoArquivo();
            return Task.FromResult(resultado);
        }

        private Result ExibeConteudoArquivo()
        {
            try
            {
                var listaDePets = _leitorDeArquivo.RealizaLeitura();

                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePets, "Exibição do arquivo realizada com sucesso!"));
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Erro na leitura de Pets!").CausedBy(ex));
            }
        }
    }
}
