// Previous contents remain the same until the constructor
        public MultiPartStreamer(IDictionary<string, object> multipartFormData, IList<FileData> multipartFileData)
        {
            _boundaryCode = DateTime.Now.Ticks.GetHashCode() + Constants.MULTIPART_BOUNDARY_SUFFIX;
            _boundary = string.Format("\r\n{0}{1}", Constants.MULTIPART_BOUNDARY_PREFIX, _boundaryCode);

            _multipartFormData = multipartFormData;
            _multipartFileData = multipartFileData;
        }

        // ... other methods remain the same until StreamFileContents

        static void StreamFileContents(Stream file, FileData fileData, Stream requestStream)
        {
            var buffer = new byte[Constants.MULTIPART_FILE_BUFFER_SIZE];

            int count;

            while ((count = file.Read(buffer, 0, buffer.Length)) > 0)
            {
                if (fileData.ContentTransferEncoding == HttpContentTransferEncoding.Base64)
                {
                    string str = Convert.ToBase64String(buffer, 0, count);

                    requestStream.WriteString(str);
                }
                else if (fileData.ContentTransferEncoding == HttpContentTransferEncoding.Binary)
                {
                    requestStream.Write(buffer, 0, count);
                }
            }
        }

        public string GetContentType()
        {
            return string.Format("multipart/form-data; boundary={0}{1}", Constants.MULTIPART_BOUNDARY_PREFIX, _boundaryCode);
        }
// Rest of the file remains the same