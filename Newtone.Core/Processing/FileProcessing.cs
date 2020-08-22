using Newtone.Core.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Newtone.Core.Processing
{
    public class FileProcessing
    {
        #region Public Methods
        public static async Task<MediaSource[]> Scan(string directory, List<string> listed = null)
        {
            if (listed == null)
                listed = new List<string>();

            return await Task.Run(() => {
                List<MediaSource> containers = new List<MediaSource>();

                string[] mp3Files = Directory.GetFiles(directory, "*.mp3");
                string[] m4aFiles = Directory.GetFiles(directory, "*.m4a");
                List<string> files = new List<string>();
                files.AddRange(mp3Files);
                files.AddRange(m4aFiles);

                files.ForEach(filepath =>
                {
                    MediaSource source = MediaProcessing.GetSource(filepath);

                    if (source != null && !containers.Contains(source))
                    {
                        containers.Add(source);
                    }
                });

                return containers.ToArray();
            });
        }
        #endregion
    }
}
