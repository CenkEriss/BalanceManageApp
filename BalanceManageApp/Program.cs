namespace BalanceManageApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            using (var loginForm = new Form1())
            {
                Application.Run(loginForm);  // App will exit when Form1 closes, unless we open Form2
            }
        }
    }
}
