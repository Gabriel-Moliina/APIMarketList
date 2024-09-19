namespace APIMarketList.ViewModel
{
    public class ResponseViewModel<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T? Data { get; set; }
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
    }
}
