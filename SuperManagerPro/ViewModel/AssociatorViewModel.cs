using SuperManagerPro.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SuperManagerPro.ViewModel
{
    public class AssociatorViewModel : ItemsViewModel, IDataErrorInfo
    {
        #region Fields

        Associator _model;
        DateTime? _chooseBirthday;
        DateTime? _chooseRegistration;

        #endregion

        #region Constructors

        public AssociatorViewModel(Repository repository)
        {
            this._repository = repository;
            this._model = new Associator();
        }

        public AssociatorViewModel(Associator associator, Repository repository)
        {
            this._repository = repository;
            this._model = associator;
            IsEdit = true;
            this.ChooseBirthday = associator.Birthday;
            this.ChooseRegistration = associator.Registration;
        }

        #endregion

        #region AssociatorProperties

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

        public string EmployeeID
        {
            get { return this._model.EmployeeID; }
            set
            {
                if (value == this._model.EmployeeID)
                    return;
                this._model.EmployeeID = value;
                base.RaisePropertyChanged("EmployeeID");
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

        public string Gender
        {
            get { return _model.Gender; }
            set
            {
                if (value == _model.Gender)
                    return;
                _model.Gender = value;
                base.RaisePropertyChanged("Gender");
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

        public DateTime Registration
        {
            get
            {
                return _model.Registration;
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

        public int Integral { get { return _model.Integral; } }

        public DateTime Birthday { get { return _model.Birthday; } }

        #endregion

        #region PresentationProperty

        public DateTime? ChooseBirthday
        {
            get { return _chooseBirthday; }
            set
            {
                if (value == _chooseBirthday)
                    return;
                _chooseBirthday = value;
                base.RaisePropertyChanged("ChooseBirthday");
            }
        }

        public DateTime? ChooseRegistration
        {
            get { return this._chooseRegistration; }
            set
            {
                if (value == this._chooseRegistration)
                    return;
                this._chooseRegistration = value;
                base.RaisePropertyChanged("ChooseRegistration");
            }
        }

        public ReadOnlyCollection<Employee> ListEmployee
        {
            get { return new ReadOnlyCollection<Employee>(this._repository.GetEmployee()); }
        }

        public ReadOnlyCollection<string> ListGender
        {
            get { return new ReadOnlyCollection<string>(new List<string> { "男", "女" }); }
        }

        public string EmployeeName
        {
            get
            {
                foreach (Employee employee in ListEmployee)
                    if (employee.ID == this.EmployeeID)
                        return employee.Name;
                return "Get Employee Information Error";
            }
        }

        #endregion

        #region OverrideMembers

        protected override bool CanSave
        {
            get
            {
                if (this.ValidateID() != null)
                    return false;
                if (this.ValidateEmployee() != null)
                    return false;
                if (this.ValidateName() != null)
                    return false;
                if (this.ValidateGender() != null)
                    return false;
                if (this.ValidateAddress() != null)
                    return false;
                if (this.ValidatePhone() != null)
                    return false;
                if (this.ValidateAlternate() != null)
                    return false;
                if (this.ValidateBirthday() != null)
                    return false;
                if (this.ValidateRegistration() != null)
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
            this._model.Birthday = (DateTime)this.ChooseBirthday;
            this._model.Registration = (DateTime)this.ChooseRegistration;
            if (this._repository.GetAssociator(this.ID) != null)
                this._repository.Update(this._model);
            else
                _repository.Add(this._model);
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
                    case "ID":
                        error = this.ValidateID();
                        break;
                    case "EmployeeID":
                        error = this.ValidateEmployee();
                        break;
                    case "Name":
                        error = this.ValidateName();
                        break;
                    case "Gender":
                        error = this.ValidateGender();
                        break;
                    case "Address":
                        error = this.ValidateAddress();
                        break;
                    case "Phone":
                        error = this.ValidatePhone();
                        break;
                    case "Alternate":
                        error = this.ValidateAlternate();
                        break;
                    case "ChooseBirthday":
                        error = this.ValidateBirthday();
                        break;
                    case "ChooseRegistration":
                        error = this.ValidateRegistration();
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
                return "会员编号不能为空";
            if (this.ID.Length != 6)
                return "编号为000000-999999";
            if (!IsEdit && this._repository.GetAssociator(this.ID) != null)
                return "此会员编号已存在";
            return null;
        }

        string ValidateEmployee()
        {
            if (string.IsNullOrEmpty(this.EmployeeID))
                return "办理员工不能为空";
            return null;
        }

        string ValidateName()
        {
            if (string.IsNullOrEmpty(this.Name))
                return "会员姓名不能为空";
            if (this.Name.Length > 4)
                return "会员姓名最多4个字";
            return null;
        }

        string ValidateGender()
        {
            if (string.IsNullOrEmpty(this.Gender))
                return "会员性别不能为空";
            return null;
        }

        string ValidateAddress()
        {
            if (this.Address != null && this.Address != "" && this.Address.Length > 50)
                return "地址不能多于50个字";
            return null;
        }

        string ValidatePhone()
        {
            if (string.IsNullOrEmpty(this.Phone))
                return "手机号码不能为空";
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

        string ValidateBirthday()
        {
            if (this.ChooseBirthday == null)
                return "会员的生日不能为空";
            if ((DateTime.Now - (DateTime)this.ChooseBirthday).Days < 365)
                return "未满周岁不能成为会员";
            return null;
        }

        string ValidateRegistration()
        {
            if (this.ChooseRegistration == null)
                return "必须选择注册日期";
            if (DateTime.Now < (DateTime)this.ChooseRegistration)
                return "注册日期错误";
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
            if (this.Remark != null && this.Remark != "" && this.Remark.Length > 50)
                return "备注信息太长了";
            return null;
        }

        #endregion
    }
}