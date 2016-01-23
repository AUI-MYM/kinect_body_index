using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MYMGames.Hopscotch.Model
{
    public class QuestionModel
    {
        public string image_path { get; set; }
        public string text { get; set; }
        private ImageSource image = null;
        public ImageSource Image
        {
            get
            {
                Uri image_uri = new Uri("../Images/" + image_path, UriKind.Relative);
                if (image == null && image_uri != null)
                {
                    image = new BitmapImage(image_uri);
                }

                return image;
            }

            private set { }
        }
        public bool answer { get; set; }

    }
}
