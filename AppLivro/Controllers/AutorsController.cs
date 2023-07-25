
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppLivro.Models;
using AppLivro.Repository;
using AppLivro.Repository.Interfaces;
using System.Linq;
using AutoMapper;
using AppLivro.DTO;

namespace AppLivro.Controllers
{
    public class AutorsController : Controller
    {
  
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;
        public AutorsController(IAutorRepository autorRepository, IMapper mapper)
        {
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        // GET: Autors
        public async Task<IActionResult> Index()
        {
            var autores = _autorRepository.GetAll();
            return View(autores.Select(x => _mapper.Map<AutorDTO>(x)));
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _autorRepository.GetById(id.Value);
            if (autor == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AutorDTO>(autor));
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autors/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _autorRepository.Create(autor);

                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<AutorDTO>(autor));
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _autorRepository.GetById(id.Value);
            if (autor == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<AutorDTO>(autor));
        }

        // POST: Autors/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Autor autor)
        {
            if (id != autor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _autorRepository.Edit(autor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<AutorDTO>(autor));
        }

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = _autorRepository.GetById(id.Value);
            if (autor == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<AutorDTO>(autor));
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _autorRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
            return _autorRepository.Exists(id);
        }
    }
}
