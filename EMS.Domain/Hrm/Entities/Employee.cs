using EMS.Core.Domain.Entities;
using EMS.Core.Domain.Validation;
using EMS.Domain.Hrm.Validations;
using System;
using System.ComponentModel;

namespace EMS.Domain.Hrm.Entities
{
    [Serializable()]
    public class Employee : BaseEntity<long>, ISelfValidation
    {
        #region Tables Memebers

        /// <remarks>SQL Type:int - </remarks>
        private int _SalutationId;

        [DisplayName("Salutation Id")]
        [Category("Column")]
        public virtual int SalutationId
        {
            get
            {
                try
                {
                    return _SalutationId;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting SalutationId", err);
                }
            }
            set
            {
                try
                {
                    _SalutationId = value;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting SalutationId", err);
                }
            }
        }

        /// <remarks>SQL Type:nvarchar - </remarks>
        private string _FirstName;

        [DisplayName("First Name")]
        [Category("Column")]
        public virtual string FirstName
        {
            get
            {
                try
                {
                    return _FirstName;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting FirstName", err);
                }
            }
            set
            {
                try
                {
                    if ((value.Length <= 100))
                    {
                        _FirstName = value;
                    }
                    else
                    {
                        throw new OverflowException("Error setting FirstName, Length of value is to long. Maximum Length: 100");
                    }
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting FirstName", err);
                }
            }
        }

        /// <remarks>SQL Type:nvarchar - </remarks>
        private string _MiddleName;

        [DisplayName("Middle Name")]
        [Category("Column")]
        public virtual string MiddleName
        {
            get
            {
                try
                {
                    return _MiddleName;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting MiddleName", err);
                }
            }
            set
            {
                try
                {
                    if ((value.Length <= 100))
                    {
                        _MiddleName = value;
                    }
                    else
                    {
                        throw new OverflowException("Error setting MiddleName, Length of value is to long. Maximum Length: 100");
                    }
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting MiddleName", err);
                }
            }
        }

        /// <remarks>SQL Type:nvarchar - </remarks>
        private string _LastName;

        [DisplayName("Last Name")]
        [Category("Column")]
        public virtual string LastName
        {
            get
            {
                try
                {
                    return _LastName;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting LastName", err);
                }
            }
            set
            {
                try
                {
                    if ((value.Length <= 100))
                    {
                        _LastName = value;
                    }
                    else
                    {
                        throw new OverflowException("Error setting LastName, Length of value is to long. Maximum Length: 100");
                    }
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting LastName", err);
                }
            }
        }

        /// <remarks>SQL Type:nvarchar - </remarks>
        private string _NickName;

        [DisplayName("Nick Name")]
        [Category("Column")]
        public virtual string NickName
        {
            get
            {
                try
                {
                    return _NickName;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting NickName", err);
                }
            }
            set
            {
                try
                {
                    if ((value.Length <= 100))
                    {
                        _NickName = value;
                    }
                    else
                    {
                        throw new OverflowException("Error setting NickName, Length of value is to long. Maximum Length: 100");
                    }
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting NickName", err);
                }
            }
        }

        /// <remarks>SQL Type:nvarchar - </remarks>
        private string _EmpName;

        [DisplayName("Emp Name")]
        [Category("Column")]
        public virtual string EmpName
        {
            get
            {
                try
                {
                    return _EmpName;
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error getting EmpName", err);
                }
            }
            set
            {
                try
                {
                    if ((value.Length <= 300))
                    {
                        _EmpName = value;
                    }
                    else
                    {
                        throw new OverflowException("Error setting EmpName, Length of value is to long. Maximum Length: 300");
                    }
                }
                catch (System.Exception err)
                {
                    throw new Exception("Error setting EmpName", err);
                }
            }
        }

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #endregion

        #region Self Validation

        public virtual bool IsValid
        {
            get
            {
                var fiscal = new EmployeeIsValidValidation();
                ValidationResult = fiscal.Valid(this);
                return ValidationResult.IsValid;
            }
        }

        #endregion
    }
}
