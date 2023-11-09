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
               .HasDefaultValueSql ("GETDATA()");

        builder.HasIndex(x => x.Slug, "IX_Post_Slug")
               .IsUnique();
    }
}
