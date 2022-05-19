using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Core;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace FitnessApp.Views
{
    public partial class VideoPopUp : Popup
    {
        public string VideoUrl { get; set; }
        public VideoPopUp(string videourl)
        {
            InitializeComponent();
            VideoUrl = videourl;

            myLabel.Text = videourl;
            Uri uri = new Uri(videourl);
            GetVideoContent();
        }

        private async void GetVideoContent()
        {
            YoutubeClient youtube = new YoutubeClient();
            // You can specify video ID or URL
            YoutubeExplode.Videos.Video video = await youtube.Videos.GetAsync("https://www.youtube.com/watch?v=6_84n7NVnOI");
            string title = video.Title; // "Downloaded Video Title"
                                        //string author = video.Author; // "Downloaded Video Author"
            TimeSpan duration = (TimeSpan)video.Duration; // "Downloaded Video Duration Count"
                                                          //Now it's time to get stream :
            StreamManifest streamManifest = await youtube.Videos.Streams.GetManifestAsync("https://www.youtube.com/watch?v=6_84n7NVnOI");
            IVideoStreamInfo streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
            if (streamInfo != null)
            {
                // Get the actual stream
                System.IO.Stream stream = await youtube.Videos.Streams.GetAsync(streamInfo);
                videoElement.Source = streamInfo.Url;
            }
        }
    }
}