using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Lab5.Messages;
using Lab5.Models;
using Lab5.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
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
        //// <summary>
        /// The command that triggers adding a new member.
        /// </summary>
        public ICommand AddCommand { get; private set; }
        public ICommand ExitCommand { get; private set; }
        public ICommand ChangeCommand { get; private set; }

        public MainViewModel()
        {
            products = new ObservableCollection<Product>();
            database = new ProductDB(products);
            products = database.GetProducts();
            AddCommand = new RelayCommand(AddMethod);
            ExitCommand = new RelayCommand<Window>(ExitMethod);
            ChangeCommand = new RelayCommand(ChangeMethod);
            Messenger.Default.Register<MessageProduct>(this, ReceiveProduct);
            Messenger.Default.Register<NotificationMessage>(this, ReceiveMessage);
        }

        


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
            AddView add = new AddView();
            add.Show();
        }
        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="window">The window to close.</param>
        private void ExitMethod(Window window)
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
                ChangeView change = new ChangeView();
                change.Show();
                Messenger.Default.Send(new NotificationMessage("Change"));
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
                products[products.IndexOf(SelectedProduct)] = m;
                database.SaveProducts();
            }
            else if (m.Message == "Add")
            {
                products.Add(m);
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
                products.Remove(SelectedProduct);
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