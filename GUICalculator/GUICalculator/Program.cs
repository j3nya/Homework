// <copyright file="Program.cs" company="Chernoshchokaya Evgenia">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GUICalculator
{
    /// <summary>
    /// class Program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
      {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Calculator());
        }
    }
}