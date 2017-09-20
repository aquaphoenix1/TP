namespace TProject
{
    public class Type : Entity
    {
        public string TypeName { get; set; }
        public Type():base(){}
        public Type(string typeName) : base()
        {
            TypeName = typeName;
        }
    }
}
