using Microsoft.AspNetCore.Mvc;

namespace DDB.DVDCentral.UI.ViewComponents
{
    public class OrderItemsTable : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(GenreManager.Load());
        }
    }
}
