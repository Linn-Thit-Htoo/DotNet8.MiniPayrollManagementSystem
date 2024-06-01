using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace DotNet8.MiniPayrollManagementSystem.Api.Services;

public class DapperService
{
    private readonly IConfiguration _configuration;

    public DapperService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #region Query

    public List<T> Query<T>(string query, object? parameters, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        List<T> lst = db.Query<T>(query, parameters, commandType: commandType).ToList();

        return lst;
    }
    #endregion

    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        IEnumerable<T> lst = await db.QueryAsync<T>(query, parameters, commandType: commandType);

        return lst;
    }

    public T QueryFirstOrDefault<T>(string query, object? parameters, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        T? item = db.QueryFirstOrDefault<T>(query, parameters, commandType: commandType);

        return item!;
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string query, object? parameters, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        T? item = await db.QueryFirstOrDefaultAsync<T>(query, parameters, commandType: commandType);

        return item!;
    }

    public int Execute(string query, object? parameters, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        return db.Execute(query, parameters, commandType: commandType);
    }

    public async Task<int> ExecuteAsync(string query, object? parameters, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        return await db.ExecuteAsync(query, parameters, commandType: commandType);
    }
}