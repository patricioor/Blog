using Blogg.Data;
using Blogg.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogg;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BlogDataContext();
        // var user = new User()
        // {
        //     Name = "Patrício Rios",
        //     Slug = "patriciorios",
        //     Email = "patricio@patricio.rios",
        //     Bio = "Dev Backend",
        //     Image = "https://google.com",
        //     PasswordHash = "123123123"
        // };

        // var category = new Category()
        // {
        //     Name = "Backend",
        //     Slug = "backend"
        // };

        // var post = new Post()
        // {
        //     Author = user,
        //     Category = category,
        //     Body = "<p> Hello world</p>",
        //     Slug = "comecando-com-ef-core",
        //     Summary = "Neste artigo vamos aprender EF core",
        //     Title = "Começando com EF Core",
        //     CreateDate = DateTime.Now,
        //     LastUpdateDate = DateTime.Now
        // };

        // context.Posts.Add(post);
        // context.SaveChanges();

        var posts = context
        .Posts
        .AsNoTracking()
        .Include(x => x.Author)
        .OrderByDescending(x => x.LastUpdateDate)
        .ToList();

        foreach(var post in posts)
            System.Console.WriteLine($"{post.Title}, escrito por {post.Author?.Name}");
    }
}