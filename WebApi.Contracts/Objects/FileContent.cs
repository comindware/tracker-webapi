using System;
using System.IO;
using Newtonsoft.Json;

namespace Comindware.Platform.WebApi.Contracts
{
    public class FileContent
    {
        public FileContent():this(new byte[0],"None")
        {
        }

        [JsonIgnore]
        public byte[] Content { get; private set; }

        public string ContentBase64
        {
            get
            {
                if (Content == null)
                {
                    return null;
                }
                return Convert.ToBase64String(Content);
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    Content = Convert.FromBase64String(value);
                }
            }
        }

        public String FileName { get;  set; }

        public MemoryStream GetStream()
        {
            return new MemoryStream(Content);
        }

        public FileContent(Stream stream, String fileName)
        {
            var ms = new MemoryStream();
            stream.CopyTo(ms);
            this.Content = ms.ToArray();
            this.FileName = fileName;
        }


        public FileContent(byte[] data, String fileName)
        {
            this.Content = data;
            this.FileName = fileName;
        }
    }
}
