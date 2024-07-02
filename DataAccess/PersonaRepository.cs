using Semana5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Semana5.DataAccess
{
    public class PersonaRepository
    {
        private string dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Persona>();
        }

        public PersonaRepository(string path)
        {
            dbPath = path;
        }

        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El nombre es requerido");

                Persona person = new Persona { Name = nombre };
                result = conn.Insert(person);
                StatusMessage = $"Dato añadido correctamente: {nombre}, {result} registros afectados.";
            }
            catch (Exception e)
            {
                StatusMessage = $"Error al insertar: {e.Message}";
            }
        }

        public List<Persona> GetAll()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception e)
            {
                StatusMessage = $"Error al mostrar: {e.Message}";
            }
            return new List<Persona>();
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.ID == id);
                if (person != null)
                {
                    conn.Delete(person);
                    StatusMessage = "Persona eliminada correctamente.";
                }
                else
                {
                    StatusMessage = "Persona no encontrada.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void UpdatePerson(int id, string name)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.ID == id);
                if (person != null)
                {
                    person.Name = name;
                    conn.Update(person);
                    StatusMessage = "Persona actualizada correctamente.";
                }
                else
                {
                    StatusMessage = "Persona no encontrada.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
}
