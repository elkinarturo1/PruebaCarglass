namespace Carglass.TechnicalAssessment.Backend.BL;

public interface ICrudAppService<TDto>
{
    IEnumerable<TDto> GetAll();
    TDto GetById(int keyValue);

    void Create(TDto item);
    void Update(TDto item);
    void Delete(TDto item);
}
