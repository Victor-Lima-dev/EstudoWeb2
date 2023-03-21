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
    public class QuestoesController : Controller
    {
        private readonly ILogger<QuestoesController> _logger;
        private readonly AppDbContext _context;

        public QuestoesController(ILogger<QuestoesController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var questoes = _context.Questoes.ToList();

            return View( questoes );
        }

        [HttpGet("CriarQuestao")]
        public IActionResult CriarQuestao()
        {
            //view data com materias para o select, matematica, portugues, ingles, etc
            ViewData["Materias"] = _context.Materias.ToList();
            return View();
        }

        [HttpPost("Criar")]
        public IActionResult Criar(Questao questao, int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);
                questao.MateriaId = materiaId;
                questao.Materia = materia;

                _context.Questoes.Add(questao);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var questao = _context.Questoes.Find(id);
            ViewData["Materias"] = _context.Materias.ToList();
            return View(questao);
        }

        [HttpPost("EditarT")]
        public IActionResult EditarT(Questao questao, int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);
                questao.MateriaId = materiaId;
                questao.Materia = materia;

                _context.Questoes.Update(questao);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        //metodo para deletar, igual do anotacoes
        [HttpPost]
        public IActionResult Deletar(int id)
        {
            var questao = _context.Questoes.Find(id);
            _context.Questoes.Remove(questao);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //detalhes
        [HttpGet("Detalhes/{id}")]
        public IActionResult Detalhes(int id)
        {
            var questao = _context.Questoes.Find(id);
            //atribuir a materia da questao a uma variavel
            questao.Materia = _context.Materias.Find(questao.MateriaId);
            return View(questao);
        }









        








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}