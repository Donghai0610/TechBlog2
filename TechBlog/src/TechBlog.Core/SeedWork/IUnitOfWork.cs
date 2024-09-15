namespace TechBlog.Core.SeedWork
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
