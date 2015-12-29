using System.Collections.Generic;

namespace GiauTM.CSharp.TikiRouter.Models
{
    class Session
    {
        public bool IsNew;
        public string Name;
        public Router Router;
        public List<Order> Orders;
    }
}