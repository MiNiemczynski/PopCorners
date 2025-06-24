using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace PopCorners.Models.Contexts;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Award> Awards { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Favourite> Favourites { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Platform> Platforms { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<ProductionAward> ProductionAwards { get; set; }

    public virtual DbSet<ProductionCast> ProductionCasts { get; set; }

    public virtual DbSet<ProductionGenre> ProductionGenres { get; set; }

    public virtual DbSet<ProductionTag> ProductionTags { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Series> Series { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = config.GetConnectionString("PopCornersConnectionString");

        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.LogTo(item => Debug.WriteLine(item));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actors__57B3EA2B47B15CBE");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Award>(entity =>
        {
            entity.HasKey(e => e.AwardId).HasName("PK__Awards__B08935DEFBEEEDEE");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirectorId).HasName("PK__Director__26C69E26C9FCB869");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.HasKey(e => e.FavouritesId).HasName("PK__Favourit__26550E2C98AED4C1");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Production).WithMany(p => p.Favourites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favourite__Produ__160F4887");

            entity.HasOne(d => d.User).WithMany(p => p.Favourites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Favourite__UserI__151B244E");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385055E9FF432E0");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Platform>(entity =>
        {
            entity.HasKey(e => e.PlatformId).HasName("PK__Platform__F559F6DA7F888A9A");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.ProductionId).HasName("PK__Producti__D5D9A2F575B53D2A");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EpisodeNumber).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.SeasonId).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.Director).WithMany(p => p.Productions).HasConstraintName("FK__Productio__Direc__6383C8BA");

            entity.HasOne(d => d.Platform).WithMany(p => p.Productions).HasConstraintName("FK__Productio__Platf__6477ECF3");

            entity.HasOne(d => d.Season).WithMany(p => p.Productions).HasConstraintName("FK__Productio__Seaso__66603565");
        });

        modelBuilder.Entity<ProductionAward>(entity =>
        {
            entity.HasKey(e => e.ProductionAwardId).HasName("PK__Producti__F86DB8740DFE512A");

            entity.HasOne(d => d.Award).WithMany(p => p.ProductionAwards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Award__74AE54BC");

            entity.HasOne(d => d.Production).WithMany(p => p.ProductionAwards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Produ__75A278F5");
        });

        modelBuilder.Entity<ProductionCast>(entity =>
        {
            entity.HasKey(e => e.ProductionCastId).HasName("PK__Producti__709621FFC2896145");

            entity.HasOne(d => d.Actor).WithMany(p => p.ProductionCasts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Actor__08B54D69");

            entity.HasOne(d => d.Production).WithMany(p => p.ProductionCasts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Produ__09A971A2");
        });

        modelBuilder.Entity<ProductionGenre>(entity =>
        {
            entity.HasKey(e => e.ProductionGenreId).HasName("PK__Producti__11E17DA540F4085A");

            entity.HasOne(d => d.Genre).WithMany(p => p.ProductionGenres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Genre__7F2BE32F");

            entity.HasOne(d => d.Production).WithMany(p => p.ProductionGenres)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Produ__00200768");
        });

        modelBuilder.Entity<ProductionTag>(entity =>
        {
            entity.HasKey(e => e.ProductionTagId).HasName("PK__Producti__ECE64BFBC415A5C3");

            entity.HasOne(d => d.Production).WithMany(p => p.ProductionTags)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__Produ__2DE6D218");

            entity.HasOne(d => d.Tag).WithMany(p => p.ProductionTags)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__TagID__2EDAF651");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE7828D05F");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Production).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__Product__1DB06A4F");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__UserID__1EA48E88");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.SeasonId).HasName("PK__Seasons__C1814E18942AA749");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasOne(d => d.Series).WithMany(p => p.Seasons)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Seasons__SeriesI__5BE2A6F2");
        });

        modelBuilder.Entity<Series>(entity =>
        {
            entity.HasKey(e => e.SeriesId).HasName("PK__Series__F3A1C101C139E35C");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CFA4C8BE9F490");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC0504EFAC");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DeletionDate).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.EditionDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
