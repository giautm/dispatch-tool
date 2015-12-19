using GiauTM.CSharp.TikiRouter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GiauTM.CSharp.TikiRouter.Controllers
{
    class SessionList
    {
        private List<Session> mSessions = new List<Session>();

        public Session findOrCreateSession(GiauTM.CSharp.TikiRouter.Models.Router router)
        {
            var session = mSessions.Find(s => s.router != null && s.router.name == router.name);
            if (session == null)
            {
                session = new Session { name = router.name, router = router, orders = new List<Order>(), isNew = true };
                mSessions.Add(session);
            }
            else
            {
                session.isNew = false;
            }

            return session;
        }

        public bool exportTo(string folderName)
        {
            try
            {
                var now = DateTime.Now;

                foreach (var session in mSessions)
                {
                    string fileName = String.Format("{0}_{1}.csv", now.ToString("yyyyyMMdd-HHmmss"), session.name);

                    using (StreamWriter file = new StreamWriter(Path.Combine(folderName, fileName)))
                    {
                        file.WriteLine("Barcode;Router");
                        foreach (var order in session.orders)
                        {
                            file.WriteLine("\"{0}\";\"{1}\"", order.Barcode, session.router.name);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

            return false;
        }

        public void Clear()
        {
            mSessions.Clear();
        }
    }
}
