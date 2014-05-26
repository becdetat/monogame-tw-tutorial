namespace Win8ShooterGame
{
    public static class Program
    {
        private static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<ShooterGame>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}