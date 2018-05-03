using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GalaSoft.MvvmLight.Command;

namespace SuperManagerPro.ViewModel
{
    public class ItemsViewModel : WorkspaceViewModel
    {
        #region Fields
        bool _isSelected;
        #endregion
        #region Constructors
        public ItemsViewModel()
        {

        }
        #endregion
        #region Properties
        bool CanSave { get; set; }
        public bool IsEdit { get; private set; }
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }


            set
            {
                if (value == _isSelected)
                    return;
                IsSelected = value;
                RaisePropertyChanged(() => IsSelected);
            }
        }
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                List<CommandViewModel> commands = new List<CommandViewModel>()
                {
                    new CommandViewModel(new RelayCommand<object>((p)=>OnRequestSave(),p => CanSave),"保存"),
                    new CommandViewModel(this.CloseCommand,"取消")
                };
                return new ReadOnlyCollection<CommandViewModel>(commands);
            }
        }
        #endregion  Properties
        #region Methods
        void OnRequestSave()
        {
            ManipulationData();
            RequestSave?.Invoke(this, EventArgs.Empty);
        }
        protected bool IsEmail(string email)
        {
            return Regex.IsMatch(
                email, @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$");
        }
        protected virtual void ManipulationData() { }
        #endregion
        #region Event
        public event EventHandler RequestSave;
        #endregion
    }
}
