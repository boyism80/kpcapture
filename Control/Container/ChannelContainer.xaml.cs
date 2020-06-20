﻿using KPCapture.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace KPCapture.Control.Container
{
    /// <summary>
    /// Interaction logic for ChannelContainer.xaml
    /// </summary>
    public partial class ChannelContainer : ItemsSourceControl
    {
        public static readonly DependencyProperty RemoveProperty = DependencyProperty.Register("Remove", typeof(ICommand), typeof(ChannelContainer));
        public ICommand Remove
        {
            get { return GetValue(RemoveProperty) as ICommand; }
            set { SetValue(RemoveProperty, value); }
        }

        public ChannelContainer()
        {
            InitializeComponent();
        }

        public override Panel GetContainer()
        {
            return this.Container;
        }

        public override FrameworkElement OnCreate(object context)
        {
            return new ChannelControl
            {
                DataContext = context,
                Remove = this.OnRemove
            };
        }

        private void OnRemove(Channel.ViewModel obj)
        {
            this.Remove?.Execute(obj);
        }
    }
}
