using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SuperManagerPro.ViewModel
{
    public class CommandViewModel : ViewModelBase
    {
        #region Properties
        public string DisplayName { get; private set; }
        public RelayCommand<object> Command { get; private set; }
        public ImageSource Image { get; private set; }
        public string Remark { get; private set; }
        #endregion

        #region Constructors
        public CommandViewModel(RelayCommand<object> command, string displayName, string imagePath, string remark)
        {
            this.Command = command;
            this.DisplayName = displayName;
            this.Image = new BitmapImage(
                new Uri("pack://application,,,/SuperManagerPro;component/Resources/" + imagePath, UriKind.Absolute));
            this.Remark = remark;          
        }
        public CommandViewModel(RelayCommand<object> command,string displayName):this(command,displayName,null,null)
        {

        }
        public CommandViewModel(RelayCommand<object> command, string displayName, string ImagePath) : this(command, displayName, ImagePath, null)
        {

        }

        #endregion Constructors
    }
}
