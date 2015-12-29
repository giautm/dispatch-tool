using GiauTM.CSharp.TikiRouter.Controllers;
using GiauTM.CSharp.TikiRouter.Models;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace GiauTM.CSharp.TikiRouter
{
    public partial class MainForm : Form
    {
        private static string sOrderUrlCPN = @"http://admin.tiki.vn/index.php/cpn/sales_order/view/order_id/";
        private OrderList mOrders = new OrderList();
        private RouterList mRouters = new RouterList();
        private SessionList mSessions = new SessionList();

        private Hashtable mOrderSession = new Hashtable();
        private delegate void MyAction();
        private int mOrdersCount = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!mRouters.ImportConfig(@"./RouterConfig.tsv"))
            {
                MessageBox.Show("Không tìm thấy tệp tin RouterConfig.tsv!");
                Application.Exit();
            }
        }

        private void showMessage(string message, bool alert = true)
        {
            if (alert)
            {
                lbMessage.BackColor = Color.Red;
                lbMessage.ForeColor = Color.White;
            }
            else
            {
                lbMessage.BackColor = Color.Green;
                lbMessage.ForeColor = Color.White;
            }

            lbMessage.Text = message;
        }


        private bool addOrder(string barcode)
        {
            var order = mOrders.FindOrderByBarcode(barcode);
            if (order != null)
            {
                var router = mRouters.FindRouterByWardId(order.WardId);

                if (router != null)
                {
                    var session = mSessions.FindOrCreateSession(router);

                    var sessionGroup = listViewSessions.Groups[session.Name];
                    if (sessionGroup == null && session.IsNew)
                    {
                        sessionGroup = listViewSessions.Groups.Add(session.Name, session.Name);
                    }

                    if (session.Orders.TrueForAll(o => o.Barcode != order.Barcode))
                    {
                        session.Orders.Add(order);

                        // Lưu lại để có thể remove từ danh sách.
                        mOrderSession.Add(order.Barcode, session);

                        sessionGroup.Header = string.Format("{0} ({1} đơn hàng)", session.Name, session.Orders.Count);
                        listViewSessions.Items.Add(new ListViewItem(order.Fields, sessionGroup));

                        btnExportSession.Enabled = true;
                        btnClearSessions.Enabled = true;

                        showMessage(router.Name, false);
                        Ultis.playRouter(router.Name);

                        lbOrderCount.Text = string.Format("{0} ĐH", ++mOrdersCount);
                    }
                    else
                    {
                        showMessage("Đã scan đơn hàng này rồi. T_T");

                        if (listViewSessions.Items.Count > 0)
                        {
                            foreach (ListViewItem item in listViewSessions.Items)
                            {
                                if (item.Text == order.Barcode)
                                {
                                    item.Selected = true;
                                    listViewSessions.Select();
                                    break;
                                }
                            }
                        }
                    }

                    return true;
                }
                else
                {
                    showMessage("Không tìm thấy tuyến.");
                    Ultis.playNotFound();
                }
            }
            else
            {
                showMessage("Không tìm thấy đơn hàng.");
                Ultis.playNotFound();
            }

            return false;
        }

        private void ImportOrderData()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = KnownFolders.GetPath(KnownFolder.Downloads); ;
            dialog.Title = "Chọn tập tin xuất từ Redash";
            dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    showMessage("Đang đọc tập tin, vui lòng chờ...", false);
                    btnImport.Enabled = false;

                    var thread = new Thread(() =>
                    {
                        if (mOrders.LoadFromCSV(dialog.FileName))
                        {
                            listViewSessions.BeginInvoke(new MyAction(() =>
                            {
                                listViewSessions.Columns.Clear();
                                foreach (var header in mOrders.Headers)
                                {
                                    listViewSessions.Columns.Add(new ColumnHeader { Text = header, Width = 150 });
                                }
                            }));

                            txtBarcode.BeginInvoke(new MyAction(() =>
                            {
                                txtBarcode.Enabled = true;
                                txtBarcode.Focus();
                                txtBarcode.SelectAll();
                            }));

                            lbMessage.BeginInvoke(new MyAction(() =>
                            {
                                showMessage("OK! Scan được rồi đó. :)", false);
                            }));
                        }
                        else
                        {
                            lbMessage.BeginInvoke(new MyAction(() =>
                            {
                                showMessage("Bị lỗi gì rồi thì phải... thử lại nhé! :(");
                            }));
                        }

                        btnImport.BeginInvoke(new MyAction(() =>
                        {
                            btnImport.Enabled = true;
                        }));
                    });

                    thread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }

        }
        private string makeExportPath()
        {
            var root = @"D:\NHAP_HANG";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            var now = DateTime.Now;
            var path = Path.Combine(root, now.ToString("yyyy-MM-dd"));

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
        private void ExportSessions()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = makeExportPath();


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (mSessions.ExportToExcelCSV(dialog.SelectedPath))
                {
                    showMessage("Xuất danh các phiên thành công!", false);
                }
                else
                {
                    showMessage("Xảy ra lỗi khi xuất phiên!");
                }
            }
        }

        private void txtBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                var barcode = txtBarcode.Text.Trim();
                if (barcode.Length > 0)
                {
                    addOrder(barcode);
                }

                e.Handled = true;
                txtBarcode.SelectAll();
            }
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            ImportOrderData();
        }

        private void btnExportSession_Click(object sender, EventArgs e)
        {
            ExportSessions();
        }

        private void btnClearSessions_Click(object sender, EventArgs e)
        {
            mSessions.Clear();
            mOrderSession.Clear();
            mOrdersCount = 0;
            lbOrderCount.Text = string.Format("{0} ĐH", 0);

            listViewSessions.Items.Clear();
            listViewSessions.Groups.Clear();

            btnClearSessions.Enabled = false;
            btnExportSession.Enabled = false;
        }

        private void menuItem_RemoveOrderItem_Click(object sender, EventArgs e)
        {
            var selected = listViewSessions.SelectedItems;
            if (selected.Count > 0)
            {
                foreach (ListViewItem item in selected)
                {
                    var barcode = item.SubItems[mOrders.BarcodeIndex].Text;
                    if (mOrderSession.ContainsKey(barcode))
                    {
                        var session = (Session)mOrderSession[barcode];
                        if (session != null)
                        {
                            session.Orders.RemoveAll(o => o.Barcode == barcode);
                            mOrderSession.Remove(barcode);

                            if (mOrdersCount > 0)
                            {
                                lbOrderCount.Text = string.Format("{0} ĐH", --mOrdersCount);
                            }
                        }
                    }

                    item.Remove();
                }
            }
        }

        private void listViewSessions_DoubleClick(object sender, EventArgs e)
        {
            var selected = listViewSessions.SelectedItems;
            if (selected.Count > 0 && mOrders.OrderIdIndex != -1)
            {
                var orderId = selected[0].SubItems[mOrders.OrderIdIndex].Text;
                Process.Start(sOrderUrlCPN + orderId);
            }
        }
    }
}