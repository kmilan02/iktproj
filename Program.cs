using System.Drawing;

Random rnd = new Random();

void KigyoStart(List<Point> kigyo)
{
    kigyo.Add(new Point(58, 14));
    kigyo.Add(new Point(59, 14));
    kigyo.Add(new Point(60, 14));
    kigyo.Add(new Point(61, 14));
    kigyo.Add(new Point(62, 14));
}

void KigyoKirajzolas(List<Point> kigyo)
{
    for (int i = 0; i < kigyo.Count; i++)
    {
        Console.SetCursorPosition(kigyo[i].X, kigyo[i].Y);
        if (i == 0)
        {
            Console.Write("@");
        }
        else if (i == kigyo.Count - 1)
        {
            Console.Write("o");
        }
        else
        {
            Console.Write("O");
        }
    }
}

void Alma(char[,] screen, int db)
{
    int szamlalo = 0;
    int maxX = screen.GetLength(0);
    int maxY = screen.GetLength(1);
    int x, y;
    Console.ForegroundColor = ConsoleColor.DarkRed;
    do
    {
        x = rnd.Next(1, maxX);
        y = rnd.Next(1, maxY - 1);
        if(screen[x, y] == 0)
        {
            screen[x, y] = 'A';
            Console.SetCursorPosition(x, y);
            Console.Write("A");
            szamlalo++;
        }
    } while (szamlalo != db);
    Console.ResetColor();
}

void Kirajzolas(char[,] screen)
{
    int x = screen.GetLength(0);
    int y = screen.GetLength(1);
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            Console.SetCursorPosition(i, j);
            Console.Write(screen[i, j]);
        }
    }
}
void PalyaKeszites(char[,] screen)
{
    int x = screen.GetLength(0);
    int y = screen.GetLength(1);
    screen[0, 0] = '╔';
    for (int i = 0; i < x - 2; i++)
    {
        screen[i + 1, 0] = '═';
    }
    screen[x - 1, 0] = '╗';
    for (int i = 0; i < y - 3; i++)
    {
        screen[0, i + 1] = '║';
        screen[x - 1, i + 1] = '║';
    }
    screen[0, y - 2] = '╚';
    for (int i = 0; i < x - 2; i++)
    {
        screen[i + 1, y - 2] = '═';
    }
    screen[x - 1, y - 2] = '╝';
}

void SzamKiiras()
{
    while (true)
    {
        Console.SetCursorPosition(20, 20);
        Console.Write(rnd.Next(11232));
    }
}

void KigyoMozgatas(Thread szal)
{
    ConsoleKeyInfo keyInfo;
    do
    {
        keyInfo = Console.ReadKey(true);
        Console.SetCursorPosition(50, 10);
        Console.Write(keyInfo.Key);
    } while (keyInfo.Key != ConsoleKey.Enter);
}

List<Point> kigyo = new List<Point>();
int ScreenX = Console.WindowWidth;
int ScreenY = Console.WindowHeight;
char[,] screen = new char[ScreenX, ScreenY];
PalyaKeszites(screen);
Kirajzolas(screen);
KigyoStart(kigyo);
KigyoKirajzolas(kigyo);
Alma(screen, 5);

string inputString = String.Empty;
Thread szal1 = new Thread(SzamKiiras);
Thread szal2 = new Thread(() => KigyoMozgatas(szal1));
szal1.Start();
szal2.Start();
szal1.Join();
szal2.Join();

Console.ReadKey();