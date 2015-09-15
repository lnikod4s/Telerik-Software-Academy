# Command Pattern
___

## Име на шаблона за дизайн:
Command Pattern

## Определение:
Шаблонът за дизайн "Command" капсулира дадена заявка като обект, което позволява параметризирането на клиенти с различни заявки, поддържайки необратими операции.

## Честота на употреба:
4/5

## UML класова диаграма:
![Command Pattern UML Class Diagram](http://www.dofactory.com/images/diagrams/net/command.gif "Command Pattern UML Class Diagram")

## Участници

Класовете и обектите, които вземат участие в този шаблон за дизайн са следните:

 - Command (Command)
   * дефинира интерфейса за отговор на дадена заявка/съобщение
 - ConcreteCommand (CalculatorCommand)
   * дефинира връзка между адресата и самото действие
   * имплементира Execute чрез извикване на съответната операция от адресата
 - Client (CommandApp)
   * създава ConcreteCommand обект и инициалира неговия адресат
 - Invoker (User)
   * задава командата за прилагане на заявката
 - Receiver  (Calculator)
   * знае кои операции да приложи към заявката
  
## Структурен код

```cs
	namespace DoFactory.GangOfFour.Command.Structural
{
    using System;

    /// <summary>
    ///     MainApp startup class for Structural
    ///     Command Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create receiver, command, and invoker
            var receiver = new Receiver();
            Command command = new ConcreteCommand(receiver);
            var invoker = new Invoker();

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Command' abstract class
    /// </summary>
    internal abstract class Command
    {
        protected Receiver receiver;

        // Constructor
        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public abstract void Execute();
    }

    /// <summary>
    ///     The 'ConcreteCommand' class
    /// </summary>
    internal class ConcreteCommand : Command
    {
        // Constructor
        public ConcreteCommand(Receiver receiver) :
            base(receiver)
        {
        }

        public override void Execute()
        {
            this.receiver.Action();
        }
    }

    /// <summary>
    ///     The 'Receiver' class
    /// </summary>
    internal class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    ///     The 'Invoker' class
    /// </summary>
    internal class Invoker
    {
        private Command _command;

        public void SetCommand(Command command)
        {
            this._command = command;
        }

        public void ExecuteCommand()
        {
            this._command.Execute();
        }
    }
}

// Output:
// =======
// Called Receiver.Action()
```

## Пример от реалния живот

```cs
	namespace DoFactory.GangOfFour.Command.RealWorld
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for Real-World
    ///     Command Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create user and let her compute
            var user = new User();

            // User presses calculator buttons
            user.Compute('+', 100);
            user.Compute('-', 50);
            user.Compute('*', 10);
            user.Compute('/', 2);

            // Undo 4 commands
            user.Undo(4);

            // Redo 3 commands
            user.Redo(3);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Command' abstract class
    /// </summary>
    internal abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }

    /// <summary>
    ///     The 'ConcreteCommand' class
    /// </summary>
    internal class CalculatorCommand : Command
    {
        private readonly Calculator _calculator;
        private int _operand;
        private char _operator;

        // Constructor
        public CalculatorCommand(Calculator calculator,
            char @operator, int operand)
        {
            this._calculator = calculator;
            this._operator = @operator;
            this._operand = operand;
        }

        // Gets operator
        public char Operator
        {
            set { this._operator = value; }
        }

        // Get operand
        public int Operand
        {
            set { this._operand = value; }
        }

        // Execute new command
        public override void Execute()
        {
            this._calculator.Operation(this._operator, this._operand);
        }

        // Unexecute last command
        public override void UnExecute()
        {
            this._calculator.Operation(this.Undo(this._operator), this._operand);
        }

        // Returns opposite operator for given operator
        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    throw new
                        ArgumentException("@operator");
            }
        }
    }

    /// <summary>
    ///     The 'Receiver' class
    /// </summary>
    internal class Calculator
    {
        private int _curr;

        public void Operation(char @operator, int operand)
        {
            switch (@operator)
            {
                case '+':
                    this._curr += operand;
                    break;
                case '-':
                    this._curr -= operand;
                    break;
                case '*':
                    this._curr *= operand;
                    break;
                case '/':
                    this._curr /= operand;
                    break;
            }
            Console.WriteLine(
                "Current value = {0,3} (following {1} {2})", this._curr, @operator, operand);
        }
    }

    /// <summary>
    ///     The 'Invoker' class
    /// </summary>
    internal class User
    {
        // Initializers
        private readonly Calculator _calculator = new Calculator();
        private readonly List<Command> _commands = new List<Command>();
        private int _current;

        public void Redo(int levels)
        {
            Console.WriteLine("\n---- Redo {0} levels ", levels);
            // Perform redo operations
            for (var i = 0; i < levels; i++)
            {
                if (this._current < this._commands.Count - 1)
                {
                    var command = this._commands[this._current++];
                    command.Execute();
                }
            }
        }

        public void Undo(int levels)
        {
            Console.WriteLine("\n---- Undo {0} levels ", levels);
            // Perform undo operations
            for (var i = 0; i < levels; i++)
            {
                if (this._current > 0)
                {
                    var command = this._commands[--this._current];
                    command.UnExecute();
                }
            }
        }

        public void Compute(char @operator, int operand)
        {
            // Create command operation and execute it
            Command command = new CalculatorCommand(this._calculator, @operator, operand);
            command.Execute();

            // Add command to undo list
            this._commands.Add(command);
            this._current++;
        }
    }
}

// Output:
// =======
// Current value = 100 (following + 100)
// Current value =  50 (following - 50)
// Current value = 500 (following * 10)
// Current value = 250 (following / 2)
// 
// ---- Undo 4 levels
// Current value = 500 (following * 2)
// Current value =  50 (following / 10)
// Current value = 100 (following + 50)
// Current value =   0 (following - 100)
// 
// ---- Redo 3 levels
// Current value = 100 (following + 100)
// Current value =  50 (following - 50)
// Current value = 500 (following * 10)
```