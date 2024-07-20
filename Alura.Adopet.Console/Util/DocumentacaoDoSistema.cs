using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util;

public class DocumentacaoDoSistema
{
    public static Dictionary<string, DocComando> ToDictionary(Assembly assemblyComOTipoDocComando)
    {
        return assemblyComOTipoDocComando.GetTypes()
                .Where(type => type.GetCustomAttributes<DocComando>().Any())
                .Select(type => type.GetCustomAttribute<DocComando>()!)
                .ToDictionary(dic => dic.Instrucao);
    }
}
