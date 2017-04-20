using System;
using System.Linq;

namespace EMS.Core.Domain.Entities
{
    /// <summary>
    /// Value Object base (Handles Equality)
    /// </summary>
    /// <typeparam name="TValueObject"></typeparam>
    public class ValueObjectBase<TValueObject> : IEquatable<TValueObject>
        where TValueObject : ValueObjectBase<TValueObject>
    {
        /// <summary>
        /// Indicates whether the current object 
        /// is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal 
        /// to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(TValueObject other)
        {
            if (other == null)
                return false;

            // Compare all public properties
            var publicProperties = GetType().GetProperties();

            if (publicProperties != null && publicProperties.Any())
                return publicProperties
                    .All(item => item.GetValue(this, null)
                        .Equals(item.GetValue(other, null)));

            return true;
        }

        /// <summary>
        /// Equality
        /// </summary>
        public override bool Equals(object obj)
        {
            // If both are null, or both are same instance, return true
            if (ReferenceEquals(obj, this))
                return true;

            if (obj == null)
                return false;

            var item = obj as ValueObjectBase<TValueObject>;

            if (item == null)
                return false;

            return Equals((TValueObject) item);
        }

        /// <summary>
        /// Get hash code
        /// </summary>
        public override int GetHashCode()
        {
            var hashCode = 31;
            var changeMultiplier = false;
            const int index = 1;

            // Compare all public properties
            var publicProperties = GetType().GetProperties();

            if (publicProperties != null && publicProperties.Any())
            {
                foreach (var value in publicProperties
                    .Select(item => item.GetValue(this, null)))
                {
                    if (value != null)
                    {
                        hashCode = hashCode*((changeMultiplier) ? 59 : 114)
                                   + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                        hashCode = hashCode ^ (index*13); // Support order
                }
            }

            return hashCode;
        }

        /// <summary>
        /// Equal operator
        /// </summary>
        public static bool operator ==(ValueObjectBase<TValueObject> x, ValueObjectBase<TValueObject> y)
        {
            return Equals(x, y);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        public static bool operator !=(ValueObjectBase<TValueObject> x, ValueObjectBase<TValueObject> y)
        {
            return !(x == y);
        }
    }
}