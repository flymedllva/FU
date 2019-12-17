// Разработать консольное приложение для ввода пароля и проверки его корректности.
class Program
{
    static void Main()
    {
        string пароль = "БИ", ответ;

        System.Console.Write("Введите пароль на вход в систему: ");
        ответ = System.Console.ReadLine();
        if (ответ == пароль)
            System.Console.WriteLine("Проходи!");
        else
            System.Console.WriteLine("Стоп! Хода нет!");
    }
}
