using Xamarin.Forms;

namespace RCMobileUI.ControlBehaviors
{
    /// <summary>
    /// Behavior for a <see cref="Button"/> that uses commands instead of events for certain actions
    /// </summary>
    public class ButtonPressedReleasedBehavior : Behavior<Button>
    {
        #region Bindable properties

        #region PressedCommand

        /// <summary>
        /// The bindable property for <see cref="PressedCommand"/>
        /// </summary>
        public static readonly BindableProperty PressedCommandProperty = BindableProperty.Create(
            nameof(PressedCommand),
            typeof(Command),
            typeof(ButtonPressedReleasedBehavior));

        /// <summary>
        /// The command that executes when the button is pressed
        /// </summary>
        public Command PressedCommand
        {
            get
            {
                return (Command)GetValue(PressedCommandProperty);
            }
            set
            {
                SetValue(PressedCommandProperty, value);
            }
        }

        #endregion

        #region ReleasedCommand

        /// <summary>
        /// The bindable property for <see cref="ReleasedCommand"/>
        /// </summary>
        public static readonly BindableProperty ReleasedCommandProperty = BindableProperty.Create(
            nameof(ReleasedCommand),
            typeof(Command),
            typeof(ButtonPressedReleasedBehavior));

        /// <summary>
        /// The command that executes when the button is released
        /// </summary>
        public Command ReleasedCommand
        {
            get
            {
                return (Command)GetValue(ReleasedCommandProperty);
            }
            set
            {
                SetValue(ReleasedCommandProperty, value);
            }
        }

        #endregion

        #endregion

        #region Events

        protected override void OnAttachedTo(Button bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Pressed += BindableOnPressed;
            bindable.Released += BindableOnReleased;
            bindable.BindingContextChanged += BindableOnBindingContextChanged;
        }

        protected override void OnDetachingFrom(Button bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Pressed -= BindableOnPressed;
            bindable.Released -= BindableOnReleased;
            bindable.BindingContextChanged -= BindableOnBindingContextChanged;
        }

        private void BindableOnBindingContextChanged(object sender, System.EventArgs e)
        {
            Button button = sender as Button;
            BindingContext = button?.BindingContext;
        }

        private void BindableOnPressed(object sender, System.EventArgs e)
        {
            this.PressedCommand?.Execute(null);
        }

        private void BindableOnReleased(object sender, System.EventArgs e)
        {
            this.ReleasedCommand?.Execute(null);
        }

        #endregion
    }
}
