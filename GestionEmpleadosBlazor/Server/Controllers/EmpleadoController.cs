using GestionEmpleadosBlazor.Server.Data;
using GestionEmpleadosBlazor.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;

namespace GestionEmpleadosBlazor.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public EmpleadoController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUpdate(Empleado empleado)
        {
            Status status = new Status();

            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Ingresar información correcta";
                return Ok(status);
            }
            try
            {
                empleado.FechaCreacion = DateTime.Now;
                if(empleado.Id == 0)
                {
                    _context.Empleado.Add(empleado);
                }
                else
                {
                    _context.Empleado.Update(empleado);
                }
                _context.SaveChanges();
                status.StatusCode = 1;
                status.Message = "Añadido correctamente";
            }
            catch (Exception ex)
            {

                status.StatusCode = 0;
                status.Message = "Error en el servidor";
            }
            return Ok(status);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Status status = new();
            var empleado= _context.Empleado.Find(id);

            if(empleado is null)
            {
                status.StatusCode = 0;
                status.Message = "El empleado no existe";
                return Ok(status);
            }
            status.StatusCode = 1;
            status.Message = "Se elimino correctamente";
            _context.Empleado.Remove(empleado);
            _context.SaveChanges();
            return Ok(status);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            var data = _context.Empleado.Find(id);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetAll(int pageNo=1, string sBusqueda = "") 
        { 
            sBusqueda = sBusqueda.ToLower();
            var data = (from empleado in _context.Empleado
                        where sBusqueda == null || empleado.NombreEmp.ToLower().StartsWith(sBusqueda)
                        orderby empleado.NombreEmp
                        select new Empleado
                        {
                            NombreEmp = empleado.NombreEmp,
                            EmpresaEmp = empleado.EmpresaEmp,
                            CorreoAsigEmp = empleado.CorreoAsigEmp,
                            CelAsigEmp = empleado.CelAsigEmp,
                            TelFijoAsigEmp = empleado.TelFijoAsigEmp,
                            ExtAsigEmp = empleado.ExtAsigEmp,
                            FechaCreacion = empleado.FechaCreacion,
                            Id = empleado.Id
                        }
                       ).ToList();
            var totalRecords = data.Count;
            int pageSize = 3;
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            int skip = (pageNo - 1) * pageSize;
            data = data.Skip(skip).Take(pageSize).ToList();
            var model = new EmpleadoList
            {
                Empleados = data,
                stringSearch = sBusqueda,
                TotalPages = totalPages,
                PageNumber = pageNo
            };

            return Ok(model);
        }
    }
}
