namespace Ex04.Menus.Interfaces
{
    public interface IMenu : IMenuItem
    {
        void Show();
        void AddItem(IMenuItem i_Item);
    }
}
