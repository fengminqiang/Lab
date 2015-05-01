namespace LabVideoTest
{
    partial class FormSceneInfo
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
            this.gb_sceneInfo = new System.Windows.Forms.GroupBox();
            this.dgv_sceneInfo = new System.Windows.Forms.DataGridView();
            this.bt_refresh = new System.Windows.Forms.Button();
            this.bt_loadScene = new System.Windows.Forms.Button();
            this.bt_deleteScene = new System.Windows.Forms.Button();
            this.bt_confirm = new System.Windows.Forms.Button();
            this.gb_sceneInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sceneInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_sceneInfo
            // 
            this.gb_sceneInfo.Controls.Add(this.dgv_sceneInfo);
            this.gb_sceneInfo.Location = new System.Drawing.Point(12, 12);
            this.gb_sceneInfo.Name = "gb_sceneInfo";
            this.gb_sceneInfo.Size = new System.Drawing.Size(431, 444);
            this.gb_sceneInfo.TabIndex = 0;
            this.gb_sceneInfo.TabStop = false;
            this.gb_sceneInfo.Text = "场景信息";
            // 
            // dgv_sceneInfo
            // 
            this.dgv_sceneInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_sceneInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sceneInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sceneInfo.Location = new System.Drawing.Point(3, 17);
            this.dgv_sceneInfo.Name = "dgv_sceneInfo";
            this.dgv_sceneInfo.RowHeadersWidth = 30;
            this.dgv_sceneInfo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_sceneInfo.RowTemplate.Height = 23;
            this.dgv_sceneInfo.Size = new System.Drawing.Size(425, 424);
            this.dgv_sceneInfo.TabIndex = 0;
            // 
            // bt_refresh
            // 
            this.bt_refresh.Location = new System.Drawing.Point(449, 66);
            this.bt_refresh.Name = "bt_refresh";
            this.bt_refresh.Size = new System.Drawing.Size(75, 23);
            this.bt_refresh.TabIndex = 1;
            this.bt_refresh.Text = "刷新";
            this.bt_refresh.UseVisualStyleBackColor = true;
            this.bt_refresh.Click += new System.EventHandler(this.bt_refresh_Click);
            // 
            // bt_loadScene
            // 
            this.bt_loadScene.Location = new System.Drawing.Point(452, 145);
            this.bt_loadScene.Name = "bt_loadScene";
            this.bt_loadScene.Size = new System.Drawing.Size(75, 23);
            this.bt_loadScene.TabIndex = 2;
            this.bt_loadScene.Text = "载入场景";
            this.bt_loadScene.UseVisualStyleBackColor = true;
            this.bt_loadScene.Click += new System.EventHandler(this.bt_loadScene_Click);
            // 
            // bt_deleteScene
            // 
            this.bt_deleteScene.Location = new System.Drawing.Point(452, 311);
            this.bt_deleteScene.Name = "bt_deleteScene";
            this.bt_deleteScene.Size = new System.Drawing.Size(75, 23);
            this.bt_deleteScene.TabIndex = 3;
            this.bt_deleteScene.Text = "删除";
            this.bt_deleteScene.UseVisualStyleBackColor = true;
            this.bt_deleteScene.Click += new System.EventHandler(this.bt_deleteScene_Click);
            // 
            // bt_confirm
            // 
            this.bt_confirm.Location = new System.Drawing.Point(452, 222);
            this.bt_confirm.Name = "bt_confirm";
            this.bt_confirm.Size = new System.Drawing.Size(75, 23);
            this.bt_confirm.TabIndex = 4;
            this.bt_confirm.Text = "保存";
            this.bt_confirm.UseVisualStyleBackColor = true;
            this.bt_confirm.Click += new System.EventHandler(this.bt_confirm_Click);
            // 
            // FormSceneInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 508);
            this.Controls.Add(this.bt_confirm);
            this.Controls.Add(this.bt_deleteScene);
            this.Controls.Add(this.bt_loadScene);
            this.Controls.Add(this.bt_refresh);
            this.Controls.Add(this.gb_sceneInfo);
            this.Name = "FormSceneInfo";
            this.Text = "FormSceneInfo";
            this.gb_sceneInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sceneInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_sceneInfo;
        private System.Windows.Forms.Button bt_refresh;
        private System.Windows.Forms.DataGridView dgv_sceneInfo;
        private System.Windows.Forms.Button bt_loadScene;
        private System.Windows.Forms.Button bt_deleteScene;
        private System.Windows.Forms.Button bt_confirm;
    }
}