﻿using RCDesktopUI.Models.DataModels;
using RCDesktopUI.ViewModels.Base;
using RCLib.Server;

namespace RCDesktopUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="MainWindow"/>
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// The current page that is loaded
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// The title of the current window
        /// </summary>
        public string WindowTitle { get; set; } = "RemoteController";

        /// <summary>
        /// The height of the current window
        /// </summary>
        public int WindowHeight { get; set; } = 800;

        /// <summary>
        /// The width of the current window
        /// </summary>
        public int WindowWidth { get; set; } = 1000;

        /// <summary>
        /// The minimal height of the current window
        /// </summary>
        public int MinWindowHeight { get; set; } = 600;

        /// <summary>
        /// The minimal width of the current window
        /// </summary>
        public int MinWindowWidth { get; set; } = 800;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainWindowViewModel()
        {
        }

        #endregion
    }
}
