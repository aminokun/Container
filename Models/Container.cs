

namespace Models
{
    public class Container
    {
        public string ID { get; set; }
        public ContainerType Type { get; set; }

        public Container(string id, ContainerType type)
        {
            ID = id;
            Type = type;
        }
    }

    public enum ContainerType
    {
        Cooled,
        Valuable,
        Normal,
        Empty
    }
}
