using NeilvynSampleBlueprint.Mobile.Xamarin.Common.Converters;
using NeilvynSampleBlueprint.Mobile.Xamarin.Domain.Validations;
using NeilvynSampleBlueprint.Mobile.Xamarin.UI.CustomControls.Effects;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace NeilvynSampleBlueprint.Mobile.Xamarin.UI.CustomControls
{
    [ExcludeFromCodeCoverage]
    [ContentProperty(nameof(InputControl))]
    public partial class InputWrapper
    {

        public event EventHandler Tapped;
        public InputWrapper()
        {
            InitializeComponent();
            UpdateAdornment(Adornment);
        }

        public static readonly BindableProperty InputMarginProperty
            = BindableProperty.Create(nameof(InputMargin), typeof(Thickness), typeof(InputWrapper), new Thickness(6));

        public static readonly BindableProperty InputHeightProperty
            = BindableProperty.Create(nameof(InputHeight), typeof(double), typeof(InputWrapper), 50d);

        public static readonly BindableProperty IsReadOnlyProperty
            = BindableProperty.Create(nameof(IsReadOnly), typeof(bool), typeof(InputWrapper), false, BindingMode.TwoWay,
                propertyChanged: OnIsReadOnlyPropertyChanged);

        public static readonly BindableProperty InputControlProperty
            = BindableProperty.Create(nameof(InputControl), typeof(View), typeof(InputWrapper),
                propertyChanged: OnInputControlChanged);

        public static readonly BindableProperty InputValueProperty
            = BindableProperty.Create(nameof(InputValue), typeof(string), typeof(InputWrapper), string.Empty,
                BindingMode.OneWay, propertyChanged: OnTextPropertyChanged);

        public static readonly BindableProperty TitleProperty
            = BindableProperty.Create(nameof(Title), typeof(string), typeof(InputWrapper), string.Empty);

        public static readonly BindableProperty PlaceholderProperty
            = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(InputWrapper), string.Empty);

        public static readonly BindableProperty AdornmentProperty
            = BindableProperty.Create(nameof(Adornment), typeof(Adornment), typeof(InputWrapper), Adornment.None,
                BindingMode.OneWay, propertyChanged: OnAdornmentPropertyChanged);

        public static readonly BindableProperty AdornmentIconProperty
            = BindableProperty.Create(nameof(AdornmentIcon), typeof(string), typeof(InputWrapper), string.Empty);

        public static readonly BindableProperty AdornmentCommandProperty
            = BindableProperty.Create(nameof(AdornmentCommand), typeof(ICommand), typeof(InputWrapper),
                default(ICommand), propertyChanged: OnAdornmentCommandPropertyChanged);

        public static readonly BindableProperty ValidationStateProperty
            = BindableProperty.Create(nameof(ValidationState), typeof(ValidationState), typeof(InputWrapper),
                ValidationState.NotValidated, BindingMode.TwoWay, propertyChanged: OnValidationStatePropertyChanged);

        public static readonly BindableProperty ErrorMessageProperty
            = BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(InputWrapper), string.Empty,
                BindingMode.TwoWay);

        public static readonly BindableProperty InputFocusedProperty
            = BindableProperty.Create(nameof(InputFocused), typeof(bool), typeof(InputWrapper),
                propertyChanged: OnInputFocusedChanged);

        public static readonly BindableProperty HasFocusedProperty
           = BindableProperty.Create(nameof(HasFocused), typeof(bool), typeof(InputWrapper), false, BindingMode.TwoWay);

        public static readonly BindableProperty FontFamilyProperty
            = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(InputWrapper), string.Empty,
                BindingMode.OneWay, propertyChanged: OnTextPropertyChanged);

        //COLORS
        public static readonly BindableProperty TextColorProperty
            = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(InputWrapper), Color.White);

        public static readonly BindableProperty FocusColorProperty
            = BindableProperty.Create(nameof(FocusColor), typeof(Color), typeof(InputWrapper), Color.White);

        public static readonly BindableProperty FocusBackgroundColorProperty
            = BindableProperty.Create(nameof(FocusBackgroundColor), typeof(Color), typeof(InputWrapper),
                Color.White);

        public static readonly BindableProperty BorderColorProperty
            = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(InputWrapper), Color.White);

        public static readonly BindableProperty PlaceHolderTextColorProperty
            = BindableProperty.Create(nameof(PlaceHolderTextColor), typeof(Color), typeof(InputWrapper), Color.FromHex("#50333333"));

        public static readonly BindableProperty ErrorColorProperty
            = BindableProperty.Create(nameof(ErrorColor), typeof(Color), typeof(InputWrapper),
                Color.FromHex("#EE3C3C"));

        public static readonly BindableProperty ShowValidationErrorProperty
                = BindableProperty.Create(nameof(ShowValidationError), typeof(bool), typeof(InputWrapper), true);

        public double InputHeight
        {
            get => (double)GetValue(InputHeightProperty);
            set => SetValue(InputHeightProperty, value);
        }

        public Thickness InputMargin
        {
            get => (Thickness)GetValue(InputMarginProperty);
            set => SetValue(InputMarginProperty, value);
        }

        public View InputControl
        {
            get => (View)GetValue(InputControlProperty);
            set => SetValue(InputControlProperty, value);
        }

        public bool InputFocused
        {
            get => (bool)GetValue(InputFocusedProperty);
            set => SetValue(InputFocusedProperty, value);
        }

        public bool HasFocused
        {
            get => (bool)GetValue(HasFocusedProperty);
            set => SetValue(HasFocusedProperty, value);
        }

        public string InputValue
        {
            get => (string)GetValue(InputValueProperty);
            set => SetValue(InputValueProperty, value);
        }

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public Color FocusColor
        {
            get => (Color)GetValue(FocusColorProperty);
            set => SetValue(FocusColorProperty, value);
        }

        public Color PlaceHolderTextColor
        {
            get => (Color)GetValue(PlaceHolderTextColorProperty);
            set => SetValue(PlaceHolderTextColorProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public bool IsReadOnly
        {
            get => (bool)GetValue(IsReadOnlyProperty);
            set => SetValue(IsReadOnlyProperty, value);
        }

        public Adornment Adornment
        {
            get => (Adornment)GetValue(AdornmentProperty);
            set => SetValue(AdornmentProperty, value);
        }

        public string AdornmentIcon
        {
            get => (string)GetValue(AdornmentIconProperty);
            set => SetValue(AdornmentIconProperty, value);
        }

        public ICommand AdornmentCommand
        {
            get => (ICommand)GetValue(AdornmentCommandProperty);
            set => SetValue(AdornmentCommandProperty, value);
        }

        public ValidationState ValidationState
        {
            get => (ValidationState)GetValue(ValidationStateProperty);
            set => SetValue(ValidationStateProperty, value);
        }

        public string ErrorMessage
        {
            get => (string)GetValue(ErrorMessageProperty);
            set => SetValue(ErrorMessageProperty, value);
        }

        public Color ErrorColor
        {
            get => (Color)GetValue(ErrorColorProperty);
            set => SetValue(ErrorColorProperty, value);
        }

        public Color FocusBackgroundColor
        {
            get => (Color)GetValue(FocusBackgroundColorProperty);
            set => SetValue(FocusBackgroundColorProperty, value);
        }

        public bool ShowValidationError 
        {
            get => (bool)GetValue(ShowValidationErrorProperty);
            set => SetValue(ShowValidationErrorProperty, value);
        }

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is InputWrapper inputContainer)
            {
                inputContainer.Reset();
            }
        }

        private static void OnIsReadOnlyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is InputWrapper inputContainer)
            {
                inputContainer.Reset();
            }
        }

        private static void OnInputFocusedChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is InputWrapper inputContainer)
            {
                inputContainer.Reset();
            }
        }

        private static void OnValidationStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is InputWrapper inputContainer)
            {
                inputContainer.UpdateControlState();
            }
        }

        private static void OnAdornmentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is InputWrapper inputContainer && newValue is Adornment adornment)
            {
                inputContainer.UpdateAdornment(adornment);
            }
        }

        private static void OnInputControlChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is InputWrapper inputContainer && newvalue is View newView)
            {
                inputContainer.UpdateNewView(newView);
            }
        }

        private static void OnAdornmentCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is InputWrapper inputContainer)
            {
                inputContainer.AdornmentIconLabel.GestureRecognizers.Clear();

                if (newValue is ICommand command)
                {
                    var tapGesture = new TapGestureRecognizer
                    {
                        Command = command
                    };

                    inputContainer.AdornmentIconLabel.GestureRecognizers.Add(tapGesture);
                }
            }
        }

        private void UpdateNewView(View newView)
        {
            newView.BackgroundColor = Color.Transparent;
            newView.Effects.Add(new NoBorderEffect());
            InputHolder.Content = newView;
            SetBinding(InputFocusedProperty, new Binding(nameof(IsFocused), source: newView));
            FocusNewViewOnAdornmentTap(newView);

            newView.VerticalOptions = LayoutOptions.Center;
            newView.SetBinding(View.HeightRequestProperty, new Binding(nameof(InputHeight), source: this));
            switch (newView)
            {
                case Label label:
                    SetBinding(InputValueProperty, new Binding(nameof(Label.Text), source: label, converter: new PickerValueToStringConverter()));
                    label.SetBinding(Label.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    label.SetBinding(Label.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    break;
                case Entry entry:
                    SetBinding(InputValueProperty, new Binding(nameof(Entry.Text), source: entry));
                    entry.SetBinding(Entry.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    entry.SetBinding(Entry.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    entry.SetBinding(Entry.PlaceholderProperty, new Binding(nameof(Placeholder), source: this));
                    entry.SetBinding(Entry.PlaceholderColorProperty, new Binding(nameof(PlaceHolderTextColorProperty), source: this));
                    break;
                case Editor editor:
                    SetBinding(InputValueProperty, new Binding(nameof(Editor.Text), source: editor));
                    editor.SetBinding(Editor.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    editor.SetBinding(Editor.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    editor.SetBinding(Editor.PlaceholderProperty, new Binding(nameof(Placeholder), source: this));
                    editor.SetBinding(Editor.PlaceholderColorProperty, new Binding(nameof(PlaceHolderTextColorProperty), source: this));
                    break;
                case NullableDatePicker nDatePicker:
                    SetBinding(InputValueProperty, new Binding(nameof(NullableDatePicker.SelectedDate), source: nDatePicker, converter: new NullableDateToStringConverter()));
                    nDatePicker.SetBinding(DatePicker.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    nDatePicker.SetBinding(DatePicker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    ReadOnlyLabel.SetBinding(Label.TextProperty, new Binding(nameof(NullableDatePicker.SelectedDate), source:nDatePicker, stringFormat:"{0:dd MMM yyyy}"));
                    break;
                case DatePicker datePicker:
                    SetBinding(InputValueProperty, new Binding(nameof(DatePicker.Date), source: datePicker));
                    datePicker.SetBinding(DatePicker.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    datePicker.SetBinding(DatePicker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    ReadOnlyLabel.SetBinding(Label.TextProperty, new Binding(nameof(DatePicker.Date), source:datePicker, stringFormat:"{0:dd MMM yyyy}"));
                    break;
                case Picker picker:
                    SetBinding(InputValueProperty, new Binding(nameof(Picker.SelectedItem), source: picker, converter: new PickerValueToStringConverter()));
                    picker.SetBinding(Picker.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    picker.SetBinding(Picker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    break;
                case NullableTimePicker nTimePicker:
                    SetBinding(InputValueProperty, new Binding(nameof(NullableTimePicker.SelectedTime), source: nTimePicker, converter: new NullableTimeToStringConverter()));
                    nTimePicker.SetBinding(TimePicker.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    nTimePicker.SetBinding(TimePicker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    ReadOnlyLabel.SetBinding(Label.TextProperty, new Binding(nameof(NullableTimePicker.SelectedTime), source:nTimePicker, stringFormat:"{0:hh:mm tt}"));
                    break;
                case TimePicker timePicker:
                    SetBinding(InputValueProperty, new Binding(nameof(TimePicker.Time), source: timePicker));
                    timePicker.SetBinding(TimePicker.TextColorProperty, new Binding(nameof(TextColor), source: this));
                    timePicker.SetBinding(TimePicker.FontFamilyProperty, new Binding(nameof(FontFamily), source: this));
                    ReadOnlyLabel.SetBinding(Label.TextProperty, new Binding(nameof(TimePicker.Time), source:timePicker, stringFormat:"{0:hh:mm tt}"));
                    break;

            }
            
            UpdateControlState();
        }

        private void FocusNewViewOnAdornmentTap(View newView)
        {
            if (!AdornmentIconLabel.GestureRecognizers.Any())
            {
                var tapGesture = new TapGestureRecognizer
                {
                    Command = new Command(() => newView.Focus())
                };

                AdornmentIconLabel.GestureRecognizers.Add(tapGesture);
            }
        }

        private void UpdateAdornment(Adornment adornment)
        {
            switch (adornment)
            {
                case Adornment.Start:
                    InputGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Auto);
                    InputGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                    Grid.SetColumn(InputHolder, 1);
                    Grid.SetColumn(PlaceholderLabel, 1);
                    Grid.SetColumnSpan(InputHolder, 1);
                    Grid.SetColumnSpan(PlaceholderLabel, 1);
                    InputGrid.Children.Add(AdornmentIconLabel);
                    Grid.SetColumn(AdornmentIconLabel, 0);
                    break;
                case Adornment.End:
                    InputGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    InputGrid.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Auto);
                    Grid.SetColumn(InputHolder, 0);
                    Grid.SetColumn(PlaceholderLabel, 0);
                    Grid.SetColumnSpan(InputHolder, 1);
                    Grid.SetColumnSpan(PlaceholderLabel, 1);
                    InputGrid.Children.Add(AdornmentIconLabel);
                    Grid.SetColumn(AdornmentIconLabel, 1);
                    break;
                default:
                    InputGrid.ColumnDefinitions[0].Width = new GridLength(1, GridUnitType.Star);
                    InputGrid.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);
                    Grid.SetColumn(InputHolder, 0);
                    Grid.SetColumn(PlaceholderLabel, 0);
                    Grid.SetColumnSpan(InputHolder, 2);
                    Grid.SetColumnSpan(PlaceholderLabel, 2);
                    InputGrid.Children.Remove(AdornmentIconLabel);
                    break;
            }
        }

        private enum ControlStateType
        {
            Empty,
            Filled,
            Focused,
            Error,
            ReadOnly
        }

        private ControlStateType GetControlState()
        {
            if (IsReadOnly)
            {
                return ControlStateType.ReadOnly;
            }

            if (InputControl?.IsFocused ?? false)
            {
                return ControlStateType.Focused;
            }

            if (ValidationState == ValidationState.Invalid)
            {
                return ControlStateType.Error;
            }

            return string.IsNullOrEmpty(InputValue) ? ControlStateType.Empty : ControlStateType.Filled;
        }

        private static string StatusToStateName(ControlStateType status)
        {
            return status switch
            {
                ControlStateType.Empty => "Empty",
                ControlStateType.Filled => "Filled",
                ControlStateType.Focused => "Focused",
                ControlStateType.Error => "Error",
                ControlStateType.ReadOnly => "ReadOnly",
                _ => "Empty"
            };
        }

        private void SetStatus(ControlStateType status)
        {
            var stateName = StatusToStateName(status);

            HasFocused = status == ControlStateType.Focused;
            VisualStateManager.GoToState(MainGrid, stateName);
        }


        private void UpdateControlState()
        {
            try
            {
                var controlState = GetControlState();

                FontFamily = string.IsNullOrEmpty(InputValue) ? "LatoRegularFontFamily" : "LatoBoldFontFamily";

                if (InputControl is DatePicker || InputControl is TimePicker || InputControl is Picker || InputControl is Label)
                {
                    PlaceholderLabel.IsVisible = string.IsNullOrEmpty(InputValue);
                    InputControl.IsVisible = !string.IsNullOrEmpty(InputValue);
                }

                SetStatus(controlState);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ClearValidation()
        {
            ValidationState = ValidationState.NotValidated;
            ErrorMessage = string.Empty;
        }

        private void Reset()
        {
            ClearValidation();
            UpdateControlState();
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            if (IsReadOnly)
            {
                return;
            }

            if (InputControl is Label && AdornmentCommand != null && AdornmentCommand.CanExecute(null))
            {
                AdornmentCommand.Execute(null);
            }

            if (InputControl is Picker || InputControl is DatePicker || InputControl is TimePicker)
            {
                InputControl.Focus();
            }

            if (InputControl is Label)
            {
                Tapped?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}