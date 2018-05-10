using GalaSoft.MvvmLight.Command;
using SuperManagerPro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperManagerPro.ViewModel
{
    public class DeleteDialogViewModel : WorkspaceViewModel
    {
        #region Fields
        readonly WorkspaceViewModel _workspace;
        #endregion

        #region Constructor

        public DeleteDialogViewModel(ItemsViewModel item, Repository repository)
        {
            this._workspace = item;
            this._repository = repository;
            this.CreateMessage();
        }

        #endregion

        #region PublicInterface

        public string Message { get; private set; }

        public event EventHandler RequestDelete;

        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                List<CommandViewModel> commands = new List<CommandViewModel>
                {
                    new CommandViewModel(new RelayCommand<object>(p => OnRequestDelete()), "确定"),
                    new CommandViewModel(base.CloseCommand, "取消")
                };
                return new ReadOnlyCollection<CommandViewModel>(commands);
            }
        }

        #endregion

        #region PrivateMethods

        void OnRequestDelete()
        {
            if (this._workspace is AssociatorViewModel)
            {
                if (this._repository.GetAssociator(((AssociatorViewModel)this._workspace).ID) != null)
                    this._repository.Delete(this._repository.GetAssociator(((AssociatorViewModel)this._workspace).ID));
            }
            if (this._workspace is EmployeeViewModel)
            {
                if (this._repository.GetEmployee(((EmployeeViewModel)this._workspace).ID) != null)
                    this._repository.Delete(this._repository.GetEmployee(((EmployeeViewModel)this._workspace).ID));
            }
            if (this._workspace is SupplierViewModel)
            {
                if (this._repository.GetSupplier(((SupplierViewModel)this._workspace).ID) != null)
                    this._repository.Delete(this._repository.GetSupplier(((SupplierViewModel)this._workspace).ID));
            }
            if (this._workspace is MerchandiseViewModel)
            {
                if (this._repository.GetMerchandise(((MerchandiseViewModel)this._workspace).ID) != null)
                    this._repository.Delete(this._repository.GetMerchandise(((MerchandiseViewModel)this._workspace).ID));
            }
            if (this._workspace is SaleViewModel)
            {
                if (this._repository.GetSale(((SaleViewModel)this._workspace).ID) != null)
                    this._repository.Delete(this._repository.GetSale(((SaleViewModel)this._workspace).ID));
            }
            if (this._workspace is RejectedViewModel)
            {
                if (this._repository.GetRejected(((RejectedViewModel)this._workspace).ID) != null)
                    this._repository.Delete(this._repository.GetRejected(((RejectedViewModel)this._workspace).ID));
            }
            EventHandler handler = this.RequestDelete;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }

        void CreateMessage()
        {
            if (this._workspace is AssociatorViewModel)
                this.Message = "会员信息";
            else if (this._workspace is EmployeeViewModel)
                this.Message = "员工档案";
            else if (this._workspace is SupplierViewModel)
                this.Message = "供应商信息";
            else if (this._workspace is MerchandiseViewModel)
                this.Message = "商品信息";
            else if (this._workspace is SaleViewModel)
                this.Message = "销售记录";
            else if (this._workspace is RejectedViewModel)
                this.Message = "退货记录";
            this.Message += "删除后无法恢复，确实要删除吗？";
        }

        #endregion
    }
}