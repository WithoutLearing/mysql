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
            this.button_CreateTable = new System.Windows.Forms.Button();
            this.button_DropTable = new System.Windows.Forms.Button();
            this.button_OpenDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_CreateDB
            // 
            this.button_CreateDB.Location = new System.Drawing.Point(813, 61);
            this.button_CreateDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_CreateDB.Name = "button_CreateDB";
            this.button_CreateDB.Size = new System.Drawing.Size(128, 54);
            this.button_CreateDB.TabIndex = 0;
            this.button_CreateDB.Text = "创建数据库";
            this.button_CreateDB.UseVisualStyleBackColor = true;
            this.button_CreateDB.Click += new System.EventHandler(this.button_CreateDB_Click);
            // 
            // button_DropDB
            // 
            this.button_DropDB.Location = new System.Drawing.Point(813, 141);
            this.button_DropDB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_DropDB.Name = "button_DropDB";
            this.button_DropDB.Size = new System.Drawing.Size(128, 54);
            this.button_DropDB.TabIndex = 1;
            this.button_DropDB.Text = "删除数据库";
            this.button_DropDB.UseVisualStyleBackColor = true;
            this.button_DropDB.Click += new System.EventHandler(this.button_DropDB_Click);
            // 
            // button_CreateTable
            // 
            this.button_CreateTable.Location = new System.Drawing.Point(813, 221);
            this.button_CreateTable.Margin = new System.Windows.Forms.Padding(4);
            this.button_CreateTable.Name = "button_CreateTable";
            this.button_CreateTable.Size = new System.Drawing.Size(128, 54);
            this.button_CreateTable.TabIndex = 2;
            this.button_CreateTable.Text = "创建数据表";
            this.button_CreateTable.UseVisualStyleBackColor = true;
            this.button_CreateTable.Click += new System.EventHandler(this.button_CreateTable_Click);
            // 
            // button_DropTable
            // 
            this.button_DropTable.Location = new System.Drawing.Point(813, 304);
            this.button_DropTable.Margin = new System.Windows.Forms.Padding(4);
            this.button_DropTable.Name = "button_DropTable";
            this.button_DropTable.Size = new System.Drawing.Size(128, 54);
            this.button_DropTable.TabIndex = 3;
            this.button_DropTable.Text = "删除数据表";
            this.button_DropTable.UseVisualStyleBackColor = true;
            this.button_DropTable.Click += new System.EventHandler(this.button_DropTable_Click);
            // 
            // button_OpenDB
            // 
            this.button_OpenDB.Location = new System.Drawing.Point(646, 61);
            this.button_OpenDB.Margin = new System.Windows.Forms.Padding(4);
            this.button_OpenDB.Name = "button_OpenDB";
            this.button_OpenDB.Size = new System.Drawing.Size(128, 54);
            this.button_OpenDB.TabIndex = 4;
            this.button_OpenDB.Text = "打开数据库";
            this.button_OpenDB.UseVisualStyleBackColor = true;
            this.button_OpenDB.Click += new System.EventHandler(this.button_OpenDB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.button_OpenDB);
            this.Controls.Add(this.button_DropTable);
            this.Controls.Add(this.button_CreateTable);
            this.Controls.Add(this.button_DropDB);
            this.Controls.Add(this.button_CreateDB);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_CreateDB;
        private System.Windows.Forms.Button button_DropDB;
        private System.Windows.Forms.Button button_CreateTable;
        private System.Windows.Forms.Button button_DropTable;
        private System.Windows.Forms.Button button_OpenDB;
    }
}

