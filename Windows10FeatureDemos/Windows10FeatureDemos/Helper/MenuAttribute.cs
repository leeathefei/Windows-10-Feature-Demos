using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Windows10FeatureDemos.Helper
{
    public class MenuAttribute : Attribute
    {
        private string _caption = "<caption>";

        public string Order { get; set; }

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
