using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab5.ViewModel
{
    
    public class AddViewModel : ViewModelBase
    {
        
        private string enteredProductId;
       
        private string enteredProductName;
        
        private string enteredQuantity;

        /// <summary>
        /// Initializes a new instance of the AddViewModel class.
        /// </summary>
        public AddViewModel()
        {
            SaveCommand = new RelayCommand<IClosable>(SaveMethod);
            __________________________________________________
        }
        /// <summary>
        /// The command that triggers saving the filled out member data.
        /// </summary>
        public ICommand SaveCommand { get; private set; }
        /// <summary>
        /// The command that triggers closing the add window.
        /// </summary>
        public ICommand CancelCommand { get; private set; }
        /// <summary>
        /// Sends a valid member to the Main VM to add to the list, then closes the window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void SaveMethod(IClosable window)
        {
            try
            {
                if (window != null)
                {
                    Messenger.Default.Send(_______________________________________));
                    window.Close();
                }
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
                MessageBox.Show("Must be a valid quantity address.", "Entry Error");
            }
        }
        /// <summary>
        /// Closes the window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void CancelMethod(IClosable window)
        {
            if (window != null)
            {
                window.Close();
            }
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
