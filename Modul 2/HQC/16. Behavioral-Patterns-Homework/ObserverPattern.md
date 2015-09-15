# Observer Pattern
___

## Име на шаблона за дизайн:
Observer Pattern

## Определение:
Шаблонът за дизайн "Observer" зависимост един-към-много между обекти, така че когато един обект промени състоянието си, всички обекти, които са зависими от него, биват уведомени и автоматично се обновяват.

## Честота на употреба:
5/5

## UML класова диаграма:
![Observer Pattern UML Class Diagram](http://www.dofactory.com/images/diagrams/net/observer.gif "Observer Pattern UML Class Diagram")

## Участници

Класовете и обектите, които вземат участие в този шаблон за дизайн са следните:

 - Subject (Stock)
   * знае за своите наблюдатели; произволен брой обекти Observer могат да наблюдават
   * предоставя интерфейс за закачане и разкачане на обекти Observer
 - ConcreteSubject (IBM)
   * съхранява състояние на интерест към ConcreteObserver
   * уведомява своите наблюдатели при евентуална негова промяна на състоянието
 - Observer  (IInvestor)
   * дефинира интерфейса за обновяване на обекти, които трябва да бъдат уведоми при евентуална промяна на обекта на наблюдение
 - ConcreteObserver (Investor)
   * поддържа референция към обекта ConcreteSubject
   * съхранява състояние, което трябва да е консистентно с това на обекта на наблюдение
   * имплементира Observer интерфейса за обновяване, за да поддържа консистентно състояние с това на обекта на наблюдение
  
## Структурен код

```cs
	namespace DoFactory.GangOfFour.Observer.Structural
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for Structural
    ///     Observer Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Configure Observer pattern
            var s = new ConcreteSubject();

            s.Attach(new ConcreteObserver(s, "X"));
            s.Attach(new ConcreteObserver(s, "Y"));
            s.Attach(new ConcreteObserver(s, "Z"));

            // Change subject and notify observers
            s.SubjectState = "ABC";
            s.Notify();

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Subject' abstract class
    /// </summary>
    internal abstract class Subject
    {
        private readonly List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var o in this._observers)
            {
                o.Update();
            }
        }
    }

    /// <summary>
    ///     The 'ConcreteSubject' class
    /// </summary>
    internal class ConcreteSubject : Subject
    {
        // Gets or sets subject state
        public string SubjectState { get; set; }
    }

    /// <summary>
    ///     The 'Observer' abstract class
    /// </summary>
    internal abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    ///     The 'ConcreteObserver' class
    /// </summary>
    internal class ConcreteObserver : Observer
    {
        private readonly string _name;
        private string _observerState;

        // Constructor
        public ConcreteObserver(
            ConcreteSubject subject, string name)
        {
            this.Subject = subject;
            this._name = name;
        }

        public override void Update()
        {
            this._observerState = this.Subject.SubjectState;
            Console.WriteLine("Observer {0}'s new state is {1}", this._name, this._observerState);
        }

        // Gets or sets subject
        public ConcreteSubject Subject { get; set; }
    }
}

// Output:
// =======
// Iterating over collection:
// Observer X's new state is ABC
// Observer Y's new state is ABC
// Observer Z's new state is ABC
```

## Пример от реалния живот

```cs
	namespace DoFactory.GangOfFour.Observer.RealWorld
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///     MainApp startup class for Real-World
    ///     Observer Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Create IBM stock and attach investors
            var ibm = new IBM("IBM", 120.00);
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));

            // Fluctuating prices will notify investors
            ibm.Price = 120.10;
            ibm.Price = 121.00;
            ibm.Price = 120.50;
            ibm.Price = 120.75;

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Subject' abstract class
    /// </summary>
    internal abstract class Stock
    {
        private readonly List<IInvestor> _investors = new List<IInvestor>();
        private double _price;

        // Constructor
        public Stock(string symbol, double price)
        {
            this.Symbol = symbol;
            this._price = price;
        }

        // Gets or sets the price
        public double Price
        {
            get { return this._price; }
            set
            {
                if (this._price != value)
                {
                    this._price = value;
                    this.Notify();
                }
            }
        }

        // Gets the symbol
        public string Symbol { get; private set; }

        public void Attach(IInvestor investor)
        {
            this._investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            this._investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (var investor in this._investors)
            {
                investor.Update(this);
            }

            Console.WriteLine("");
        }
    }

    /// <summary>
    ///     The 'ConcreteSubject' class
    /// </summary>
    internal class IBM : Stock
    {
        // Constructor
        public IBM(string symbol, double price)
            : base(symbol, price)
        {
        }
    }

    /// <summary>
    ///     The 'Observer' interface
    /// </summary>
    internal interface IInvestor
    {
        void Update(Stock stock);
    }

    /// <summary>
    ///     The 'ConcreteObserver' class
    /// </summary>
    internal class Investor : IInvestor
    {
        private readonly string _name;

        // Constructor
        public Investor(string name)
        {
            this._name = name;
        }

        // Gets or sets the stock
        public Stock Stock { get; set; }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " +
                              "change to {2:C}", this._name, stock.Symbol, stock.Price);
        }
    }
}

// Output:
// =======
// Notified Sorros of IBM's change to $120.10
// Notified Berkshire of IBM's change to $120.10
// 
// Notified Sorros of IBM's change to $121.00
// Notified Berkshire of IBM's change to $121.00
// 
// Notified Sorros of IBM's change to $120.50
// Notified Berkshire of IBM's change to $120.50
// 
// Notified Sorros of IBM's change to $120.75
// Notified Berkshire of IBM's change to $120.75
```