# Factory Method
___

## Име на шаблона за дизайн:
Factory Method

## Кратко описание:
Шаблонът за дизайн "Factory Method" създава инстанции на наследени класове.

## Употреба:
Често използван, сравнително лесен за имплементация и удобен за централизиране на управлението на живота на обекти и избягване на повторение на код.

## Ниво на сложност:
1/5

## UML класова диаграма:
![Factory Method UML Class Diagram](http://download.codeplex.com/download?ProjectName=csharpdesignpatterns&DownloadId=236767 "Factory Method UML Class Diagram")

## Подробно обяснение
+ Абстрактният клас имплементира factory метод, който връща обект. Освен това той съдържа и метод, който валидира използвания шаблон за дизайн.
+ Всеки конкретен клас презаписва абстрактния factory метод и връща специфичен обект в зависимост от контекста.
+ В следващия пример шаблонът "Factory Method" е използван вътрешно, за да зададе стойност на свойство, но може да бъде използван и извън рамките на класа за създаване на обекти.

```cs
	public abstract class BookReader
    {
        public BookReader()
        {
            Book = BuyBook();
        }
 
        public Book Book { get; set; }
 
        public abstract Book BuyBook();

        
        public void DisplayOwnedBooks()
        {
            Console.WriteLine(Book.GetType().ToString());
        }
    }
 
    public class HorrorBookReader : BookReader
    {
        public override Book BuyBook()
        {
            return new Dracula();
        }
    }
 
    public class FantasyBookReader : BookReader
    {
        public override Book BuyBook()
        {
            return new LordOfTheRings();
        }
    }
 
    public class AdventureBookReader : BookReader
    {
        public override Book BuyBook()
        {
            return new TreasureIsland();
        }
    }
```

+ Абстрактният клас дефинира интерфейсът и структурата на класа за всички новосъздадени обекти чрез конкретните класове-създатели и техните factory методи.

```cs
    public abstract class Book
    {
    }
 
    public class Dracula : Book
    {
    }
 
    public class LordOfTheRings : Book
    {
    }
 
    public class TreasureIsland : Book
    {
    }
 
    public class Encyclopedia : Book
    {
    }
```

+ Съществува и възможността за създаване на спефично за езика C# решение, което използва шаблони.

```cs
    public Book BuyBook<T>()
        where T : Book, new()
    {
        return new T();
    }
```

+ При последната стъпка добавяме малко код, за да тестваме дизайна и самата имплементация на шаблона.

```cs
	private static void FactoryMethod()
    {
        var bookReaderList = new List<BookReader>();
 
        bookReaderList.Add(new AdventureBookReader());
        bookReaderList.Add(new FantasyBookReader());
        bookReaderList.Add(new HorrorBookReader());
 
        foreach (var reader in bookReaderList)
        {
            Console.WriteLine(reader.GetType() .ToString());
            // language agnostic solution
            reader.DisplayOwnedBooks();
 
            Console.WriteLine();
        }
 
        // C# specific solution using generics
        var genericReader = new AdventureBookReader();
        Book book = genericReader.BuyBook<Encyclopedia>();
        Console.WriteLine(book.GetType().ToString());
 
        Console.ReadKey();
    }
```