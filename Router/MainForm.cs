using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Media;
using System.Threading;
using System.Collections;

using LumenWorks.Framework.IO.Csv;
using GiauTM.CSharp.TikiRouter.Properties;
using GiauTM.CSharp.TikiRouter.Controllers;
using GiauTM.CSharp.TikiRouter.Models;

namespace GiauTM.CSharp.TikiRouter
{
    public partial class MainForm : Form
    {
        private OrderList mOrders = new OrderList();
        private RouterList mRouters = new RouterList();
        private SessionList mSessions = new SessionList();

        private Hashtable mGroupRouter = new Hashtable();
        private Hashtable mOrderSession = new Hashtable();
        private delegate void MyAction();

        public MainForm()
        {
            InitializeComponent();
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

                    if (session.isNew)
                    {
                        var group = new ListViewGroup(router.name,
                            HorizontalAlignment.Left);


                        mGroupRouter.Add(router.name, group);
                        listViewSessions.Groups.Add(group);
                    }

                    if (session.orders.TrueForAll(o => o.Barcode != order.Barcode))
                    {
                        // Lưu lại để có thể remove từ danh sách.
                        mOrderSession.Add(order.Barcode, session);

                        session.orders.Add(order);
                        showMessage(router.name, false);

                        var item = new ListViewItem(order.Fields);
                        item.Group = (ListViewGroup)mGroupRouter[router.name];
                        listViewSessions.Items.Add(item);

                        btnExportSession.Enabled = true;
                        btnClearSessions.Enabled = true;

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

        private void importData()
        {
            string dummyFile = @"D:\OneDrive\giautm\devel\ws-csharp\Router\Router\bin\Debug\data.csv";
            if (File.Exists(dummyFile))
            {
                if (mOrders.loadCsv(dummyFile))
                {
                    showMessage("OK! Scan được rồi.", false);
                    txtBarcode.Enabled = true;
                    txtBarcode.Focus();
                    txtBarcode.SelectAll();
                }
            }
            else
            {
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.InitialDirectory = KnownFolders.GetPath(KnownFolder.Downloads); ;
                dialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                dialog.FilterIndex = 1;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btnImport.Enabled = false;
                        lbMessage.Text = "Đang đọc tập tin, vui lòng chờ...";
                        var thread = new Thread(() =>
                        {

                            if (mOrders.loadCsv(dialog.FileName))
                            {
                                lbMessage.BeginInvoke(new MyAction(() =>
                                {
                                    showMessage("OK! Scan được rồi đó. :)", false);
                                }));

                                btnImport.BeginInvoke(new MyAction(() =>
                                {
                                    btnImport.Enabled = true;
                                }));

                                txtBarcode.BeginInvoke(new MyAction(() =>
                                {
                                    txtBarcode.Enabled = true;
                                    txtBarcode.Focus();
                                    txtBarcode.SelectAll();
                                }));

                                listViewSessions.BeginInvoke(new MyAction(() =>
                                {
                                    listViewSessions.Columns.Clear();
                                    foreach (var header in mOrders.Headers)
                                    {
                                        listViewSessions.Columns.Add(new ColumnHeader { Text = header, Width = 100 });
                                    }
                                }));
                            }
                            else
                            {
                                lbMessage.BeginInvoke(new MyAction(() =>
                                {
                                    showMessage("Bị lỗi gì rồi thì phải... thử lại nhé! :(");
                                }));

                                btnImport.BeginInvoke(new MyAction(() =>
                                {
                                    btnImport.Enabled = true;
                                }));
                            }
                        });

                        thread.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void exporeSessions()
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

        private void menuItem_ExportSessions_Click(object sender, EventArgs e)
        {
            exporeSessions();
        }
        private void menuItem_ImportData_Click(object sender, EventArgs e)
        {
            importData();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            importData();
        }

        private void btnExportSession_Click(object sender, EventArgs e)
        {
            exporeSessions();
        }

        private void btnClearSessions_Click(object sender, EventArgs e)
        {
            mSessions.Clear();
            mGroupRouter.Clear();
            mOrderSession.Clear();

            listViewSessions.Items.Clear();
            listViewSessions.Groups.Clear();

            btnClearSessions.Enabled = false;
            btnExportSession.Enabled = false;
        }

        private void listViewSessions_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listViewSessions.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
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



    }
}
