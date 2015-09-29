﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows10FeatureDemos.Helper;
using Windows10FeatureDemos.Views;

namespace Windows10FeatureDemos.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public SampleDefinition[] Samples
        {
            get
            {
                List<SampleDefinition> samples = new List<SampleDefinition>();

                var assembly = typeof(App).GetTypeInfo().Assembly;

                foreach (Type type in assembly.GetTypes())
                {
                    var cas = type.GetTypeInfo().GetCustomAttributes(typeof(MenuAttribute)).ToArray();
                    if (cas.Length > 0)
                    {
                        var ca = cas[0] as MenuAttribute;
                        SampleDefinition sd = new SampleDefinition();
                        sd.Caption = ca.Caption;
                        sd.Order = ca.Order;
                        sd.Symbol = ca.Symbol;
                        sd.SampleType = type;
                        samples.Add(sd);
                    }
                }

                return samples.ToArray();
            }
        }

        public Frame RootFrame { get; set; }
        public SampleDefinition SelectedSample { get; private set; }

        #region Page Header

        public string PageHeader
        {
            get
            {
                return _pageHeader;
            }

            set
            {
                _pageHeader = value;
                OnPropertyChanged();
            }
        }

        private string _pageHeader = "Windows 10 Feature Demos";

        #endregion

        public void ShowSample(SampleDefinition sample)
        {
            this.SelectedSample = sample;

            sampleHistory.Add(sample);
            this.PageHeader = sample.Caption;

            RootFrame.Navigate(typeof(SamplePage), sample);

            OnPropertyChanged("BackButtonVisibility");
        }

        private List<SampleDefinition> sampleHistory = new List<SampleDefinition>();

        public void GoBack()
        {
            if (RootFrame.CanGoBack)
            {
                RootFrame.GoBack();
            }

            OnPropertyChanged("BackButtonVisibility");

            if (sampleHistory.Count > 0)
            {
                sampleHistory.RemoveAt(sampleHistory.Count - 1);
            }

            if (sampleHistory.Count == 0)
            {
                this.PageHeader = "Start";
            }
            else
            {
                this.PageHeader = sampleHistory[sampleHistory.Count - 1].Caption;
            }

        }

        public Visibility BackButtonVisibility
        {
            get
            {
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    return Visibility.Visible;
                }

                if (DeviceFamilyHelper.IsMobile)
                {
                    return Visibility.Collapsed;
                }

                if (RootFrame != null && RootFrame.CanGoBack)
                {
                    return Visibility.Visible;
                }

                return Visibility.Collapsed;
            }
        }
    }
}
