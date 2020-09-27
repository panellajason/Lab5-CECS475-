using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Lab5.Messages;
using Lab5.Models;
using Lab5.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Lab5.ViewModel
{
    /// <summary>
    /// The VM for the main screen that shows the member list.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
       
        private ObservableCollection<Product> products;
       
        private Product selectedProduct;
        
        private ProductDB database;
        
        public MainViewModel()
        {
            products =
            database =
            products = database.GetProducts();
            AddCommand =
            ExitCommand =
            ChangeCommand =
            Messenger.Default.Register<MessageProduct>(this, ReceiveProduct);
            Messenger.Default.Register<NotificationMessage>(this, ReceiveMessage);
        }
        /// <summary>
        /// The command that triggers adding a new member.
        /// </summary>
        public ICommand AddCommand { get; private set; }

        
        public Product SelectedProduct
        {
            get
            {
                return selectedProduct;
            }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged("SelectedProduct");
            }
        }
        /// <summary>
        /// Shows a new add screen.
        /// </summary>
        public void AddMethod()
        {
            AddWindow add = new AddWindow();
            add.Show();
        }
        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void ExitMethod(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        /// <summary>
        /// Opens the change window.
        /// </summary>
        public void ChangeMethod()
        {
            if (SelectedProduct != null)
            {
                ChangeWindow change = new ChangeWindow();
                change.Show();
                Messenger.Default.Send(__________________________);
            }
        }
        /// <summary>
        /// Gets a new member for the list.
        /// </summary>
        /// <param name="m">The member to add. The message denotes how it is added.
        /// "Update" replaces at the specified index, "Add" adds it to the list.</param>
        public void ReceiveProduct(MessageProduct m)
        {
            if (m.Message == "Update")
            {
                _____________________________________
            database.SaveProducts();
            }
            else if (m.Message == "Add")
            {
                ______________________________________
            database.SaveProducts();
            }
        }
        /// <summary>

        /// Gets text messages.
        /// </summary>
        /// <param name="msg">The received message. "Delete" means the currently selected member is deleted.</param>
        public void ReceiveMessage(NotificationMessage msg)
        {
            if (msg.Notification == "Delete")
            {
                _______________________________________________
                database.SaveProducts();
            }
        }
        /// <summary>
        /// The list of registered members.
        /// </summary>
        public ObservableCollection<Product> ProductList
        {
            get { return products; }
        }
    }
}