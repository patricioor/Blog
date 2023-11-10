using Blogg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogg.Data.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .ValueGeneratedOnAdd()
               .UseIdentityColumn(1 ,1);
        
        builder.Property(x => x.LastUpdateDate)
               .IsRequired()
               .HasColumnName("LastUpdateDate")
               .HasColumnType("SMALLDATETIME")
               .HasDefaultValueSql("GETDATA()");

        builder.HasIndex(x => x.Slug, "IX_Post_Slug")
               .IsUnique();

        builder.HasOne(x => x.Author)
               .WithMany(x => x.Posts)
               .HasConstraintName("FK_Post_Author")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Category)
               .WithMany(x => x.Posts)
               .HasConstraintName("FK_Post_Category")
               .OnDelete(DeleteBehavior.Cascade);

       //Virtual Table
        builder.HasMany(x => x.Tags)
               .WithMany(x => x.Posts)
               .UsingEntity<Dictionary<string, object>>
               (
                     "PostTag",
                     tag => tag.HasOne<Tag>()
                            .WithMany()
                            .HasForeignKey("TagId")
                            .HasConstraintName("FK_PostTag_TagId")
                            .OnDelete(DeleteBehavior.Cascade),
                            
                     post => post.HasOne<Post>()
                            .WithMany()
                            .HasForeignKey("PostId")
                            .HasConstraintName("FK_PostTag_PostId")
                            .OnDelete(DeleteBehavior.Cascade)
               );
    }
}
