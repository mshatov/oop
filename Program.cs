
var str = "вааврварапвав";// Console.ReadLine();
var find = "ва"; //Console.ReadLine();
string res = "";

for (int i = 0; i < str.Length;)
{
    char first = find[0];
    char current = str[i];
    string repl = "";
    bool match = false;

    if (first != current)
    {
        i++;
    }
    else
    {
        int counter = 1;
        for (int j = 1; j < find.Length; j++)
        {
            int index = i + j;
            if (index >= str.Length) break;

            if (find[j] == str[index])
            {
                counter++;
            }
        }
        if (counter == find.Length)
        {
            match = true;

            for (int k = 0; k < find.Length; k++)
            {
                repl += char.ToUpper(str[i + k]);
            }
            Console.WriteLine(i);
            i += find.Length;
        }
        else
        {
            i++;
        }
    }
    res = match ? res + repl : res + current;

}

Console.WriteLine(res);
