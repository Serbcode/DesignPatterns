
using SingletonPattern4;

internal class Program
{
    private static void Main(string[] args)
    {
        var inst1 = Logger.Instance;
        var inst2 = Logger.Instance;

        inst1.Log($"message from {inst1}");
        inst2.Log($"message from {inst2}");

        if (object.ReferenceEquals(inst1, inst2) && inst2 == Logger.Instance)
        {
            Logger.Instance.Log("Yep, same object");
        }
    }
}