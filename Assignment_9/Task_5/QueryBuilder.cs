namespace Task_5
{
    public class QueryBuilder<T, TJoin>
    {
        private IEnumerable<object>? _result;
        private IEnumerable<T> _primaryList;
        private IEnumerable<TJoin> _joinList;

        public QueryBuilder(IEnumerable<T> primaryList, IEnumerable<TJoin> joinList)
        {
            _primaryList = primaryList;
            _joinList = joinList;
        }

        public QueryBuilder<T, TJoin> Filter(Func<T, bool> filter)
        {
            IEnumerable<T>? temp = _result as IEnumerable<T>;
            _result = _primaryList.Where(filter) as IEnumerable<object>;
            return this;
        }

        public QueryBuilder<T, TJoin> SortBy(Func<T, object> sortColumn)
        {
            IEnumerable<T>? temp = _result as IEnumerable<T>;
            _result = temp.OrderBy(sortColumn) as IEnumerable<object>;
            return this;
        }

        public QueryBuilder<T, TJoin> Join(Func<TJoin, T, bool> joinCondition)
        {
            var filteredPrimary = _result as IEnumerable<T>;
            _result = filteredPrimary
                .SelectMany(p => _joinList
                    .Where(s => joinCondition(s, p))
                    .Select(s => new { Product = p, Supplier = s })) as IEnumerable<object>;
            return this;
        }

        public IEnumerable<object>? Execute()
        {
            return _result;
        }

    }
}