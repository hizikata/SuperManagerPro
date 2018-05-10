using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using SuperManagerPro.Model;

namespace SuperManagerPro.ViewModel
{
    public class WorkspaceViewModel : ViewModelBase,IDisposable
    {
        #region Events
        /// <summary>
        /// 请求关闭事件
        /// </summary>
        public event EventHandler RequestClose;
        #endregion
        #region Fields
        RelayCommand<object> _closeCommand;
        protected Repository _repository;
        #endregion

        #region Properties
        public virtual Repository Repository
        {
            get
            {
                return _repository;
            }
            set
            {
                _repository = value;
            }

        }
        /// <summary>
        /// 请求关闭事件
        /// </summary>
        /// <remarks>请求关闭事件</remarks>
        public RelayCommand<object> CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                    _closeCommand = new RelayCommand<object>(p=> this.OnRequestClose());
                return _closeCommand;
            }
        }
        #endregion
        #region Constructors
        public WorkspaceViewModel()
        {
            Repository = new Repository();
        }
        #endregion
        #region CommandMethods
        /// <summary>
        /// CloseCommand的执行方法
        /// </summary>
        /// <remarks>CloseCommand的执行方法</remarks>
        void OnRequestClose()
        {
            if (RequestClose != null)
                RequestClose(this, EventArgs.Empty);
        }


        #endregion CommandMethods
        #region IDispase Memebers
        public void Dispose()
        {
            this.OnDispose();
        }
        protected virtual void OnDispose()
        {
            
        }
        #endregion  
    }
}
