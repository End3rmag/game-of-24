var num = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
Console.WriteLine(CanForm24(num) ? "YES" : "NO");

static bool CanForm24(int[] nums)
{
    var allPeresntanovka = Perestanovka(nums);
    var operations = new char[] { '+', '-', '*' };

    foreach (var mesto in allPeresntanovka)
    {
        foreach (var op1 in operations)
        {
            foreach (var op2 in operations)
            {
                foreach (var op3 in operations)
                { 
                    if (Evalute(mesto[0], mesto[1], mesto[2], mesto[3], op1, op2, op3) == 24) return true;
                }
            }
        }
    }
    
    return false;
}

static double Operation (double x, double y, char op) 
{
    switch (op) 
    {
        case '+': return x + y;
        case '-': return x - y;
        case '*': return x * y;
        default: throw new InvalidCastException();
    }
}

static double Evalute(int a, int b, int c, int d, char op1 ,char op2, char op3) 
{
    return Operation(Operation(Operation (a , b , op1),c , op2),d, op3);
}

static IEnumerable<int[]> Perestanovka(int[] num) 
{
    int n = num.Length;
    var result = new List<int[]>();
    var index = new int[n];

    result.Add((int[])num.Clone());

    for (int i = 0; i < n;)
    {
        if (index[i] < i)
        {
            int j = i % 2 == 0 ? 0 : index[i]; 
            (num[j],num[i]) = (num[i], num[j]); 
            result.Add((int[])num.Clone()); 
            index[i]++;
            i = 0;

        }
        else
        {
            index[i] = 0; 
            i++;
        }
    }
    return result;
    
}


