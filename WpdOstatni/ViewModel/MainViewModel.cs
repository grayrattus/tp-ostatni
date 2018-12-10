
using Repository;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpdOstatni.MVVMLight;

namespace WpdOstatni.ViewModel
{
    class MainViewModel: ViewModelBase
    {
        #region constructors
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            FetchDataCommend = new RelayCommand(() => DataLayer = new DataRepository());
            DisplayTextCommand = new RelayCommand(ShowPopupWindow, () => !string.IsNullOrEmpty(m_ActionText));
            RemoveUser = new RelayCommand(RemoveCurrentUser, () => !string.IsNullOrEmpty(m_ActionText));
            AddUser = new RelayCommand(AddNewUser, () => !string.IsNullOrEmpty(m_ActionText));
            UpdateUser = new RelayCommand(UpdateDataUser, () => !string.IsNullOrEmpty(m_ActionText));
            // RemoveUser = new RelayCommand(RemoveCurrentUser);
            m_ActionText = "Text to be displayed on the popup";
            DataLayer = new DataRepository();
            refreshUsers();
            UserToAdd = new User { Name = "", Age = 0, Active = false };
        }
        #endregion

        private void refreshUsers()
        {
            Users = new ObservableCollection<User>(DataLayer.getUsers());
        }
        #region ViewModel API
        public ObservableCollection<User> Users
        {
            get { return m_Users; }
            set
            {
                m_Users = value;
                RaisePropertyChanged();
            }
        }
        public User CurrentUser
        {
            get
            {
                return m_CurrentUser;
            }
            set
            {
                m_CurrentUser = value;
                RaisePropertyChanged();
            }
        }


        public User UserToAdd
        {
            get
            {
                return m_UserToAdd;
            }
            set
            {
                m_UserToAdd = value;
                RaisePropertyChanged();
            }
        }

        public string ActionText
        {
            get { return m_ActionText; }
            set
            {
                m_ActionText = value;
                DisplayTextCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }
        public RelayCommand DisplayTextCommand
        {
            get;
            private set;
        }

        public RelayCommand RemoveUser
        {
            get;
            set;
        }
        public RelayCommand AddUser
        {
            get;
            set;
        }

        public RelayCommand UpdateUser
        {
            get;
            set;
        }
        /// <summary>
        /// Gets the commend responsible to fetch data.
        /// </summary>
        public RelayCommand FetchDataCommend
        {
            get; private set;
        }

        #endregion

        #region Unit test instrumentation
        /// <summary>
        /// Gets or sets the message box show delegate.
        /// </summary>
        /// <remarks>
        /// It is to be used by unit test to override default popup. Limited access ability is addressed by explicate allowing unit test assembly to access internals 
        /// using <see cref="System.Runtime.CompilerServices.InternalsVisibleToAttribute"/>.
        /// </remarks>
        /// <value>The message box show delegate.</value>
        public Func<string, string, MessageBoxButton, MessageBoxImage, MessageBoxResult> MessageBoxShowDelegate { get; set; } = MessageBox.Show;
        public IDataRepository DataLayer
        {
            get { return m_DataLayer; }
            set
            {
                m_DataLayer = value; Users = new ObservableCollection<User>(value.getUsers());
            }
        }
        #endregion

        #region Private stuff
        private IDataRepository m_DataLayer;
        private User m_CurrentUser;
        private User m_UserToAdd;
        private string m_ActionText;
        private ObservableCollection<User> m_Users;

        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate("test", "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RemoveCurrentUser()
        {
            DataLayer.removeUser(CurrentUser);
            refreshUsers();
        }

        private void AddNewUser()
        {
            DataLayer.addUser(new User { Name = UserToAdd.Name, Age = UserToAdd.Age, Active = UserToAdd.Active });
            refreshUsers();
        }

        private void UpdateDataUser()
        {
            DataLayer.updateUser(CurrentUser);
            refreshUsers();
        }

        #endregion


    }
}
