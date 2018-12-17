using System;

namespace ArrayCalc.Services
{
    public class ArrayCalcService : IArrayCalcService
    {
        public void Reverse(int[] array)
        {
            if (array == null) throw new ArgumentNullException("Supplied array is null");

            Reverse(array, array.GetLowerBound(0), array.Length);
        }

        public void Reverse(int[] array, int start, int length)
        {
            if (array == null || array.Length == 0) throw new ArgumentNullException("Supplied array is null");
            if (start < array.GetLowerBound(0) || length < 0) throw new ArgumentOutOfRangeException("The start index is out of range");
            if (array.Length - (start - array.GetLowerBound(0)) < length) throw new ArgumentOutOfRangeException("The lenght of the array is out of range");

            int startPos = start;
            int endPos = start + length - 1;

            while (startPos < endPos)
            {
                var temp = array[startPos];
                array[startPos] = array[endPos];
                array[endPos] = temp;

                startPos++; endPos--;
            }
        }

        public void RemoveAt(int position, ref int[] array)
        {
            if (array == null || array.Length == 0) throw new ArgumentNullException("Supplied array is null");
            if (position > (array.Length - 1) || position < 0) throw new ArgumentOutOfRangeException("The position index is out of range");

            for (int i = position; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
        }

    }
}
