using System.Security.Cryptography.X509Certificates;

static int A(string s ,int k)
{
    int x=0,index=1,min=int.MaxValue;
    int[] arr = new int[27];
    int[] ezer = new int[s.Length];
    //טיפול באיבר ראשון
    arr[s[0] - 97] = 0;
    ezer[0] = 1;
    for (int i = 1; i < s.Length; i++)
    {
        //אם התו שווה לתו שלפניו
        if (s[i] == s[i - 1])
        {
            ezer[i] = ezer[i - 1] + 1;
            arr[s[i] - 97] = i;
        }
        //אם התו קיים בתווך הרצף הנוכחי
        else if (ezer[i - 1] > i - arr[s[i] - 97])
        {
            ezer[i] = ezer[i - 1] + 1;
            arr[s[i] - 97] = i;
        }
          //האם לא הגענו למקסימום התווים האפשריים ברצף
        else if(index<k)
        {
            index++;
            ezer[i] = ezer[i - 1] + 1;
            arr[s[i] - 97] = i;
        }
        //מחיקת האיבר שהמופע האחרון שלו הרחוק ביותר 
        else { 
            for (int j = 0; j <27; j++)
            {
                if (arr[j] > i - ezer[i - 1])
                    if (arr[j] < min)
                        min = arr[j];
            }
            ezer[i] = i - min;
        }
    }
    for (int i = 0; i < ezer.Length; i++)
    {
        if (ezer[i] > x)
        {
            x = ezer[i];
            index = i;
        }

    }
    Console.Write("the subString is ");
    for (int i =index-x; i <index; i++) 
    {
        Console.Write($"{s[i]},");
      }
    Console.WriteLine();    
    return x;
}
string s = "abcba";
Console.WriteLine($"the string is {s}");
Console.WriteLine($"the long of string is {A(s,2)}");