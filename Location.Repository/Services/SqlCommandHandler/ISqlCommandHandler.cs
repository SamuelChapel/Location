namespace Location.Repository.Services.SqlCommandHandler;

public interface ISqlCommandHandler<SqlCommand, TReturn>
{
    Task<TReturn> Execute(SqlCommand command);
}