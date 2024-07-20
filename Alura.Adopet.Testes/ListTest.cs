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

public class ListTest
{
    [Fact]
    public async Task QuandoExecutarComandoListDeveRetornarListaDePets()
    {
        // Arrange
        var listaDePet = new List<Pet>();

        var pet = new Pet(
            new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
            "Lima",
            TipoPet.Cachorro);
        listaDePet.Add(pet);

        var httpClientPet = HttpClientPetMockBuilder.GetMockList(listaDePet);

        // Act
        Result retorno = await new Alura.Adopet.Console.Comandos.List(httpClientPet.Object)
            .ExecutarAsync();
        var resultado = (SuccessWithPets)retorno.Successes[0];

        // Assert
        Assert.Single(resultado.Data);
    }
}
