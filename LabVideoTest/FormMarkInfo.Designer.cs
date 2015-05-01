namespace LabVideoTest
{
    partial class FormMarkInfo
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
            this.gb_markInfo = new System.Windows.Forms.GroupBox();
            this.dgv_markInfo = new System.Windows.Forms.DataGridView();
            this.bt_confirm = new System.Windows.Forms.Button();
            this.bt_deleteScene = new System.Windows.Forms.Button();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.gb_markInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_markInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_markInfo
            // 
            this.gb_markInfo.Controls.Add(this.dgv_markInfo);
            this.gb_markInfo.Location = new System.Drawing.Point(23, 12);
            this.gb_markInfo.Name = "gb_markInfo";
            this.gb_markInfo.Size = new System.Drawing.Size(431, 444);
            this.gb_markInfo.TabIndex = 1;
            this.gb_markInfo.TabStop = false;
            this.gb_markInfo.Text = "标定信息";
            // 
            // dgv_markInfo
            // 
            this.dgv_markInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_markInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_markInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_markInfo.Location = new System.Drawing.Point(3, 17);
            this.dgv_markInfo.Name = "dgv_markInfo";
            this.dgv_markInfo.RowHeadersWidth = 30;
            this.dgv_markInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_markInfo.RowTemplate.Height = 23;
            this.dgv_markInfo.Size = new System.Drawing.Size(425, 424);
            this.dgv_markInfo.TabIndex = 0;
            // 
            // bt_confirm
            // 
            this.bt_confirm.Location = new System.Drawing.Point(503, 211);
            this.bt_confirm.Name = "bt_confirm";
            this.bt_confirm.Size = new System.Drawing.Size(75, 23);
            this.bt_confirm.TabIndex = 8;
            this.bt_confirm.Text = "保存";
            this.bt_confirm.UseVisualStyleBackColor = true;
            this.bt_confirm.Click += new System.EventHandler(this.bt_confirm_Click);
            // 
            // bt_deleteScene
            // 
            this.bt_deleteScene.Location = new System.Drawing.Point(503, 304);
            this.bt_deleteScene.Name = "bt_deleteScene";
            this.bt_deleteScene.Size = new System.Drawing.Size(75, 23);
            this.bt_deleteScene.TabIndex = 7;
            this.bt_deleteScene.Text = "删除";
            this.bt_deleteScene.UseVisualStyleBackColor = true;
            this.bt_deleteScene.Click += new System.EventHandler(this.bt_deleteScene_Click);
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(503, 110);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(75, 23);
            this.bt_refresh.TabIndex = 5;
            this.bt_refresh.Text = "刷新";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // FormMarkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 542);
            this.Controls.Add(this.bt_confirm);
            this.Controls.Add(this.bt_deleteScene);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.gb_markInfo);
            this.Name = "FormMarkInfo";
            this.Text = "FormMarkInfo";
            this.gb_markInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_markInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_markInfo;
        private System.Windows.Forms.DataGridView dgv_markInfo;
        private System.Windows.Forms.Button bt_confirm;
        private System.Windows.Forms.Button bt_deleteScene;
        private System.Windows.Forms.Button bt_refresh;

    }
}