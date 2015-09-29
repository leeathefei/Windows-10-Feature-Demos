using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI.Core;
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

                // Sort

                var samplesOrdered = from sam in samples
                                     orderby sam.Order
                                     select sam;

                return samplesOrdered.ToArray();
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
                Visibility result;
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    result = Visibility.Visible;
                }
                else if (DeviceFamilyHelper.IsMobile)
                {
                    result = Visibility.Collapsed;
                }
                else if (RootFrame != null && RootFrame.CanGoBack)
                {
                    result = Visibility.Visible;
                }
                else
                {
                    result = Visibility.Collapsed;
                }


                AppViewBackButtonVisibility systemBackButton = AppViewBackButtonVisibility.Collapsed;

                if (result == Visibility.Visible)
                {
                    systemBackButton = AppViewBackButtonVisibility.Visible;
                }

                SystemNavigationManager
                    .GetForCurrentView()
                    .AppViewBackButtonVisibility = systemBackButton;

                return result;
            }
        }

        public List<Person> Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = new List<Person>();
                    for (int i=0; i<100; i++)
                    {
                        Person p = new Person();
                        p.Name = "Name " + i;
                        p.FirstName = "First " + i;
                        _persons.Add(p);
                    }
                }
                return _persons;
            }

            set
            {
                _persons = value;
            }
        }

        private List<Person> _persons;

        public string VeryLongText
        {
            get
            {
                return "Every breaking wave on the shore \n"
                    + "Tells the next one there'll be one more \n"
                    + "And every gambler knows that to lose \n"
                    + "Is what you're really there for \n"
                    + "Summer I was fearless\n"
                    + "Now I speak into an answer phone\n"
                    + "Like every silent leave on the breeze\n"
                    + "Winter wouldn't leave it alone \n"
                    + "Alone\n"
                    + "\n"
                    + "If you go\n"
                    + "If you go your way and I go mine\n"
                    + "Are we so\n"
                    + "Are we so helpless against the tide\n"
                    + "Baby, every dog on the street\n"
                    + "Knows that we’re in love with defeat\n"
                    + "Are we ready to be swept off our feet\n"
                    + "And stop chasing every breaking wave\n"
                    + "\n"
                    + "Every sailor knows that the sea\n"
                    + "Is a friend made enemy\n"
                    + "And every shipwrecked soul knows what it is\n"
                    + "To live without intimacy\n"
                    + "\n"
                    + "I thought I heard the captain’s voice\n"
                    + "It's hard to listen while you preach \n"
                    + "Like every broken wave on the shore\n"
                    + "This was as far as I can reach\n"
                    + "\n"
                    + "If you go\n"
                    + "If you go your way and I go mine\n"
                    + "Are we so\n"
                    + "Are we so helpless against the tide\n"
                    + "Baby, every dog on the street\n"
                    + "Knows that we’re in love with defeat\n"
                    + "Are we ready to be swept off our feet\n"
                    + "And stop chasing every breaking wave\n"
                    + "\n"
                    + "The sea knows where are the rocks\n"
                    + "And drowning is no sin\n"
                    + "You know where my heart is\n"
                    + "The same place that yours has been\n"
                    + "And we know the fear to win\n"
                    + "And so we end before we begin\n"
                    + "Before we begin\n"
                    + "\n"
                    + "If you go\n"
                    + "If you go your way and I go mine\n"
                    + "Are we so\n"
                    + "Are we so helpless against the tide\n"
                    + "Baby, every dog on the street\n"
                    + "Knows that we’re in love with defeat\n"
                    + "Are we ready to be swept off our feet\n"
                    + "And stop chasing every breaking wave";
            }
        }
    }

    public class Person
    {
        public string FirstName { get; internal set; }
        public string Name { get; internal set; }
    }
}
