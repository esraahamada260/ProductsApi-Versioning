namespace ProductsApi.Models
{
    public class Product
    {
        public int Id {set; get;}
        public string Name {get; set;} = string.Empty;
        public decimal Price {get; set;}
    }
}