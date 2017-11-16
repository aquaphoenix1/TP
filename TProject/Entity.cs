namespace TProject
{
    public class Entity
    {
        public static long curMaxId { get; set; }
        public long ID { get; set; }

        public Entity()
        {
            ID = ++curMaxId;
        }

    }
}
