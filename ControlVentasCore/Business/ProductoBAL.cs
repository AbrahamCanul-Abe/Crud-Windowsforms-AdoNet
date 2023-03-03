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
            ProductoDAL = new Data.ProductoDAL();
        }
        #endregion

        #region Properties
        public string ConnectionString 
        {
            get { return ProductoDAL.ConnectionString; }
            set { ProductoDAL.ConnectionString = value; } 
        }
        #endregion

        #region Methods
        public Entity.ProductoInfo GetProducto (int Id)
        {
            if (Id == 0) throw new ArgumentException("No recibi el id del producto que desea obtener");
            return ProductoDAL.GetEntityObject(Id);
        }

        /// <summary>
        /// Metodo que devuelve TODOS los productos existentes
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        public List<Entity.ProductoInfo> GetProductos()
        {
            return ProductoDAL.FindBy(new Entity.ProductoInfo());
        }
        
        public List<Entity.ProductoInfo> GetProductosPorId(int CategoriaId)
        {
            if (CategoriaId == 0) throw new Exception("No recibí el Id de la categoría de la que se desean obtener los productos");
            return ProductoDAL.FindBy(new Entity.ProductoInfo() { CategoriaId = CategoriaId });
        }

        public List<Entity.ProductoInfo> FindBy(Entity.ProductoInfo ProductoInfo)
        {
            if(ProductoInfo == null) throw new ArgumentNullException("No recibi un objeto entidad Producto para aplicar el filtro");
            return ProductoDAL.FindBy(ProductoInfo);
        }

        public int Save(Entity.ProductoInfo ProductoInfo)
        {
            if (ProductoInfo == null) throw new ArgumentNullException("No recibi un objeto entidad Producto para aplicar el filtro");
            if (ProductoInfo.Id == 0)
                return ProductoDAL.Insert(ProductoInfo);
            else
                return ProductoDAL.Update(ProductoInfo);
        }
        #endregion
    }
}
