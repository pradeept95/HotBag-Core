namespace HotBag.AspNetCore.ResultWrapper.ResponseModel
{
    public class ResultDto<T>
    {
        public T Data { get; set; }

        public ResultDto(T data)
        {
            this.Data = data;
        }

    }
}
