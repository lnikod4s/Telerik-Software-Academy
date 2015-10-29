# Chain of Responsibility
___

## Име на шаблона за дизайн:
Chain of Responsibility

## Определение:
Шаблонът за дизайн "Chain of Responsibility" предотвратява директното обвързване на адресанта на дадена заявка/съобщение с адресата. Заявката/съобщението бива предадено по веригата, докато не бъде намерен обект, който може да отговори адекватно.

## Честота на употреба:
2/5

## UML класова диаграма:
![Chain of Responsibility UML Class Diagram](http://www.dofactory.com/images/diagrams/net/chain.gif "Chain of Responsibility UML Class Diagram")

## Участници

Класовете и обектите, които вземат участие в този шаблон за дизайн са следните:

 - Handler (Approver)
   * дефинира интерфейса за отговор на дадена заявка/съобщение
   * (опционално) имплементира линк за положителен отговор на заявката/съобщението
 - ConcreteHandler   (Director, VicePresident, President)
   * отговаря на заявката/съобщението, за което е отговорен
   * може да достъпва положителния отговор
   * ако може да отговори адекватно на заявката/съобщението, го прави; иначе го препраща по-нататък във веригата
 - Client   (ChainApp)
   * изпраща заявката/съобщението по веригата
  
## Структурен код

```cs
	namespace DoFactory.GangOfFour.Chain.Structural
{
    using System;

    /// <summary>
    ///     MainApp startup class for Structural
    ///     Chain of Responsibility Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Setup Chain of Responsibility
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request
            int[] requests = {2, 5, 14, 22, 18, 3, 27, 20};

            foreach (var request in requests)
            {
                h1.HandleRequest(request);
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Handler' abstract class
    /// </summary>
    internal abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    /// <summary>
    ///     The 'ConcreteHandler1' class
    /// </summary>
    internal class ConcreteHandler1 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (this.successor != null)
            {
                this.successor.HandleRequest(request);
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteHandler2' class
    /// </summary>
    internal class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (this.successor != null)
            {
                this.successor.HandleRequest(request);
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteHandler3' class
    /// </summary>
    internal class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}",
                    this.GetType().Name, request);
            }
            else if (this.successor != null)
            {
                this.successor.HandleRequest(request);
            }
        }
    }
}

// Output:
// =======
// ConcreteHandler1 handled request 2
// ConcreteHandler1 handled request 5
// ConcreteHandler2 handled request 14
// ConcreteHandler3 handled request 22
// ConcreteHandler2 handled request 18
// ConcreteHandler1 handled request 3
// ConcreteHandler3 handled request 27
// ConcreteHandler3 handled request 20
```

## Пример от реалния живот

```cs
	namespace DoFactory.GangOfFour.Chain.RealWorld
{
    using System;

    /// <summary>
    ///     MainApp startup class for Real-World
    ///     Chain of Responsibility Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Setup Chain of Responsibility
            Approver larry = new Director();
            Approver sam = new VicePresident();
            Approver tammy = new President();

            larry.SetSuccessor(sam);
            sam.SetSuccessor(tammy);

            // Generate and process purchase requests
            var p = new Purchase(2034, 350.00, "Assets");
            larry.ProcessRequest(p);

            p = new Purchase(2035, 32590.10, "Project X");
            larry.ProcessRequest(p);

            p = new Purchase(2036, 122100.00, "Project Y");
            larry.ProcessRequest(p);

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Handler' abstract class
    /// </summary>
    internal abstract class Approver
    {
        protected Approver successor;

        public void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }

        public abstract void ProcessRequest(Purchase purchase);
    }

    /// <summary>
    ///     The 'ConcreteHandler' class
    /// </summary>
    internal class Director : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 10000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (this.successor != null)
            {
                this.successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteHandler' class
    /// </summary>
    internal class VicePresident : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 25000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else if (this.successor != null)
            {
                this.successor.ProcessRequest(purchase);
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteHandler' class
    /// </summary>
    internal class President : Approver
    {
        public override void ProcessRequest(Purchase purchase)
        {
            if (purchase.Amount < 100000.0)
            {
                Console.WriteLine("{0} approved request# {1}",
                    this.GetType().Name, purchase.Number);
            }
            else
            {
                Console.WriteLine(
                    "Request# {0} requires an executive meeting!",
                    purchase.Number);
            }
        }
    }

    /// <summary>
    ///     Class holding request details
    /// </summary>
    internal class Purchase
    {
        // Constructor
        public Purchase(int number, double amount, string purpose)
        {
            this.Number = number;
            this.Amount = amount;
            this.Purpose = purpose;
        }

        // Gets or sets purchase number
        public int Number { get; set; }

        // Gets or sets purchase amount
        public double Amount { get; set; }

        // Gets or sets purchase purpose
        public string Purpose { get; set; }
    }
}

// Output:
// =======
// Director Larry approved request# 2034
// President Tammy approved request# 2035
// Request# 2036 requires an executive meeting!
```