namespace mysql
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_CreateDB = new System.Windows.Forms.Button();
            this.button_DropDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_CreateDB
            // 
            this.button_CreateDB.Location = new System.Drawing.Point(610, 49);
            this.button_CreateDB.Name = "button_CreateDB";
            this.button_CreateDB.Size = new System.Drawing.Size(96, 43);
            this.button_CreateDB.TabIndex = 0;
            this.button_CreateDB.Text = "创建数据库";
            this.button_CreateDB.UseVisualStyleBackColor = true;
            this.button_CreateDB.Click += new System.EventHandler(this.button_CreateDB_Click);
            // 
            // button_DropDB
            // 
            this.button_DropDB.Location = new System.Drawing.Point(610, 113);
            this.button_DropDB.Name = "button_DropDB";
            this.button_DropDB.Size = new System.Drawing.Size(96, 43);
            this.button_DropDB.TabIndex = 1;
            this.button_DropDB.Text = "删除数据库";
            this.button_DropDB.UseVisualStyleBackColor = true;
            this.button_DropDB.Click += new System.EventHandler(this.button_DropDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_DropDB);
            this.Controls.Add(this.button_CreateDB);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_CreateDB;
        private System.Windows.Forms.Button button_DropDB;
    }
}

