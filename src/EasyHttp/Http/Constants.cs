namespace EasyHttp.Infrastructure
{
    /// <summary>
    /// Contains constant values used throughout the EasyHttp library
    /// </summary>
    public static class EasyHttpConstants
    {
        // Buffer sizes for file streaming operations
        /// <summary>
        /// Default buffer size for file streaming operations (8KB)
        /// </summary>
        public const int DefaultStreamBufferSize = 8192;
        
        /// <summary>
        /// Buffer size used for PUT file operations (80KB)
        /// </summary>
        public const int PutFileBufferSize = 81982;
        
        // Timeout configurations
        /// <summary>
        /// Default HTTP request timeout in milliseconds (100 seconds)
        /// Based on .NET HttpWebRequest default timeout
        /// See: http://msdn.microsoft.com/en-us/library/system.net.httpwebrequest.timeout.aspx
        /// </summary>
        public const int DefaultRequestTimeoutMs = 100000;
        
        // Multipart form data constants
        /// <summary>
        /// Magic number appended to boundary codes for multipart form data
        /// </summary>
        public const string BoundaryCodeSuffix = "548130";
        
        /// <summary>
        /// Prefix used for multipart boundary lines
        /// </summary>
        public const string BoundaryPrefix = "\r\n----------------";
        
        /// <summary>
        /// Prefix used for multipart content type boundary
        /// </summary>
        public const string ContentTypeBoundaryPrefix = "--------------";
        
        // HTTP error detection constants
        /// <summary>
        /// Divisor used to extract HTTP status code class (4xx, 5xx)
        /// </summary>
        public const int HttpStatusCodeClassDivisor = 100;
        
        /// <summary>
        /// HTTP status code class for client errors (4xx)
        /// </summary>
        public const int ClientErrorStatusClass = 4;
        
        /// <summary>
        /// HTTP status code class for server errors (5xx)
        /// </summary>
        public const int ServerErrorStatusClass = 5;
        
        // Multipart form data headers
        /// <summary>
        /// Template for multipart file boundary headers
        /// </summary>
        public const string FileBoundaryHeaderTemplate = 
            "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\n" +
            "Content-Type: {2}\r\n" +
            "Content-Transfer-Encoding: {3}\r\n\r\n";
        
        /// <summary>
        /// Template for multipart form boundary headers
        /// </summary>
        public const string FormBoundaryHeaderTemplate = 
            "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";
        
        /// <summary>
        /// Multipart boundary ending marker
        /// </summary>
        public const string BoundaryEndMarker = "--";
    }
}