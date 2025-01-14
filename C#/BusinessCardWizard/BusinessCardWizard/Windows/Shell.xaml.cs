using BusinessCardWizard.ApplicationLayer.Services;
using BusinessCardWizard.Configuration;
using BusinessCardWizard.Controls;
using BusinessCardWizard.CoreLayer.SerializerHelpers;
using BusinessCardWizard.CoreLayer.Serializers;
using BusinessCardWizard.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BusinessCardWizard.Windows
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    /// 
    public partial class Shell : Window
    {
        private ContactDataService contactDataService { get; set; }

       // public JsonSerializer jsonSerializer { get; set; }

        public Shell()
        {
            contactDataService = new ContactDataService(SerializerHelperConfig.GetInstance().serializerHelper, LoggerConfig.GetInstance().logger);

            contactDataService.Deserialize();

            DataContext = contactDataService;

            InitializeComponent();
        }

        public void Save()
        {

            TabItem tab = (TabItem)tabs.SelectedItem;

            Contact contact = (Contact)tab.DataContext;

            tab.Header = contact.FullName;

            contactDataService.Save(contact);

            status.Text = "Saved";
        }

        public void Add(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.OriginalSource;

            Contact contact = button.DataContext as Contact;

            foreach (TabItem item in tabs.Items)
            {
                if (contact.Same((Contact)item.DataContext))
                {
                    item.Focus();

                    return;
                };
            }

            Insert(contact.FullName, contact);

            status.Text = "Opened";
        }

        public void Insert(string header, Contact contact)
        {
            ContentPresenter presenter = new ContentPresenter();

            presenter.Content = new EditContactView();

            TabItem tab = new TabItem();

            tab.DataContext = contact;

            tab.Header = header;

            tab.Content = presenter;

            tabs.Items.Insert(0, tab);

            tab.Focus();

            status.Text = "Inserted";
        }

        public void Delete()
        {
            TabItem tab = (TabItem)tabs.SelectedItem;

            Contact contact = (Contact)tab.DataContext;

            contactDataService.Delete(contact);

            tabs.Items.Remove(tab);

            status.Text = "Deleted";
        }

        public void Shut()
        {
            TabItem tab = tabs.SelectedItem as TabItem;

            tabs.Items.Remove(tab);

            status.Text = "Closed";
        }

        private void RoutedEvent(object sender, RoutedEventArgs e)
        {
            //Not to delete!
        }

        /*
        Not to delete:
toborzó
        private void SideBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((e.OriginalSource as FrameworkElement).GetType() == typeof(Button))
            {
                Add(sender, e);
            }
        }
        */

        private void tabs_Click(object sender, RoutedEventArgs e)
        {
            object shell = this;

            Button button = (Button)e.OriginalSource;

            MethodInfo methodInfo = this.GetType().GetMethod((string)button.Content);

            methodInfo.Invoke(shell, new object[] {});
        }


        private void sidebar_button_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = e.OriginalSource as FrameworkElement;

            if (element.Name.Equals("insert"))
            {
                Insert("New Item", new Contact());
            }

            if (element.Name.Equals("add"))
            {
                Add(sender, e);
            }
        }

        public string AskUserForImagePath()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.ShowDialog();

            return dlg.FileName;
        }

        private void AddImage()
        {
            TabItem tab = (TabItem)tabs.SelectedItem;

            Contact contact = (Contact)tab.DataContext;

            contact.ImagePath = AskUserForImagePath();

            tab.DataContext = null;

            tab.DataContext = contact;
        }

        private void tabs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)e.OriginalSource;

            if (element.Name == "imagetb")
            {
                AddImage();
            }
        }
    }
}
