using ProductsAttributesAPI.Data;

namespace ProductsAttributesRestApi.Repositories.Impl;

public abstract class BaseRepository
{
    protected readonly DataContext _dataContext;

    public BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
}
