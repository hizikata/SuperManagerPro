using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperManagerPro.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        #region Fields
        #endregion
        #region Properties
        private bool _showMerchandiseManagement;

        public bool ShowMerchandiseManagement
        {
            get { return _showMerchandiseManagement; }
            set
            {
                _showMerchandiseManagement = !_showMerchandiseManagement;
                RaisePropertyChanged(() => ShowMerchandiseManagement);
            }
        }

        #endregion
        #region Constructors
        public MainViewModel()
        {

        }
        #endregion
        #region Commands
        public ReadOnlyCollection<CommandViewModel> MerchandiseManagementCommand
        {
            get
            {
                List<CommandViewModel> list = new List<CommandViewModel>()
                {
                    new CommandViewModel(new RelayCommand<object>(p=>MerchandiseManagement()),"商品管理")
                };
                return new ReadOnlyCollection<CommandViewModel>(list);
            }
        }
        public ReadOnlyCollection<CommandViewModel> MerchandiseManagementCommands
        {
            get
            {
                List<CommandViewModel> list = new List<CommandViewModel>()
                {
                    new CommandViewModel(new RelayCommand<object>(p=>SuppliserManagement()),"供应商信息"),
                    new CommandViewModel(new RelayCommand<object>(p=>MerchandiseInfo()),"商品信息"),
                    new CommandViewModel(new RelayCommand<object>(p=>InventoryManagement()),"库存信息")
                };
                return new ReadOnlyCollection<CommandViewModel>(list);

            }
        }
        #endregion
        #region Command Methods
        //改变子菜单的可见性
        void MerchandiseManagement()
        {
            this.ShowMerchandiseManagement = !ShowMerchandiseManagement;
        }
        void SuppliserManagement()
        {

        }
        void MerchandiseInfo()
        {

        }
        void InventoryManagement()
        {

        }
        #endregion


    }
}