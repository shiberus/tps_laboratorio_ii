using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;

namespace AfipExceptionTest
{
    [TestClass]
    public class AfipExceptionTest
    {
        [TestMethod]
        [ExpectedException(typeof(AfipException))]
        public void KioscoPagarImpuestos_CuandoNoAlcanzaElDinero_DeberiaLanzarAfipException()
        {
            Orden orden = new Orden();
            Producto producto = new Producto("Alfajor Jorgito", 90);
            orden.Productos.Add(producto);
            Kiosco kiosco = new Kiosco(1, "Kiosco Evasor");
            kiosco.Compras.Add(orden);

            kiosco.PagarImpuestos();
        }
    }
}
