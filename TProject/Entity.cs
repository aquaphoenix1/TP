namespace TProject
{
    public class Entity
    {
        private static long curMaxId = 0;
        public long ID { get; set; }

        public Entity()
        {
            ID = ++curMaxId;
        }

    }
}
