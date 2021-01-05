using System;

namespace book.Domain.Entities.pagination
{
    public class DateTimeParams
    {
         protected DateTime _MinDateTime  = DateTime.MinValue ;
        protected DateTime _MaxDateTime = DateTime.MaxValue ;  
        public DateTime MinDateTime {
            get {
                return _MinDateTime ; 
            }
            set {
                if(value>= _MinDateTime) {
                    _MinDateTime = value ; 
                }
            }
        }
        public DateTime MaxDateTime {
            get {
                return _MaxDateTime  ; 
            }
            set {
                if(value<= _MaxDateTime) {
                    _MaxDateTime = value ; 
                }
            }
        }
    }
}