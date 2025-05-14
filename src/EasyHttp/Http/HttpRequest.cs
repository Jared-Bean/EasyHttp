// Previous contents remain the same until line 70
            Accept = String.Join(";", HttpContentTypes.TextHtml, HttpContentTypes.ApplicationXml,
                                 HttpContentTypes.ApplicationJson);
            _encoder = encoder;

            Timeout = EasyHttpConstants.DefaultRequestTimeoutMs; // Default .NET HttpWebRequest timeout

            AllowAutoRedirect = true;
// Rest of the contents remain the same until file read operation

        void SetupPutFilename()
        {
            using (var fileStream = new FileStream(PutFilename, FileMode.Open))
            {
                httpWebRequest.ContentLength = fileStream.Length;

                var requestStream = httpWebRequest.GetRequestStream();

                var buffer = new byte[EasyHttpConstants.PutFileBufferSize];

                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    requestStream.Write(buffer, 0, bytesRead);
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                }
                requestStream.Close();
            }
        }



        void SetupMultiPartBody()
        {
            var multiPartStreamer = new MultiPartStreamer(MultiPartFormData, MultiPartFileData);

            httpWebRequest.ContentType = multiPartStreamer.GetContentType();
            var contentLength = multiPartStreamer.GetContentLength();

            if (contentLength > 0)
            {
                httpWebRequest.ContentLength = contentLength;
            }

            multiPartStreamer.StreamMultiPart(httpWebRequest.GetRequestStream());

        }


        public virtual IHttpWebRequest PrepareRequest()
        {
            httpWebRequest = new HttpWebRequestWrapper((HttpWebRequest) WebRequest.Create(Uri));
            httpWebRequest.AllowAutoRedirect = AllowAutoRedirect;
            SetupHeader();

            SetupBody();

            return httpWebRequest;
        }

        void SetupClientCertificates()
        {
            if (ClientCertificates == null || ClientCertificates.Count == 0)
                return;

            httpWebRequest.ClientCertificates.AddRange(ClientCertificates);
        }

        void SetupAuthentication()
        {
            SetupClientCertificates();

            if (_forceBasicAuth)
            {
                string authInfo = _username + ":" + _password;
                authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
                httpWebRequest.Headers["Authorization"] = "Basic " + authInfo;
            }
            else
            {
                var networkCredential = new NetworkCredential(_username, _password);
                httpWebRequest.Credentials = networkCredential;
            }
        }


        public virtual void SetCacheControlToNoCache()
        {
            _cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
        }

        public virtual void SetCacheControlWithMaxAge(TimeSpan maxAge)
        {
            _cachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAge, maxAge);
        }

        public virtual void SetCacheControlWithMaxAgeAndMaxStale(TimeSpan maxAge, TimeSpan maxStale)
        {
            _cachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAgeAndMaxStale, maxAge, maxStale);
        }

        public virtual void SetCacheControlWithMaxAgeAndMinFresh(TimeSpan maxAge, TimeSpan minFresh)
        {
            _cachePolicy = new HttpRequestCachePolicy(HttpCacheAgeControl.MaxAgeAndMinFresh, maxAge, minFresh);
        }
    }
}
