namespace ProjectInternship.ViewModels
{
    public class ResultVM<T>
    {
        public bool Success { get; set; }

        public string? ErrorMessage { get; set; }
        public T? Data { get; set; }

        public static ResultVM<T> Successful(T data){
            return new ResultVM<T>
            {
                Success = true,
                Data = data
            };
        }

        public static ResultVM<T> Fail(string mes)
        {
            return new ResultVM<T>
            {
                Success = false,
                ErrorMessage = mes
            };
        }
    }
}
