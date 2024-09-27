namespace DocumentProxyExample;

public class DocumentProxy : IDocument
{
    private readonly string filename;
    private readonly Lazy<IDocument> _document;

    public DocumentProxy(string filename)
    {
        this.filename = filename;
        _document = new Lazy<IDocument>(() => new Document(filename));
    }

    public void Preview()
    {
        // document will be created here
        _document.Value.Preview();
    }
}