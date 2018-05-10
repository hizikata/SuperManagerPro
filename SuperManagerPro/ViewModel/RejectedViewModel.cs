using SuperManagerPro.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SuperManagerPro.ViewModel
{
    public class RejectedViewModel : ItemsViewModel, IDataErrorInfo
    {
        #region Fields

        Rejected _model;
        DateTime? _purchased;

        #endregion

        #region Constructors

        public RejectedViewModel(Repository repository)
        {
            this._model = new Rejected();
            this._repository = repository;
        }

        public RejectedViewModel(Rejected model, Repository repository)
        {
            this._model = model;
            this._repository = repository;
            IsEdit = true;
            this._purchased = model.Record;
        }

        #endregion

        #region Properties

        public int ID { get { return this._model.ID; } }

        public string MerchandiseID
        {
            get { return this._model.MerchandiseID; }
            set
            {
                if (value == this._model.MerchandiseID)
                    return;
                this._model.MerchandiseID = value;
                base.RaisePropertyChanged("MerchandiseID");
            }
        }

        public string AssociatorID
        {
            get { return this._model.AssociatorID; }
            set
            {
                if (value == this._model.AssociatorID)
                    return;
                this._model.AssociatorID = value;
                base.RaisePropertyChanged("AssociatorID");
            }
        }

        public decimal Price
        {
            get { return this._model.Price; }
            set
            {
                if (value == this._model.Price)
                    return;
                this._model.Price = value;
                base.RaisePropertyChanged("Price");
            }
        }

        public int Quantity
        {
            get { return this._model.Quantity; }
            set
            {
                if (value == this._model.Quantity)
                    return;
                this._model.Quantity = value;
                base.RaisePropertyChanged("Quantity");
            }
        }

        public DateTime? Purchased
        {
            get { return this._purchased; }
            set
            {
                if (value == this._purchased)
                    return;
                this._purchased = value;
                base.RaisePropertyChanged("Purchased");
            }
        }

        public string MerchandiseName
        {
            get
            {
                foreach (Merchandise merchandise in ListMerchandise)
                    if (merchandise.ID == this.MerchandiseID)
                        return merchandise.Name;
                return "商品信息错误";
            }
        }

        public string AssociatorName
        {
            get
            {
                foreach (Associator associator in ListAssociator)
                    if (associator.ID == this.AssociatorID)
                        return associator.Name;
                return "会员信息错误";
            }
        }

        public ReadOnlyCollection<Merchandise> ListMerchandise
        {
            get { return new ReadOnlyCollection<Merchandise>(this._repository.GetMerchandise(null, null)); }
        }

        public ReadOnlyCollection<Associator> ListAssociator
        {
            get { return new ReadOnlyCollection<Associator>(this._repository.GetAssociator()); }
        }

        #endregion

        #region OverrideMembers

        protected override bool CanSave
        {
            get
            {
                if (this.ValidateMerchandise() != null)
                    return false;
                if (this.ValidateAssociator() != null)
                    return false;
                if (this.ValidatePrice() != null)
                    return false;
                if (this.ValidateQuantity() != null)
                    return false;
                if (this.ValidatePurchased() != null)
                    return false;
                return true;
            }
        }

        protected override void ManipulationData()
        {
            this._model.Record = (DateTime)this.Purchased;
            this._repository.Add(this._model);
        }

        #endregion

        #region IDataErrorInfoMembers

        string IDataErrorInfo.Error { get { return (_model as IDataErrorInfo).Error; } }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;
                switch (propertyName)
                {
                    case "MerchandiseID":
                        error = this.ValidateMerchandise();
                        break;
                    case "AssociatorID":
                        error = this.ValidateAssociator();
                        break;
                    case "Price":
                        error = this.ValidatePrice();
                        break;
                    case "Quantity":
                        error = this.ValidateQuantity();
                        break;
                    case "Purchased":
                        error = this.ValidatePurchased();
                        break;
                }
                System.Windows.Input.CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }

        string ValidateMerchandise()
        {
            if (string.IsNullOrEmpty(this.MerchandiseID))
                return "必须选择商品";
            return null;
        }

        string ValidateAssociator()
        {
            if (string.IsNullOrEmpty(this.AssociatorID))
                return "必须选择会员";
            return null;
        }

        string ValidatePrice()
        {
            if (this.Price == 0m)
                return "商品单价不能为零";
            return null;
        }

        string ValidateQuantity()
        {
            if (this.Quantity == 0)
                return "退货数量不能为零";
            return null;
        }

        string ValidatePurchased()
        {
            if (this.Purchased == null)
                return "退货日期不能为空";
            return null;
        }

        #endregion
    }
}