using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;
using Moq;
using System.Numerics;

namespace Alura.Adopet.Testes;

public class ImportTest
{
    [Fact]
    public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
    {
        // Arrange
        var listaDePet = new List<Pet>();
        var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriarMock(listaDePet);

        var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        // Act
        await import.ExecutarAsync();

        // Assert
        httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
    }

    [Fact]
    public async Task QuandoArquivoNaoExistenteDeveGerarFalha()
    {
        // Arrange
        List<Pet> listaDePet = new();
        var leitor = LeitorDeArquivosMockBuilder.GetMock(listaDePet);
        leitor.Setup(_ => _.RealizaLeitura()).Throws<FileNotFoundException>();

        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitor.Object);

        // Act
        var resultado = await import.ExecutarAsync();

        // Assert
        Assert.True(resultado.IsFailed);
    }

    [Fact]
    public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
    {
        // Arrange
        var listaDePet = new List<Pet>();

        var pet = new Pet(
            new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
            "Lima",
            TipoPet.Cachorro);
        listaDePet.Add(pet);

        var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriarMock(listaDePet);

        var httpClientPet = HttpClientPetMockBuilder.GetMock();

        var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

        // Act
        var resultado = await import.ExecutarAsync();
        var sucesso = (SuccessWithPets)resultado.Successes[0];

        // Assert
        Assert.True(resultado.IsSuccess);
        Assert.Equal(pet.Nome, sucesso.Data.First().Nome);
    }
}
