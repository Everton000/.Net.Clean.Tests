using Alura.Adopet.Console.Util;
using FluentResults;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(
        instrucao: "help",
        documentacao: "adopet help comando que exibe informações da ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    public class Help : IComando
    {
        private Dictionary<string, DocComando> _docs;
        private string? Comando;

        public Help(string? comando)
        {
            _docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
            Comando = comando;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return Task.FromResult(
                    Result.Ok().WithSuccess(
                        new SuccessWithDocs(GerarDocumentacao())
                    )
                );
            }
            catch(Exception ex)
            {
                return Task.FromResult(
                    Result.Fail(new Error("Exibição da documentação com erro!").CausedBy(ex))
                );
            }
        }

        public IEnumerable<string> GerarDocumentacao()
        {
            List<string> resultado = new List<string>();
            if (Comando is null)
            {
                foreach (var doc in _docs.Values)
                {
                    resultado.Add(doc.Documentacao);
                }
            }
            // exibe o help daquele comando específico
            else
            {
                if (_docs.ContainsKey(Comando))
                {
                    var comando = _docs[Comando];
                    resultado.Add(comando.Documentacao);
                }
                else
                {
                    resultado.Add("Comando não encontrado!");
                    throw new ArgumentException();
                }
            }

            return resultado;
        }
    }
}
