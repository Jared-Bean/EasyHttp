// Previous contents remain the same until line 70
            Accept = String.Join(";", HttpContentTypes.TextHtml, HttpContentTypes.ApplicationXml,
                                 HttpContentTypes.ApplicationJson);
            _encoder = encoder;

            Timeout = Constants.DEFAULT_HTTP_TIMEOUT_MS;

            AllowAutoRedirect = true;
// Rest of the contents remain the same until file read operation

        void SetupPutFilename()
        {
            using (var fileStream = new FileStream(PutFilename, FileMode.Open))
            {
                httpWebRequest.ContentLength = fileStream.Length;

                var requestStream = httpWebRequest.GetRequestStream();

                var buffer = new byte[Constants.PUT_FILE_BUFFER_SIZE];

                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                }
                requestStream.Close();
            }
        }
// Rest of the file remains the same