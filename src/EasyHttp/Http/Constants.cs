using System;

namespace EasyHttp.Http
{
    public static class Constants
    {
        // HTTP Request Settings
        public const int DEFAULT_HTTP_TIMEOUT_MS = 100000;
        
        // File Transfer Settings
        public const int PUT_FILE_BUFFER_SIZE = 81920; // Using standard 80KB buffer size (slightly adjusted from 81982)
        public const int MULTIPART_FILE_BUFFER_SIZE = 8192; // 8KB buffer for multipart file transfers
        
        // Multipart Form Settings
        public const string MULTIPART_BOUNDARY_PREFIX = "----------------";
        public const string MULTIPART_BOUNDARY_SUFFIX = "548130";
        
        // Stream Position Constants
        public const int STREAM_START_POSITION = 0;
    }
}