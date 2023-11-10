using Blogg.Data;
using Blogg.Models;
using Microsoft.EntityFrameworkCore;

namespace Blogg;

class Program
{
    static void Main(string[] args)
    {
        using var context = new BlogDataContext();
        // context.Users.Add(new User
        // {
        //     Name = "Patrício Rio",
        //     Slug = "patriciorio",
        //     Email = "patricio@patricio.rios",
        //     Bio = "Dev Backend",
        //     Image = "https://google.com",
        //     PasswordHash = "123123123"
        // });
        // context.SaveChanges();

        var user = context.Users.FirstOrDefault(x => x.Id == 3);
        var post = new Post
        {
            Author = user,
            Body = "Meu Artigo",
            Category = new Category
                {
                    Name = "BackEnd",
                    Slug = "backend"
                },
            CreateDate = DateTime.Now,
            Slug = "meu-artigo",
            Summary = "Neste artigo..",
            Title = "Meu artigo"
        };
        context.Posts.Add(post);
        context.SaveChanges();

    }
}