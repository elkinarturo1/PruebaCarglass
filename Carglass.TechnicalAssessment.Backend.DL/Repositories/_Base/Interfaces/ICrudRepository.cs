namespace Carglass.TechnicalAssessment.Backend.DL.Repositories;

public interface ICrudRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity? GetById(int keyValue);
    TEntity? GetByDocNum(string keyValue);
    void Create(TEntity item);
    void Update(TEntity item);
    void Delete(TEntity item);
}
