namespace ArrayCalc.Services
{
    public interface IArrayCalcService
    {
        void Reverse(int[] array);
        void Reverse(int[] array, int start, int length);
        void RemoveAt(int position, ref int[] array);
    }
}
