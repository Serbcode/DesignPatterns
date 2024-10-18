namespace CommandPattern4.Management;

/// <summary>
/// Class "Invoker" to effectively invoke commands
/// Can store commands or implement Undo/Redo logic
/// </summary>
internal class UserManager
{
    public void Invoke(Command command)
    {
        command.Execute();
    }
}
0123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789