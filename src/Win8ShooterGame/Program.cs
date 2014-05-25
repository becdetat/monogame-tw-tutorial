using System;

namespace Win8ShooterGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var factory = new MonoGame.Framework.GameFrameworkViewSource<ShooterGame>();
            Windows.ApplicationModel.Core.CoreApplication.Run(factory);
        }
    }
}
