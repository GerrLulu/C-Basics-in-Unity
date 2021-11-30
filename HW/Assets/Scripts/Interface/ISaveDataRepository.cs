namespace Geekbrains
{
    public interface ISaveDataRepository
    {
        void Save(PlayerBase player, ListExecuteObject interactiveObject);
        void Load(PlayerBase player, ListExecuteObject interactiveObject);
    }
}