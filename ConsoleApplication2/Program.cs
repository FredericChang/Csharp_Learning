namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
        }
        
        

        public int kGoodnessString(string s, int k)
        {
            int minOperations = 0;
            int x = 0;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if(s[i] != s[s.Length - i - 1]) {
                    x++;
                }
            }
            if(x == k) {
                minOperations = 0;
            }
            else if(x > k) {
                minOperations = x - k;
            }
            else {
                minOperations = k - x;
            }
            return minOperations;
        }
    }
}