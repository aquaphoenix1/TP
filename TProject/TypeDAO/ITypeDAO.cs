namespace TProject.TypeDAO
{
    public interface ITypeDAO
    {
        bool Insert(Type obj);
        bool Delete(long ID);
        bool Update(Type obj);
    }
}
