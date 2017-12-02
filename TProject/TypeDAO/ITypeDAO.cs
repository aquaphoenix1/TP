namespace TProject.TypeDAO
{
    public interface ITypeDAO
    {
        bool Insert(object obj);
        bool Delete(string ID);
        bool Update(object obj, string ID);
    }
}
