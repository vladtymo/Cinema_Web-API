using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).HasMaxLength(350).IsRequired();
            builder.HasOne(m => m.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(m => m.GenreId)
                   .IsRequired();
        }
    }
}
