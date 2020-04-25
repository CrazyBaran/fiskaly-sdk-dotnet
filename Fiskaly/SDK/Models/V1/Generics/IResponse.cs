namespace Fiskaly.Models.V1.Generics
{
    public interface IResponse
    {
        string _type { get; set; }
        string _env { get; set; }
        string _version { get; set; }
    }
}
