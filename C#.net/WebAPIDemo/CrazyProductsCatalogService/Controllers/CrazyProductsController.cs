using CrazyProductsCatalogService.Models.Data;
using CrazyProductsCatalogService.Models.DomainModels;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace CrazyProductsCatalogService.Controllers
{
    public class CrazyProductsController : ApiController
    {
        private CrazyProductsDbContext db = new CrazyProductsDbContext();

        #region post end points

        [Route("api/async/crazyproducts")]
        public async Task<IHttpActionResult> PostAsync(CrazyProduct product)
        {
            //validate
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input"); //400
            }
            db.CrazyProducts.Add(product);
            await db.SaveChangesAsync();
            //return: status code -> 201; location where the resource is added; content
            return Created($"api/crazyproducts/{product.Id}", product);
        }

        public IHttpActionResult Delete(int id)
        {
            var product = db.CrazyProducts.Find(id);
            if(product == null)
            {
                return NotFound();
            }
            db.CrazyProducts.Remove(db.CrazyProducts.Find(id));
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Put(CrazyProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        #endregion

        #region get end points

        //Design and implement the end-points
        //URI
        //Resource : Products
        //Action : GET
        //URI : .../api/CrazyProducts/
        
        [EnableQuery]
        [Authorize]
        public IHttpActionResult GetCrazyProducts()
        {
            return Ok(db.CrazyProducts.AsQueryable());
        }

        //[Route("api/v2/crazyproducts")]
        //If a new version of the method is to be created with additional properties
        //Create a new method with the above route

        //[Route("api/crazyproducts")]
        public IHttpActionResult Post(CrazyProduct product)
        {
            //validate
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input"); //400
            }
            db.CrazyProducts.Add(product);
            db.SaveChanges();
            //return: status code -> 201; location where the resource is added; content
            return Created($"api/crazyproducts/{product.Id}", product);
        }

        #region other get end points
        // GET .../api/crazyproducts/id
        public IHttpActionResult GetCrazyProduct(int id)
        {
            var product = db.CrazyProducts.Find(id);
            if(product == null)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(product);
        }
        //GET .../api/crazyproducts/category/categoryname
        [Route("api/crazyproducts/category/{category}")]
        public IHttpActionResult GetCrazyProductsByCategory(string category)
        {
            var products = (from p in db.CrazyProducts
                           where p.Category == category
                           select p).ToList();
            if (products == null || products.Count==0)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(products);
        }
        //return all products based on country
        [Route("api/crazyproducts/country/{country}")]
        public IHttpActionResult GetCrazyProductsByCountry(string country)
        {
            var products = (from p in db.CrazyProducts
                            where p.Country == country
                            select p).ToList();
            if (products == null || products.Count == 0)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(products);
        }


        //return all products based on brand
        [Route("api/crazyproducts/brand/{brand}")]
        public IHttpActionResult GetCrazyProductsByBrand(string brand)
        {
            var products = (from p in db.CrazyProducts
                            where p.Brand == brand
                            select p).ToList();
            if (products == null || products.Count == 0)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(products);
        }


        //return expensive product
        [Route("api/crazyproducts/cheapest")]
        public IHttpActionResult GetCheapestCrazyProducts()
        {
            var minPrice = db.CrazyProducts.Min(p => p.Price);
            var product = (from p in db.CrazyProducts
                            where p.Price == minPrice
                            select p).Take(1);
            if (product == null)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(product);
        }

        //return costliest
        [Route("api/crazyproducts/costliest")]
        public IHttpActionResult GetCostliestCrazyProduct()
        {
            var maxPrice = db.CrazyProducts.Max(p => p.Price);
            var product = (from p in db.CrazyProducts
                           where p.Price == maxPrice
                           select p).Take(1);
            if (product == null)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(product);
        }
        //return all products between min and max price
        [Route("api/crazyproducts/min/{min}/max/{max}")]
        public IHttpActionResult GetCrazyProductsNotMinAndMax(int min, int max)
        {
            var products = (from p in db.CrazyProducts
                           where p.Price > min && p.Price < max
                           select p).ToList();
            if (products == null || products.Count==0)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(products);
        }
        //return product based on name
        [Route("api/crazyproducts/name/{name}")]
        public IHttpActionResult GetCrazyProductsNotMinAndMax(string name)
        {
            var products = (from p in db.CrazyProducts
                            where p.Name.ToLower().Contains(name.ToLower())
                            select p).ToList();
            if (products == null || products.Count == 0)
            {
                //return status code 404
                return NotFound();
            }
            //return data + status code 200
            return Ok(products);
        }
        #endregion
        [Route("api/crazyproducts/download-pdf")]
        [HttpGet]
        public IHttpActionResult DownloadProducts()
        {
            var products = db.CrazyProducts.ToList();

            // Initialize a new MemoryStream object
            var memoryStream = new MemoryStream();

            // Generate the PDF using iText7
            var pdfDoc = new PdfDocument(new PdfWriter(memoryStream));
            var document = new Document(pdfDoc);

            // Create a table with 7 columns
            var table = new Table(7);
            document.Add(new Paragraph("List of Crazy Products"));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Product ID")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Product Name")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Product Description")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Product Price")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Product Brand")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Product Category")));
            table.AddHeaderCell(new Cell().Add(new Paragraph("Product Country")));

            foreach(var product in products)
            {
                table.AddCell(new Cell().Add(new Paragraph(product.Id.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.Name)));
                table.AddCell(new Cell().Add(new Paragraph(product.Description)));
                table.AddCell(new Cell().Add(new Paragraph(product.Price.ToString())));
                table.AddCell(new Cell().Add(new Paragraph(product.Brand)));
                table.AddCell(new Cell().Add(new Paragraph(product.Category)));
                table.AddCell(new Cell().Add(new Paragraph(product.Country)));
            }
            document.Add(table);

            document.Close();

            // Return the PDF as a file download
            var fileStream = new MemoryStream(memoryStream.ToArray());
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(fileStream)
            };
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Crazy Products.pdf"
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            return ResponseMessage(response);
        }
        #endregion
    }
}
