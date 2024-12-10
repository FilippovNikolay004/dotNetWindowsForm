namespace practice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label5 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            MenuToolStripMenuItem = new ToolStripMenuItem();
            DeleteAllContextMenuToolStripMenuItem = new ToolStripMenuItem();
            GetFirstBookContextMenuToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            MenuToolStripMenuItem1 = new ToolStripMenuItem();
            DeleteAllToolStripMenuItem = new ToolStripMenuItem();
            GetFirstBookToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem1 = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Название книги:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 79);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 1;
            label2.Text = "Автор книги:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 116);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 2;
            label3.Text = "Жанр:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 153);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 3;
            label4.Text = "Год издания:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(115, 39);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(128, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(115, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(128, 23);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(115, 116);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(128, 23);
            textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(115, 153);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(128, 23);
            textBox4.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(10, 197);
            button1.Name = "button1";
            button1.Size = new Size(110, 23);
            button1.TabIndex = 9;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(133, 197);
            button2.Name = "button2";
            button2.Size = new Size(110, 23);
            button2.TabIndex = 10;
            button2.Text = "Удалить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.ControlLightLight;
            label5.Location = new Point(249, 39);
            label5.Name = "label5";
            label5.Size = new Size(169, 181);
            label5.TabIndex = 11;
            label5.Text = "label5";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { MenuToolStripMenuItem, выходToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(109, 48);
            // 
            // MenuToolStripMenuItem
            // 
            MenuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { DeleteAllContextMenuToolStripMenuItem, GetFirstBookContextMenuToolStripMenuItem });
            MenuToolStripMenuItem.Name = "MenuToolStripMenuItem";
            MenuToolStripMenuItem.Size = new Size(108, 22);
            MenuToolStripMenuItem.Text = "Меню";
            // 
            // DeleteAllContextMenuToolStripMenuItem
            // 
            DeleteAllContextMenuToolStripMenuItem.Name = "DeleteAllContextMenuToolStripMenuItem";
            DeleteAllContextMenuToolStripMenuItem.Size = new Size(207, 22);
            DeleteAllContextMenuToolStripMenuItem.Text = "Удалить все записи";
            DeleteAllContextMenuToolStripMenuItem.Click += удалитьВсеЗаписиToolStripMenuItem_Click;
            // 
            // GetFirstBookContextMenuToolStripMenuItem
            // 
            GetFirstBookContextMenuToolStripMenuItem.Name = "GetFirstBookContextMenuToolStripMenuItem";
            GetFirstBookContextMenuToolStripMenuItem.Size = new Size(207, 22);
            GetFirstBookContextMenuToolStripMenuItem.Text = "Получить первую книгу";
            GetFirstBookContextMenuToolStripMenuItem.Click += GetFirstBookContextMenuToolStripMenuItem_Click;
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(108, 22);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += выходToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuToolStripMenuItem1, ExitToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(431, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuToolStripMenuItem1
            // 
            MenuToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { DeleteAllToolStripMenuItem, GetFirstBookToolStripMenuItem });
            MenuToolStripMenuItem1.Name = "MenuToolStripMenuItem1";
            MenuToolStripMenuItem1.Size = new Size(53, 20);
            MenuToolStripMenuItem1.Text = "Меню";
            // 
            // DeleteAllToolStripMenuItem
            // 
            DeleteAllToolStripMenuItem.Name = "DeleteAllToolStripMenuItem";
            DeleteAllToolStripMenuItem.Size = new Size(212, 22);
            DeleteAllToolStripMenuItem.Text = "Удалиить все записи";
            DeleteAllToolStripMenuItem.Click += удалиитьВсеЗаписиToolStripMenuItem_Click;
            // 
            // GetFirstBookToolStripMenuItem
            // 
            GetFirstBookToolStripMenuItem.Name = "GetFirstBookToolStripMenuItem";
            GetFirstBookToolStripMenuItem.Size = new Size(212, 22);
            GetFirstBookToolStripMenuItem.Text = "Получить первую кнгигу";
            GetFirstBookToolStripMenuItem.Click += GetFirstBookToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem1
            // 
            ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1";
            ExitToolStripMenuItem1.Size = new Size(53, 20);
            ExitToolStripMenuItem1.Text = "Выход";
            ExitToolStripMenuItem1.Click += выходToolStripMenuItem1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 233);
            Controls.Add(menuStrip1);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library";
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button1;
        private Button button2;
        private Label label5;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem MenuToolStripMenuItem;
        private ToolStripMenuItem DeleteAllContextMenuToolStripMenuItem;
        private ToolStripMenuItem GetFirstBookContextMenuToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuToolStripMenuItem1;
        private ToolStripMenuItem DeleteAllToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem1;
        private ToolStripMenuItem GetFirstBookToolStripMenuItem;
    }
}
