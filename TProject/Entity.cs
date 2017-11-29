namespace TProject
{
    public class Entity
    {
        private static long CurrentMaxID { get; set; }
        public long ID { get; set; }

        public Entity()
        {
            this.ID = ++CurrentMaxID;
        }
    }
}
