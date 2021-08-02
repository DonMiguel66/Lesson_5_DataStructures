namespace Lesson_5
{
    // Task2
    // Класс, содержащий метод расширения для строкового типа данных
    public static class StringExtention
    {
        public static int CharCount(this string str, char c)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    count++;
            }
            return count;
        }
    }
}
