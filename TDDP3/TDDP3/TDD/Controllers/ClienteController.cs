using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TDD.Data;
using TDD.Models;

namespace TDD.Controllers
{
    public class ClienteController : Controller
    {
        ClienteDataAccessLayer objClientesDAL = new ClienteDataAccessLayer();

        // GET: Cliente/Details/5
        public IActionResult Details(int id)
        {
            Cliente? cliente = objClientesDAL.getAllClientes().FirstOrDefault(c => c.Codigo == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }


        // GET: ClienteController
        public IActionResult Index()
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes = objClientesDAL.getAllClientes().ToList();
            return View(clientes);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente objCliente)
        {
            if (ModelState.IsValid)
            {
                objClientesDAL.AddCliente(objCliente);
                return RedirectToAction("Index");

            }

            return View(objCliente);
        }



        // GET: Cliente/Edit/5
        public IActionResult Edit(int id)
        {
            Cliente? cliente = objClientesDAL.getAllClientes().FirstOrDefault(c => c.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Cliente objCliente)
        {
            if (id != objCliente.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                objClientesDAL.UpdateCliente(objCliente);
                return RedirectToAction("Index");
            }
            return View(objCliente);
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(int id)
        {
            Cliente? cliente = objClientesDAL.getAllClientes().FirstOrDefault(c => c.Codigo == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            objClientesDAL.DeleteCliente(id);
            return RedirectToAction("Index");
        }

    }
}
