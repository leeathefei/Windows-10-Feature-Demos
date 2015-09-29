using System;
using Windows.UI.Xaml.Controls;

namespace Windows10FeatureDemos.Helper
{
    public class MenuAttribute : Attribute
    {
        
        private int _order = 999;

        public int Order
        {
            get
            {
                return _order;
            }

            set
            {
                _order = value;
            }
        }

        public Symbol Symbol
        {
            get
            {
                return _symbol;
            }

            set
            {
                _symbol = value;
            }
        }

        private string _caption = "<caption>";

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
            }
        }

        private Symbol _symbol = Symbol.Help;
    }
}
