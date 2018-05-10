using SuperManagerPro.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SuperManagerPro.ViewModel
{
    public class EmployeeViewModel : ItemsViewModel, IDataErrorInfo
    {
        #region Fields

        Employee _model;

        #endregion

        #region Constructors

        public EmployeeViewModel(Repository repository)
        {
            this._model = new Employee();
            this._repository = repository;
        }

        public EmployeeViewModel(Employee model, Repository repository)
        {
            this._model = model;
            this._repository = repository;
            IsEdit = true;
        }

        #endregion

        #region EmployeeProperties

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

        public string Phone
        {
            get { return _model.Phone; }
            set
            {
                if (value == _model.Phone)
                    return;
                _model.Phone = value;
                base.RaisePropertyChanged("Phone");
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
                base.RaisePropertyChanged("Alternate");
            }
        }

        public string Education
        {
            get { return _model.Education; }
            set
            {
                if (value == _model.Education)
                    return;
                _model.Education = value;
                base.RaisePropertyChanged("Education");
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
                base.RaisePropertyChanged("Address");
            }
        }

        public string Email
        {
            get { return _model.Email; }
            set
            {
                if (value == _model.Email)
                    return;
                _model.Email = value;
                base.RaisePropertyChanged("Email");
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

        #endregion

        #region PresentationProperty

        public ReadOnlyCollection<string> EducationOption
        {
            get { return new ReadOnlyCollection<string>(new List<string> { "专科", "本科", "硕士" }); }
        }

        #endregion

        #region OverrideMembers

        protected override bool CanSave
        {
            get
            {
                if (this.ValidateID() != null)
                    return false;
                if (this.ValidateName() != null)
                    return false;
                if (this.ValidatePhone() != null)
                    return false;
                if (this.ValidateAlternate() != null)
                    return false;
                if (this.ValidateAddress() != null)
                    return false;
                if (this.ValidateEmail() != null)
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

        #endregion

        #region IDataErrorInfoMembers

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
                    case "Phone":
                        error = this.ValidatePhone();
                        break;
                    case "Alternate":
                        error = this.ValidateAlternate();
                        break;
                    case "Address":
                        error = this.ValidateAddress();
                        break;
                    case "Email":
                        error = this.ValidateEmail();
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
                return "身份证编号不能为空";
            if (!(this.ID.Length == 15 || this.ID.Length == 18))
                return "身份证编号位数错误";
            if (!base.IsEdit && this._repository.GetEmployee(this.ID) != null)
                return "身份证编号重复";
            return null;
        }

        string ValidateName()
        {
            if (string.IsNullOrEmpty(this.Name))
                return "员工的姓名不能为空";
            if (this.Name.Length > 5)
                return "这名字也太长了，改改先";
            return null;
        }

        string ValidatePhone()
        {
            if (string.IsNullOrEmpty(this.Phone))
                return "员工手机号码不能为空";
            if (this.Phone.Length != 11)
                return "手机号码位数错误";
            return null;
        }

        string ValidateAlternate()
        {
            if (this.Alternate != null && this.Alternate != "" && this.Alternate.Length != 11)
                return "备用电话位数错误";
            return null;
        }

        string ValidateAddress()
        {
            if (this.Address != null && this.Address != "" && this.Address.Length > 25)
                return "不支持过长的地址";
            return null;
        }

        string ValidateEmail()
        {
            if (!string.IsNullOrEmpty(this.Email))
                if (!IsEmail(this.Email))
                    return "电子邮件地址格式不正确";
            return null;
        }

        string ValidateRemark()
        {
            if (this.Remark != null && this.Remark != "" && this.Remark.Length > 25)
                return "备注信息太长了";
            return null;
        }

        #endregion
    }
}