using System;
using System.Collections.Generic;

namespace ARK.CORE.Request
{
    public enum FilterClauseEnum
    {
        And = 0,
        Or = 1
    }

    public enum FilterConditionEnum
    {
        Eq = 0, //Equal == 
        Neq = 1, //NotEqual !=
        Gt = 2, //GreaterThan >
        Gteq = 3, //GreaterThanOrEqual >=
        Lt = 4, //LessThan <
        Lteq = 5, //LessThanOrEqual <=
        Con = 6, //Contains 
        Dnc = 7, //DoesNotContain
        Reg = 8 //Regex
    }

    public class FilterQuery
    {
        public string FilterName { get; set; }
        public string FilterValue { get; set; }
        public FilterClauseEnum Clause { get; private set; }
        public FilterConditionEnum Condition { get; private set; }

        public List<FilterQuery> SubFilters { get; set; } = new List<FilterQuery>();
        public List<FilterEnumContainer> Clauses { get; } = new List<FilterEnumContainer>();
        public List<FilterEnumContainer> Conditions { get; } = new List<FilterEnumContainer>();

        public FilterQuery()
        {

        }

        public FilterQuery(string filterName, string clause, string condition, string filterValue)
        {
            BuildQuery(filterName, MapClause(clause), MapCondition(condition), filterValue);
        }

        public FilterQuery(string filterName, FilterClauseEnum clause, FilterConditionEnum condition, string filterValue)
        {
            BuildQuery(filterName, clause, condition, filterValue);
        }

        private void BuildQuery(string filterName, FilterClauseEnum clause, FilterConditionEnum condition, string filterValue)
        {
            FilterName = filterName;
            Clause = clause;
            Condition = condition;
            FilterValue = filterValue;

            foreach (FilterClauseEnum val in Enum.GetValues(typeof(FilterClauseEnum)))
            {
                var isSelected = val == clause;

                Clauses.Add(new FilterEnumContainer { Name = val.ToString(), Value = (int)val, Selected = isSelected });
            }

            foreach (FilterConditionEnum val in Enum.GetValues(typeof(FilterConditionEnum)))
            {
                var isSelected = val == condition;

                Conditions.Add(
                    new FilterEnumContainer { Name = val.ToString(), Value = (int)val, Selected = isSelected });
            }
        }

        private static FilterClauseEnum MapClause(string clause)
        {
            foreach (FilterClauseEnum filterClauseEnum in Enum.GetValues(typeof(FilterClauseEnum)))
                if (filterClauseEnum.ToString() == clause)
                    return filterClauseEnum;

            throw new ArgumentException();
        }

        private static FilterConditionEnum MapCondition(string condition)
        {
            foreach (FilterConditionEnum filterConditionEnum in Enum.GetValues(typeof(FilterConditionEnum)))
                if (filterConditionEnum.ToString() == condition)
                    return filterConditionEnum;

            throw new ArgumentException();
        }

        public class FilterEnumContainer
        {
            public string Name { get; set; }
            public bool Selected { get; set; }
            public int Value { get; set; }
        }
    }


}