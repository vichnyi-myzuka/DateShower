using System;

namespace DateShower.Models
{
    public class UserDateModel
    {
        #region Fields
        private DateTime _dateTime = DateTime.Now;
        private int _age;
        #endregion

        #region Properties

        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }
            set
            {
                _dateTime = value;
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        #endregion
    }
}