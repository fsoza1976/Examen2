using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using Entity;

namespace WBL
{
    public interface IOrdenService
    {
        Task<DBEntity> Create(OrdenEntity entity);
        Task<DBEntity> Delete(OrdenEntity entity);
        Task<IEnumerable<OrdenEntity>> Get();
        Task<OrdenEntity> GetById(OrdenEntity entity);
        Task<DBEntity> Update(OrdenEntity entity);
    }

    public class OrdenService : IOrdenService
    {
        private readonly IDataAccess sql;

        public OrdenService(IDataAccess _sql)
        {
            sql = _sql;
        }


        #region MetodosCRUD

        //Método GET
        public async Task<IEnumerable<OrdenEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<OrdenEntity, ProductoEntity>("dbo.OrdenObtener","IdOrden, IdProducto");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método GET ID
        public async Task<OrdenEntity> GetById(OrdenEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<OrdenEntity>("dbo.OrdenObtener", new { entity.IdOrden });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método CREATE
        public async Task<DBEntity> Create(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.OrdenInsertar", new
                {
                    entity.IdProducto,
                    entity.CantidadProducto,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método UPDATE
        public async Task<DBEntity> Update(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.OrdenActualizar", new
                {
                    entity.IdOrden,
                    entity.IdProducto,
                    entity.CantidadProducto,
                    entity.Estado
                });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Método ELIMINAR
        public async Task<DBEntity> Delete(OrdenEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.OrdenEliminar", new
                {
                    entity.IdOrden
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
