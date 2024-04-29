using NovaVidaInfra.Common;

namespace NovaVidaInfra.Repositories
{
    public class BaseRepository
    {
        protected readonly DbContextApplication _rep;       
        public BaseRepository(DbContextApplication repository)
        {
            _rep = repository;            
        }
    }
}
