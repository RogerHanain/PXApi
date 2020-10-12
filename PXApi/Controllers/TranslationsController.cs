using DXProject.Database;
using DXProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SXDatabase;
using SXDatabase.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AXApi.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        private readonly PXDbContext _context;

        public TranslationsController(PXDbContext context)
        {
            _context = context;
        }

        //REQUESTS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Translation>>> GetTranslations()
        {
            List<Translation> allTranslations = await _context.Translations.ToListAsync();

            var query = this.Request.QueryString;

            if (!query.HasValue || query.Value == "?") return allTranslations;


            var word = query.Value.Split("word=")[1].Trim();
            
            return allTranslations.Where(w => w.Word.Trim() == word).ToList();
        }
    }

}
