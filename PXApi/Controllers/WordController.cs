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
    public class WordController : ControllerBase //TODO renommer en WordsController
    {
        private readonly PXDbContext context;

        public WordController(PXDbContext context)
        {
            this.context = context;
        }

        //REQUESTS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Word>>> GetWords()
        {
            List<Word> l = await GetAllWords();

            var allWords = new List<Word>();
            foreach (var item in l)
            {
                allWords.Add(CleanWord(item));
            }

            var query = this.Request.QueryString;
            //_context.Requests.Add(new Request() { RequestURL = query.ToString() });


            if (query.HasValue)
            {
                var episodeName = GetEpisodeName(query.Value);
                return allWords.Where(w => w.Episod.Trim() == episodeName).ToList();
            }

            return allWords;
        }

        //TODO A mettre dans le domaine
        private async Task<List<Word>> GetAllWords()
        {
            return await context.Words.ToListAsync();
        }

        private string GetEpisodeName(string queryString)
        {
            return queryString.Split('=')[1];
        }

        private Word CleanWord(Word item)
        {
            var newWord = new Word();
            newWord.Id = item.Id;
            newWord.Name = item.Name.Trim();
            newWord.Episod = item.Episod.Trim();

            return newWord;
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Word>> DeleteWord(int id)
        //{
        //    var mots = await context.Words.FindAsync(id);
        //    if (mots == null)
        //    {
        //        return NotFound();
        //    }

        //    context.Words.Remove(mots);
        //    await context.SaveChangesAsync();

        //    return mots;
        //}
    }

}
