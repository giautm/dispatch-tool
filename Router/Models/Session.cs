using System.Collections.Generic;

namespace GiauTM.CSharp.TikiRouter.Models
{
    class Session
    {
        public bool isNew;
        public string name;
        public Router router;
        public List<Order> orders;
    }
}