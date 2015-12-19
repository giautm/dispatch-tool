using LumenWorks.Framework.IO.Csv;
using GiauTM.CSharp.TikiRouter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GiauTM.CSharp.TikiRouter.Controllers
{
    class OrderList
    {
        private List<Order> mOrders = new List<Order>();
        public string[] Headers { get; private set;}

        public int BarcodeIndex { get; private set; }
        public int WardIdIndex { get; private set; }

        public bool loadCsv(string fileName)
        {
            try
            {
                mOrders.Clear();

                using (CsvReader csv = new CsvReader(new StreamReader(fileName), true))
                {
                    int fieldCount = csv.FieldCount;

                    Headers = csv.GetFieldHeaders();

                    BarcodeIndex = -1;
                    WardIdIndex = -1;

                    for (int i = 0; i < Headers.Length; ++i)
                    {
                        if (Headers[i].ToUpper() == "BARCODE")
                        {
                            BarcodeIndex = i;
                        }
                        else if (Headers[i].ToUpper() == "WARDID")
                        {
                            WardIdIndex = i;
                        }
                    }

                    if (BarcodeIndex == -1 || WardIdIndex == -1)
                    {
                        MessageBox.Show("Cấu trúc tệp CSV không đúng! Cần phải có các trường Barcode, WardId.");
                        return false;
                    }

                    if (mOrders == null)
                    {
                        mOrders = new List<Order>(1000);
                    }

                    while (csv.ReadNextRecord())
                    {
                        var fields = new string[fieldCount];

                        csv.CopyCurrentRecordTo(fields);
                        mOrders.Add(new Order(fields, BarcodeIndex, WardIdIndex));
                    }

                    Console.WriteLine("{0} order(s) was load.", mOrders.Count);
                    return true;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không thể mở tệp tin.\r" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }

            return false;
        }

        public Order findOrder(string barcode)
        {
            return mOrders.Find(o => o.Barcode == barcode);
        }
    }
}
