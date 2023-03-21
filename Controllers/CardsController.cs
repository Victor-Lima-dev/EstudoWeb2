using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EstudoWeb2.context;
using EstudoWeb2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EstudoWeb2.Controllers
{
    [Route("[controller]")]
    public class CardsController : Controller
    {
        private readonly ILogger<CardsController> _logger;
        private readonly AppDbContext _context;

        public CardsController(ILogger<CardsController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        [HttpGet("Index")]
        public IActionResult Index()
        {
            var cards = _context.Cards.ToList();
            //associar a materia do card
            foreach (var card in cards)
            {
                card.Materia = _context.Materias.Find(card.MateriaId);
            }

            return View( cards );
        }

        [HttpGet("CriarCard")]
        public IActionResult CriarCard()
        {
            //view data com materias para o select, matematica, portugues, ingles, etc
            ViewData["Materias"] = _context.Materias.ToList();
            return View();
        }

        [HttpPost("Criar")]
        public IActionResult Criar(Card card, int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);
                card.MateriaId = materiaId;
                card.Materia = materia;

                _context.Cards.Add(card);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var card = _context.Cards.Find(id);
            ViewData["Materias"] = _context.Materias.ToList();
            return View(card);
        }

        [HttpPost("EditarT")]
        public IActionResult EditarT(Card card, int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);
                card.MateriaId = materiaId;
                card.Materia = materia;

                _context.Cards.Update(card);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var card = _context.Cards.Find(id);
            _context.Cards.Remove(card);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Detalhes/{id}")]
        public IActionResult Detalhes(int id)
        {
            var card = _context.Cards.Find(id);
            //associar a materia do card
            card.Materia = _context.Materias.Find(card.MateriaId);
            return View(card);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}