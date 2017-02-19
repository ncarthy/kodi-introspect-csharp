namespace KodiIntrospect
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMethods = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxNamespaces = new System.Windows.Forms.ComboBox();
            this.buttonAllMethods = new System.Windows.Forms.Button();
            this.buttonAllTypes = new System.Windows.Forms.Button();
            this.buttonAllNotifications = new System.Windows.Forms.Button();
            this.buttonEverything = new System.Windows.Forms.Button();
            this.comboBoxTypeNamespaces = new System.Windows.Forms.ComboBox();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxNotifications = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(44, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(682, 356);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(632, 412);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(94, 69);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear Window";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(632, 487);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 69);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close Window";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Methods";
            // 
            // comboBoxMethods
            // 
            this.comboBoxMethods.FormattingEnabled = true;
            this.comboBoxMethods.Location = new System.Drawing.Point(370, 472);
            this.comboBoxMethods.Name = "comboBoxMethods";
            this.comboBoxMethods.Size = new System.Drawing.Size(118, 21);
            this.comboBoxMethods.TabIndex = 9;
            this.comboBoxMethods.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethods_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Method Namespaces";
            // 
            // comboBoxNamespaces
            // 
            this.comboBoxNamespaces.FormattingEnabled = true;
            this.comboBoxNamespaces.Location = new System.Drawing.Point(370, 428);
            this.comboBoxNamespaces.Name = "comboBoxNamespaces";
            this.comboBoxNamespaces.Size = new System.Drawing.Size(118, 21);
            this.comboBoxNamespaces.TabIndex = 7;
            this.comboBoxNamespaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxNamespaces_SelectedIndexChanged);
            // 
            // buttonAllMethods
            // 
            this.buttonAllMethods.Location = new System.Drawing.Point(44, 412);
            this.buttonAllMethods.Name = "buttonAllMethods";
            this.buttonAllMethods.Size = new System.Drawing.Size(94, 69);
            this.buttonAllMethods.TabIndex = 11;
            this.buttonAllMethods.Text = "All Methods";
            this.buttonAllMethods.UseVisualStyleBackColor = true;
            this.buttonAllMethods.Click += new System.EventHandler(this.buttonAllMethods_Click);
            // 
            // buttonAllTypes
            // 
            this.buttonAllTypes.Location = new System.Drawing.Point(144, 412);
            this.buttonAllTypes.Name = "buttonAllTypes";
            this.buttonAllTypes.Size = new System.Drawing.Size(94, 69);
            this.buttonAllTypes.TabIndex = 13;
            this.buttonAllTypes.Text = "All Types";
            this.buttonAllTypes.UseVisualStyleBackColor = true;
            this.buttonAllTypes.Click += new System.EventHandler(this.buttonAllTypes_Click);
            // 
            // buttonAllNotifications
            // 
            this.buttonAllNotifications.Location = new System.Drawing.Point(248, 412);
            this.buttonAllNotifications.Name = "buttonAllNotifications";
            this.buttonAllNotifications.Size = new System.Drawing.Size(94, 69);
            this.buttonAllNotifications.TabIndex = 14;
            this.buttonAllNotifications.Text = "All Notifications";
            this.buttonAllNotifications.UseVisualStyleBackColor = true;
            this.buttonAllNotifications.Click += new System.EventHandler(this.buttonAllNotifications_Click);
            // 
            // buttonEverything
            // 
            this.buttonEverything.Location = new System.Drawing.Point(44, 487);
            this.buttonEverything.Name = "buttonEverything";
            this.buttonEverything.Size = new System.Drawing.Size(298, 69);
            this.buttonEverything.TabIndex = 15;
            this.buttonEverything.Text = "Everything";
            this.buttonEverything.UseVisualStyleBackColor = true;
            this.buttonEverything.Click += new System.EventHandler(this.buttonEverything_Click);
            // 
            // comboBoxTypeNamespaces
            // 
            this.comboBoxTypeNamespaces.FormattingEnabled = true;
            this.comboBoxTypeNamespaces.Location = new System.Drawing.Point(509, 428);
            this.comboBoxTypeNamespaces.Name = "comboBoxTypeNamespaces";
            this.comboBoxTypeNamespaces.Size = new System.Drawing.Size(103, 21);
            this.comboBoxTypeNamespaces.TabIndex = 16;
            this.comboBoxTypeNamespaces.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeNamespaces_SelectedIndexChanged);
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.FormattingEnabled = true;
            this.comboBoxTypes.Location = new System.Drawing.Point(509, 472);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(103, 21);
            this.comboBoxTypes.TabIndex = 17;
            this.comboBoxTypes.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypes_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(506, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Type Namespaces";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(506, 456);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Types";
            // 
            // comboBoxNotifications
            // 
            this.comboBoxNotifications.FormattingEnabled = true;
            this.comboBoxNotifications.Location = new System.Drawing.Point(370, 513);
            this.comboBoxNotifications.Name = "comboBoxNotifications";
            this.comboBoxNotifications.Size = new System.Drawing.Size(118, 21);
            this.comboBoxNotifications.TabIndex = 20;
            this.comboBoxNotifications.SelectedIndexChanged += new System.EventHandler(this.comboBoxNotifications_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 497);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Notifications";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 564);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxNotifications);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxTypes);
            this.Controls.Add(this.comboBoxTypeNamespaces);
            this.Controls.Add(this.buttonEverything);
            this.Controls.Add(this.buttonAllNotifications);
            this.Controls.Add(this.buttonAllTypes);
            this.Controls.Add(this.buttonAllMethods);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMethods);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxNamespaces);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMethods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxNamespaces;
        private System.Windows.Forms.Button buttonAllMethods;
        private System.Windows.Forms.Button buttonAllTypes;
        private System.Windows.Forms.Button buttonAllNotifications;
        private System.Windows.Forms.Button buttonEverything;
        private System.Windows.Forms.ComboBox comboBoxTypeNamespaces;
        private System.Windows.Forms.ComboBox comboBoxTypes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxNotifications;
        private System.Windows.Forms.Label label5;
    }
}

