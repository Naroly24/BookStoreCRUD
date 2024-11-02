using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using BookStoreWeb.Models;
using System.Text.Json;
using BookStoreCRUD.Domain.Models;

public class BookService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    // Definimos JsonSerializerOptions como estático
    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        // Puedes agregar más configuraciones aquí si lo necesitas
    };

    public BookService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
    {
        _httpClient = httpClient;
        _baseUrl = apiSettings.Value.BaseUrl;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/books");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<Book>>(_jsonOptions);
    }

    public async Task<Book> GetBookByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}/books/{id}");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<Book>(_jsonOptions);
    }

    public async Task CreateBookAsync(Book book)
    {
        var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/books", book, _jsonOptions);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateBookAsync(Book book)
    {
        var response = await _httpClient.PutAsJsonAsync($"{_baseUrl}/books/{book.Id}", book, _jsonOptions);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteBookAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{_baseUrl}/books/{id}");
        response.EnsureSuccessStatusCode();
    }
}
