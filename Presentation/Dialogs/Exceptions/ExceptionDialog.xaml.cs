using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DataExplorer.Presentation.Dialogs.Exceptions
{
    /// <summary>
    /// Interaction logic for ExceptionDialog.xaml
    /// </summary>
    public partial class ExceptionDialog : Window, IExceptionDialog
    {
        public ExceptionDialog()
        {
            InitializeComponent();
        }

        public void SetStartupLocation(WindowStartupLocation location)
        {
            this.WindowStartupLocation = location;
        }

        public void SetIcon(Icon icon)
        {
            var iconSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle, 
                Int32Rect.Empty, 
                BitmapSizeOptions.FromEmptyOptions());

            this.Icon = iconSource;
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public void SetMessage(string message)
        {
            this.MessageLabel.Text = message;
        }

        public void SetException(Exception ex)
        {
            this.BodyTextBox.Text = GetExceptionText(ex);
        }

        public new void ShowDialog()
        {
            base.ShowDialog();
        }

        private string GetExceptionText(Exception ex)
        {
            var text = new StringBuilder()
                .AppendLine("Message: " + ex.Message)
                .AppendLine("Type: " + ex.GetType().FullName)
                .AppendLine("Source: " + ex.Source)
                .AppendLine("Stack Trace:" + Environment.NewLine + ex.StackTrace);

            if (ex.InnerException != null)
                text.Append("Inner Exception: " + GetExceptionText(ex.InnerException));

            return text.ToString();
        }
    }
}
