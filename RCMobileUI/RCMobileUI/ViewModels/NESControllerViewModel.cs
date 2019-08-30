using RCLib.Models;
using RCMobileUI.Client;
using RCMobileUI.Utils;
using RCMobileUI.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RCMobileUI.ViewModels
{
    /// <summary>
    /// The view model for <see cref="NESControllerView"/>
    /// </summary>
    public class NESControllerViewModel : BaseViewModel
    {
        #region Public properties

        /// <summary>
        /// <see cref="ButtonHandler"/> stores all NES buttons
        /// </summary>
        public NESButtonHandler ButtonHandler { get; set; }

        #endregion

        #region Commands

        // Commands for NES button actions
        public Command AButtonPressed { get; set; }
        public Command AButtonReleased { get; set; }

        public Command BButtonPressed { get; set; }
        public Command BButtonReleased { get; set; }

        public Command SelectButtonPressed { get; set; }
        public Command SelectButtonReleased { get; set; }

        public Command StartButtonPressed { get; set; }
        public Command StartButtonReleased { get; set; }

        public Command LeftButtonPressed { get; set; }
        public Command LeftButtonReleased { get; set; }

        public Command RightButtonPressed { get; set; }
        public Command RightButtonReleased { get; set; }

        public Command UpButtonPressed { get; set; }
        public Command UpButtonReleased { get; set; }

        public Command DownButtonPressed { get; set; }
        public Command DownButtonReleased { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public NESControllerViewModel()
        {
            this.ButtonHandler = new NESButtonHandler();
            this.MakeCommands();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Make the commands needed for this view model
        /// </summary>
        private void MakeCommands()
        {
            this.AButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.A.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.A);
                    }
                });
            });

            this.AButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.A.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.A);
                    }
                });
            });

            this.BButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.B.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.B);
                    }
                });
            });

            this.BButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.B.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.B);
                    }
                });
            });

            this.SelectButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Select.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Select);
                    }
                });
            });

            this.SelectButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Select.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Select);
                    }
                });
            });

            this.StartButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Start.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Start);
                    }
                });
            });

            this.StartButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Start.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Start);
                    }
                });
            });

            this.LeftButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Left.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Left);
                    }
                });
            });

            this.LeftButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Left.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Left);
                    }
                });
            });

            this.RightButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Right.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Right);
                    }
                });
            });

            this.RightButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Right.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Right);
                    }
                });
            });

            this.UpButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Up.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Up);
                    }
                });
            });

            this.UpButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Up.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Up);
                    }
                });
            });

            this.DownButtonPressed = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Down.KeyState = ConsoleKeyStateEnum.PRESSED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Down);
                    }
                });
            });

            this.DownButtonReleased = new Command(async () =>
            {
                await Task.Run(() =>
                {
                    if (SingletonRCClient.SingleRCClient.IsConnected)
                    {
                        this.ButtonHandler.Down.KeyState = ConsoleKeyStateEnum.RELEASED;
                        SingletonRCClient.SingleRCClient.SendConsoleButtonAsCSV(this.ButtonHandler.Down);
                    }
                });
            });
        }

        #endregion
    }
}
