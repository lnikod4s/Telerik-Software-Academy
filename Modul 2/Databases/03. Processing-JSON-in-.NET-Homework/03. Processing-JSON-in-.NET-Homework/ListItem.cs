namespace Processing_JSON_in_.NET_Homework
{
    using Newtonsoft.Json;

    public class ListItem : IListItem
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        public override string ToString()
        {
            return $"Item: Title: {this.Title}";
        }
    }
}