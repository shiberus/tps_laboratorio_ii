using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using System.Collections.Generic;

namespace SerializadorTest
{
    [TestClass]
    public class SerializadorTest
    {
        [TestMethod]
        public void Test_Serializar_Deserializar()
        {
            Orden ordenOriginal = new Orden();
            Orden ordenDeserializada;
            Producto producto = new Producto("Alfajor Jorgito", 90);
            string nombreArchivo = ordenOriginal.GetHashCode().ToString();
            ordenOriginal.Productos.Add(producto);

            Serializador.Serializar<Orden>(ordenOriginal);
            ordenDeserializada = Serializador.Deserializar<Orden>(nombreArchivo);

            Assert.AreEqual(ordenOriginal.Total, ordenDeserializada.Total);
            Assert.AreEqual(ordenOriginal.Fecha, ordenDeserializada.Fecha);
        }
    }
}
