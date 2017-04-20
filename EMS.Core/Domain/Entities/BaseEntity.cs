using System;
using System.ComponentModel;
using EMS.Core.Domain.Validation;
using EMS.Core.Helpers;

namespace EMS.Core.Domain.Entities
{
    [Serializable]
    public abstract class BaseEntity<TKey> : IEquatable<IEntity<TKey>>, IAggregateRoot
    {
        private TKey _Id;

        [Browsable(false)]
        [DisplayName("Id")]
        [Category("Primary Key")]
        public virtual TKey Id
        {
            get
            {
                try
                {
                    return _Id;
                }
                catch (Exception err)
                {
                    throw new Exception("Error getting Id", err);
                }
            }
            protected set
            {
                try
                {
                    _Id = value;
                }
                catch (Exception err)
                {
                    throw new Exception("Error setting Id", err);
                }
            }
        }

        /// <remarks>SQL Type:tinyint - </remarks>
        private byte _LocationId;

        [Browsable(false)]
        [DisplayName("Location Id")]
        [Category("Column")]
        public virtual byte LocationId
        {
            get
            {
                try
                {
                    return _LocationId;
                }
                catch (Exception err)
                {
                    throw new Exception("Error getting LocationId", err);
                }
            }
            set
            {
                try
                {
                    _LocationId = value;
                }
                catch (Exception err)
                {
                    throw new Exception("Error setting LocationId", err);
                }
            }
        }

        private DateTime _InsertDate;

        [Browsable(false)]
        [DisplayName("Insert Date")]
        [Category("Column")]
        public virtual DateTime InsertDate
        {
            get
            {
                try
                {
                    return _InsertDate;
                }
                catch (Exception err)
                {
                    throw new Exception("Error getting InsertDate", err);
                }
            }
            set
            {
                try
                {
                    _InsertDate = value;
                }
                catch (Exception err)
                {
                    throw new Exception("Error setting InsertDate", err);
                }
            }
        }

        private DateTime _UpdateDate;

        [Browsable(false)]
        [DisplayName("Update Date")]
        [Category("Column")]
        public virtual DateTime UpdateDate
        {
            get
            {
                try
                {
                    return _UpdateDate;
                }
                catch (Exception err)
                {
                    throw new Exception("Error getting UpdateDate", err);
                }
            }
            set
            {
                try
                {
                    _UpdateDate = value;
                }
                catch (Exception err)
                {
                    throw new Exception("Error setting UpdateDate", err);
                }
            }
        }

        private ValidationResult _ValidationResult;

        [Browsable(false)]
        public virtual ValidationResult ValidationResult
        {
            get { return _ValidationResult; }
            protected set { _ValidationResult = value; }
        }

        private EntityState _state;

        [Browsable(false)]
        public virtual EntityState State
        {
            get { return _state; }
            set { _state = value; }
        }

        [Browsable(false)]
        public virtual Boolean IsAdded
        {
            get { return _state == EntityState.Added; }
        }

        [Browsable(false)]
        public virtual Boolean IsModified
        {
            get { return _state == EntityState.Modified; }
        }

        [Browsable(false)]
        public virtual Boolean IsDeleted
        {
            get { return _state == EntityState.Deleted; }
        }

        [Browsable(false)]
        public virtual Boolean IsDetached
        {
            get { return _state == EntityState.Detached; }
        }

        [Browsable(false)]
        public virtual Boolean IsUnchanged
        {
            get { return _state == EntityState.Unchanged; }
        }

        #region IEquatable<Entity> Members

        public override bool Equals(object obj)
        {
            var entity = obj as IEntity<TKey>;
            if (entity != null)
            {
                return Equals(entity);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode()*907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

        public virtual bool Equals(IEntity<TKey> other)
        {
            if (other == null)
            {
                return false;
            }
            return Id.Equals(other.Id);
        }

        #endregion

        #region State Changed Methods

        /// <summary>
        /// Changes the Item.EntityState of a item to Added.
        /// </summary>        
        public virtual void SetAdded()
        {
            _state = EntityState.Added;
        }

        /// <summary>
        /// Changes the Item.EntityState of a item to Modified.
        /// </summary>        
        public virtual void SetModified()
        {
            _state = EntityState.Modified;
        }

        /// <summary>
        /// Delete the Item.
        /// </summary>
        public virtual void Delete()
        {
            _state = EntityState.Deleted;
        }

        /// <summary>
        /// Detached the Item.
        /// </summary>        
        public virtual void SetDetached()
        {
            _state = EntityState.Detached;
        }

        /// <summary>
        /// Unchanged the Item.
        /// </summary>
        public virtual void SetUnchanged()
        {
            _state = EntityState.Unchanged;
        }

        #endregion

        public virtual Object Copy()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Copy Item with New status
        /// </summary>
        /// <returns></returns>
        //public TEntity CopyAsNew<TEntity>()
        //{
        //    Object tNew = MemberwiseClone();
        //    ((BaseEntity)tNew).SetAdded();
        //    return (TEntity)tNew;
        //}

        #region Property Changed Methods
        protected internal virtual Boolean PropertyChanged(String oldValue, String newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Object oldValue, Object newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Int64 oldValue, Int64 newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Int32 oldValue, Int32 newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Int16 oldValue, Int16 newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Double oldValue, Double newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Decimal oldValue, Decimal newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(DateTime oldValue, DateTime newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Byte[] oldValue, Byte[] newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        protected internal virtual Boolean PropertyChanged(Boolean oldValue, Boolean newValue)
        {
            if (_state.Equals(EntityState.Unchanged).IsFalse()) return true;

            if (oldValue.NotEquals(newValue))
            {
                _state = EntityState.Modified;
                return true;
            }
            return false;
        }

        #endregion
    }
}