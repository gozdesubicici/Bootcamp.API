using System.Text.Json.Serialization;

namespace Bootcamp.API.DTOs
{
    // Tüm uygulamalarımdan endpointlerden dönecek Modelim
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; } // Kodun içerisinde kullanmak için yazdım ama Response'da gözükmesine gerek yok o yüzden [JsonIgnore] koydum.

        internal static ResponseDto<NoContent> Fail(string message)
        {
            throw new NotImplementedException();
        }

        // Tek bir nesne örneği üreteceğim için Factory Method DP kullanılabilirdi. Ama bir DP projeyi daha karmaşık hale getirecekse uygulamamalıyız.
        // Burada o yüzden Static Factory Method kullanacağım.

        // Static Factory Method : Ekstra interfaceler ekstra factory classları tanımlatmadan nesne örneği üreteceğiniz classın içerisinde direkt methodlarla beraber geri dönmemize imkan verir.

        public static ResponseDto<T> Success(T Data, int statusCode)
        {
            return new ResponseDto<T> { Data = Data, StatusCode = statusCode };
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = statusCode };
        }

        public static ResponseDto<T> Fail(List<String> errors, int statusCode)
        {
            return new ResponseDto<T>{ Data = default(T), Errors = errors, StatusCode=statusCode };  
        }

        public static ResponseDto<T> Fail(string errors, int statusCode)
        {
            return new ResponseDto<T> { Data = default(T), Errors = new List<string>() { errors }, StatusCode=statusCode };
        }
        // Eğer bu metotların sayısı artarsa Factory Method DP kullanacağız. Ama şu an 4 tane yeterli.

    }
}
