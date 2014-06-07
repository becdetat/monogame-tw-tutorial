using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShooterGame.Tests.ObjectMothers
{
    public abstract class BuilderFor<T>
    {
        private readonly IDictionary<string, object> _properties
            = new Dictionary<string, object>();

        private static string GetPropertyName<TValue>(Expression<Func<T, TValue>> property)
        {
            var memberExpression = property.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("Property must be valid on the target object", "property");
            }

            return memberExpression.Member.Name;
        }

        protected BuilderFor<T> Set<TValue>(Expression<Func<T, TValue>> property, TValue value)
        {
            _properties[GetPropertyName(property)] = value;

            return this;
        }

        protected TValue Get<TValue>(Expression<Func<T, TValue>> property)
        {
            if (!Has(property))
            {
                throw new ArgumentException(
                    string.Format("{0} has not been specified", property),
                    "property");
            }
            return (TValue) _properties[GetPropertyName(property)];
        }

        protected TValue Get<TValue>(Expression<Func<T, TValue>> property, TValue orDefault)
        {
            return Has(property) ? Get(property) : orDefault;
        }

        protected bool Has<TValue>(Expression<Func<T, TValue>> property)
        {
            return _properties.ContainsKey(GetPropertyName(property));
        }

        public abstract T Build();
    }
}