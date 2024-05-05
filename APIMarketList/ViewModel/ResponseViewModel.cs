namespace APIMarketList.ViewModel
{
    public class ResponseViewModel<T>
    {
        public ResponseViewModel(T Data)
        {
            Success = true;
            this.Data = Data;
        }
        public ResponseViewModel(Exception ex)
        {
            Success = false;
            Error = ex.Message;
        }
        public bool Success;
        public string Error;
        public T? Data { get; set; }
    }
}
