namespace BaseAlgorithms
{
    public class Common
    {
        public static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
