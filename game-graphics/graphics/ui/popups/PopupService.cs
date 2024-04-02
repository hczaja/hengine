namespace game_graphics.graphics.ui.popups;

internal class PopupService
{
    private IEnumerable<Popup> _popups;

    public PopupService()
    {
        _popups = new List<Popup>();
    }
}
