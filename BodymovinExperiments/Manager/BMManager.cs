using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace BodymovinExperiments.Manager
{
    public class BMManager
    {
        private static string template;

        private static async Task CheckTemplate()
        {
            if (template == null)
            {
                var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Templates/Template.html"));
                template = await FileIO.ReadTextAsync(file);
            }
        }

        public static async Task<string> ReadData(string jsonuri)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(jsonuri));
            return await FileIO.ReadTextAsync(file);
        }

        public static async Task<string> GetTemplate()
        {
            await CheckTemplate();

            return template;
        }

    }
}
