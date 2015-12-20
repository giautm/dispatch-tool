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
            this.btnExportSession = new System.Windows.Forms.Button();
            this.btnClearSessions = new System.Windows.Forms.Button();
            this.listViewSessions = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_RemoveOrderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbOrderCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.Enabled = false;
            this.txtBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtBarcode.Location = new System.Drawing.Point(13, 61);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(211, 31);
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
            this.lbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbMessage.Location = new System.Drawing.Point(13, 9);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(800, 44);
            this.lbMessage.TabIndex = 1;
            this.lbMessage.Text = "Nhập dữ liệu đơn hàng để bắt đầu";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnImport.Location = new System.Drawing.Point(341, 60);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(153, 34);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Nhập dữ liệu";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExportSession
            // 
            this.btnExportSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSession.Enabled = false;
            this.btnExportSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnExportSession.Location = new System.Drawing.Point(500, 60);
            this.btnExportSession.Name = "btnExportSession";
            this.btnExportSession.Size = new System.Drawing.Size(153, 34);
            this.btnExportSession.TabIndex = 1;
            this.btnExportSession.Text = "Xuất các phiên";
            this.btnExportSession.UseVisualStyleBackColor = true;
            this.btnExportSession.Click += new System.EventHandler(this.btnExportSession_Click);
            // 
            // btnClearSessions
            // 
            this.btnClearSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSessions.Enabled = false;
            this.btnClearSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClearSessions.Location = new System.Drawing.Point(659, 60);
            this.btnClearSessions.Name = "btnClearSessions";
            this.btnClearSessions.Size = new System.Drawing.Size(153, 34);
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
            this.listViewSessions.ContextMenuStrip = this.contextMenuStrip1;
            this.listViewSessions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.listViewSessions.FullRowSelect = true;
            this.listViewSessions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSessions.Location = new System.Drawing.Point(13, 101);
            this.listViewSessions.MultiSelect = false;
            this.listViewSessions.Name = "listViewSessions";
            this.listViewSessions.ShowItemToolTips = true;
            this.listViewSessions.Size = new System.Drawing.Size(799, 199);
            this.listViewSessions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewSessions.TabIndex = 6;
            this.listViewSessions.UseCompatibleStateImageBehavior = false;
            this.listViewSessions.View = System.Windows.Forms.View.Details;
            this.listViewSessions.DoubleClick += new System.EventHandler(this.listViewSessions_DoubleClick);
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
            // lbOrderCount
            // 
            this.lbOrderCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbOrderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbOrderCount.Location = new System.Drawing.Point(230, 61);
            this.lbOrderCount.Name = "lbOrderCount";
            this.lbOrderCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbOrderCount.Size = new System.Drawing.Size(105, 31);
            this.lbOrderCount.TabIndex = 7;
            this.lbOrderCount.Text = "0 ĐH";
            this.lbOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(12, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Mẹo: Nhấp đúp vào đơn hàng để mở trên CPN / Nhấp chuột phải để xoá.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbOrderCount);
            this.Controls.Add(this.listViewSessions);
            this.Controls.Add(this.btnClearSessions);
            this.Controls.Add(this.btnExportSession);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.txtBarcode);
            this.MinimumSize = new System.Drawing.Size(840, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công cụ phân tuyến";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExportSession;
        private System.Windows.Forms.Button btnClearSessions;
        private System.Windows.Forms.ListView listViewSessions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_RemoveOrderItem;
        private System.Windows.Forms.Label lbOrderCount;
        private System.Windows.Forms.Label label1;
    }
}

