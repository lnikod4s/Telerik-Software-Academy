# Bridge Pattern
___

## Име на шаблона за дизайн:
Bridge Pattern

## Кратко описание:
Шаблонът за дизайн "Bridge Pattern" разделя имплементацията от интерфейсите на даден обект.

## Употреба:
Този шаблон е спорадично използван, изключително удобен при разкачане на абстракция от конкретна имплементация, което позволява отделната им манипулация.

## Ниво на сложност:
1/5

## UML класова диаграма:
![Bridge Pattern UML Class Diagram](http://download.codeplex.com/download?ProjectName=csharpdesignpatterns&DownloadId=260116 "Bridge Pattern UML Class Diagram")

## Подробно обяснение

+  Абстрактният клас Repository дефинира интерфейса, който всички наследници ще използват за собствени нужди.
+  Важно е да се отбележи, че операциите в класа Repository се извършват на високи ниво.

```cs
	public abstract class Repository
    {        
        public abstract void AddObject(DataObject dataObject);
        public abstract void CopyObject(DataObject dataObject);
        public abstract void RemoveObject(DataObject dataObject);
 
        public void SaveChanges()
        {
            Console.WriteLine("Changes were saved");
        }
    }
```

+ Усъвършенстваните класове-наследници на класа Repository разширяват основните функционалности и имплементират кода, който използват конкретните класове. Те трябва да съдържат логика, специфична за конкретните класове.
```cs
    public class ClientRepository : Repository
    {
        public override void AddObject(DataObject dataObject)
        {
            // Do repository specific work
            dataObject.Register();            
        }
 
        public override void CopyObject(DataObject dataObject)
        {
            // Do repository specific work
            dataObject.Copy();            
        }
 
        public override void RemoveObject(DataObject dataObject)
        {
            // Do repository specific work
            dataObject.Delete();            
        }
    }
 
    public class ProductRepository : Repository
    {
        public override void AddObject(DataObject dataObject)
        {
            // Do repository specific work
            dataObject.Register();
        }
 
        public override void CopyObject(DataObject dataObject)
        {
            // Do repository specific work
            dataObject.Copy();
        }
 
        public override void RemoveObject(DataObject dataObject)
        {
            // Do repository specific work
            dataObject.Delete();
        }
    }
```

+ Абстрактният клас Data дефинира интерфейсите на имплементационните класове. Важно е да се отбележи, че абстрактните класове Repository и DataObject могат да имат абсолютно различни интерфейси.
+ Конкретният имплементации на класа DataObject съдържат код, който изпълнява всички операции на ниско ниво.
+ Това, което се забелязва, е, че методите на класа Repository може да извикват множество методи на имплементационните класове.

```cs
	public abstract class DataObject
    {
        public abstract void Register();
        public abstract DataObject Copy();
        public abstract void Delete();
    }
 
    public class ClientDataObject : DataObject
    {
        public override void Register()
        {
            Console.WriteLine("ClientDataObject was registered");
        }
 
        public override DataObject Copy()
        {
            Console.WriteLine("ClientDataObject was copied");
            return new ClientDataObject();
        }
 
        public override void Delete()
        {
            Console.WriteLine("ClientDataObject was deleted");
        }
    }
 
    public class ProductDataObject : DataObject
    {
        public override void Register()
        {
            Console.WriteLine("ProductDataObject was registered");
        }
 
        public override DataObject Copy()
        {
            Console.WriteLine("ProductDataObject was copied");
            return new ProductDataObject();
        }
 
        public override void Delete()
        {
            Console.WriteLine("ProductDataObject was deleted");
        }
    }
```

+ В последната стъпка е добавен код, който тества софтуерния дизайн на шаблона.

```cs
	public static void Bridge()
    {
        var clientRepository = new ClientRepository();
        var productRepository = new ProductRepository();
 
        var clientDataObject = new ClientDataObject();
        clientRepository.AddObject(clientDataObject);
        clientRepository.SaveChanges();
 
        clientRepository.CopyObject(clientDataObject);
            
        clientRepository.RemoveObject(clientDataObject);
        clientRepository.SaveChanges();
 
        var productDataObject = new ProductDataObject();
        productRepository.AddObject(productDataObject);
        clientRepository.SaveChanges();
            
        productRepository.CopyObject(productDataObject);
            
        productRepository.RemoveObject(productDataObject);
        productRepository.SaveChanges();
 
        Console.ReadKey();
    }
```