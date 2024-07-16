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
            listView_categoriesList = new ListView();
            SuspendLayout();
            // 
            // label_host
            // 
            label_host.AutoSize = true;
            label_host.Font = new Font("Segoe UI", 16F);
            label_host.Location = new Point(119, 20);
            label_host.Name = "label_host";
            label_host.Size = new Size(176, 30);
            label_host.TabIndex = 0;
            label_host.Text = "מארח - קטגוריות";
            // 
            // textBox_inputCategory
            // 
            textBox_inputCategory.Font = new Font("Segoe UI", 16F);
            textBox_inputCategory.Location = new Point(139, 97);
            textBox_inputCategory.Name = "textBox_inputCategory";
            textBox_inputCategory.Size = new Size(136, 36);
            textBox_inputCategory.TabIndex = 1;
            // 
            // button_addCategory
            // 
            button_addCategory.Font = new Font("Segoe UI", 12F);
            button_addCategory.Location = new Point(139, 139);
            button_addCategory.Name = "button_addCategory";
            button_addCategory.Size = new Size(136, 37);
            button_addCategory.TabIndex = 2;
            button_addCategory.Text = "הוסף קטגוריה";
            button_addCategory.UseVisualStyleBackColor = true;
            button_addCategory.Click += button_addCategory_Click;
            // 
            // listView_categoriesList
            // 
            listView_categoriesList.GridLines = true;
            listView_categoriesList.Location = new Point(108, 198);
            listView_categoriesList.Name = "listView_categoriesList";
            listView_categoriesList.RightToLeftLayout = true;
            listView_categoriesList.Size = new Size(198, 215);
            listView_categoriesList.TabIndex = 4;
            listView_categoriesList.UseCompatibleStateImageBehavior = false;
            listView_categoriesList.View = View.List;
            // 
            // HostForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 450);
            Controls.Add(listView_categoriesList);
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
        private ListView listView_categoriesList;
    }
}