public interface IDocument
{
    void Preview();
}

internal class Document : IDocument
{
    private readonly string _filename;

    public Document(string fileName)
    {
        _filename = fileName;
        LongOperationLoadDocument();
    }

    private void LongOperationLoadDocument()
    {
        Thread.Sleep(1000);
    }

    public void Preview()
    {
        Console.WriteLine($"Preview document {_filename}");
    }
}

internal class DocumentLazyLoad : IDocument
{
    private readonly string _filename;

    private readonly Lazy<IDocument> _document;

    public DocumentLazyLoad(string fileName)
    {
        _filename = fileName;
        _document = new Lazy<IDocument>(() => new Document(_filename));
    }

    public void Preview()
    {
        Console.WriteLine($"Preview document {_filename}");
    }
}

internal class DocumentProtectedLazyLoad : IDocument
{
    private readonly string _filename;

    private readonly string _role;

    private readonly IDocument _document;

    public DocumentProtectedLazyLoad(string fileName, string role)
    {
        _filename = fileName;
        _role = role;
        _document = new DocumentLazyLoad(_filename);
    }

    public void Preview()
    {
        Console.WriteLine($"Entering Preview() in {nameof(DocumentProtectedLazyLoad)}");

        if (_role != "Viewer")
        {
            throw new UnauthorizedAccessException();
        }
        else
        {
            _document.Preview();
        }
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var doc1 = new Document("Document1.pdf");
        doc1.Preview();

        var doc2 = new DocumentLazyLoad("Document2.pdf");
        doc2.Preview();

        var doc3 = new DocumentProtectedLazyLoad("Document3.pdf", "Viewer");
        doc3.Preview();
    }
}