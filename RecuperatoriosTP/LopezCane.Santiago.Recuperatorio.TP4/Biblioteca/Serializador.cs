using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class Serializador
    {
        private static string ruta;

        static Serializador()
        {
            DirectoryInfo path = Directory.CreateDirectory($"{Environment.CurrentDirectory}\\FacturasKiosco\\");

            Serializador.ruta = path.FullName;
        }

        public static bool Serializar<T>(T obj) where T : class, new()
        {
            JsonSerializerOptions opciones = new JsonSerializerOptions();
            opciones.WriteIndented = true;
            string jsonString = JsonSerializer.Serialize(obj, opciones);

            try
            {
                File.WriteAllText($"{Serializador.ruta}{obj.GetHashCode()}.json", jsonString);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static T Deserializar<T>(string nombreArchivo) where T : class, new()
        {
            string jsonString;
            T obj;

            try
            {
                jsonString = File.ReadAllText($"{Serializador.ruta}{nombreArchivo}.json");
                obj = JsonSerializer.Deserialize<T>(jsonString);
            }
            catch(Exception)
            {
                return null;
            }

            return obj;
        }
    }
}
