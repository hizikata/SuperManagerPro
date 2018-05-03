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
        protected Repository _repository;
        string _fieldName;
        string _searchValue;
        #endregion Fields
        #region Constructor
        public CollectionViewModel(Repository repository)
        {
            this._repository = repository;
            this._repository.ModelAdded += OnModelAddedToRepository;
            this._repository.ModelDeleted += OnModelDeletedToRepository;
            this.CreatAll();
        }
        #endregion Constructor
        #region Properties
        public int MyProperty { get; set; }
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
        public ObservableCollection<ItemsViewModel> AllItems { get; private set; }
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
        void OnModelAddedToRepository(object sender,ModelAddedEventArgs e)
        {

        }
        void OnModelDeletedToRepository(object sender,ModelDeletedEventArgs e)
        {
            AllItems.Remove(AllItems.FirstOrDefault<ItemsViewModel>(item => item.IsSelected));
        }
        #endregion
        #region Virtual Methods
        public virtual void CreatAll(){ }
        public virtual void Add() { }
        public virtual void Delete() { }
        public virtual void Edit() { }
        public virtual void Search() { }
        #endregion Virtual Methods
    }
}
