# Iterator Pattern
___

## Име на шаблона за дизайн:
Iterator Pattern

## Определение:
Шаблонът за дизайн "Iterator" предоставя начин за последователен достъп до елементите на изброим обект чрез излагане на съответната им репрезентация.

## Честота на употреба:
5/5

## UML класова диаграма:
![Iterator Pattern UML Class Diagram](http://www.dofactory.com/images/diagrams/net/iterator.gif "Iterator Pattern UML Class Diagram")

## Участници

Класовете и обектите, които вземат участие в този шаблон за дизайн са следните:

 - Iterator (AbstractIterator)
   * дефинира интерфейса за достъп и обикаляне на елементи
 - ConcreteIterator (Iterator)
   * имплементира интерфейса Iterator
   * пази конкретната позиция при обикаляне на елементите
 - Aggregate (AbstractCollection)
   * дефинира интерфейса за създаване на самия обект Iterator
 - ConcreteAggregate (Collection)
   * имплементира самия Iterator интерфейс, който връща инстанция на обекта ConcreteIterator
  
## Структурен код

```cs
	namespace DoFactory.GangOfFour.Iterator.Structural
{
    using System;
    using System.Collections;

    /// <summary>
    ///     MainApp startup class for Structural
    ///     Iterator Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            var a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate
            var i = new ConcreteIterator(a);

            Console.WriteLine("Iterating over collection:");

            var item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     The 'Aggregate' abstract class
    /// </summary>
    internal abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    /// <summary>
    ///     The 'ConcreteAggregate' class
    /// </summary>
    internal class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();

        // Gets item count
        public int Count
        {
            get { return this._items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return this._items[index]; }
            set { this._items.Insert(index, value); }
        }

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
    }

    /// <summary>
    ///     The 'Iterator' abstract class
    /// </summary>
    internal abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    /// <summary>
    ///     The 'ConcreteIterator' class
    /// </summary>
    internal class ConcreteIterator : Iterator
    {
        private readonly ConcreteAggregate _aggregate;
        private int _current;

        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        // Gets first iteration item
        public override object First()
        {
            return this._aggregate[0];
        }

        // Gets next iteration item
        public override object Next()
        {
            object ret = null;
            if (this._current < this._aggregate.Count - 1)
            {
                ret = this._aggregate[++this._current];
            }

            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem()
        {
            return this._aggregate[this._current];
        }

        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return this._current >= this._aggregate.Count;
        }
    }
}

// Output:
// =======
// Iterating over collection:
// Item A
// Item B
// Item C
// Item D
```

## Пример от реалния живот

```cs
	namespace DoFactory.GangOfFour.Iterator.RealWorld
{
    using System;
    using System.Collections;

    /// <summary>
    ///     MainApp startup class for Real-World
    ///     Iterator Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        ///     Entry point into console application.
        /// </summary>
        private static void Main()
        {
            // Build a collection
            var collection = new Collection();
            collection[0] = new Item("Item 0");
            collection[1] = new Item("Item 1");
            collection[2] = new Item("Item 2");
            collection[3] = new Item("Item 3");
            collection[4] = new Item("Item 4");
            collection[5] = new Item("Item 5");
            collection[6] = new Item("Item 6");
            collection[7] = new Item("Item 7");
            collection[8] = new Item("Item 8");

            // Create iterator
            var iterator = new Iterator(collection);

            // Skip every other item
            iterator.Step = 2;

            Console.WriteLine("Iterating over collection:");

            for (var item = iterator.First();
                !iterator.IsDone;
                item = iterator.Next())
            {
                Console.WriteLine(item.Name);
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    ///     A collection item
    /// </summary>
    internal class Item
    {
        // Constructor
        public Item(string name)
        {
            this.Name = name;
        }

        // Gets name
        public string Name { get; private set; }
    }

    /// <summary>
    ///     The 'Aggregate' interface
    /// </summary>
    internal interface IAbstractCollection
    {
        Iterator CreateIterator();
    }

    /// <summary>
    ///     The 'ConcreteAggregate' class
    /// </summary>
    internal class Collection : IAbstractCollection
    {
        private readonly ArrayList _items = new ArrayList();

        // Gets item count
        public int Count
        {
            get { return this._items.Count; }
        }

        // Indexer
        public object this[int index]
        {
            get { return this._items[index]; }
            set { this._items.Add(value); }
        }

        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
    }

    /// <summary>
    ///     The 'Iterator' interface
    /// </summary>
    internal interface IAbstractIterator
    {
        bool IsDone { get; }
        Item CurrentItem { get; }
        Item First();
        Item Next();
    }

    /// <summary>
    ///     The 'ConcreteIterator' class
    /// </summary>
    internal class Iterator : IAbstractIterator
    {
        private readonly Collection _collection;
        private int _current;
        private int _step = 1;

        // Constructor
        public Iterator(Collection collection)
        {
            this._collection = collection;
        }

        // Gets or sets stepsize
        public int Step
        {
            get { return this._step; }
            set { this._step = value; }
        }

        // Gets first item
        public Item First()
        {
            this._current = 0;
            return this._collection[this._current] as Item;
        }

        // Gets next item
        public Item Next()
        {
            this._current += this._step;
            if (!this.IsDone)
                return this._collection[this._current] as Item;
            return null;
        }

        // Gets current iterator item
        public Item CurrentItem
        {
            get { return this._collection[this._current] as Item; }
        }

        // Gets whether iteration is complete
        public bool IsDone
        {
            get { return this._current >= this._collection.Count; }
        }
    }
}

// Output:
// =======
// Iterating over collection:
// Item 0
// Item 2
// Item 4
// Item 6
// Item 8
```