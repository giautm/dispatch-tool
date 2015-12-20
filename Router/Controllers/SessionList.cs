using GiauTM.CSharp.TikiRouter.Models;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GiauTM.CSharp.TikiRouter.Controllers
{
    class SessionList
    {
        private List<Session> mSessions = new List<Session>();

        public Session findOrCreateSession(Router router)
        {
            var session = mSessions.Find(s => s.router != null && s.router.name == router.name);
            if (session == null)
            {
                session = new Session
                {
                    name = router.name,
                    isNew = true,
                    router = router,
                    orders = new List<Order>()
                };

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
                    string fileName = String.Format("{0}_{1}.csv", session.name, now.ToString("yyyyyMMdd-HHmmss"));

                    using (StreamWriter file = new StreamWriter(Path.Combine(folderName, fileName)))
                    {
                        // 'Nói' cho Excel biết là các field được phân cách bằng dấu ','.
                        file.WriteLine("sep=,");
                        file.WriteLine("Barcode,Router");
                        foreach (var order in session.orders)
                        {
                            file.WriteLine("\"{0}\",\"{1}\"", order.Barcode, session.router.name);
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
