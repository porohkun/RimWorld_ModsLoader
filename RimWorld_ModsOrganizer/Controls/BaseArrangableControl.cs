using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows;

namespace RimWorld_ModsOrganizer
{
    public class BaseArrangableControl : UserControl, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        
        private bool _focused;
        private Brush _selectedColor;
        private Brush _cachedColor;

        public bool Focused
        {
            get { return _focused; }
            set
            {
                if (_focused != value)
                {
                    if (SetField(ref _focused, value, "Focused"))
                        if (value)
                        {
                            _cachedColor = Background;
                            Background = SelectedColor;
                        }
                        else
                            Background = _cachedColor;
                }
            }
        }

        #region SelectedColor
        public Brush SelectedColor
        {
            get { return _selectedColor; }
            set { SetField(ref _selectedColor, value, "SelectedColor"); }
        }

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            "SelectedColor",
            typeof(Brush),
            typeof(BaseArrangableControl),
            new FrameworkPropertyMetadata(null,
                FrameworkPropertyMetadataOptions.AffectsRender,
                new PropertyChangedCallback(OnSelectedColorPropertyChanged)
                )
            );

        private static void OnSelectedColorPropertyChanged(DependencyObject source,
            DependencyPropertyChangedEventArgs e)
        {
            BaseArrangableControl control = source as BaseArrangableControl;
            control._selectedColor = (Brush)e.NewValue;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        private string _locale = "Default";
        public string Locale { get { return _locale; } set { _locale = value; UpdateText(); } }
        public event Action<BaseArrangableControl > WantBeDeleted;

        public BaseArrangableControl() : base()
        {
            Focusable = true;
            GotFocus += BaseArrangableControl_GotFocus;
            LostFocus += BaseArrangableControl_LostFocus;
        }

        private void BaseArrangableControl_LostFocus(object sender, RoutedEventArgs e)
        {
            Focused = false;
        }

        private void BaseArrangableControl_GotFocus(object sender, RoutedEventArgs e)
        {
            Focused = true;
        }

        public virtual bool OpenIndent { get { return false; } }
        public virtual bool CloseIndent { get { return false; } }

        protected virtual void UpdateText()
        {
            
        }

        protected virtual void OnVantBeDeleted(BaseArrangableControl  sender)
        {
            WantBeDeleted?.Invoke(sender);
        }
    }
}
