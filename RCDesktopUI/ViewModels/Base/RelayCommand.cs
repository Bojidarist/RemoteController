using System;
using System.Windows.Input;

namespace RCDesktopUI.ViewModels.Base
{
    public class RelayCommand : ICommand
    {
        #region EventHandler

        /// <summary>
        /// Event called when CanExecute changes
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        private Action commandAction;

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="action">The action to be executed</param>
        public RelayCommand(Action action)
        {
            this.commandAction = action;
        }

        #endregion

        #region CanExecute And Execute Methods

        /// <summary>
        /// Always execute
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute Command
        /// </summary>
        public void Execute(object parameter)
        {
            this.commandAction();
        }

        #endregion
    }
}
