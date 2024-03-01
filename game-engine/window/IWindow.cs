namespace game_engine.window;

public interface IWindow 
{
    bool IsOpen();
    void Update();
    void Draw();
    void Display();
    void DispatchEvents();
    void Clear();
    void Close();
}
