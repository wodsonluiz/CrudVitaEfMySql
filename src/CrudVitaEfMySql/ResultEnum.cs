namespace CrudVitaEfMySql
{
    public enum ResultEnum
    {
        NotFund,
        Success,
        Fail
    }

    public class ResponseOperation
    {
        public ResultEnum Result { get; set; }
        public string Msg { get; set; }
    }
}
