using Alura.Adopet.Console.Modelos;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos;

public class HttpClientPet
{
    private readonly HttpClient _client;

    public HttpClientPet(HttpClient client)
    {
        _client = client;
    }

    public virtual Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        HttpResponseMessage? response = null;
        using (response = new HttpResponseMessage())
        {
            return _client.PostAsJsonAsync("pet/add", pet);
        }
    }

    public virtual async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
