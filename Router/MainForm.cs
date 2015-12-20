using GiauTM.CSharp.TikiRouter.Controllers;
using GiauTM.CSharp.TikiRouter.Models;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
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

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "GiauTM.CSharp.TikiRouter.RouterConfig.csv";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null || !mRouters.importConfig(stream))
                {
                    MessageBox.Show("Không tìm thấy tệp tin RouterConfig.csv trong Resource!");

                    Application.Exit();
                }
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
            var order = mOrders.findOrder(barcode);
            if (order != null)
            {
                var router = mRouters.findRouter(order.WardId);

                if (router != null)
                {
                    var session = mSessions.findOrCreateSession(router);

                    var sessionGroup = listViewSessions.Groups[session.name];
                    if (sessionGroup == null && session.isNew)
                    {
                        sessionGroup = listViewSessions.Groups.Add(session.name, session.name);
                    }

                    if (session.orders.TrueForAll(o => o.Barcode != order.Barcode))
                    {
                        session.orders.Add(order);

                        // Lưu lại để có thể remove từ danh sách.
                        mOrderSession.Add(order.Barcode, session);

                        sessionGroup.Header = string.Format("{0} ({1})", session.name, session.orders.Count);
                        listViewSessions.Items.Add(new ListViewItem(order.Fields, sessionGroup));

                        btnExportSession.Enabled = true;
                        btnClearSessions.Enabled = true;

                        showMessage(router.name, false);
                        Ultis.playAudio(router.name);
                    }
                    else
                    {
                        showMessage("Đã scan đơn hàng này rồi. T_T");
                    }

                    return true;
                }
                else
                {
                    showMessage("Không tìm thấy tuyến.");
                    Ultis.playAudio("NOTFOUND");
                }
            }
            else
            {
                showMessage("Không tìm thấy đơn hàng.");
                Ultis.playAudio("NOTFOUND");
            }

            return false;
        }

        private void importOrderData()
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
                        if (mOrders.loadCsv(dialog.FileName))
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

        private void exportSessions()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (mSessions.exportTo(fbd.SelectedPath))
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
            importOrderData();
        }

        private void btnExportSession_Click(object sender, EventArgs e)
        {
            exportSessions();
        }

        private void btnClearSessions_Click(object sender, EventArgs e)
        {
            mSessions.Clear();
            mOrderSession.Clear();

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
                            session.orders.RemoveAll(o => o.Barcode == barcode);
                            mOrderSession.Remove(barcode);
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