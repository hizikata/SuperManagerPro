using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SuperManagerPro.Model;

namespace SuperManagerPro.ViewModel
{
    public class MainViewModel : WorkspaceViewModel
    {
        #region Fields
        #endregion
        #region Properties
        private bool _showMerchandiseManagement;
        WorkspaceViewModel _workspace;
        public bool ShowMerchandiseManagement
        {
            get { return _showMerchandiseManagement; }
            set
            {
                if (value == _showMerchandiseManagement)
                    return;
                _showMerchandiseManagement = value;
                RaisePropertyChanged(() => ShowMerchandiseManagement);
            }
        }

        
        public WorkspaceViewModel Workspace
        {
            get { return _workspace; }
            set
            {
                if (value == _workspace)
                    return;
                _workspace = value;
                RaisePropertyChanged(() => Workspace);
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
                    new CommandViewModel(new RelayCommand<object>(p=>MerchandiseManagement()),"商品管理","Merchandise.ico","一些示例文字")
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
                    new CommandViewModel(new RelayCommand<object>(p=>SuppliserManagement()),"供应商信息","Supplier.ico"),
                    new CommandViewModel(new RelayCommand<object>(p=>MerchandiseInfo()),"商品信息","MerchandiseInfo.ico"),
                    new CommandViewModel(new RelayCommand<object>(p=>InventoryManagement()),"库存信息","Inventory.ico")
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
        void SuppliserManagement() => ChangeWorkspace(new AllSupplierViewModel());
        void MerchandiseInfo()
        {
            
        }
        void InventoryManagement()
        {

        }
        #endregion
        #region Methods
        void ChangeWorkspace(WorkspaceViewModel workspace)
        {
            if (workspace == _workspace)
                return;
            //if (Workspace != null)

            //    Workspace.Dispose();
            Workspace?.Dispose();
            Workspace = workspace;
        }
        protected override void OnDispose()
        {
            //todo 重写OnDispose()方法
            base.OnDispose();
        }
        #endregion  Methods

    }
}