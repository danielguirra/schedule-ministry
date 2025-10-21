namespace ApiEscala.Database;

public abstract class BaseService(AppDbContext context)
{
    protected readonly AppDbContext context = context;

    protected async Task SaveAsync()
    {
        int saved = await context.SaveChangesAsync();
        if (saved == 0)
            throw new Exception("Nada foi salvo no banco.");
    }
}
