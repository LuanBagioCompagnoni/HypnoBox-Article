// See https://aka.ms/new-console-template for more information
using HypnoBox_Article.Requester;

APIRequester requester = new();

Console.WriteLine("This is the top 10 articles, ordened by comments:\n");
foreach (var item in await requester.GetTopArticles())
{
    Console.WriteLine(item);
}