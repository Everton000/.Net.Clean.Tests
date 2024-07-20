using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public class LeitorDeArquivo
{
    private string? _caminhoDoArquivo;
    public LeitorDeArquivo(string? caminhoDoArquivoASerLido)
    {
        _caminhoDoArquivo = caminhoDoArquivoASerLido;
    }

    public virtual List<Pet> RealizaLeitura()
    {
        if (string.IsNullOrEmpty(_caminhoDoArquivo)) return null;

        var listaDePets = new List<Pet>();

        using (StreamReader sr = new StreamReader(_caminhoDoArquivo))
        {
            while (!sr.EndOfStream)
            {
                listaDePets.Add(sr.ReadLine().ConverteDoTexto());
            }
        }

        return listaDePets;
    }
}
