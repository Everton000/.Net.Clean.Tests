using Alura.Adopet.Console.Comandos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes;

public class FabricaDeComandosTest
{
    [Fact]
    public void DadoUmParametroDeveRetornarUmTipoImport()
    {
        // Arrange
        string[] args = { "import", "list.csv" };

        // Act
        var comando = FabricaDeComandos.CriarComando(args);

        // Assert
        Assert.IsType<Import>(comando);
    }

    [Fact]
    public void DadoUmParametroInvalidoDeveRetornarNull()
    {
        // Arrange
        string[] args = { "invalid", "list.csv" };

        // Act
        var comando = FabricaDeComandos.CriarComando(args);

        // Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosNuloDeveRetornarNull()
    {
        // Arrange

        // Act
        var comando = FabricaDeComandos.CriarComando(null);

        // Assert
        Assert.Null(comando);
    }

    [Fact]
    public void DadoUmArrayDeArgumentosVazioDeveRetornarNull()
    {
        // Arrange
        string[] args = { };

        // Act
        var comando = FabricaDeComandos.CriarComando(args);

        // Assert
        Assert.Null(comando);
    }
}
