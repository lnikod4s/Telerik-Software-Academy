# Singleton Pattern
___

## Име на шаблона за дизайн:
Adapter Pattern

## Кратко описание:
Шаблонът за дизайн "Adapter Pattern" подбира членове-променливи от класове с различни интерфейси.

## Употреба:
Този шаблон е често използван и лесен за имплементация, изключително удобен при работа с класове, които имат несъвместими интерфейси.

## Ниво на сложност:
1/5

## UML класова диаграма:
![Adapter Pattern UML Class Diagram](http://download.codeplex.com/download?ProjectName=csharpdesignpatterns&DownloadId=260121 "Adapter Pattern UML Class Diagram")

## Подробно обяснение
+ Класът TradingDataImporter симулира клиентско поведение с интерфейс Connector.

```cs
	public class TradingDataImporter
    {
        public void ImportData(Connector connector)
        {
            connector.GetData();
        }
    }
```

+ Абстрактният клас Adapter дефинира интерфейса, който клиента познава и с който може да работи.
+ Конкретните Adapter класове интерфейса на несъвместими класове в интерфейс, който клиента разпознава. Те позволяват на несъвместими интерфейси да работят заедно въпреки очевидните различия помежду им.

```cs
    public abstract class Connector
    {
        public abstract void GetData();
    }
 
    public class DatabaseConnector : Connector
    {
        public override void GetData()
        {
            var databaseHelper = new DatabaseHelper();
            databaseHelper.QueryForChanges();
        }
    }
 
    public class XmlFileConnector : Connector
    {
        public override void GetData()
        {
            var xmlfileLoader = new XmlFileLoader();
            xmlfileLoader.LoadXML();
        }
    }
 
    public class HttpStreamConnector : Connector
    {
        public override void GetData()
        {
            var websiteScanner = new WebSiteScanner();
            websiteScanner.Scan();
        }
    }
```

+ По-долу е даден пример с различни Adapter класове, които имплементират различни интерфейси. Клиентът от своя страна очаква шаблонен интерфейс, който тези класове не предоставят. Ето защо те биват манипулирани от конкретните Adapter класове, за да ги направят съвместими с клиента.

```cs
	public class DatabaseHelper
    {
        public void QueryForChanges()
        {
            Console.WriteLine("Database queried.");
        }
    }
 
    public class WebSiteScanner
    {
        public void Scan()
        {
            Console.WriteLine("Web sites scanned.");
        }
    }
 
    public class XmlFileLoader
    {
        public void LoadXML()
        {
            Console.WriteLine("Xml files loaded.");
        }
    }
```

+ В последната стъпка е добавен код, който тества софтуерния дизайн на шаблона.

```cs
	public static void Adapter()
    {
        var tradingdataImporter = new TradingDataImporter();
 
        Connector databaseConnector = new DatabaseConnector();
        tradingdataImporter.ImportData(databaseConnector);
 
        Connector xmlfileConnector = new XmlFileConnector();
        tradingdataImporter.ImportData(xmlfileConnector);
 
        Connector httpstreamConnector = new HttpStreamConnector();
        tradingdataImporter.ImportData(httpstreamConnector);            
 
        Console.ReadKey();
    }
```