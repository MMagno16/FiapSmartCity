using Microsoft.AspNetCore.Mvc;
using FiapSmartCity.Repository;
using FiapSmartCity.Models;

namespace FiapSmartCity.Controllers
{
    public class PessoaController : Controller
    {

        public PessoaRepository pessoaRepository;
        public PessoaController () { 
        
            pessoaRepository = new PessoaRepository ();
        }

        public IActionResult Index()
        {

            var listPessoa = pessoaRepository.Listar();
            return View(listPessoa);
        }

        public ActionResult Cadastrar()
        {
            return View(new Pessoa());
        }
        // Anotação de uso do Verb HTTP Post
        [HttpPost]
        public ActionResult Cadastrar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaRepository.Inserir(pessoa);
                @TempData["mensagem"] = "Tipo cadastrado com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            else
            {
                return View(pessoa);
            }
        }
        [HttpGet]
        public ActionResult Editar(int Id)
        {
            var pessoa = pessoaRepository.Consultar(Id);
            return View(pessoa);
        }
        [HttpPost]
        public ActionResult Editar(Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaRepository.Alterar(pessoa);
                @TempData["mensagem"] = "Pessoa alterada com sucesso!";
                return RedirectToAction("Index", "Pessoa");
            }
            else
            {
                return View(pessoa);
            }
        }
        [HttpGet]
        public ActionResult Consultar(int Id)
        {
            var pessoa = pessoaRepository.Consultar(Id);
            return View(pessoa);
        }
        [HttpGet]
        public ActionResult Excluir(int Id)
        {
            pessoaRepository.Excluir(Id);
            @TempData["mensagem"] = "Pessoa removido com sucesso!";
            return RedirectToAction("Index", "Pessoa");
        }
    }
}
