using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1Portfolio_app.Classes
{
    internal class SalesOrder
    {
        public int _customerID {  get; set; }
        public int _salesPID {  get; set; }
        public DateTime _orderDate {  get; set; }

        public SalesOrder(int customerID, int  salesPID, DateTime orderDate)
        {
            _customerID = customerID;
            _salesPID = salesPID;
            _orderDate = orderDate;
        }

      


        
    }
}
