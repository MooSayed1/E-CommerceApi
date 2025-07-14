namespace Persistance;

public static class SpecificationEvaluator
{
    public static IQueryable<T>? GetQuery<T>(IQueryable inputQuery,Specifications<T> specifications) where T : class
    {
        var query = inputQuery as IQueryable<T>;
        
        if (specifications.Criteria != null)
        {
            query = query.Where(specifications.Criteria);
        }
        if (specifications.IncludeExpressions.Any())
        {
            foreach (var includeExpression in specifications.IncludeExpressions)
            {
                query = query.Include(includeExpression);
            }
        }

        return query;
    }
}