namespace SpotifyApplication.Common
{
     public class OperationResult<T> : OperationResult
    {
        public OperationResult(bool success)
            : base(success, string.Empty, 500)
        {
        }

        public OperationResult(bool success, string message, int code)
            : base(success, message, code)
        {
        }

        public OperationResult(bool success, KeyValuePair<int, string> resourceConstant)
            : base(success, resourceConstant.Value, resourceConstant.Key)
        {
        }

        public OperationResult(T data)
            : base(true, string.Empty, 200)
        {
            Data = data;
        }
        public OperationResult(T data, string message)
            : base(true, string.Empty, 200)
        {
            Data = data;
            Message = message;
        }

        public OperationResult(T data, KeyValuePair<int, string> resourceConstant)
            : base(true, resourceConstant.Value, resourceConstant.Key)
        {
            Data = data;
        }

        public T Data { get; set; }
    }

    public class OperationResult
    {
        public OperationResult(bool success, string message, int code)
        {
            Success = success;
            Message = message;
            if (!success && code == 0)
                Code = 500;
            else
                Code = code;
        }

        public OperationResult(bool success, KeyValuePair<int, string> resourceConstant)
            : this(success, resourceConstant.Value, resourceConstant.Key)
        {
        }

        public OperationResult(bool success)
            : this(success, string.Empty, 200)
        {
        }

        public OperationResult()
        {

        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
}
