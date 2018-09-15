namespace News.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using News.Data;
    using News.Data.Models;

    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly NewsDbContext db;

        public NewsController(NewsDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAllNews()
        {
            return this.Ok(this.db.News);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingleNews([FromRoute]int id)
        {
            var newsFromDb = this.db.News.Find(id);

            if (newsFromDb==null)
            {
                return NotFound();
            }

            return this.Ok(newsFromDb);
        }
        
        // POST api/values
        [HttpPost]
        public IActionResult PostNews([FromBody] News news)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            this.db.Add(news);
            this.db.SaveChanges();

            return CreatedAtAction("GetSingleNews",new { id = news.Id }, news);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult PutNews([FromRoute]int id, [FromBody]News newNews)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
            if (id!=newNews.Id)
            {
                return BadRequest();
            }

            News oldNews = this.db.News.Find(id);
            if (oldNews==null)
            {
                return BadRequest();
            }

            oldNews.Title = newNews.Title;
            oldNews.Content = newNews.Content;
            oldNews.PublishedDate = newNews.PublishedDate;

            this.db.News.Update(oldNews);
            this.db.SaveChanges();

            return this.Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNews([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }
          
            News newsToDelete = this.db.News.Find(id);

            if (newsToDelete == null)
            {
                return BadRequest();
            }

            this.db.News.Remove(newsToDelete);
            this.db.SaveChanges();

            return Ok();
        }
    }
}
