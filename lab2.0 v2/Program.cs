using System;

class ModelWindow
{
    private string title;
    private int x;
    private int y;
    private int width;
    private int height;
    private string color;
    private bool isVisible;
    private bool hasBorder;

    public ModelWindow(string title, int x, int y, int width, int height, string color, bool isVisible, bool hasBorder)
    {
        this.title = title;
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.color = color;
        this.isVisible = isVisible;
        this.hasBorder = hasBorder;
    }

    public static ModelWindow operator +(ModelWindow window, int dx)
    {
        if (window.x + dx >= 0 && window.x + dx + window.width <= Console.WindowWidth)
        {
            window.x += dx;
        }
        return window;
    }

    public static ModelWindow operator -(ModelWindow window, int dx)
    {
        if (window.x - dx >= 0 && window.x - dx + window.width <= Console.WindowWidth)
        {
            window.x -= dx;
        }
        return window;
    }

    public static ModelWindow operator ++(ModelWindow window)
    {
        if (window.y + 1 >= 0 && window.y + 1 + window.height <= Console.WindowHeight)
        {
            window.y += 1;
        }
        return window;
    }

    public static ModelWindow operator --(ModelWindow window)
    {
        if (window.y - 1 >= 0 && window.y - 1 + window.height <= Console.WindowHeight)
        {
            window.y -= 1;
        }
        return window;
    }

    public int X
    {
        get { return x; }
        set
        {
            if (value >= 0 && value + width <= Console.WindowWidth)
            {
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            if (value >= 0 && value + height <= Console.WindowHeight)
            {
                y = value;
            }
        }
    }

    public void PrintWindowInfo()
    {
        
        Console.WriteLine($"Позиция: ({x}, {y})");
        Console.WriteLine($"Размер: {width}x{height}");
        Console.WriteLine($"Цвет: {color}");
        Console.WriteLine($"Видимость: {(isVisible ? "Видимое" : "Скрытое")}");
        Console.WriteLine($"Граница: {(hasBorder ? "С границей" : "Без границы")}");
    }
}

class Program
{
    static void Main()
    {
        ModelWindow window = new ModelWindow("Тестовое окно", 5, 5, 20, 10, "Синий", true, true);
        window.PrintWindowInfo();

        Console.WriteLine();

        window += 5;  
        window--;     
        window.X = 15; 
        window.PrintWindowInfo();
    }
}
