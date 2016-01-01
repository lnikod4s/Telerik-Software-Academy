# Abstract Factory
___

## Име на шаблона за дизайн:
Abstract factory pattern

## Кратко описание:
Шаблонът за дизайн "Abstract Factory" създава инстанции на класове, които принадлежат към различни фамилии.

## Ниво на сложност:
1/5

## UML класова диаграма:
![Abstract Factory UML Class Diagram](http://download.codeplex.com/download?ProjectName=csharpdesignpatterns&DownloadId=236763 "Abstract Factory UML Class Diagram")

## Подробно обяснение
+ Класът Abstract Factory дефинира конкретните абстрактни методи, които трябва да бъдат имплементирани от конкретните factory класове. Той изпълнява ролята на интерфейс и дефиниция на договора.
+ Конкретните factory класове съдържат в себе си реалната имплементация на класовете, които биват създадени по време на изпълнение на програмата.
+ Важно е да се отбележи, че методите, които връщат стойност, също са дефинирани от абстрактни класове, което от своя страна позволява голяма гъвкавост и независимост, водейки до методи, които трябва да бъдат имплементирани само веднъж.
+ Върнатите класове обаче са специфични за всеки конкретен factory клас (вж. имплементацията по-долу).

```cs
public abstract class CarFactory
    {
        public abstract SportsCar CreateSportsCar();
        public abstract FamilyCar CreateFamilyCar();
    }
 
    public class AudiFactory : CarFactory
    {
        public override SportsCar CreateSportsCar()
        {
            return new AudiSportsCar();
        }
 
        public override FamilyCar CreateFamilyCar()
        {
            return new AudiFamilyCar();
        }
    }
 
    public class MercedesFactory : CarFactory
    {
        public override SportsCar CreateSportsCar()
        {
            return new MercedesSportsCar();
        }
 
        public override FamilyCar CreateFamilyCar()
        {
            return new MercedesFamilyCar();
        }
    }
```

+ Тук ясно се виждат абстрактните класове, които се използват по време на процеса на създаването на новите класове.
+ Стъпвайки върху абстрактните класове, се създават реални примерни класове, които биват инстанцирани по време на изпълнение на програмата в зависимост от конкретните factory класове, които ги създават.

```cs
    public abstract class SportsCar
    {
    }
 
    public abstract class FamilyCar
    {
        public abstract void Speed(SportsCar abstractFamilyCar);
    }
 
    class MercedesSportsCar : SportsCar
    {
    }
    
    class MercedesFamilyCar : FamilyCar
    {
        public override void Speed(SportsCar abstractSportsCar)
        {
            Console.WriteLine(GetType().Name + " is slower than "
                + abstractSportsCar.GetType().Name);
        }
    }
 
    class AudiSportsCar : SportsCar
    {
    }
 
    class AudiFamilyCar : FamilyCar
    {
        public override void Speed(SportsCar abstractSportsCar)
        {
            Console.WriteLine(GetType().Name + " is slower than "
                + abstractSportsCar.GetType().Name);
        }
    }
```

+ При имплементацията на асоциациите на класа Driver абстрактният factory клас и абстрактните класове може да бъде използван стандартния за езика C# агностичен подход чрез употребата единствено на частни членове-променливи, което от своя страна е най-ефикасния начин за спестяване на памет.

```cs
	public class Driver
    {
        private SportsCar _sportsCar;
        private FamilyCar _familyCar;
 
        public Driver(CarFactory carFactory)
        {
            _sportsCar = carFactory.CreateSportsCar();
            _familyCar = carFactory.CreateFamilyCar();
        }
 
        public void CompareSpeed()
        {
            _familyCar.Speed(_sportsCar);
        }
    }
```

+ Възможен е и друг подход, специфичен за езика C#, а именно подход, при който всичко е обвито в частни свойства. Това позволява добавянето на допълнителна логика при достъп или промяна на частните членове-променливи, но може да се окаже прекалено (това е един от ефектите, който се получава след автоматичното генериране при моделиране на класови диаграми).

```cs
	public class Driver
    {
        private CarFactory _carFactory;
        private SportsCar _sportsCar;
        private FamilyCar _familyCar;
 
        public Driver(CarFactory carFactory)
        {
            CarFactory = carFactory;
            SportsCar = CarFactory.CreateSportsCar();
            FamilyCar = CarFactory.CreateFamilyCar();
        }
 
        private CarFactory CarFactory
        {
            get { return _carFactory; }
            set { _carFactory = value; } 
        }
 
        private SportsCar SportsCar
        {
            get { return _sportsCar; }
            set { _sportsCar = value; } 
        }
 
        private FamilyCar FamilyCar
        {
            get { return _familyCar; }
            set { _familyCar = value; } 
        }
 
        public void CompareSpeed()
        {
            FamilyCar.Speed(SportsCar);
        }
    }
```

+ Друг често срещан подход при езика C# е използването на шаблонни класове за създаване на обекти.

```cs
	public class GenericFactory<T> 
        where T : new()
    {
        public T CreateObject()
        {
            return new T();
        }
    }
```

+ При последната стъпка добавяме малко код, за да тестваме дизайна и самата имплементация на шаблона.

```cs
	public static void AbstractFactory()
    {
        // Language agnostic version
        CarFactory audiFactory = new AudiFactory();
        Driver driver1 = new Driver(audiFactory);
        driver1.CompareSpeed(); ;
 
        CarFactory mercedesFactory = new MercedesFactory();
        Driver driver2 = new Driver(mercedesFactory);
        driver2.CompareSpeed();
 
        // C# specific version using generics
        var factory = new GenericFactory<MercedesSportsCar>();
        var mercedesSportsCar = factory.CreateObject();
        Console.WriteLine(mercedesSportsCar.GetType().ToString());
 
        Console.ReadKey();
    }
```