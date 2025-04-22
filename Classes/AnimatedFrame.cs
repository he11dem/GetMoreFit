using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GetMoreFit.Classes
{
    public class AnimatedFrame : Frame
    {
        private ContentPresenter _contentPresenter;
        private object _oldContent;

        public IPageTransition PageTransition { get; set; }

        public AnimatedFrame()
        {
            PageTransition = new WipeTransition();
            Navigated += OnNavigated;
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            if (_contentPresenter == null)
            {
                _contentPresenter = Template.FindName("PART_FrameCP", this) as ContentPresenter;
            }

            if (_contentPresenter != null)
            {
                var newContent = _contentPresenter.Content;
                PageTransition.AnimateTransition(_contentPresenter, _oldContent, newContent);
                _oldContent = newContent;
            }
        }
    }
}
