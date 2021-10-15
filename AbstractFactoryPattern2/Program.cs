using System;

namespace AbstractFactoryPattern2
{
    #region GUI Elements
    public interface IButton
    {
        void Paint();
    }

    public class WinButton : IButton
    {
        public void Paint() => Console.WriteLine("windows button");
    }

    public class MacButton : IButton
    {
        public void Paint() => Console.WriteLine("mac button");
    }

    public interface ICheckbox
    {
        void Paint();
    }

    public class WinCheckbox : ICheckbox
    {
        public void Paint() => Console.WriteLine("windows checkbox");
    }

    public class MacCheckbox : ICheckbox
    {
        public void Paint() => Console.WriteLine("mac checkbox");
    }

    #endregion

    #region GUI factories
    public interface IGuiFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    public class MacFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new MacButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacCheckbox();
        }
    }

    public class WinFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WinCheckbox();
        }
    }
    #endregion

    /// <summary>
    /// Application code never changed
    /// </summary>
    public class Application
    {
        private readonly IGuiFactory factory;

        private IButton button;
        private ICheckbox checkbox;

        public Application(IGuiFactory factory)
        {
            this.factory = factory;
        }

        public void CreateUI()
        {
            button = factory.CreateButton();
            button.Paint();

            checkbox = factory.CreateCheckbox();
            checkbox.Paint();
        }
    }


    public class Driver
    {
        private readonly Func<ConsoleKeyInfo> userInput;

        public Driver(Func<ConsoleKeyInfo> UserInput)
        {
            this.userInput = UserInput;
            InitFactory();
        }

        public IGuiFactory Factory { get; private set; }

        private void InitFactory()
        {
            Console.WriteLine("Input 'w' for Windows render, 'm' - for Mac render");
            ConsoleKeyInfo? key = this.userInput?.Invoke();
            if (!key.HasValue) throw new NotImplementedException();
            Factory = key.Value.KeyChar switch
            {
                'w' => new WinFactory(),
                'm' => new MacFactory(),
                _ => throw new NotImplementedException()
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver(Console.ReadKey);
            Application app = new Application(driver.Factory);
            app.CreateUI();
        }
    }
}
