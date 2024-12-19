namespace WinFormsCalendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string date = monthCalendar.SelectionStart.ToShortDateString(); //pobranie poczatku zakresu wybranej daty (tu konkretnej daty) i konwersja
            string note = noteTextBox.Text;
            ListViewItem newItem = new ListViewItem(new[] { date, note }); //stworzenie nowego elementu zainicjowanego data i tekstem
            calendarListView.Items.Add(newItem); //dodanie nowego elementu do ListView
            noteTextBox.Text = ""; //wyczyszczenie miejsca do wpisaywania tekstu
            notifyIcon.ShowBalloonTip(1000, "Item added", "Added new event", ToolTipIcon.Info); //w ostatnim argumencie mozna wybrac tryb
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in calendarListView.SelectedItems)
                calendarListView.Items.Remove(item);
        }

        private void calendarListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            removeButton.Enabled = calendarListView.SelectedItems.Count > 0;
        }

        private void ExitContextMenu_Click(object sender, EventArgs e)
        {
            Close();
        }

    private void Form1_Load(object sender, EventArgs e)
        {
            notifyIconContextMenu.Items.Add("Exit", null, ExitContextMenu_Click);
        }
    }
}
