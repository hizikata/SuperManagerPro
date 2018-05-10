using GalaSoft.MvvmLight.Command;
using System;

namespace SuperManagerPro.ViewModel
{
    public class SearchViewModel : WorkspaceViewModel
    {
        readonly CollectionViewModel _parent;
        string _searchCondition;
        string _searchValue;
        //在Template 定义SearchViewModel的DataTemplate，采用了
        //有参构造函数，为何可以运行？？
        public SearchViewModel(CollectionViewModel vm)
        {
            this._parent = vm;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Condition> ListCondition
        {
            get
            {
                System.Collections.Generic.List<Condition> conditions = new System.Collections.Generic.List<Condition>();

                if (this._parent is AllAssociatorViewModel)
                {
                    Condition first = new Condition();
                    first.Name = "会员编号";
                    first.FieldName = "ID";
                    conditions.Add(first);

                    Condition second = new Condition();
                    second.Name = "会员姓名";
                    second.FieldName = "Name";
                    conditions.Add(second);
                }
                else if (this._parent is AllSupplierViewModel)
                {
                    Condition first = new Condition();
                    first.Name = "供应商名称";
                    first.FieldName = "Name";
                    conditions.Add(first);
                }
                else if (this._parent is AllMerchandiseViewModel)
                {
                    Condition first = new Condition();
                    first.Name = "商品编号";
                    first.FieldName = "ID";
                    conditions.Add(first);

                    Condition second = new Condition();
                    second.Name = "商品名称";
                    second.FieldName = "Name";
                    conditions.Add(second);
                }

                return new System.Collections.ObjectModel.ReadOnlyCollection<Condition>(conditions);
            }
        }

        public string SearchCondition
        {
            get { return this._searchCondition; }
            set
            {
                if (value == this._searchCondition)
                    return;
                this._searchCondition = value;
                base.RaisePropertyChanged("SearchCondition");
            }
        }

        public string SearchValue
        {
            get { return this._searchValue; }
            set
            {
                if (value == this._searchValue)
                    return;
                this._searchValue = value;
                base.RaisePropertyChanged("SearchValue");
            }
        }

        #region CommandMembers

        public System.Collections.ObjectModel.ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                System.Collections.Generic.List<CommandViewModel> commands =
                    new System.Collections.Generic.List<CommandViewModel>
                {
                    new CommandViewModel(new RelayCommand<object>(p => this.OnRequestSearch()), "查找"),
                    new CommandViewModel(base.CloseCommand, "取消")
                };
                return new System.Collections.ObjectModel.ReadOnlyCollection<CommandViewModel>(commands);
            }
        }

        public event EventHandler RequestSearch;

        void OnRequestSearch()
        {
           
            this._parent._fieldName = this.SearchCondition;
            this._parent._searchValue = this.SearchValue;
            //EventHandler handler = this.RequestSearch;
            //if (handler != null)
            //    handler(this, EventArgs.Empty);
            RequestSearch?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }

    public class Condition
    {
        public string Name { get; set; }
        public string FieldName { get; set; }
    }
}