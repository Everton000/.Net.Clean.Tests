using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes;

public class ShowTest
{
    [Fact]
    public async Task QuandoArquivoExistenteDeveRetornarMensagemSucesso()
    {
        // Arrange
        var listaDePet = new List<Pet>();

        var pet = new Pet(
            new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
            "Lima",
            TipoPet.Cachorro);
        listaDePet.Add(pet);

        var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriarMock(listaDePet);
        var show = new Show(leitorDeArquivo.Object);

        // Act
        Result resultado = await show.ExecutarAsync();

        // Assert
        Assert.NotNull(resultado);
        var sucesso = (SuccessWithPets)resultado.Successes[0];
        Assert.Equal("Exibição do arquivo realizada com sucesso!", sucesso.Message);
    }
}
