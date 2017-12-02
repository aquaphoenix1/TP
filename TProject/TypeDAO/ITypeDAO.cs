namespace TProject.TypeDAO
{
    public interface ITypeDAO
    {
        bool Insert(Type obj);
        bool Delete(string ID);
        bool Update(Type obj);
    }
}
