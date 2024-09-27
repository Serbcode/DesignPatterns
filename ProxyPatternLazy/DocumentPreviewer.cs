// proxy pattern with lazy loading example
namespace DocumentProxyExample;
/// <summary>
/// When we add proxy with lazy loading this client code stays not changed!
/// </summary>
internal static class DocumentPreviewer
{
    public static void PreviewDocuments(IEnumerable<IDocument> documents)
    {
        foreach (var doc in documents)
        {
            doc.Preview();
        }
    }

    public static void PreviewDocument(IDocument document)
    {
        document.Preview();
    }
}
