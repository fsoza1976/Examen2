using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebAppE2.Pages.Producto
{
    public class EditModel : PageModel
    {
        private readonly IProductoService ProductoService;

        public EditModel(IProductoService ProductoService)
        {
            this.ProductoService = ProductoService;
        }

        [BindProperty]
        public ProductoEntity Entity { get; set; } = new ProductoEntity();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await ProductoService.GetById(new() { IdProducto = id });
                }

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                //Metodo de actualizar
                if (Entity.IdProducto.HasValue)
                {
                    result = await ProductoService.Update(Entity);
                }
                else
                {
                    result = await ProductoService.Create(Entity);
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