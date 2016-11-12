namespace PremierZal.App
{
    public partial class ProgressWindow
    {
        public ProgressWindow()
        {
            InitializeComponent();
        }

        public ProgressWindow(string title) : this()
        {
            LblTitle.Content = title;
        }
    }
}