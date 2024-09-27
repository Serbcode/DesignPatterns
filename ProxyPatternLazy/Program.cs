using DocumentProxyExample;
// proxy pattern with lazy loading example

/// <summary>
/// Driver
/// </summary>
internal class Program
{
    public static void Main(string[] args)
    {
        var doc1 = new Document("Document1.pdf");
        DocumentPreviewer.PreviewDocuments([doc1]);

        System.Console.WriteLine();

        var doc2 = new DocumentProxy("Document2.docx");

        // document will be loaded only here
        DocumentPreviewer.PreviewDocument(doc2);
    }
}