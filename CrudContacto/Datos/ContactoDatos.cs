using CrudContacto.Models;
using System.Data;
using System.Data.SqlClient;

namespace CrudContacto.Datos {
	public class ContactoDatos {
		/******************************************************************/
		public List<ContactoModel> List() {

			var lista = new List<ContactoModel>();
			var conexion = new Conexion();

			using (var conn = new SqlConnection(conexion.getCadenaSql())) {
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_Listar", conn);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var reader = cmd.ExecuteReader()) {
					
					while (reader.Read()) {
						lista.Add(new ContactoModel() { 
							IdContacto = Convert.ToInt32(reader["IdContacto"]),
							Nombre = reader["Nombre"].ToString(),
							Telefono = reader["Telefono"].ToString(),
							Correo = reader["Correo"].ToString(),
						});
					}
				}
			}
			return lista;
		}
		/******************************************************************/
		public ContactoModel GetId(int IdContacto) {

			var contacto = new ContactoModel();
			var conexion = new Conexion();

			using (var conn = new SqlConnection(conexion.getCadenaSql())) {
				conn.Open();
				SqlCommand cmd = new SqlCommand("sp_Obtener", conn);
				cmd.Parameters.AddWithValue("IdContacto", IdContacto);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var reader = cmd.ExecuteReader()) {
					while (reader.Read()) {
						contacto.IdContacto = Convert.ToInt32(reader["IdContacto"]);
						contacto.Nombre = reader["Nombre"].ToString();
						contacto.Telefono = reader["Telefono"].ToString();
						contacto.Correo = reader["Correo"].ToString();
					}
				}
			}
			return contacto;
		}
		/******************************************************************/
		public bool Create(ContactoModel contacto) {
			bool response;

			try {
				var conexion = new Conexion();

				using(var conn = new SqlConnection(conexion.getCadenaSql())) {
					conn.Open();
					SqlCommand cmd = new SqlCommand("sp_Guardar", conn);
					cmd.Parameters.AddWithValue("Nombre", contacto.Nombre);
					cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
					cmd.Parameters.AddWithValue("Correo", contacto.Correo);

					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
				}
				response = true;

			} catch (Exception e) {

				string error = e.Message;
				response = false;
			}
			return response;
		}
		/******************************************************************/
		public bool Update(ContactoModel contacto) {
			bool response;

			try {
				var conexion = new Conexion();

				using (var conn = new SqlConnection(conexion.getCadenaSql())) {
					conn.Open();
					SqlCommand cmd = new SqlCommand("sp_Editar", conn);

					cmd.Parameters.AddWithValue("IdContacto", contacto.IdContacto);
					cmd.Parameters.AddWithValue("Nombre", contacto.Nombre);
					cmd.Parameters.AddWithValue("Telefono", contacto.Telefono);
					cmd.Parameters.AddWithValue("Correo", contacto.Correo);

					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
				}
				response = true;

			} catch (Exception e) {

				string error = e.Message;
				response = false;
			}
			return response;
		}
		/******************************************************************/
		public bool Delete(int idContacto) {
			bool response;

			try {
				var conexion = new Conexion();

				using (var conn = new SqlConnection(conexion.getCadenaSql())) {
					conn.Open();
					SqlCommand cmd = new SqlCommand("sp_Eliminar", conn);
					cmd.Parameters.AddWithValue("IdContacto", idContacto);

					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
				}
				response = true;

			} catch (Exception e) {

				string error = e.Message;
				response = false;
			}
			return response;
		}
		/******************************************************************/
	}
}










