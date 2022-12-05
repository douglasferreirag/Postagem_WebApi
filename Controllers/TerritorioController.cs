using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Postagem.Context;
using Postagem.Models;

namespace Postagem.Controllers
{
    public class TerritorioController: Controller
    {

            private readonly PostagemContext _context;

            public TerritorioController(PostagemContext context){

                        _context = context;


            }

            public IActionResult Index(){

                       var territorios = _context.Territorios.ToList();

                        return View(territorios);
                      
            }

            public IActionResult Criar(){

                         

                            return View();

             }

            [HttpPost]
            public IActionResult Criar(Territorio territorio){

                    if(ModelState.IsValid){

                        _context.Territorios.Add(territorio);

                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));


                     }

                    return View(territorio);

            }

            public IActionResult Editar (int id){

                    var territorio = _context.Territorios.Find(id);

                    if(territorio == null)

                        return RedirectToAction(nameof (Index));

                    return View(territorio);


             }
            [HttpPost]
             public IActionResult Editar(Territorio territorio){

                        var territorioBanco = _context.Territorios.Find(territorio.Id);

                       territorioBanco.Id = territorio.Id;

                        territorioBanco.Descricao = territorio.Descricao;

                       territorioBanco.Cidade= territorio.Cidade;

                       territorioBanco.PontoReferencia= territorio.PontoReferencia;

                        _context.Territorios.Update(territorioBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(int id){

                       var territorio = _context.Territorios.Find (id);

                       if (territorio== null)

                            return RedirectToAction(nameof (Index));

                        return View(territorio);

             }

             

            public IActionResult Deletar(int id){

                       var territorio = _context.Territorios.Find (id);

                       if (territorio == null)

                            return RedirectToAction(nameof (Index));

                        return View(territorio);

             }

              [HttpPost]
             public IActionResult Deletar(Territorio territorio){

                     var territorioBanco = _context.Territorios.Find(territorio.Id);

                     _context.Territorios.Remove(territorioBanco);

                     _context.SaveChanges();

                     return RedirectToAction(nameof (Index));

             }



    }

           
}