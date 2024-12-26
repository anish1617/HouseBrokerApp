namespace HouseBrokerApp.Application.Dtos
{
    public record PropertyDto(
        string PropertyType,
        string Location,
        decimal Price,
        List<string> Features,
        string BrokerContact
        );
}
