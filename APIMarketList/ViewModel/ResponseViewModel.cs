namespace APIMarketList.ViewModel
{
    public class ResponseViewModel<T>
    {
        public bool Success;
        public T? Data { get; set; }
    }
}
