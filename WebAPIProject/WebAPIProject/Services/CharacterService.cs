
using WebAPIProject.Models;
using WebAPIProject.Services.Interfaces.WebMVC_API_Client.Services.Interfaces;
using WebMVC_API_Client.Helpers;

namespace WebAPIProject.Services
{
    public class CharacterService : ICharacterInterface
    {
        private readonly HttpClient _client;
        public const string BasePath = "/api/Characters/";

        public CharacterService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<Character>> FindAll()
        {
            var responseGet = await _client.GetAsync(BasePath);

            var response = await responseGet.ReadContentAsync<List<Character>>();

            return response;
        }

        public async Task<Character> FindOne(int id)
        {
            var request = BasePath + id.ToString();
            var responseGet = await _client.GetAsync(request);

            var response = await responseGet.ReadContentAsync<Character>();

            var character = new Character(response.Id, response.Name, response.Strength, response.Speed, response.Age,response.Level,response.EquipmentId);

            return character;
        }
    }
}
