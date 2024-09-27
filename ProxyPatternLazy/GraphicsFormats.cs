namespace DocumentProxyExample;

internal class GraphicsFormats
{
    private readonly string _formatName;

    public static GraphicsFormats Pdf = new("PDF");
    public static GraphicsFormats Png = new("PNG");
    public static GraphicsFormats Bmp = new("BMP");
    public static GraphicsFormats Unknown = new("");

    public static IEnumerable<GraphicsFormats> Supported => [Pdf, Png, Bmp];

    protected GraphicsFormats(string formatName)
    {
        this._formatName = formatName;
    }
}