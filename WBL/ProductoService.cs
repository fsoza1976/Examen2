using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Entity;

namespace WBL
{
    public interface IProductoService
    {
        Task<DBEntity> Create(ProductoEntity entity);
        Task<DBEntity> Delete(ProductoEntity entity);
        Task<IEnumerable<ProductoEntity>> Get();
        Task<IEnumerable<ProductoEntity>> GetLista();
        Task<ProductoEntity> GetById(ProductoEntity entity);
        Task<DBEntity> Update(ProductoEntity entity);
    }

    public class ProductoService : IProductoService
    {
        private readonly IDataAccess sql;

        public ProductoService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region MetodosCRUD

        //Método GET
        public async Task<IEnumerable<ProductoEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ProductoEntity>("dbo.ProductoObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Método GET Lista
        public async Task<IEnumerable<ProductoEntity>> GetLista()
        {
            try
            {
                var result = sql.QueryAsync<ProductoEntity>("dbo.ProductoLista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Método GET ID
        public async Task<ProductoEntity> GetById(ProductoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ProductoEntity>("dbo.ProductoObtener", new { entity.IdProducto });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método CREATE
        public async Task<DBEntity> Create(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductoInsertar", new
                {
                    entity.NombreProducto,
                    entity.PrecioProducto
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método UPDATE
        public async Task<DBEntity> Update(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductoActualizar", new
                {
                    entity.IdProducto,
                    entity.NombreProducto,
                    entity.PrecioProducto
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método ELIMINAR
        public async Task<DBEntity> Delete(ProductoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProductoEliminar", new
                {
                    entity.IdProducto
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion

    }
}


