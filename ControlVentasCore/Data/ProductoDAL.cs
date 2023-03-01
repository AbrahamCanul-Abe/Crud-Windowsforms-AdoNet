using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlVentasCore.Data
{
    public class ProductoDAL
    {
        #region Properties
        /// <summary>
        /// String de conexion a la bd
        /// </summary>
        public string ConnectionString { get; set; }
        #endregion

        #region Methods 

        /// <summary>
        /// devuelve un objeto entidad del id solicitado
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Entity.ProductoInfo GetEntityObject(int Id)
        {
            
        }

        /// <summary>
        /// Devulve un objeto entidad con los datos recibidos en el row
        /// </summary>
        /// <param name="Row"></param>
        /// <returns></returns>
        private Entity.ProductoInfo GetEntityObject(DataRow Row)
        {
            if (Row == null) throw new ArgumentNullException("No recibimos el datarow para obtener los datos");

            Entity.ProductoInfo ProductoInfo = new Entity.ProductoInfo();
            ProductoInfo.Id = Convert.ToInt32(Row[Entity.ProductoInfo.FieldName.Id]);
            ProductoInfo.Nombre = Row[Entity.ProductoInfo.FieldName.Nombre].ToString();
            ProductoInfo.Descripcion = Row[Entity.ProductoInfo.FieldName.Descripcion].ToString();
            ProductoInfo.Precio = Convert.ToDecimal(Row[Entity.ProductoInfo.FieldName.Precio].ToString());
            ProductoInfo.CategoriaId = Convert.ToInt32([Entity.ProductoInfo.FieldName.CategoriaId]);

            return ProductoInfo;
        }

        /// <summary>
        /// inserta el objeto entidad especificado en la BD
        /// </summary>
        /// <param name="ProductoInfo"></param>
        /// <returns></returns>
        public int Insert(Entity.ProductoInfo ProductoInfo)
        {

        }

        /// <summary>
        /// actualiza el objetoe entidad especificad
        /// </summary>
        /// <param name="ProductosInfo"></param>
        /// <returns></returns>
        public int Update(Entity.ProductoInfo ProductosInfo)
        {

        }

        /// <summary>
        /// borra el objeto entidad con el id especificado
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int Delete(int Id)
        {

        }

        /// <summary>
        /// Devulve una lista de objetos entidad que cumplen las condiciones modificadas en el objeto entidad especificado
        /// </summary>
        /// <param name="Producto"></param>
        /// <returns></returns>
        public List<Entity.ProductoInfo> GetEntityObjects(Entity.ProductoInfo Producto)
        {

        }
        #endregion
    }
}
