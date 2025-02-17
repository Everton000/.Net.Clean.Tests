﻿using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.UI;

public static class ConsoleUI
{
    public static void ExibeResultado(Result result)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;
        try
        {
            if (result.IsFailed)
            {
                ExibeFalha(result);
            }
            else
            {
                ExibeSucesso(result);
            }
        }
        finally
        {
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }

    private static void ExibeFalha(Result result)
    {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine($"Aconteceu um exceção: {result.Errors.First()}");
    }

    private static void ExibeSucesso(Result result)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;
        var sucesso = result.Successes.First();
        switch (sucesso)
        {
            case SuccessWithPets s:
                ExibePets(s);
                break;
            case SuccessWithDocs d:
                ExibeDocumentacao(d);
                break;
        }
    }

    private static void ExibePets(SuccessWithPets sucesso)
    {
        foreach (var pet in sucesso.Data)
        {
            System.Console.WriteLine(pet);
        }
        System.Console.WriteLine(sucesso.Message);
    }

    private static void ExibeDocumentacao(SuccessWithDocs documentacaoCOmando)
    {
        System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
        System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.\n");

        foreach (var doc in documentacaoCOmando.Documentacao)
        {
            System.Console.WriteLine(doc);
        }
    }
}
