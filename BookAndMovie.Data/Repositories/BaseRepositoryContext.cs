namespace BookAndMovie.Data.Repositories
{
    public abstract class BaseRepositoryContext
    {
        protected readonly BookAndMovieDbContext context;
        public BaseRepositoryContext(BookAndMovieDbContext context)
        {
            this.context=context;
        }
    }
}
