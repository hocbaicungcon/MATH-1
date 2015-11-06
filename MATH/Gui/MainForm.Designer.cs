namespace MATH {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(12, 12);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(260, 238);
            this.list.TabIndex = 0;
            this.list.DoubleClick += new System.EventHandler(this.enterItem);
            this.list.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.checkEnterKey);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MATH";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list;




    }
}

