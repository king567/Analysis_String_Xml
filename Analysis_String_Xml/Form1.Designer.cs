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
            this.Get_Content_Bt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Get_Content_Bt
            // 
            this.Get_Content_Bt.Location = new System.Drawing.Point(240, 12);
            this.Get_Content_Bt.Name = "Get_Content_Bt";
            this.Get_Content_Bt.Size = new System.Drawing.Size(187, 61);
            this.Get_Content_Bt.TabIndex = 0;
            this.Get_Content_Bt.Text = "取出內容";
            this.Get_Content_Bt.UseVisualStyleBackColor = true;
            this.Get_Content_Bt.Click += new System.EventHandler(this.Get_Content_Bt_ClickAsync);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 89);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(469, 327);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 428);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Get_Content_Bt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Get_Content_Bt;
        private System.Windows.Forms.TextBox textBox1;
    }
}

