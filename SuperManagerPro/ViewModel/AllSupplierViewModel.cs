using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperManagerPro.Model;
using GalaSoft.MvvmLight.Ioc;

namespace SuperManagerPro.ViewModel
{
    public class AllSupplierViewModel:CollectionViewModel
    {
        #region Constructors
        //[PreferredConstructor]
        //public AllSupplierViewModel(Repository repository) : base(repository)
        //{
            
        //}
        public AllSupplierViewModel()
        {

        }

        #endregion
        #region Properties
        #endregion
        #region Override Methods
        protected override void CreatAll()
        {
            AllItems = new System.Collections.ObjectModel.ObservableCollection<ItemsViewModel>(Create(_repository.GetSupplier(null, null)));
        }
        protected override void OnModelAddedToRepository(object sender, ModelAddedEventArgs e)
        {
            var vm = new SupplierViewModel(e.NewModel as Supplier, _repository);
            AllItems.Add(vm);
        }

        protected override void Search()
        {
            new ChildWindow(new SearchViewModel(this), 300, 220).ShowDialog();
            AllItems.Clear();
            System.Collections.Generic.List<SupplierViewModel> results = this.Create(_repository.GetSupplier(_fieldName, _searchValue));
            for (int i = 0; i < results.Count; i++)
                AllItems.Add(results[i]);
            _fieldName = _searchValue = null;
        }
        #endregion Override Methods

        #region Methods
        List<SupplierViewModel> Create(System.Collections.Generic.List<Supplier> models)
        {
            return (from model in models select new SupplierViewModel(model, _repository)).ToList();
        }
        #endregion
    }
}
