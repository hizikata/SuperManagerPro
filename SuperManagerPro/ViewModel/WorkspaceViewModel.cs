using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace SuperManagerPro.ViewModel
{
    public class WorkspaceViewModel : ViewModelBase
    {
        #region Events
        /// <summary>
        /// 请求关闭事件
        /// </summary>
        public event EventHandler RequestClose;
        #endregion
        #region Fields
        RelayCommand<object> _closeCommand;

        #endregion
        #region Properties
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
    }
}
