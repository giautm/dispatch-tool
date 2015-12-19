using System;
using System.Collections.Generic;
using System.Text;

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
