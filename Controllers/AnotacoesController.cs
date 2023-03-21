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
    public class AnotacoesController : Controller
    {
        private readonly ILogger<AnotacoesController> _logger;
        private readonly AppDbContext _context;

        public AnotacoesController(ILogger<AnotacoesController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("Index")]
        public IActionResult Index()
        {
            var anotacoes = _context.Anotacoes.ToList();


            return View(anotacoes);
        }

        [HttpGet("CriarNota")]
        public IActionResult CriarNota()
        {
            //view data com materias para o select, matematica, portugues, ingles, etc
            ViewData["Materias"] = _context.Materias.ToList();
            return View();
        }

        [HttpPost("Criar")]
        public IActionResult Criar(Anotacao anotacao, int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);
                anotacao.MateriaId = materiaId;
                anotacao.Materia = materia;

                _context.Anotacoes.Add(anotacao);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }


        [HttpGet("Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var anotacao = _context.Anotacoes.Find(id);
            ViewData["Materias"] = _context.Materias.ToList();
            return View(anotacao);
        }

        [HttpPost("EditarT")]
        public IActionResult EditarT(Anotacao anotacao, int materiaId)
        {
            var materia = _context.Materias.Find(materiaId);
            anotacao.MateriaId = materiaId;
            anotacao.Materia = materia;

            _context.Anotacoes.Update(anotacao);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    
        [HttpPost("DeletarT")]
        public IActionResult DeletarT(int anotacaoId)
        {
            var anotacao = _context.Anotacoes.Find(anotacaoId);
            _context.Anotacoes.Remove(anotacao);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("Detalhes/{id}")]
        public IActionResult Detalhes(int id)
        {
            var anotacao = _context.Anotacoes.Find(id);
            //associar materia a anotacao
            var materia = _context.Materias.Find(anotacao.MateriaId);
            anotacao.Materia = materia;
            return View(anotacao);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}