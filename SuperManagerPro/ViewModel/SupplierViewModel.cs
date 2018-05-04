using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperManagerPro.Model;

namespace SuperManagerPro.ViewModel
{
    public class SupplierViewModel:ItemsViewModel
    {
        #region Fields
        Supplier _model;
        Repository _repository;
        #endregion
        #region Constructors
        public SupplierViewModel(Supplier model,Repository repository)
        {
            this._model = model;
            this._repository = repository;
            this.IsEdit = true;
        }
        public SupplierViewModel(Repository repository) 
        {
            _model = new Supplier();
            this._repository = repository;
        }
        #endregion Constructors
        #region Properties
        public string ID
        {
            get { return _model.ID; }
            set
            {
                if (value == _model.ID)
                    return;
                _model.ID = value;
                RaisePropertyChanged("ID");
            }
        }

        public string Name
        {
            get { return _model.Name; }
            set
            {
                if (value == _model.Name)
                    return;
                _model.Name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string LinkMan
        {
            get { return _model.LinkMan; }
            set
            {
                if (value == _model.LinkMan)
                    return;
                _model.LinkMan = value;
                RaisePropertyChanged("LinkMan");
            }
        }

        public string Phone
        {
            get { return _model.Phone; }
            set
            {
                if (value == _model.Phone)
                    return;
                _model.Phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Alternate
        {
            get { return _model.Alternate; }
            set
            {
                if (value == _model.Alternate)
                    return;
                _model.Alternate = value;
                RaisePropertyChanged("Alternate");
            }
        }

        public string Address
        {
            get { return _model.Address; }
            set
            {
                if (value == _model.Address)
                    return;
                _model.Address = value;
                RaisePropertyChanged("Address");
            }
        }

        public string Remark
        {
            get { return _model.Remark; }
            set
            {
                if (value == _model.Remark)
                    return;
                _model.Remark = value;
                RaisePropertyChanged("Remark");
            }
        }
        #endregion
        #region Override Members
        //protected override bool CanSave
        //{
        //    get
        //    {
        //        if (this.ValidateID() != null)
        //            return false;
        //        if (this.ValidateName() != null)
        //            return false;
        //        if (this.ValidateLinkMan() != null)
        //            return false;
        //        if (this.ValidatePhone() != null)
        //            return false;
        //        if (this.ValidateAlternate() != null)
        //            return false;
        //        if (this.ValidateAddress() != null)
        //            return false;
        //        if (this.ValidateRemark() != null)
        //            return false;
        //        return true;
        //    }
        //}

        protected override void ManipulationData()
        {
            this._repository.Add(_model);
        }
        #endregion
    }
}
