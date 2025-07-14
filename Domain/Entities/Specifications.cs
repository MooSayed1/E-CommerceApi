using System.Linq.Expressions;

namespace Domain.Entities;

public abstract class Specifications<T>(Expression<Func<T, bool>>? criteria)
{
    public Expression<Func<T,bool>>? Criteria { get;} = criteria;
    public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();
    public void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        IncludeExpressions.Add(includeExpression);
    }
}

// include --> List<Expression<Func<TEntity, object>>> load data 
// include --> List<Expression<Func<TEntity, bool>>> where data
