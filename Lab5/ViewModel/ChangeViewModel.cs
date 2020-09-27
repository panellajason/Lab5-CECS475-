using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab5.ViewModel
{
    
    public class ChangeViewModel : ViewModelBase
    {
        private string enteredProductId;

        private string enteredProductName;

        private string enteredQuantity;

        public ChangeViewModel()
        {
            UpdateCommand = new RelayCommand<IClosable>(UpdateMethod);
            DeleteCommand = new RelayCommand<IClosable>(DeleteMethod);

            Messenger.Default.Register<Product>(this, GetSelected);
        }
        /// <summary>
        /// The command that triggers saving the filled out member data.
        /// </summary>
        public ICommand UpdateCommand { get; private set; }
        /// <summary>
        /// The command that triggers removing the previously selected user.
        /// </summary>
        public ICommand DeleteCommand { get; private set; }
        /// <summary>
        /// Sends a valid member to the main VM to replace at the selected index with, then closes the change window.
    /// </summary>
    /// <param name="window">The window to close.</param>
        public void UpdateMethod(IClosable window)
        {
            try
            {
                Messenger.Default.Send(new NotificationMessage("Update"));
                window.Close();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Fields must be under 25 characters.", "Entry Error");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Fields cannot be empty.", "Entry Error");
            }
            catch (FormatException)
            {
                MessageBox.Show("Must be a valid quantity.", "Entry Error");
            }
        }
        /// <summary>
        /// Sends out a message to initiate closing the change window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void DeleteMethod(IClosable window)
        {
            if (window != null)
            {
                Messenger.Default.Send(new NotificationMessage("Delete"));
                window.Close();
            }
        }

        /// <summary>
        /// Receives a member from the main VM to auto-fill the change box with the currently selected member.
        /// </summary>
        /// <param name="m">The member data to fill in.</param>
        public void GetSelected(Product m)
        {
            ___________________________
        }

        public string EnteredProductId
        {
            get
            {
                return enteredProductId;
            }
            set
            {
                enteredProductId = value;
                RaisePropertyChanged("EnteredProductId");
            }
        }

        public string EnteredProductName
        {
            get
            {
                return enteredProductName;
            }
            set
            {
                enteredProductName = value;
                RaisePropertyChanged("EnteredProductName");
            }
        }
        public string EnteredQuantity
        {
            get
            {
                return enteredQuantity;
            }
            set
            {
                enteredQuantity = value;
                RaisePropertyChanged("EnteredQuantity");
            }
        }
    }
}

