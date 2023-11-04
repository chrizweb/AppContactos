using CrudContacto.Datos;
using CrudContacto.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudContacto.Controllers {
	public class ContactoController : Controller {

		ContactoDatos Datos = new ContactoDatos();
		/*******************************************************************/
		public IActionResult listContactos() {
			var list_contacto = Datos.List();
			
			return View(list_contacto);
		}
		/*******************************************************************/
		public IActionResult createContacto(ContactoModel contacto) {
			if(!ModelState.IsValid)
				return View();

			var response = Datos.Create(contacto);

			if (response)
				return RedirectToAction("listContactos");
			else
				return View();
		}
		/*******************************************************************/
		public IActionResult edit(int idContacto) {
			/*Devuelve la vista con los datos*/
			var contacto = Datos.GetId(idContacto);
			return View(contacto);
		}
		/*******************************************************************/
		public IActionResult updateContacto(ContactoModel contacto) {
			if (!ModelState.IsValid)
				return View();

			var response = Datos.Update(contacto);

			if (response)
				return RedirectToAction("listContactos");
			else
				return View();
		}
		/*******************************************************************/
		public IActionResult delete(int idContacto) {
			/*Devuelve la vista con los datos*/
			var contacto = Datos.GetId(idContacto);
			return View(contacto);
		}
		/*******************************************************************/
		public IActionResult deleteContacto(ContactoModel contacto) {

			var response = Datos.Delete(contacto.IdContacto);

			if (response)
				return RedirectToAction("listContactos");
			else
				return View();
		}
	}
}























