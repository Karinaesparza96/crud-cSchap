
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppLivro.Models;
using AppLivro.Repository;
using AppLivro.Repository.Interfaces;
using AutoMapper;
using AppLivro.DTO;
using System.Collections;
using System.Linq;

namespace AppLivro.Controllers
{
    public class LivrosController : Controller
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly IMapper _mapper;

        public LivrosController(ILivroRepository livroRepository, IAutorRepository autorRepository, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
            _mapper = mapper;
        }

        // GET: Livroes
        public async Task<IActionResult> Index()
        {
            var livros = _livroRepository.GetAll();
            
            return View(livros.Select(x => _mapper.Map<LivroDTO>(x)));
        }

        // GET: Livroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _livroRepository.GetById(id.Value);
            
            if (livro == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<LivroDTO>(livro));
        }

        // GET: Livroes/Create
        public IActionResult Create()
        {
            ViewDataSelectAutor();
            return View();
        }

        // POST: Livroes/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,AutorId")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _livroRepository.Create(livro);
                return RedirectToAction(nameof(Index));
            }
            ViewDataSelectAutor(livro.AutorId);
            return View(_mapper.Map<LivroDTO>(livro));
        }

        // GET: Livroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _livroRepository.GetById(id.Value);
            if (livro == null)
            {
                return NotFound();
            }
            ViewDataSelectAutor(livro.AutorId);
            return View(_mapper.Map<LivroDTO>(livro));
        }

        // POST: Livroes/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,AutorId")] Livro livro)
        {
            if (id != livro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _livroRepository.Edit(livro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.Id))
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
            ViewDataSelectAutor(livro.AutorId);
            return View(_mapper.Map<LivroDTO>(livro));
        }

        // GET: Livroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var livro = _livroRepository.GetById(id.Value);
            if (livro == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<LivroDTO>(livro));
        }

        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _livroRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
            return _livroRepository.Exists(id);
        }

        private void ViewDataSelectAutor(int? id = null)
        {
            ViewData["AutorId"] = new SelectList(_autorRepository.GetAll(), "Id", "Nome", id);

        }
    }
}
