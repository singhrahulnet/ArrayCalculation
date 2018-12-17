namespace ArrayCalc.Services
{
    public interface IArrayCalcService
    {
        void Reverse(int[] array);
        void RemoveAt(int position, ref int[] array);
    }
}
