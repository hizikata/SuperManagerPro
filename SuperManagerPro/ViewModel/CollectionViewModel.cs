using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SuperManagerPro.Model;

namespace SuperManagerPro.ViewModel
{
    public class CollectionViewModel:WorkspaceViewModel
    {
        #region Fields
        //查询条件
        public string _fieldName;
        //搜索信息
        public string _searchValue;
        #endregion Fields
        #region Constructor
        public CollectionViewModel()
        {
            this.Load();
        }
        #endregion Constructor
        #region Initialize Method
        public void Load()
        {
            Repository.ModelAdded += OnModelAddedToRepository;
            Repository.ModelDeleted += OnModelDeletedToRepository;
            this.CreatAll();
        }
        #endregion
        #region Properties
        public ObservableCollection<CommandViewModel> Commands
        {
            get
            {
                List<CommandViewModel> commands = new List<CommandViewModel>()
                {
                    new CommandViewModel(new RelayCommand<object>(p=>Add()),"新增"),
                    new CommandViewModel(new RelayCommand<object>(p=>Delete()),"删除"),
                    new CommandViewModel(new RelayCommand<object>(p=>Edit()),"修改"),
                    new CommandViewModel(new RelayCommand<object>(p=>Search()),"查询"),
                    new CommandViewModel(CloseCommand,"关闭")
                };
                return new ObservableCollection<CommandViewModel>(commands);
            }
        }
        public ObservableCollection<ItemsViewModel> AllItems { get; protected set; }
        public ItemsViewModel SelectedItem
        {
            get
            {
                if (AllItems != null && AllItems.Count > 0)
                {
                    return AllItems.FirstOrDefault<ItemsViewModel>(item => item.IsSelected);
                }
                else
                {
                    return null;    
                }
            }
        }
        public bool IsNotNull

        {
            get
            {
                if (SelectedItem == null)
                    return false;
                else
                {
                    return true;
                }
            }
        }
        #endregion
        #region Event Methods
        protected virtual void OnModelAddedToRepository(object sender,ModelAddedEventArgs e)
        {

        }
        protected virtual void OnModelDeletedToRepository(object sender,ModelDeletedEventArgs e)
        {
            AllItems.Remove(AllItems.FirstOrDefault<ItemsViewModel>(item => item.IsSelected));
        }
        #endregion
        #region Virtual Methods
        protected virtual void CreatAll(){ }
        protected virtual void Add() { }
        protected virtual void Delete() { }
        protected virtual void Edit() { }
        protected virtual void Search() { }
        #endregion Virtual Methods
    }
}
