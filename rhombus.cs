string str = "x";

int n = 9,
    center = n / 2,
    x = center;

for (int i = 0; i < n; i++)
{
    if (i <= center)
    {
        Console.SetCursorPosition(x--, i);
        Console.WriteLine(str);
        if (i < center)
        {
            str += "xx";
        }
    }
    else
    {
        str = str.Remove(str.Length - 2);
        Console.SetCursorPosition(++x + 1, i);
        Console.WriteLine(str);
    }
}
Console.ReadKey();
