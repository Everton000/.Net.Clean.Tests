using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util;

public static class PetAPartirDoCsv
{
    public static Pet ConverteDoTexto(this string? linha)
    {
        string[]? propriedades = linha?.Split(';')
            ?? throw new ArgumentNullException("Texto não pode ser nulo!");

        if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio!");

        if (propriedades.Length != 3) throw new ArgumentException("Texto inválido!");

        bool petIdValido = Guid.TryParse(propriedades[0], out Guid petId);
        if (!petIdValido) throw new ArgumentException("Campo ID inválido!");

        bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
        if (!tipoValido) throw new ArgumentException();
        if (tipoPet != 0 && tipoPet != 1) throw new ArgumentException();

        return new Pet(petId,
            propriedades[1],
            tipoPet == 0 ? TipoPet.Gato : TipoPet.Cachorro
        );
    }
}
