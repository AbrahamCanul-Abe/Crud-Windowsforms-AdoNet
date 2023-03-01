using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlVentasCore.Entity
{
    /// <summary>
    /// Definicion de clase que permite exponer los atributos de un producto
    /// </summary>
    public class ProductoInfo
    {
        #region Database FieldNames
        public class FieldName
        {
            public const string Id = "Id";
            public const string Nombre = "Nombre";
            public const string Descripcion = "Descripcion";
            public const string Precio = "Precio";
            public const string CategoriaId = "CategoriaId";
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        #endregion
    }
}
