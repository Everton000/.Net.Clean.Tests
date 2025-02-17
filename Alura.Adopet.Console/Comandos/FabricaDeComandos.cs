﻿using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos;

public static class FabricaDeComandos
{
    public static IComando? CriarComando(string[] argumentos)
    {
        if (argumentos is null || argumentos.Length == 0) return null;

        string comando = argumentos[0];

        switch (comando)
        {
            case "import":
                var httpClientPetImport = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                var leitorDeArquivoImport = new LeitorDeArquivo(caminhoDoArquivoASerLido: argumentos?.Length > 1 ? argumentos[1] : "");
                return new Import(httpClientPetImport, leitorDeArquivoImport);
            case "list":
                var httpClientPetList = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
                return new List(httpClientPetList);
            case "show":
                var leitorDeArquivoShow = new LeitorDeArquivo(caminhoDoArquivoASerLido: argumentos?.Length > 1 ? argumentos[1] : "");
                return new Show(leitorDeArquivoShow);
            case "help":
                var comandoASerExibido = argumentos.Length == 2 ? argumentos?[1] : null;
                return new Help(comandoASerExibido);
            default: return null;
        }
    }
}
