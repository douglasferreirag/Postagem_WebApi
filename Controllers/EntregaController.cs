using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Postagem.Context;
using Postagem.Models;

namespace Postagem.Controllers
{
    public class EntregaController: Controller
    {

            private readonly PostagemContext _context;

            public EntregaController(PostagemContext context){

                        _context = context;


            }

           

            public IActionResult Index(){

                    
                           var entregas = _context.Entregas.ToList();

                        return View(entregas);

            }

            public IActionResult Criar(){

                            var cartas = _context.Cartas.ToList();

                            var territorios = _context.Territorios.ToList();

                            ViewBag.cartas = cartas;

                            ViewBag.territorios = territorios;

                            return View();

            }

            [HttpPost]
            public IActionResult Criar(Entrega entrega)
            {


                        if (ModelState.IsValid)
                        {

                            _context.Entregas.Add(entrega);

                            _context.SaveChanges();

                            return RedirectToAction(nameof(Index));


                        }

                        return View(entrega);


            }

            public IActionResult Editar (string id){

                    var carta = _context.Cartas.Find(id);

                    if(carta == null)

                        return RedirectToAction(nameof (Index));

                    return View(carta);


             }
            [HttpPost]
             public IActionResult Editar(Entrega entrega){

                        var entregaBanco = _context.Entregas.Find(entrega.Id);

                        entregaBanco .Id = entrega.Id;

                        entregaBanco.IdCarta = entrega.IdCarta;

                        entregaBanco.IdTerritorio = entrega.IdTerritorio;

                        entregaBanco.Data = entrega.Data;

                        entregaBanco.Local = entrega.Local;

                        entregaBanco.Status = entrega.Status;

                        _context.Entregas.Update(entregaBanco);

                        _context.SaveChanges();

                        return RedirectToAction(nameof (Index));

             }

             public IActionResult Detalhes(int id){

                       var entrega = _context.Entregas.Find (id);

                       if (entrega == null)

                            return RedirectToAction(nameof (Index));

                        return View(entrega);

             }

             

            public IActionResult Deletar(int id){

                       var entrega = _context.Entregas.Find (id);

                       if (entrega == null)

                            return RedirectToAction(nameof (Index));

                        return View(entrega);

             }

              [HttpPost]
             public IActionResult Deletar(Entrega entrega){

                     var entregaBanco = _context.Entregas.Find(entrega.Id);

                     _context.Entregas.Remove(entregaBanco);

                     _context.SaveChanges();

                     return RedirectToAction(nameof (Index));

             }




    }

  }