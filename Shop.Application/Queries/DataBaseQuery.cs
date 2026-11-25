using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Shop.Application.Queries;

public abstract class DataBaseQuery<TDto, TFilter>
{
    protected string _connectionString;
    protected abstract string _queryString { get; }
    
    public DataBaseQuery(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string not found.");
    }

    public virtual async Task<IEnumerable<TDto>> ExecuteAsync(TFilter variables)
        => await new SqlConnection(_connectionString).QueryAsync<TDto>(_queryString, variables);
}
