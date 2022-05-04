using Microsoft.AspNetCore.Mvc;

namespace DocumentsManager.Service.Controllers{
    
   [ApiController]
   [Route("api")]
    public class DocumentsController : ControllerBase {

        [HttpGet("getDocuments")]
        public string Get(){
            return "test";
        }
    }

}
    
        
        
        
        
        
        
        