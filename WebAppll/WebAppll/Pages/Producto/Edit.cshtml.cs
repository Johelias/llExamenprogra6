using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebAppll.Pages.Producto
{

    public class EditModel : PageModel
    {
        private readonly IProductoService productoService;
        
        public EditModel(IProductoService productoService)
        {
            this.productoService = productoService;
       
        }

        [BindProperty]
        public ProductoEntity Entity { get; set; } = new ProductoEntity();
     

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


       
        public async Task<IActionResult> OnPostAsync()
        {

            try
            {
                //Metodo Actualizar
                if (Entity.IdProducto.HasValue)
                {
                    var result = await productoService.Update(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha actualizado";
                }
                else
                {
                    var result = await productoService.Create(Entity);

                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha insertado";
                }

                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }








    }
}
