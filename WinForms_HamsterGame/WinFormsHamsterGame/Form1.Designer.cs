namespace WinFormsHamsterGame
{
    partial class HamsterGame
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
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            trackBar1 = new TrackBar();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            button14 = new Button();
            button13 = new Button();
            button16 = new Button();
            button15 = new Button();
            button10 = new Button();
            button9 = new Button();
            button12 = new Button();
            button11 = new Button();
            button6 = new Button();
            button5 = new Button();
            button8 = new Button();
            button7 = new Button();
            button1 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.ControlLightLight;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlDark;
            splitContainer1.Panel1.Controls.Add(trackBar1);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlDarkDark;
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.SplitterWidth = 10;
            splitContainer1.TabIndex = 0;
            splitContainer1.SplitterMoving += splitContainer1_SplitterMoving;
            // 
            // trackBar1
            // 
            trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            trackBar1.Location = new Point(45, 165);
            trackBar1.Maximum = 1000;
            trackBar1.Minimum = 10;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(156, 69);
            trackBar1.TabIndex = 1;
            trackBar1.Value = 10;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 0);
            label1.Name = "label1";
            label1.Size = new Size(108, 25);
            label1.TabIndex = 0;
            label1.Text = "GameSpeed";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(button14, 0, 3);
            tableLayoutPanel1.Controls.Add(button13, 0, 3);
            tableLayoutPanel1.Controls.Add(button16, 0, 3);
            tableLayoutPanel1.Controls.Add(button15, 0, 3);
            tableLayoutPanel1.Controls.Add(button10, 0, 2);
            tableLayoutPanel1.Controls.Add(button9, 0, 2);
            tableLayoutPanel1.Controls.Add(button12, 0, 2);
            tableLayoutPanel1.Controls.Add(button11, 0, 2);
            tableLayoutPanel1.Controls.Add(button6, 0, 1);
            tableLayoutPanel1.Controls.Add(button5, 0, 1);
            tableLayoutPanel1.Controls.Add(button8, 0, 1);
            tableLayoutPanel1.Controls.Add(button7, 0, 1);
            tableLayoutPanel1.Controls.Add(button1, 0, 0);
            tableLayoutPanel1.Controls.Add(button4, 2, 0);
            tableLayoutPanel1.Controls.Add(button3, 1, 0);
            tableLayoutPanel1.Controls.Add(button2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(524, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button14
            // 
            button14.BackColor = Color.DimGray;
            button14.Dock = DockStyle.Fill;
            button14.Location = new Point(134, 339);
            button14.Name = "button14";
            button14.Size = new Size(125, 108);
            button14.TabIndex = 15;
            button14.Tag = "13";
            button14.UseVisualStyleBackColor = false;
            button14.Click += button_Click;
            // 
            // button13
            // 
            button13.BackColor = Color.DimGray;
            button13.Dock = DockStyle.Fill;
            button13.Location = new Point(3, 339);
            button13.Name = "button13";
            button13.Size = new Size(125, 108);
            button13.TabIndex = 14;
            button13.Tag = "12";
            button13.UseVisualStyleBackColor = false;
            button13.Click += button_Click;
            // 
            // button16
            // 
            button16.BackColor = Color.DimGray;
            button16.Dock = DockStyle.Fill;
            button16.Location = new Point(396, 339);
            button16.Name = "button16";
            button16.Size = new Size(125, 108);
            button16.TabIndex = 13;
            button16.Tag = "15";
            button16.UseVisualStyleBackColor = false;
            button16.Click += button_Click;
            // 
            // button15
            // 
            button15.BackColor = Color.DimGray;
            button15.Dock = DockStyle.Fill;
            button15.Location = new Point(265, 339);
            button15.Name = "button15";
            button15.Size = new Size(125, 108);
            button15.TabIndex = 12;
            button15.Tag = "14";
            button15.UseVisualStyleBackColor = false;
            button15.Click += button_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.DimGray;
            button10.Dock = DockStyle.Fill;
            button10.Location = new Point(134, 227);
            button10.Name = "button10";
            button10.Size = new Size(125, 106);
            button10.TabIndex = 11;
            button10.Tag = "9";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.DimGray;
            button9.Dock = DockStyle.Fill;
            button9.Location = new Point(3, 227);
            button9.Name = "button9";
            button9.Size = new Size(125, 106);
            button9.TabIndex = 10;
            button9.Tag = "8";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.DimGray;
            button12.Dock = DockStyle.Fill;
            button12.Location = new Point(396, 227);
            button12.Name = "button12";
            button12.Size = new Size(125, 106);
            button12.TabIndex = 9;
            button12.Tag = "11";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.DimGray;
            button11.Dock = DockStyle.Fill;
            button11.Location = new Point(265, 227);
            button11.Name = "button11";
            button11.Size = new Size(125, 106);
            button11.TabIndex = 8;
            button11.Tag = "10";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.DimGray;
            button6.Dock = DockStyle.Fill;
            button6.Location = new Point(134, 115);
            button6.Name = "button6";
            button6.Size = new Size(125, 106);
            button6.TabIndex = 7;
            button6.Tag = "5";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.DimGray;
            button5.Dock = DockStyle.Fill;
            button5.Location = new Point(3, 115);
            button5.Name = "button5";
            button5.Size = new Size(125, 106);
            button5.TabIndex = 6;
            button5.Tag = "4";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.DimGray;
            button8.Dock = DockStyle.Fill;
            button8.Location = new Point(396, 115);
            button8.Name = "button8";
            button8.Size = new Size(125, 106);
            button8.TabIndex = 5;
            button8.Tag = "7";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button_Click;
            // 
            // button7
            // 
            button7.BackColor = Color.DimGray;
            button7.Dock = DockStyle.Fill;
            button7.Location = new Point(265, 115);
            button7.Name = "button7";
            button7.Size = new Size(125, 106);
            button7.TabIndex = 4;
            button7.Tag = "6";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.DimGray;
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(125, 106);
            button1.TabIndex = 3;
            button1.Tag = "0";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DimGray;
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(396, 3);
            button4.Name = "button4";
            button4.Size = new Size(125, 106);
            button4.TabIndex = 2;
            button4.Tag = "3";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DimGray;
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(265, 3);
            button3.Name = "button3";
            button3.Size = new Size(125, 106);
            button3.TabIndex = 1;
            button3.Tag = "2";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DimGray;
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(134, 3);
            button2.Name = "button2";
            button2.Size = new Size(125, 106);
            button2.TabIndex = 0;
            button2.Tag = "1";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button_Click;
            // 
            // HamsterGame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            MinimumSize = new Size(300, 200);
            Name = "HamsterGame";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HamsterGame";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private TrackBar trackBar1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button14;
        private Button button13;
        private Button button16;
        private Button button15;
        private Button button10;
        private Button button9;
        private Button button12;
        private Button button11;
        private Button button6;
        private Button button5;
        private Button button8;
        private Button button7;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
    }
}
