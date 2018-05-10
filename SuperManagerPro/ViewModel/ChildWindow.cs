using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace SuperManagerPro.ViewModel
{
    public class ChildWindow : Window
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="workspaceViewModel">工作区视图模型</param>
        /// <param name="width">窗体宽度</param>
        /// <param name="height">窗体高度</param>
        public ChildWindow(WorkspaceViewModel workspaceViewModel, double width, double height)
        {
            InitializationWindow();
            SetWindowSize(width, height);
            //指定窗体内容
            Content = workspaceViewModel;
            AddCloseEvent(workspaceViewModel);
            if (workspaceViewModel is DeleteDialogViewModel)
                AddDeleteEvent(workspaceViewModel);
            if (workspaceViewModel is ItemsViewModel)
                AddSaveEvent(workspaceViewModel);
            if (workspaceViewModel is SearchViewModel)
                AddSearchEvent(workspaceViewModel);
        }

        /// <summary>
        /// 初始化窗体
        /// </summary>
        void InitializationWindow()
        {
            WindowStyle = WindowStyle.None;
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0FFF"));
            AllowsTransparency = true;
            ShowInTaskbar = false;
            Owner = Application.Current.MainWindow;
        }

        /// <summary>
        /// 设置窗体大小
        /// </summary>
        /// <param name="width">窗体宽度</param>
        /// <param name="height">窗体高度</param>
        void SetWindowSize(double width, double height)
        {
            if (width == 0d && height == 0d)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                Width = width;
                Height = height;
                Top = (SystemParameters.WorkArea.Height - Height) / 2d;
                Left = (SystemParameters.WorkArea.Width - Width) / 2d;
            }
        }

        /// <summary>
        /// 添加关闭事件
        /// </summary>
        /// <param name="vm">工作区视图模型</param>
        void AddCloseEvent(WorkspaceViewModel vm)
        {
            EventHandler close = null;
            close = delegate
            {
                vm.RequestClose -= close;
                vm.Dispose();
                this.Close();
            };
            vm.RequestClose += close;
        }

        /// <summary>
        /// 添加保存事件
        /// </summary>
        /// <param name="vm">工作区视图模型</param>
        void AddSaveEvent(WorkspaceViewModel vm)
        {
            EventHandler save = null;
            save = delegate
            {
                ((ItemsViewModel)vm).RequestSave -= save;
                vm.Dispose();
                this.Close();
            };
            ((ItemsViewModel)vm).RequestSave += save;
        }

        /// <summary>
        /// 添加删除事件
        /// </summary>
        /// <param name="vm">工作区视图模型</param>
        void AddDeleteEvent(WorkspaceViewModel vm)
        {
            EventHandler delete = null;
            delete = delegate
            {
                ((DeleteDialogViewModel)vm).RequestDelete -= delete;
                vm.Dispose();
                this.Close();
            };
            ((DeleteDialogViewModel)vm).RequestDelete += delete;
        }

        /// <summary>
        /// 添加查询事件
        /// </summary>
        /// <param name="vm">工作区视图模型</param>
        void AddSearchEvent(WorkspaceViewModel vm)
        {
            EventHandler search = null;
            search = (sender,e)=>
            {
                ((SearchViewModel)vm).RequestSearch -= search;
                vm.Dispose();
                this.Close();
            };
            ((SearchViewModel)vm).RequestSearch += search;
        }
    }
}
