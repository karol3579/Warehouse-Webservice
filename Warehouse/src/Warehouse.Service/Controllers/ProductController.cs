using Microsoft.AspNetCore.Mvc;
using Warehouse.Service.Entities;
using Warehouse.Service.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Warehouse.Service.Controllers{

    [ApiController]
    public class ProductController : ControllerBase{
        public SqlRepository sqlRepository;

        public ProductController(SqlRepository sqlRepository)
        {   
            this.sqlRepository = sqlRepository;
        }

        [Route("[controller]")]
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get(){
            var products = sqlRepository.Product.ToList();
            return Ok(products);
        }

        [HttpGet("[controller]/{id}")]
        public ProductDto GetSingleDto(Guid id){
            return GetSingle(id).AsDto();
        }


        [HttpPost("addProduct")]
        public ActionResult<ProductDto> Post(string name){
            var product = new Product();
            product.name= name;
            product.createdAt = DateTime.Now;
            if(sqlRepository.Database.CanConnect()){
                sqlRepository.Add<Product>(product);
                sqlRepository.SaveChanges();
                return Ok();

            }
            return BadRequest();
        }

        [HttpPost("addQuantity")]
        public async Task<ActionResult<ProductWithQuantityDto>> Postinv(CreateProductWithQuantityDto product){
            var prod = GetSingle(product.productId);
            var searchresut = sqlRepository.Stock.Include(s => s.product).FirstOrDefault( s => s.product.id == product.productId);
            if(searchresut != null){
                searchresut.quantity += product.quantity;
            }
            else{
            var inv = new Stock(){
            product = prod,
            quantity=product.quantity
            };
            await sqlRepository.AddAsync<Stock>(inv);
            }

            await sqlRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("getQuantity/{id}")]
        public ActionResult<IEnumerable<ProductWithQuantityDto>> GetInvById(Guid id){
            var result = sqlRepository.Stock.Include(s => s.product).Where(s => s.product.id==id).ToList();
            foreach (var x in result) x.AsDto();
            return Ok(result);
        }

        private Product GetSingle(Guid id){
            return sqlRepository.Find<Product>(id);
        }

    }
}