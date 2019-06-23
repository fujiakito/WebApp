using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {
        private readonly IApplicationDbContext db;

        public ProductsController()
        {
            db = new ApplicationDbContext();
        }

        public ProductsController(IApplicationDbContext context)
        {
            db = context;
        }

        // GET: api/Products
        public GetProductsDto GetProducts()
        {
            var products = from p in db.Products
                           select new ProductDto
                           {
                               Id = p.Id
                           };

            var dto = new GetProductsDto
            {
                Id = Guid.NewGuid().ToString(),
                Timestamp = DateTime.Now,
                Products = products.ToList()
            };

            return dto;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            //db.Entry(product).State = EntityState.Modified;
            db.MarkAsModified(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(PutProductsDto))]
        public async Task<IHttpActionResult> PostProduct(PutProductsDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (var product in dto.Products)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
            }

            return CreatedAtRoute("DefaultApi", new { id = dto.Id }, dto);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}