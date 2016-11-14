using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace RimWorld_ModsOrganizer
{
    public class ControlsPanel : Lancer1WPF.ArrangePanel
    {
        public double Indent = 50;

        public ControlsPanel()
        {
            _strategy = new Lancer1WPF.ListLayoutStrategy();
        }

        private void RecalculateIndent()
        {
            double indent = 0;
            foreach (var child in Children.OfType<FrameworkElement>().OrderBy(GetOrder))
            {
                BaseArrangableControl  control = null;
                if (child is BaseArrangableControl )
                    control = (BaseArrangableControl )child;
                if (control != null && control.CloseIndent)
                    indent -= Indent;
                if (indent < 0)
                    indent = 0;
                if (child.Margin.Left != indent)
                    child.Margin = new Thickness(indent, 0, 0, 0);
                if (control != null && control.OpenIndent)
                    indent += Indent;
            }
        }

        protected override Size[] MeasureChildren()
        {
            RecalculateIndent();
            return base.MeasureChildren();
        }
    }
}
