using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IProductoService
    {
        Task<BDEntity> Create(ProductoEntity entity);
        Task<BDEntity> Delete(ProductoEntity entity);
        Task<IEnumerable<ProductoEntity>> Get();
        Task<ProductoEntity> GetById(ProductoEntity entity);
        Task<BDEntity> Update(ProductoEntity entity);

        Task<IEnumerable<ProductoEntity>> GetLista();

    }


    public class ProductoService : IProductoService
    {
        private readonly IDataAccess sql;

        public ProductoService(IDataAccess _sql)
        {
            sql = _sql;
        }


   

        #region MetodosCrud

        public async Task<BDEntity> Create(ProductoEntity entity)
        {

            try
            {
                var result = sql.ExecuteAsync("exp.Insertar", new
                {
                    entity.IdProducto,           
                    entity.NombreProducto,
                    entity.PrecioProducto,
                    


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<BDEntity> Delete(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.Eliminar", new
                {
                    entity.IdProducto,



                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ProductoEntity>("exp.Obtener", "IdProducto");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ProductoEntity> GetById(ProductoEntity entity)
        {

            try
            {
                var result = sql.QueryFirstAsync<ProductoEntity>("exp.Obtener", new
                { entity.IdProducto});

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ProductoEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ProductoEntity>("ProductoLista");

                return await result;
            }
            catch (Exception EX)
            {

                throw;
            }
        }

        public async Task<BDEntity> Update(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("exp.Actualizar", new
                {
                    entity.IdProducto,
                    entity.NombreProducto,
                    entity.PrecioProducto,
                    

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    
    #endregion


}
