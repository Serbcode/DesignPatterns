// proxy pattern with lazy loading example

namespace DocumentProxyExample;

public interface IDocument
{
    void Preview();
}

public class Document : IDocument
{
    private readonly string filename;

    public Document(string filename)
    {
        this.filename = filename;
        LoadDocument(filename);
    }

    private void LoadDocument(string filename)
    {
        Thread.Sleep(1000);
    }

    public void Preview()
    {
        Console.WriteLine($"Preview document {filename}");
    }
}