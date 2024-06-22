namespace YouTube.AspNetCore.API.Tutorial.Basic.Models.Others
{
    public class CustomResponseDto<TEntity>
    {
        public CustomResponseDto(int statusCode)
        {
            StatusCode = statusCode;
        }
        public CustomResponseDto(TEntity data, int statusCode)
        {
            Data = data;
            StatusCode = statusCode;
        }
        public CustomResponseDto(int statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
        public CustomResponseDto(int statusCode, string error)
        {
            StatusCode = statusCode;
            Errors = new List<string> { error };
        }


        public TEntity? Data { get; set; }
        public int StatusCode { get; set; }
        public List<string>? Errors { get; set; }


        public static CustomResponseDto<TEntity> Success(TEntity data, int statusCode)
        {
            return new CustomResponseDto<TEntity>(data, statusCode);
        }

        public static CustomResponseDto<TEntity> Success(int statusCode)
        {
            return new CustomResponseDto<TEntity>(statusCode);
        }

        public static CustomResponseDto<TEntity> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<TEntity>(statusCode, errors);
        }

        public static CustomResponseDto<TEntity> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<TEntity>(statusCode, error);
        }
    }
}
