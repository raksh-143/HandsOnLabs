using MenuItemListing.API.Controllers;
using MenuItemListing.API.Models;
using OrderItem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace OrderItem.API.Controllers
{
    public class OrderController : ApiController
    {
        private MenuItemController MyMenuItemController = null;
        public OrderController(MenuItemController menuItemController) {
            MyMenuItemController = menuItemController;
        }
        List<Cart> MyCarts = new List<Cart>();
        [HttpPost]
        [Route("/api/menuitem/{MenuItemId}")]
        public IHttpActionResult SetCart(int MenuItemId)
        {
            IHttpActionResult result = MyMenuItemController.GetMenuItemById(MenuItemId);
            if(result is OkNegotiatedContentResult<MenuItem>)
            {
                MenuItem menuItem = (result as OkNegotiatedContentResult<MenuItem>).Content;
                MyCarts.Add(new Cart
                {
                    Id = 1,
                    UserId = 1,
                    MenuItemId = MenuItemId,
                    MenuItemName = menuItem.Name
                });
                return Ok();
            }
            else
            {
                return BadRequest("Invalid Menu Item ID");
            }
        }
    }
}