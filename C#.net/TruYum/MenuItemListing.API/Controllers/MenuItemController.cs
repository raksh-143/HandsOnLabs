using MenuItemListing.API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;

namespace MenuItemListing.API.Controllers
{
    public class MenuItemController : ApiController
    {
        List<MenuItem> myMenuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Id = 1,
                    Name = "Pizza",
                    FreeDelivery = true,
                    Price = 300,
                    //DateOfLaunch = DateTime.ParseExact("2023-02-29","yyyy-MM-dd",null),
                    Active = true
                },
                new MenuItem
                {
                    Id = 2,
                    Name = "Burger",
                    FreeDelivery = false,
                    Price = 100,
                    DateOfLaunch = DateTime.ParseExact("2023-01-20","yyyy-MM-dd",null),
                    Active = true
                },
                new MenuItem
                {
                    Id = 3,
                    Name = "Fried Chicken",
                    FreeDelivery = false,
                    Price = 500,
                    DateOfLaunch = DateTime.ParseExact("2022-11-27","yyyy-MM-dd",null),
                    Active = false
                }
            };
        // GET: MenuItem
        [HttpGet]
        public IHttpActionResult GetAllMenuItems()
        {
            return Ok(myMenuItems);
        }
        [HttpGet]
        public IHttpActionResult GetMenuItemById(int Id) {
            return Ok(myMenuItems.Find(x => x.Id == Id));
        }
    }
}