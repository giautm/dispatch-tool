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

        public Session FindOrCreateSession(Router router)
        {
            var session = mSessions.Find(s => s.Router != null && s.Router.Name == router.Name);
            if (session == null)
            {
                session = new Session
                {
                    Name = router.Name,
                    IsNew = true,
                    Router = router,
                    Orders = new List<Order>()
                };

                mSessions.Add(session);
            }
            else
            {
                session.IsNew = false;
            }

            return session;
        }

        public bool ExportToExcelCSV(string folderName)
        {
            try
            {
                var now = DateTime.Now;

                string fileName = String.Format("{0}_{1}.csv", "PNH", now.ToString("yyyy-MM-dd_HH-mm-ss"));
                foreach (var session in mSessions)
                {
//                  string fileName = String.Format("{0}_{1}.csv", session.Name, now.ToString("yyyyyMMdd-HHmmss"));

                    using (StreamWriter file = new StreamWriter(Path.Combine(folderName, fileName)))
                    {
                        // 'Nói' cho Excel biết là các field được phân cách bằng dấu ','.
                        file.WriteLine("sep=,");
                        file.WriteLine("Barcode,Route,DateTime");
                        foreach (var order in session.Orders)
                        {
                            file.WriteLine("\"{0}\",\"{1}\",\"{2}\"", order.Barcode,
                                session.Router.Name, now.ToString("yyyy-MM-dd HH:mm:ss"));
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
