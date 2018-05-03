using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperManagerPro.Model
{
    public class Repository
    {
        #region Events
        public event EventHandler<ModelAddedEventArgs> ModelAdded;
        public event EventHandler<ModelDeletedEventArgs> ModelDeleted;
        #endregion
        #region Properties

        #endregion Properties
        #region PublicMethods
        #endregion
        #region PrivateMethods

        #endregion
    }
    public class ModelAddedEventArgs : EventArgs
    {
        public ModelAddedEventArgs(ModelBase model)
        {
            this.NewModel = model;
        }
        public ModelBase NewModel
        {
            get;
            private set;
        }
    }
    public class ModelDeletedEventArgs : EventArgs
    {
        public ModelDeletedEventArgs(ModelBase model)
        {
            this.NewModel = model;
        }
        public ModelBase NewModel
        {
            get;
            private set;
        }
    }
}
