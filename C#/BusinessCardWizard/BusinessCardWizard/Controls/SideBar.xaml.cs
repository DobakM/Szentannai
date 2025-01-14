using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BusinessCardWizard.Controls
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public static readonly RoutedEvent clickEvent = EventManager.RegisterRoutedEvent("Routed", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SideBar));

        public List<string> keys = new List<string>
        {
            "grad_aqua",
            "grad_magenta",
            "grad_yellow",
            "grad_pink",
            "grad_aquamarine",
            "grad_lime"
        };

        public event RoutedEventHandler click
        {
            add { AddHandler(clickEvent, value); }
            remove { RemoveHandler(clickEvent, value); }
        }

        public SideBar()
        {
            InitializeComponent();

            ((INotifyCollectionChanged)itemscontrol.Items).CollectionChanged += ItemsControl_CollectionChanged;
        }

        public void Recolor()
        {
            int i = 0;

            foreach (var item in itemscontrol.Items)
            {
                UIElement container = (UIElement)itemscontrol.ItemContainerGenerator.ContainerFromItem(item);

                Border border = VisualTreeHelper.GetChild(container, 0) as Border;

                border.Background = (LinearGradientBrush)FindResource(keys[i]);

                if (i++ >= keys.Count() - 1)
                {
                    i = 0;
                }
            }
        }

        private void Event_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs routedEventArgs = new RoutedEventArgs(clickEvent);

            RaiseEvent(routedEventArgs);
        }

        private void itemscontrol_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() => Recolor()));
        }

        private void ItemsControl_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Loaded, new Action(() => Recolor()));
            }
        }

        private void Insert_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
