using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperManagerPro.ViewModel
{
    public class MainViewModel : WorkspaceViewModel
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
                if (value == _showMerchandiseManagement)
                    return;
                _showMerchandiseManagement = value;
                RaisePropertyChanged(() => ShowMerchandiseManagement);
            }
        }

        WorkspaceViewModel _workspace;
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
                    new CommandViewModel(new RelayCommand<object>(p=>MerchandiseManagement()),"��Ʒ����","Merchandise.ico","һЩʾ������")
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
                    new CommandViewModel(new RelayCommand<object>(p=>SuppliserManagement()),"��Ӧ����Ϣ","Supplier.ico"),
                    new CommandViewModel(new RelayCommand<object>(p=>MerchandiseInfo()),"��Ʒ��Ϣ","MerchandiseInfo.ico"),
                    new CommandViewModel(new RelayCommand<object>(p=>InventoryManagement()),"�����Ϣ","Inventory.ico")
                };
                return new ReadOnlyCollection<CommandViewModel>(list);

            }
        }
        #endregion
        #region Command Methods
        //�ı��Ӳ˵��Ŀɼ���
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
        #region Methods
        void ChangeWorkspace(WorkspaceViewModel workspace)
        {
            if (workspace == _workspace)
                return;
            if (Workspace != null)
                //Dispase����û��ʵ�壿
                Workspace.Dispose();
            Workspace = workspace;
        }
        #endregion  Methods

    }
}