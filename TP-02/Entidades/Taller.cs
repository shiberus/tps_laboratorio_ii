﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }

        #region "Constructores"
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Taller(int espacioDisponible)
            : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            if(taller != null)
            {
                sb.AppendLine($"Tenemos {taller.vehiculos.Count} lugares ocupados de un total de {taller.espacioDisponible} disponibles");
                sb.AppendLine("");
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if(tipo == ETipo.Todos || tipo.ToString().ToLower() == v.GetType().Name.ToLower())
                    {
                        sb.AppendLine(v.Mostrar());
                    }
                }
            }

            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns></returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            bool estaEnElTaller = false;

            if(taller != null && vehiculo != null)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        estaEnElTaller = true;
                        break;
                    }
                }

                if(!estaEnElTaller && taller.vehiculos.Count < taller.espacioDisponible)
                {
                    taller.vehiculos.Add(vehiculo);
                }
            }

            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns></returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            if(taller != null && vehiculo != null)
            {
                foreach (Vehiculo v in taller.vehiculos)
                {
                    if (v == vehiculo)
                    {
                        taller.vehiculos.Remove(v);
                        break;
                    }
                }
            }

            return taller;
        }
        #endregion
    }
}
