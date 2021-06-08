using System;

namespace Delegates2
{   
    public delegate void LoadHandler(object sender, EventArgs e);
    public delegate void ErrorHandler(object sender, EventArgs e);

    public class WebPageLoader
    {
        public bool Ready { get; protected set; }
        public event LoadHandler PageLoad;
        public event ErrorHandler PageError;

        public WebPageLoader()
        {
            Ready = false;
        }

        public void MakeRequest(Uri address)
        {
            // emulate request
            System.Threading.Thread.Sleep(1000);            
            bool loaded = (new Random().Next(100) <= 40) ? true : false;

            if (loaded)
            {
                // notify client code
                PageLoad?.Invoke(this, new EventArgs());
                Ready = true;
            }
            else 
            {
                PageError?.Invoke(this, new EventArgs());
                Ready = true;
            }
            
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            WebPageLoader loader = new WebPageLoader();
            
            loader.PageLoad += Page_Load;
            loader.PageError += Page_Error;

            for (int i = 0; i < 10; i++)
            {
                loader.MakeRequest(new Uri("https://asthenis.de"));
                Console.WriteLine("PageLoader is ready: " + loader.Ready);
            }

            Console.ResetColor();
        }

        private static void Page_Error(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Client: Cannot load page");
        }

        public static void Page_Load(object sender, EventArgs e)
        {
            Console.ResetColor();
            Console.WriteLine("Client: Page_Load event handler");
        }
    }
}
