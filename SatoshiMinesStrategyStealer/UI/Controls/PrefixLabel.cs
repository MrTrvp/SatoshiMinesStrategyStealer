using System.Windows.Forms;

namespace SatoshiMinesStrategyStealer.UI.Controls
{
    public class PrefixLabel : Label
    {
        private string _prefix;
        public string Prefix
        {
            get { return _prefix; }
            set
            {
                _prefix = value;

                Text = FullText;
                Invalidate();
            }
        }

        private string _realText;
        public string RealText
        {
            get { return _realText; }
            set
            {
                _realText = value;

                Text = FullText;
                Invalidate();
            }
        }

        public string FullText
        {
            get { return string.Concat(Prefix, _realText); }
        }
    }
}