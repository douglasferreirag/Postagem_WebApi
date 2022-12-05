using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Postagem.Context;
using Postagem.Models;

namespace Postagem.Controllers
{
    public class CartaController : Controller
    {

            private readonly PostagemContext _context;

            public CartaController(PostagemContext context){

                        _context = context;


            }

            public IActionResult Index(){

                       var cartas = _context.Cartas.ToList();

                        return View(cartas);
                      
            }

            public IActionResult Criar(){

                         

                            return View();

             }

            [HttpPost]
            public IActionResult Criar(Carta carta){

                    if(ModelState.IsValid){

                        _context.Cartas.Add(carta);

                        _context.SaveChanges();

                        return RedirectToAction(nameof(Index));


                     }

                    return View(carta);

            }

            public IActionResult Editar (string id){

                    var carta = _context.Cartas.Find(id);

                    if(carta == null)

                        return RedirectToAction(nameof (Index));

                    return View(carta);


             }
            [HttpPost]
             public IActionResult Editar(Carta carta){

                        var cartaBanco = _context.Cartas.Find(carta.Id);

                        cartaBanco .Id = carta.Id;

                        cartaBanco.Tema = carta.Tema;

                        cartaBanco.Base  = carta.Base;

                        _context.Cartas.Update(cartaBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(string id){

                       var carta = _context.Cartas.Find (id);

                       if (carta == null)

                            return RedirectToAction(nameof (Index));

                        return View(carta);

             }

             

            public IActionResult Deletar(string id){

                       var carta = _context.Cartas.Find (id);

                       if (carta == null)

                            return RedirectToAction(nameof (Index));

                        return View(carta);

             }

              [HttpPost]
             public IActionResult Deletar(Carta carta){

                     var cartaBanco = _context.Cartas.Find(carta.Id);

                     _context.Cartas.Remove(cartaBanco);

                     _context.SaveChanges();

                     return RedirectToAction(nameof (Index));

             }



    }

           
}