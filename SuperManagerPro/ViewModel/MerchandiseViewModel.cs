using SuperManagerPro.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SuperManagerPro.ViewModel
{
    public class MerchandiseViewModel : ItemsViewModel, IDataErrorInfo
    {
        Merchandise _model;

        public MerchandiseViewModel(Repository repository)
        {
            this._model = new Merchandise();
            this._repository = repository;
        }

        public MerchandiseViewModel(Merchandise model, Repository repository)
        {
            this._model = model;
            this._repository = repository;
            IsEdit = true;
        }

        public string ID
        {
            get { return _model.ID; }
            set
            {
                if (value == _model.ID)
                    return;
                _model.ID = value;
                base.RaisePropertyChanged("ID");
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
                base.RaisePropertyChanged("Name");
            }
        }

        public string Type
        {
            get { return _model.Type; }
            set
            {
                if (value == _model.Type)
                    return;
                _model.Type = value;
                base.RaisePropertyChanged("Type");
            }
        }

        public string Picture
        {
            get { return _model.Picture; }
            set
            {
                if (value == _model.Picture)
                    return;
                _model.Picture = value;
                base.RaisePropertyChanged("Picture");
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
                base.RaisePropertyChanged("Remark");
            }
        }

        public ReadOnlyCollection<string> ListType
        {
            get { return new ReadOnlyCollection<string>(new List<string> { "玻璃", "家居", "塑料", "陶瓷", "不锈钢", "小商品类" }); }
        }

        protected override bool CanSave
        {
            get
            {
                if (this.ValidateID() != null)
                    return false;
                if (this.ValidateName() != null)
                    return false;
                if (this.ValidateType() != null)
                    return false;
                if (this.ValidateRemark() != null)
                    return false;
                return true;
            }
        }

        protected override void ManipulationData()
        {
            this._repository.Add(_model);
        }

        string IDataErrorInfo.Error
        {
            get { return (_model as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                string error = null;
                switch (propertyName)
                {
                    case "ID":
                        error = this.ValidateID();
                        break;
                    case "Name":
                        error = this.ValidateName();
                        break;
                    case "Type":
                        error = this.ValidateType();
                        break;
                    case "Remark":
                        error = this.ValidateRemark();
                        break;
                }
                System.Windows.Input.CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }

        string ValidateID()
        {
            if (string.IsNullOrEmpty(this.ID))
                return "商品编号不能为空";
            if (this.ID.Length > 4)
                return "编号错误，格式为0000-9999之间的字符串";
            if (!base.IsEdit && this._repository.GetMerchandise(this.ID) != null)
                return "此商品编号已存在";
            return null;
        }

        string ValidateName()
        {
            if (string.IsNullOrEmpty(this.Name))
                return "商品名称不能为空";
            if (this.Name.Length > 10)
                return "名称太长，简写一下";
            return null;
        }

        string ValidateType()
        {
            if (string.IsNullOrEmpty(this.Type))
                return "商品类型不能为空";
            return null;
        }

        string ValidateRemark()
        {
            if (this.Remark != null && this.Remark != "" && this.Remark.Length > 40)
                return "备注信息太长了";
            return null;
        }
    }
}