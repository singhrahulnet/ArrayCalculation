using System;

namespace ArrayCalc.Services
{
    public class ArrayCalcService : IArrayCalcService
    {
        public void Reverse(int[] array)
        {
            if (array == null || array.Length == 0) throw new ArgumentNullException("Supplied array is null");


            Reverse(array, array.GetLowerBound(0), array.Length);
        }

        //Positioin is 0 based index here
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

        private void Reverse(int[] array, int startPos, int length)
        {            
            int endPos = startPos + length - 1;

            while (startPos < endPos)
            {
                var temp = array[startPos];
                array[startPos] = array[endPos];
                array[endPos] = temp;

                startPos++; endPos--;
            }
        }

    }
}
