using System;

using System.Windows.Forms;

// Абстрактний базовий клас Body
public abstract class Body
{
    // Віртуальний метод для обчислення площі поверхні
    public abstract double CalculateSurfaceArea();

    // Віртуальний метод для обчислення об'єму
    public abstract double CalculateVolume();
}

// Похідний клас Parallelepiped
public class Parallelepiped : Body
{
    private double length;
    private double width;
    private double height;

    // Конструктор класу Parallelepiped
    public Parallelepiped(double l, double w, double h)
    {
        length = l;
        width = w;
        height = h;
    }

    // Перевизначення методу для обчислення площі поверхні
    public override double CalculateSurfaceArea()
    {
        return 2 * (length * width + width * height + height * length);
    }

    // Перевизначення методу для обчислення об'єму
    public override double CalculateVolume()
    {
        return length * width * height;
    }
}

// Похідний клас Ball
public class Ball : Body
{
    private double radius;

    // Конструктор класу Ball
    public Ball(double r)
    {
        radius = r;
    }

    // Перевизначення методу для обчислення площі поверхні
    public override double CalculateSurfaceArea()
    {
        return 4 * Math.PI * Math.Pow(radius, 2);
    }

    // Перевизначення методу для обчислення об'єму
    public override double CalculateVolume()
    {
        return (4 / 3) * Math.PI * Math.Pow(radius, 3);
    }
}

// Форма для виводу результатів
public class ResultsForm : Form
{
    public ResultsForm(string bodyType, double surfaceArea, double volume)
    {
        Label label = new Label();
        label.Text = $"{bodyType}:\nSurface Area: {surfaceArea}\nVolume: {volume}";
        label.AutoSize = true;

        Controls.Add(label);
    }
}

class Program
{
    static void Main()
    {
        // Приклад використання класів
        Parallelepiped parallelepiped = new Parallelepiped(3, 4, 5);
        Ball ball = new Ball(2);

        // Створення форми і виведення результатів
        ResultsForm resultsForm1 = new ResultsForm("Parallelepiped", parallelepiped.CalculateSurfaceArea(), parallelepiped.CalculateVolume());
        ResultsForm resultsForm2 = new ResultsForm("Ball", ball.CalculateSurfaceArea(), ball.CalculateVolume());

        // Запуск форм
        Application.Run(resultsForm1);
        Application.Run(resultsForm2);
    }
}