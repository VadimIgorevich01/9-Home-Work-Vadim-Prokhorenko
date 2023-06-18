int GetCheckedNumber(string info, string allowedCharacters)
{
    Console.WriteLine(info);
    string? numberToBeChecked = Console.ReadLine();
    while (IsThereText(numberToBeChecked!, allowedCharacters!) |
                        TestForNullOrEmpty(numberToBeChecked!))
    {
        Console.WriteLine("Условие не выполнено или строка пуста, попробуйте ввести иначе");
        Console.WriteLine(info);
        numberToBeChecked = Console.ReadLine();
    }
    int numberOk = Convert.ToInt32(numberToBeChecked);
    return numberOk;
}

int GetOkNumInclDouble(string info, string allowedCharacters, bool doWeCountFrom)
{
    Console.WriteLine(info);
    string? numberToBeChecked = Console.ReadLine();
    while (IsThereText(numberToBeChecked!, allowedCharacters!) |
                        TestForNullOrEmpty(numberToBeChecked!))
    {
        Console.WriteLine("Условие не выполнено или строка пуста, попробуйте ввести иначе");
        Console.WriteLine(info);
        numberToBeChecked = Console.ReadLine();
    }
    if (IsItDouble(numberToBeChecked!))
    {
        string[] splitedNumber = numberToBeChecked!.Split(',');
        numberToBeChecked = splitedNumber[0];
        int numberOk = Convert.ToInt32(numberToBeChecked);
        if (doWeCountFrom == true)
        {
            numberOk++; // для задания 2, чтобы были выбраны целые числа в полуинтервале, 
                        // например для (4,2; 7,4] будут выбраны 5, 6, 7
        }
    return numberOk;
    }
    else
    {
        int numberOk = Convert.ToInt32(numberToBeChecked);
        return numberOk;
    }
}

bool IsItDouble(string numberString)
{
    for (int i = 0; i < numberString.Length; i++)
    {
        if (numberString [i] == ',')
        {
            return true;
        }
    }
    return false;
}

bool TestForNullOrEmpty(string s)
{
    bool result;
    result = s == null || s == string.Empty;
    return result;
}

bool IsThereText(string typedNumber, string okChars)
{
    char characterToBeChecked = ' ';
    int checkedChars = 0;
    for (int i = 0; i < typedNumber.Length; i++)
    {
        characterToBeChecked = typedNumber[i];
        for (int j = 0; j < okChars.Length; j++)
        {
            if (characterToBeChecked == okChars[j])
            {
                checkedChars++;
                break;
            }
        }
    }
    if (checkedChars == typedNumber.Length)
    {
        return false;
    }
    else
    {
        return true;
    }
}


void ShowTaskNumber(int numberOfTask)
{
    Console.WriteLine("\nЗадача номер " + numberOfTask);
}


// Task1______________________________________________
// Задача 64: Задайте значение N. Напишите программу,
// которая выведет все натуральные числа в промежутке от N до 1. Выполнить с помощью рекурсии.
ShowTaskNumber(1);
int userNumber = GetCheckedNumber("Задайте натуральное число от 1", "123456789");
int numberTill = 1;
string ShowNumbers(int numbertoBiggest, int numberToSmallest)
{
    if (numbertoBiggest == numberToSmallest)
    {
        return numberToSmallest.ToString();
    }
    return numbertoBiggest + ", " + ShowNumbers(numbertoBiggest - 1, numberToSmallest);
}
Console.WriteLine(ShowNumbers(userNumber, numberTill));
// ____________________________________________________

// Task2_______________________________________________
// Задача 66: Задайте значения M и N. Напишите программу, 
// которая найдёт сумму натуральных элементов в промежутке от M до N.
ShowTaskNumber(2);
string allowdChars = "1234567890-,";
int numberM = GetOkNumInclDouble("Задайте число M", allowdChars, true);
int numberN = GetOkNumInclDouble("Задайте число N", allowdChars, false);
while (numberM < 0 & numberN < 0 | numberM > numberN | numberM == numberN)
{
    string detailedInfo = "Получить натуральные числа не получится из-за следующих " +
    "возможных проблем:\nЧисло M больше, чем N; Оба числа отрицательные или одинаковые.\n" + 
    "В интервале нет натуральных чисел.\n";
    numberM = GetOkNumInclDouble(detailedInfo + "Задайте число M", allowdChars, true);
    numberN = GetOkNumInclDouble(detailedInfo + "Задайте число N", allowdChars, false);
}
int SumOfNumbersInInterval(int fromSmallest, int toBiggest)
{
    if (fromSmallest == toBiggest)
    {
        return toBiggest;
    }
    if (fromSmallest < 0)
    {
        return SumOfNumbersInInterval(fromSmallest + 1, toBiggest); //отрицательные числа не суммируем
    }
    else
    {
        return fromSmallest + SumOfNumbersInInterval(fromSmallest + 1, toBiggest);
    }
}
System.Console.WriteLine("Сумма натуральных чисел нашего отрезка от М до N:\nравна " +
SumOfNumbersInInterval(numberM, numberN) + " (суммируются только натуральные числа)");
// ____________________________________________________

// Task3_______________________________________________
// Напишите программу вычисления функции Аккермана с помощью рекурсии. 
// Даны два неотрицательных числа m и n.
ShowTaskNumber(3);
string infoTask3 = "Задайте положительное целое число ";
string allowdCharsTask3 = "1234567890";
int numM = GetCheckedNumber(infoTask3 + "M", allowdCharsTask3);
int numN = GetCheckedNumber(infoTask3 + "N", allowdCharsTask3);
int Akkerman(int m, int n)
{
    if (m == 0)
    {
        return n + 1;
    }
    else if (n == 0)
    {
        return Akkerman(m - 1, 1);
    }
    else
    {
        return Akkerman (m - 1, Akkerman (m, n - 1));
    }
}
System.Console.WriteLine("Вычисление функции Аккермана дало число " + 
Akkerman (numM, numN));