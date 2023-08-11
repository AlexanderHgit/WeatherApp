
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace WeatherApp.Services
{
    public static class ImageLoader
    {
        public static async Task<ImageSource> LoadImageFromUriAsync(string imageUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // Download the image data from the URL
                    var imageBytes = await httpClient.GetByteArrayAsync(imageUrl);

                    // Convert the image data to a stream
                    var imageStream = new MemoryStream(imageBytes);

                    // Create the ImageSource from the stream
                    var imageSource = ImageSource.FromStream(() => imageStream);

                    return imageSource;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                Console.WriteLine($"Error loading image: {ex.Message}");
                return null;
            }
        }
    }
}
