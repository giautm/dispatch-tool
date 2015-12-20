using GiauTM.CSharp.TikiRouter.Models;
using LumenWorks.Framework.IO.Csv;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace GiauTM.CSharp.TikiRouter.Controllers
{
    class RouterList
    {
        private List<Router> mRouters = new List<Router>();
        public bool importConfig(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open))
            {
                return importConfig(stream);
            }
        }

        public bool importConfig(Stream file)
        {
            using (CsvReader csv = new CsvReader(new StreamReader(file), true, '\t'))
            {

                string[] headers = csv.GetFieldHeaders();
                int idxRouter = -1;
                int idxWardId = -1;

                for (int i = 0; i < csv.FieldCount; ++i)
                {
                    if (headers[i].ToUpper() == "ROUTER")
                    {
                        idxRouter = i;
                    }
                    else if (headers[i].ToUpper() == "WARDID")
                    {
                        idxWardId = i;
                    }
                }

                if (idxRouter == -1 || idxWardId == -1)
                {
                    MessageBox.Show("Cấu trúc tệp tin cấu hình không đúng." +
                        " Cần phải có các trường Router, WardId");
                    return false;
                }

                Hashtable routerWardId = new Hashtable();

                while (csv.ReadNextRecord())
                {
                    var routerName = csv[idxRouter];
                    var router = routerWardId[routerName] as Router;
                    if (router == null)
                    {
                        router = new Router
                        {
                            name = routerName,
                            wards = new List<string> { csv[idxWardId] }
                        };

                        routerWardId.Add(routerName, router);
                    }

                    router.wards.Add(csv[idxWardId]);
                }

                Router[] temp = new Router[routerWardId.Count];
                routerWardId.Values.CopyTo(temp, 0);

                mRouters.Clear();
                mRouters.AddRange(temp);

                return true;
            }
        }

        public Router findRouter(string wardId)
        {
            return mRouters.Find(r => r.wards.Contains(wardId));
        }
    }
}
