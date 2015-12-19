namespace GiauTM.CSharp.TikiRouter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tệpTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_ImportData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_ExportSessions = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExportSession = new System.Windows.Forms.Button();
            this.btnClearSessions = new System.Windows.Forms.Button();
            this.listViewSessions = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_RemoveOrderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtBarcode.Location = new System.Drawing.Point(12, 92);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(380, 29);
            this.txtBarcode.TabIndex = 3;
            this.txtBarcode.Text = "Scan mã ĐH vào đây";
            this.txtBarcode.Click += new System.EventHandler(this.txtBarcode_Click);
            this.txtBarcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarcode_KeyPress);
            // 
            // lbMessage
            // 
            this.lbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMessage.Location = new System.Drawing.Point(12, 38);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(707, 41);
            this.lbMessage.TabIndex = 1;
            this.lbMessage.Text = "Import danh sách đơn hàng để bắt đầu";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(398, 92);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(103, 29);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Nhập dữ liệu";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tệpTinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tệpTinToolStripMenuItem
            // 
            this.tệpTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_ImportData,
            this.menuItem_ExportSessions});
            this.tệpTinToolStripMenuItem.Name = "tệpTinToolStripMenuItem";
            this.tệpTinToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.tệpTinToolStripMenuItem.Text = "Tệp tin";
            // 
            // menuItem_ImportData
            // 
            this.menuItem_ImportData.Name = "menuItem_ImportData";
            this.menuItem_ImportData.Size = new System.Drawing.Size(152, 22);
            this.menuItem_ImportData.Text = "Nhập dữ liệu";
            this.menuItem_ImportData.Click += new System.EventHandler(this.menuItem_ImportData_Click);
            // 
            // menuItem_ExportSessions
            // 
            this.menuItem_ExportSessions.Name = "menuItem_ExportSessions";
            this.menuItem_ExportSessions.Size = new System.Drawing.Size(152, 22);
            this.menuItem_ExportSessions.Text = "Xuất các tuyến";
            this.menuItem_ExportSessions.Click += new System.EventHandler(this.menuItem_ExportSessions_Click);
            // 
            // btnExportSession
            // 
            this.btnExportSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSession.Enabled = false;
            this.btnExportSession.Location = new System.Drawing.Point(507, 92);
            this.btnExportSession.Name = "btnExportSession";
            this.btnExportSession.Size = new System.Drawing.Size(103, 29);
            this.btnExportSession.TabIndex = 1;
            this.btnExportSession.Text = "Xuất các phiên";
            this.btnExportSession.UseVisualStyleBackColor = true;
            this.btnExportSession.Click += new System.EventHandler(this.btnExportSession_Click);
            // 
            // btnClearSessions
            // 
            this.btnClearSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSessions.Enabled = false;
            this.btnClearSessions.Location = new System.Drawing.Point(616, 92);
            this.btnClearSessions.Name = "btnClearSessions";
            this.btnClearSessions.Size = new System.Drawing.Size(103, 29);
            this.btnClearSessions.TabIndex = 2;
            this.btnClearSessions.Text = "Xoá danh sách";
            this.btnClearSessions.UseVisualStyleBackColor = true;
            this.btnClearSessions.Click += new System.EventHandler(this.btnClearSessions_Click);
            // 
            // listViewSessions
            // 
            this.listViewSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listViewSessions.FullRowSelect = true;
            this.listViewSessions.Location = new System.Drawing.Point(13, 128);
            this.listViewSessions.Name = "listViewSessions";
            this.listViewSessions.Size = new System.Drawing.Size(706, 380);
            this.listViewSessions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewSessions.TabIndex = 6;
            this.listViewSessions.UseCompatibleStateImageBehavior = false;
            this.listViewSessions.View = System.Windows.Forms.View.Details;
            this.listViewSessions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewSessions_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_RemoveOrderItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 26);
            // 
            // menuItem_RemoveOrderItem
            // 
            this.menuItem_RemoveOrderItem.Name = "menuItem_RemoveOrderItem";
            this.menuItem_RemoveOrderItem.Size = new System.Drawing.Size(153, 22);
            this.menuItem_RemoveOrderItem.Text = "Xoá khỏi phiên";
            this.menuItem_RemoveOrderItem.Click += new System.EventHandler(this.menuItem_RemoveOrderItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 520);
            this.Controls.Add(this.listViewSessions);
            this.Controls.Add(this.btnClearSessions);
            this.Controls.Add(this.btnExportSession);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Công cụ phân tuyến";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tệpTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_ImportData;
        private System.Windows.Forms.ToolStripMenuItem menuItem_ExportSessions;
        private System.Windows.Forms.Button btnExportSession;
        private System.Windows.Forms.Button btnClearSessions;
        private System.Windows.Forms.ListView listViewSessions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RemoveOrderItem;
    }
}

