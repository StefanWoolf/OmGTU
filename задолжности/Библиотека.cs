using System;

class Book
{
    private string Author = "";
    private string Bookname = "";
    private int Year;
    private int[] Dates;

    public Book(string author, string bookname, int year, int[] dates)
    {
        this.Author = author;
        this.Bookname = bookname;
        this.Year = year;
        this.Dates = dates;
    }

    public void Vidacha()
    {
        for (int i = 0; i < this.Dates.Length; i++)
        {
            Console.WriteLine($"'{this.Bookname}', года {this.Year}, автора {this.Author}, была выдана в {this.Dates[i]} месяце");
        }
    }

    public void BigYear(int inputYear)
    {
        if (this.Year > inputYear)
        {
            Console.WriteLine($"'{this.Bookname}', книга в которой год издания больше заданного ({inputYear}) года");
        }
    }

    public void AuthorGive(string AuthorGive)
    {
        if (this.Author == AuthorGive)
        {
            Console.WriteLine($"'{this.Bookname}', книга заданного автора {AuthorGive}");
        }
    }

    public static int GetInputYear()
    {
        Console.WriteLine("Введите год: ");
        int inputYear;
        while (!int.TryParse(Console.ReadLine(), out inputYear))
        {
            Console.WriteLine("Введите корректный год: ");
        }
        return inputYear;
    }

    public static string GetAuthorGive()
    {
        Console.WriteLine("Введите имя автора: ");
        return Console.ReadLine();
    }
}

class Andrey_and_Yasha
{
    static void Main()
    {
        Book[] books =
        {
            new Book("Сидоров", "Весна", 1968, new int[] {1, 2, 3}),
            new Book("Иванов", "Лето", 1975, new int[] {4, 5, 6}),
            new Book("Петров", "Осень", 1982, new int[] {7, 8, 9}),
        };


        for (int j = 0; j < books.Length; j++)
        {
            books[j].Vidacha();
        }

        int inputYear = Book.GetInputYear();
        for (int x = 0; x < books.Length; x++)
        {
            books[x].BigYear(inputYear);
        }


        string AuthorGive = Book.GetAuthorGive();
        for (int y = 0; y < books.Length; y++)
        {
            books[y].AuthorGive(AuthorGive);
        }
    }
}
