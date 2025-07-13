namespace TheLockedDoor;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Set the door's initial numeric passcode: ");

        int initialCode = getCode();

        var door = new Door(initialCode);

        while (true)
        {
            Console.WriteLine($"The door is currently {door.State}");
            Console.Write("Choose a command ('open', 'close', 'lock', 'unlock', 'change code'): ");
            string? input = Console.ReadLine();

            if (input == null) continue;

            switch (input)
            {
                case "open":
                    door.Open();
                    break;
                case "close":
                    door.Close();
                    break;
                case "lock":
                    door.Lock();
                    break;
                case "unlock":
                    Console.Write("Passcode: ");
                    var code = getCode();
                    door.Unlock(code);
                    break;
                case "change code":
                    Console.Write("Current passcode: ");
                    var currentCode = getCode();
                    Console.Write("New Passcode: ");
                    var newCode = getCode();
                    door.ChangeCode(currentCode, newCode);
                    break;
            }
        }
    }

    static int getCode()
    {
        return Convert.ToInt32(Console.ReadLine());
    }
}

class Door
{
    private int _code;
    public DoorState State { get; internal set; }

    public Door(int code)
    {
        _code = code;
        State = DoorState.Locked;
    }

    public void Open()
    {
        State = State == DoorState.Closed ? DoorState.Open : State;
    }

    public void Close()
    {
        State = State == DoorState.Open ? DoorState.Closed : State;
    }

    public void Lock()
    {
        State = State == DoorState.Closed ? DoorState.Locked : State;
    }

    public void Unlock(int code)
    {
        State = State == DoorState.Locked && code == _code ? DoorState.Closed : State;
    }

    public void ChangeCode(int currentCode, int newCode)
    {
        _code = currentCode == _code ? newCode : _code;
    }
}

enum DoorState
{
    Open,
    Closed,
    Locked,
}