
using System;
using System.Collections.ObjectModel;
using System.Windows;
using WpdOstatni.Model;
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
            m_ActionText = "Text to be displayed on the popup";
            DataRepository dl = new DataRepository();
            m_Users = new ObservableCollection<User>(dl.User);
        }
        #endregion

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
        public DataRepository DataLayer
        {
            get { return m_DataLayer; }
            set
            {
                m_DataLayer = value; Users = new ObservableCollection<User>(value.User);
            }
        }
        #endregion

        #region Private stuff
        private DataRepository m_DataLayer;
        private User m_CurrentUser;
        private string m_ActionText;
        private ObservableCollection<User> m_Users;
        private void ShowPopupWindow()
        {
            MessageBoxShowDelegate(ActionText, "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
        }

       
        #endregion


    }
}
