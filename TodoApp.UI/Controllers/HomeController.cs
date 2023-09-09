﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoApp.BLL.Service;
using TodoApp.EN;
using TodoApp.EN.ViewModels;
using TodoApp.UI.Models;

namespace TodoApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITareaService _tareaService;

        public HomeController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listar()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            IQueryable<Tarea> queryTarea = await _tareaService.ObtenerTodos();

            List<MVTarea> tareas = queryTarea
                .Select(t => new MVTarea()
                {
                    Id = t.Id,
                    Nombre = t.Nombre,
                    Descripcion = t.Descripcion,
                    FechaRegistro = t.FechaRegistro.Value.ToString("dd/MM/yyyyy"),
                    Completada = t.Completada

                }).ToList();

            return StatusCode(StatusCodes.Status200OK, tareas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}