using System;
using PlainElastic.Net.Utils;

namespace PlainElastic.Net.Queries
{
    /// <summary>
    /// Facets provide aggregated data based on a search query.
    /// see http://www.elasticsearch.org/guide/reference/api/search/facets/index.html
    /// </summary>
    public class Facets<T> : QueryBase<Facets<T>>
    {

        /// <summary>
        /// Allows to specify field facets that return the N most frequent terms
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/terms-facet.html
        /// </summary>
        public Facets<T> Terms(Func<TermsFacet<T>, TermsFacet<T>> termsFacet)
        {
            RegisterJsonPartExpression(termsFacet);
            return this;
        }

        /// <summary>
        /// Allows you to return a count of the hits matching the filter.
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/filter-facet.html
        /// </summary>
        public Facets<T> FilterFacets(Func<FilterFacet<T>, FilterFacet<T>> filterFacet)
        {
            RegisterJsonPartExpression(filterFacet);
            return this;
        }

        /// <summary>
        /// Allows to specify a set of ranges and get both the number of docs (count) that fall within each range,
        /// and aggregated data either based on the field, or using another field.
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/range-facet.html
        /// </summary>
        public Facets<T> Range(Func<RangeFacet<T>, RangeFacet<T>> rangeFacet)
        {
            RegisterJsonPartExpression(rangeFacet);
            return this;
        }

        /// <summary>
        /// Allows to compute statistical data on a numeric fields.
        /// The statistical data include count, total, sum of squares, mean (average), minimum, maximum, variance, and standard deviation.
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/statistical-facet/
        /// </summary>
        public Facets<T> Statistical(Func<StatisticalFacet<T>, StatisticalFacet<T>> statisticalFacet)
        {
            RegisterJsonPartExpression(statisticalFacet);
            return this;
        }

        /// <summary>
        /// Combines both the terms and statistical allowing to compute stats computed on a field, per term value driven by another field.
        /// see http://www.elasticsearch.org/guide/reference/api/search/facets/terms-stats-facet/
        /// </summary>
        public Facets<T> TermsStats(Func<TermsStatsFacet<T>, TermsStatsFacet<T>> termsStatsFacet)
        {
            RegisterJsonPartExpression(termsStatsFacet);
            return this;
        }
        

        protected override bool HasRequiredParts()
        {
            return true;
        }

        protected override string ApplyJsonTemplate(string body)
        {
            return "'facets': {{ {0} }}".AltQuoteF(body);
        }
    }
}