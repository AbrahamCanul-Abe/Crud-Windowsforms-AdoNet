using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlVentasCore.Business
{
    /// <summary>
    /// Definicion de clase que permite exponer metodos de negocio para los productos
    /// </summary>
    public class ProductoBAL
    {
        #region Variables Globales...
        private Data.ProductoDAL ProductoDAL;
        #endregion

        #region Constructor...
        public ProductoBAL()
        {
            ProductoBAL = new Data.ProductoDAL();
        }
        #endregion
    }
}
