using Newtone.Core.Media;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Newtone.Core.Processing
{
    public static class FileProcessing
    {
        #region Public Methods
        public static async Task<MediaSource[]> Scan(string directory)
        {
            return await Task.Run(() => {
                List<MediaSource> containers = new List<MediaSource>();

                string[] mp3Files = null;
                string[] m4aFiles = null;
                try
                {
                    mp3Files = Directory.GetFiles(directory, "*.mp3");
                    m4aFiles = Directory.GetFiles(directory, "*.m4a");
                }
                catch
                {
                    //If don't have access to directory, ignore
                }

                List<string> files = new List<string>();
                files.AddRange(mp3Files);
                files.AddRange(m4aFiles);

                files.ForEach(filepath =>
                {
                    MediaSource source = MediaProcessing.GetSource(filepath);

                    Debug.Write("Load " + filepath);
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
