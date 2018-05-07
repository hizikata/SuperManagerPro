using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperManagerPro.Model;

namespace SuperManagerPro.ViewModel
{
    public class AllSupplierViewModel:CollectionViewModel
    {
        #region Constructors
        public AllSupplierViewModel(Repository repository) : base(repository)
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
        #endregion Override Methods

        #region Methods
        List<SupplierViewModel> Create(System.Collections.Generic.List<Supplier> models)
        {
            return (from model in models select new SupplierViewModel(model, _repository)).ToList();
        }
        #endregion
    }
}
