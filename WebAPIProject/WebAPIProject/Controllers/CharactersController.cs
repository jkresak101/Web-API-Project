using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAPIProject.Models;
using WebAPIProject.Services.Interfaces.WebMVC_API_Client.Services.Interfaces;
using static System.Net.WebRequestMethods;

namespace WebAPIProject.Controllers
{
    public class CharacterController : Controller
    {
        private ICharacterInterface? _service;

        private static readonly HttpClient client = new HttpClient();

        private string requestUri = "https://localhost:7183/api/Characters/";

        public CharacterController(ICharacterInterface service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("User-Agent", "Jim's API");
        }

        
        public async Task<IActionResult> Index()
        {
            var response = await _service.FindAll();

            return View(response);
        }

        // GET: 
        public async Task<IActionResult> Details(int id)
        {
            var character = await _service.FindOne(id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Strength,Speed,Age,Level,EquipmentId")] Character character)
        {
            character.Id = null;
            var resultPost = await client.PostAsync<Character>(requestUri, character, new JsonMediaTypeFormatter());

            return RedirectToAction(nameof(Index));
        }

        // GET:
        public async Task<IActionResult> Edit(int id)
        {
            var character = await _service.FindOne(id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Strength,Speed,Age,Level,Equipment Id")] Character character)
        {
            if (id != character.Id)
            {
                return NotFound();
            }

            var resultPut = await client.PutAsync<Character>(requestUri + character.Id.ToString(), character, new JsonMediaTypeFormatter());
            return RedirectToAction(nameof(Index));
        }

        // GET: 
        public async Task<IActionResult> Delete(int id)

        {
            var character = await _service.FindOne(id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: VideoGame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultDelete = await client.DeleteAsync(requestUri + id.ToString());
            return RedirectToAction(nameof(Index));
        }
    }
}



