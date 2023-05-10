using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypnoBox_Article.Entity
{
    public class ArticleResponse
    {
        [JsonProperty("page")]
        public int page { get; set; }

        [JsonProperty("per_page")]
        public int per_page { get; set; }

        [JsonProperty("total")]
        public int total { get; set; }

        [JsonProperty("total_pages")]
        public int total_pages { get; set; }

        [JsonProperty("data")]
        public List<Article> articles { get; set; }


        public class Article
        {
            [JsonProperty("title")]
            public string title { get; set; }

            [JsonProperty("url")]
            public string url { get; set; }

            [JsonProperty("author")]
            public string author { get; set; }

            [JsonProperty("num_comments")]
            public int? num_comments { get; set; }

            [JsonProperty("story_id")]
            public object story_id { get; set; }

            [JsonProperty("story_title")]
            public string story_title { get; set; }

            [JsonProperty("story_url")]
            public string story_url { get; set; }

            [JsonProperty("parent_id")]
            public int? parent_id { get; set; }

            [JsonProperty("created_at")]
            public int created_at { get; set; }
        }
    }
}
