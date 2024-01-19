using ApiAnimais.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAnimais.Database;

public class AnimaisContext : DbContext
{
    #nullable disable
    public AnimaisContext(DbContextOptions<AnimaisContext> options) : base(options){}
    public DbSet<Animal> Animais { get; set; }
}