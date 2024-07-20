using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Testes;

public class PetAPartirDoCsvTest
{
    [Fact]
    public void QuandoStringForValidaDeveRetornarUmPet()
    {
        // Arrange
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

        // Act
        Pet pet = linha.ConverteDoTexto();

        // Assert
        Assert.NotNull(pet);
    }

    [Fact]
    public void QuandoStringNulaDeveLancarArgumentNullException()
    {
        // Arrange
        string? linha = null;

        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoStringVaziaDeveLancarArgumentException()
    {
        // Arrange
        string linha = string.Empty;

        // Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoCamposInsuficientesDeveLancarArgumentException()
    {
        // Arrange
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão";

        // Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoGuidInvalidoDeveLancarArgumentException()
    {
        // Arrange
        string linha = "asdfsdfds;Lima Limão;1";

        // Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }

    [Fact]
    public void QuandoTipoInvalidoDeveLancarArgumentException()
    {
        // Arrange
        string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;-1";

        // Act + Assert
        Assert.Throws<ArgumentException>(() => linha.ConverteDoTexto());
    }
}
