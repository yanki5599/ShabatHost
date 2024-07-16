namespace ShabatHost
{
    partial class HostForm
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
            label_host = new Label();
            textBox_inputCategory = new TextBox();
            button_addCategory = new Button();
            listBox_categories = new ListBox();
            SuspendLayout();
            // 
            // label_host
            // 
            label_host.AutoSize = true;
            label_host.Location = new Point(255, 90);
            label_host.Name = "label_host";
            label_host.Size = new Size(38, 15);
            label_host.TabIndex = 0;
            label_host.Text = "label1";
            // 
            // textBox_inputCategory
            // 
            textBox_inputCategory.Location = new Point(213, 121);
            textBox_inputCategory.Name = "textBox_inputCategory";
            textBox_inputCategory.Size = new Size(136, 23);
            textBox_inputCategory.TabIndex = 1;
            // 
            // button_addCategory
            // 
            button_addCategory.Location = new Point(213, 150);
            button_addCategory.Name = "button_addCategory";
            button_addCategory.Size = new Size(136, 37);
            button_addCategory.TabIndex = 2;
            button_addCategory.Text = "button1";
            button_addCategory.UseVisualStyleBackColor = true;
            // 
            // listBox_categories
            // 
            listBox_categories.FormattingEnabled = true;
            listBox_categories.ItemHeight = 15;
            listBox_categories.Location = new Point(184, 250);
            listBox_categories.Name = "listBox_categories";
            listBox_categories.Size = new Size(181, 139);
            listBox_categories.TabIndex = 3;
            // 
            // HostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 450);
            Controls.Add(listBox_categories);
            Controls.Add(button_addCategory);
            Controls.Add(textBox_inputCategory);
            Controls.Add(label_host);
            Name = "HostForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            Text = "שבת - מארח";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_host;
        private TextBox textBox_inputCategory;
        private Button button_addCategory;
        private ListBox listBox_categories;
    }
}