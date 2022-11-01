namespace WebAPIProject.Services.Interfaces
{
    using WebAPIProject.Models;
   

    namespace WebMVC_API_Client.Services.Interfaces
    {
        public interface ICharacterInterface
        {
            Task<IEnumerable<Character>> FindAll();

            Task<Character> FindOne(int id);
        }
    }
}
