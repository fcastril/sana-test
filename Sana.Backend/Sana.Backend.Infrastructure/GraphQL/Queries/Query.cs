namespace Sana.Backend.Infrastructure.GraphQL.Queries
{
    public partial class Query
    {
        
        public string IsReady => $"The services is Ready: {DateTime.Now}";
    }
}
