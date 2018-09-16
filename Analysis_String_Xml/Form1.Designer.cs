namespace Analysis_String_Xml
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Get_Content_Bt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Save_To_Xml = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.File_Path_Box = new System.Windows.Forms.TextBox();
            this.Save_Path_Box = new System.Windows.Forms.TextBox();
            this.Select_File_Path = new System.Windows.Forms.Button();
            this.Select_Save_Path = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Api_Key_Box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Get_Content_Bt
            // 
            this.Get_Content_Bt.Location = new System.Drawing.Point(12, 124);
            this.Get_Content_Bt.Name = "Get_Content_Bt";
            this.Get_Content_Bt.Size = new System.Drawing.Size(197, 60);
            this.Get_Content_Bt.TabIndex = 0;
            this.Get_Content_Bt.Text = "開始翻譯String.xml";
            this.Get_Content_Bt.UseVisualStyleBackColor = true;
            this.Get_Content_Bt.Click += new System.EventHandler(this.Get_Content_Bt_ClickAsync);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 190);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(469, 327);
            this.textBox1.TabIndex = 1;
            // 
            // Save_To_Xml
            // 
            this.Save_To_Xml.Location = new System.Drawing.Point(284, 124);
            this.Save_To_Xml.Name = "Save_To_Xml";
            this.Save_To_Xml.Size = new System.Drawing.Size(197, 60);
            this.Save_To_Xml.TabIndex = 2;
            this.Save_To_Xml.Text = "儲存檔案";
            this.Save_To_Xml.UseVisualStyleBackColor = true;
            this.Save_To_Xml.Click += new System.EventHandler(this.Save_To_Xml_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "檔案路徑：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "儲存路徑：";
            // 
            // File_Path_Box
            // 
            this.File_Path_Box.Location = new System.Drawing.Point(101, 7);
            this.File_Path_Box.Name = "File_Path_Box";
            this.File_Path_Box.Size = new System.Drawing.Size(343, 25);
            this.File_Path_Box.TabIndex = 5;
            this.File_Path_Box.TextChanged += new System.EventHandler(this.File_Path_Box_TextChanged);
            // 
            // Save_Path_Box
            // 
            this.Save_Path_Box.Location = new System.Drawing.Point(101, 43);
            this.Save_Path_Box.Name = "Save_Path_Box";
            this.Save_Path_Box.Size = new System.Drawing.Size(343, 25);
            this.Save_Path_Box.TabIndex = 6;
            this.Save_Path_Box.TextChanged += new System.EventHandler(this.Save_Path_Box_TextChanged);
            // 
            // Select_File_Path
            // 
            this.Select_File_Path.Location = new System.Drawing.Point(450, 7);
            this.Select_File_Path.Name = "Select_File_Path";
            this.Select_File_Path.Size = new System.Drawing.Size(33, 25);
            this.Select_File_Path.TabIndex = 7;
            this.Select_File_Path.Text = "...";
            this.Select_File_Path.UseVisualStyleBackColor = true;
            this.Select_File_Path.Click += new System.EventHandler(this.Select_File_Path_Click);
            // 
            // Select_Save_Path
            // 
            this.Select_Save_Path.Location = new System.Drawing.Point(450, 43);
            this.Select_Save_Path.Name = "Select_Save_Path";
            this.Select_Save_Path.Size = new System.Drawing.Size(33, 25);
            this.Select_Save_Path.TabIndex = 8;
            this.Select_Save_Path.Text = "...";
            this.Select_Save_Path.UseVisualStyleBackColor = true;
            this.Select_Save_Path.Click += new System.EventHandler(this.Select_Save_Path_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Yandax Api Key：";
            // 
            // Api_Key_Box
            // 
            this.Api_Key_Box.Location = new System.Drawing.Point(124, 79);
            this.Api_Key_Box.Name = "Api_Key_Box";
            this.Api_Key_Box.Size = new System.Drawing.Size(359, 25);
            this.Api_Key_Box.TabIndex = 10;
            this.Api_Key_Box.TextChanged += new System.EventHandler(this.Api_Key_Box_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 529);
            this.Controls.Add(this.Api_Key_Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Select_Save_Path);
            this.Controls.Add(this.Select_File_Path);
            this.Controls.Add(this.Save_Path_Box);
            this.Controls.Add(this.File_Path_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save_To_Xml);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Get_Content_Bt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Strings.xml繁化工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Get_Content_Bt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Save_To_Xml;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox File_Path_Box;
        private System.Windows.Forms.TextBox Save_Path_Box;
        private System.Windows.Forms.Button Select_File_Path;
        private System.Windows.Forms.Button Select_Save_Path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Api_Key_Box;
    }
}

