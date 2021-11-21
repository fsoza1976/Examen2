using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebAppE2.Pages.Orden
{
    public class EditModel : PageModel
    {
        private readonly IOrdenService OrdenService;
        private readonly IProductoService productoService;

        public EditModel(IOrdenService OrdenService, IProductoService productoService)
        {
            this.OrdenService = OrdenService;
            this.productoService = productoService;
        }

        [BindProperty]
        public OrdenEntity Entity { get; set; } = new OrdenEntity();
        public IEnumerable<ProductoEntity> Lista = new List<ProductoEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await OrdenService.GetById(new() { IdOrden = id });
                }

                Lista = await productoService.GetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                //Metodo de actualizar
                if (Entity.IdOrden.HasValue)
                {
                    result = await OrdenService.Update(Entity);
                }
                else
                {
                    result = await OrdenService.Create(Entity);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
    
