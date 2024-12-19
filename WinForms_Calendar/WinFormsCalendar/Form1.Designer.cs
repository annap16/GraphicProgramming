namespace WinFormsCalendar
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
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            splitContainer1 = new SplitContainer();
            noteTextBox = new TextBox();
            monthCalendar = new MonthCalendar();
            calendarListView = new ListView();
            dateColumnHeader = new ColumnHeader();
            noteColumnHeader = new ColumnHeader();
            removeButton = new Button();
            addButton = new Button();
            notifyIcon = new NotifyIcon(components);
            notifyIconContextMenu = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.LightSteelBlue;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel1.Controls.Add(noteTextBox);
            splitContainer1.Panel1.Controls.Add(monthCalendar);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.ControlLight;
            splitContainer1.Panel2.Controls.Add(calendarListView);
            splitContainer1.Panel2.Controls.Add(removeButton);
            splitContainer1.Panel2.Controls.Add(addButton);
            splitContainer1.Size = new Size(778, 444);
            splitContainer1.SplitterDistance = 312;
            splitContainer1.TabIndex = 0;
            // 
            // noteTextBox
            // 
            noteTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            noteTextBox.Location = new Point(12, 254);
            noteTextBox.Multiline = true;
            noteTextBox.Name = "noteTextBox";
            noteTextBox.Size = new Size(750, 46);
            noteTextBox.TabIndex = 2;
            // 
            // monthCalendar
            // 
            monthCalendar.CalendarDimensions = new Size(2, 1);
            monthCalendar.Location = new Point(9, 0);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 1;
            // 
            // calendarListView
            // 
            calendarListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            calendarListView.Columns.AddRange(new ColumnHeader[] { dateColumnHeader, noteColumnHeader });
            calendarListView.FullRowSelect = true;
            calendarListView.Location = new Point(12, 47);
            calendarListView.Name = "calendarListView";
            calendarListView.Size = new Size(757, 69);
            calendarListView.TabIndex = 5;
            calendarListView.UseCompatibleStateImageBehavior = false;
            calendarListView.View = View.Details;
            calendarListView.SelectedIndexChanged += calendarListView_SelectedIndexChanged;
            // 
            // dateColumnHeader
            // 
            dateColumnHeader.Text = "Date";
            dateColumnHeader.Width = 120;
            // 
            // noteColumnHeader
            // 
            noteColumnHeader.Text = "Note";
            noteColumnHeader.Width = 200;
            // 
            // removeButton
            // 
            removeButton.Enabled = false;
            removeButton.Location = new Point(130, 7);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(112, 34);
            removeButton.TabIndex = 3;
            removeButton.Text = "Remove";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 7);
            addButton.Name = "addButton";
            addButton.Size = new Size(112, 34);
            addButton.TabIndex = 4;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = notifyIconContextMenu;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Windows Forms Calendar";
            notifyIcon.Visible = true;
            // 
            // notifyIconContextMenu
            // 
            notifyIconContextMenu.ImageScalingSize = new Size(24, 24);
            notifyIconContextMenu.Name = "notifyIconContextMenu";
            notifyIconContextMenu.Size = new Size(61, 4);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 444);
            Controls.Add(splitContainer1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox noteTextBox;
        private MonthCalendar monthCalendar;
        private ListView calendarListView;
        private Button removeButton;
        private Button addButton;
        private ColumnHeader dateColumnHeader;
        private ColumnHeader noteColumnHeader;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip notifyIconContextMenu;
    }
}
