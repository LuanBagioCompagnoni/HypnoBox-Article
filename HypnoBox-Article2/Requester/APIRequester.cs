using HypnoBox_Article.Entity;
using HypnoBox_Article.Requester;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HypnoBox_Article.Entity.ArticleResponse;

namespace HypnoBox_Article.Requester
{
    public class APIRequester
    {
        public APIRequester() { }

        public async Task<List<string>> GetTopArticles()
        {
            HttpClient client = new HttpClient();
            int page = 1;
            string host = "http://mock-api.hypnobox.com.br:4011/";
            List<string> topArticles = new();
            List<Article> articles = new();
            try
            {
                do
                {
                    using var response = await client.GetAsync($"{host}teste/api/articles?page={page}");
                    var content = await response.Content.ReadAsStringAsync();
                    ArticleResponse pageArticle = JsonConvert.DeserializeObject<ArticleResponse>(content);
                    foreach (var article in pageArticle.articles)
                    {
                        articles.Add(article);
                    }

                    if (page == pageArticle.total_pages)
                        break;
                    page++;
                } while (true);

                articles.RemoveAll(x => x.title == null && x.story_title == null);

                foreach (var item in articles)
                {
                    if (item.title == null)
                        articles.FirstOrDefault(item).title = item.story_title;
                }

                var ordenedArticles = articles.OrderByDescending(x=>x.num_comments).ToList();

                var firstTenTopArticles = ordenedArticles.Take(10);

                int position = 1;
                foreach (var item in firstTenTopArticles)
                {
                    topArticles.Add($"{position}° - \"" + item.title + $"\" - With {item.num_comments} comments!\n");
                    position++;
                }
                return topArticles;
            }
            catch{ return null; }
        }
    }
}
