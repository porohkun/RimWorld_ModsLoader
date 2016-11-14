using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Lancer1WPF
{
    public class ListLayoutStrategy : ILayoutStrategy
    {
        private double _colWidth;
        private readonly List<double> _rowHeights = new List<double>();
        private int _elementCount;

        public Size ResultSize
        {
            get { return _rowHeights.Any() ? new Size(_colWidth, _rowHeights.Sum()) : new Size(0, 0); }
        }

        public void Calculate(Size availableSize, Size[] measures)
        {
            BaseCalculation(availableSize, measures);
            AdjustEmptySpace(availableSize);
        }

        private void BaseCalculation(Size availableSize, Size[] measures)
        {
            _elementCount = measures.Length;

            ResetSizes();
            _colWidth = availableSize.Width;
            for (int row = 0; row < measures.Length; row++)
                _rowHeights.Add(measures[row].Height);
        }

        public Rect GetPosition(int index)
        {
            var rowIndex = index;
            var y = 0d;
            for (int i = 0; i < rowIndex; i++)
            {
                y += _rowHeights[i];
            }
            return new Rect(new Point(0, y), new Size(_colWidth, _rowHeights[rowIndex]));
        }

        public int GetIndex(Point position)
        {
            var row = 0;
            var y = 0d;
            while (y < position.Y && _rowHeights.Count > row)
            {
                y += _rowHeights[row];
                row++;
            }
            row--;
            if (row < 0) row = 0;
            var result = row;
            if (result > _elementCount) result = _elementCount - 1;
            return result;
        }

        private void AdjustEmptySpace(Size availableSize)
        {
            if (!double.IsNaN(availableSize.Width) && availableSize.Width > _colWidth)
            {
                var dif = (availableSize.Width - _colWidth);

                _colWidth += dif;
            }
        }

        private void ResetSizes()
        {
            _rowHeights.Clear();
            _colWidth = 0;
        }

    }
}