# Singleton Pattern
___

## Име на шаблона за дизайн:
Singleton Pattern

## Кратко описание:
Шаблонът за дизайн "Singleton" създава една-единствена инстанция на даден клас.

## Употреба:
Често този шаблон за дизайн е използван за обекти, които трябва да осигурят глобален достъп с ограничението за една-единствена инстанция на класа в програмата.

## Ниво на сложност:
1/5

## UML класова диаграма:
![Singleton UML Class Diagram](http://download.codeplex.com/download?ProjectName=csharpdesignpatterns&DownloadId=244664 "Singleton UML Class Diagram")

## Подробно обяснение
+ Съществуват множество имплементации на шаблона за дизайн "Singleton". Тук ще се спрем на най-ефикасните от тях по отношение на сигурността при многонишково програмиране.
+ Важно е да се отбележи, че при първият пример стандартният конструктор е дефиниран като частен и съответно не може да бъде инстанциран отвън. Освен това той е маркиран като sealed, което означава, че не може да бъде наследяван.
+ Вътрешно инстанцираният обект е запазен в частна статична променлива. Ролята на публичното статично свойство GetInstance е да осигури достъп до този обект. То съдържа бизнес логиката, която гарантира наличието на една-единствена инстанция.
+ За постигането на гореописаното поведение е използван подход за заключване, който гарантира, че една-единствена нишка ще премине през null проверката и ще бъде създадено нова инстанция, ако тя не съществува вече.
+ Добавен е метод DisplayConfiguration(), чиято роля е провери наличния класов дизайн.

```cs
	public sealed class ConfigurationManager
    {
        private static ConfigurationManager instance;
        private static object syncRoot = new Object();
 
        private ConfigurationManager() 
        { 
        
        }
 
        public static ConfigurationManager GetInstance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new ConfigurationManager();
                    }
                }
 
                return instance;
            }
        }
 
        public void DisplayConfiguration()
        {
            Console.WriteLine("Single instance object");
        }
    }
```

+ Във вторият пример стандартният конструктор отново е дефиниран като частен, така че инстанцирането на обекта отвън е невъзможно.  Освен това той е маркиран като sealed, което означава, че не може да бъде наследяван.
+ Този път е използван частен nested клас, който трябва да осигури достъп инстанцията, която от своя страна трябва да бъде една-единствена в цялото приложение.
+ Този nested клас притежава статичен стандартен конструктор и статична internal read-only инстанция на обекта. Само контейнер класът по дизайн има достъп до тази инстанция (автоматично инстанциран и маркиран като read-only).
+ Добавен е метод DisplayRules(), чиято роля е провери наличния класов дизайн.
+ Този подход е препоръчителен, понеже няма заключване и е ефикасен по отношение на производителността.

```cs
    public sealed class BusinessRulesManager
    {
        private BusinessRulesManager()
        {
 
        }
 
        public static BusinessRulesManager GetInstance
        {
            get
            {
                return BusinessRulesManagerImpl.instance;
            }
        }
 
        public void DisplayRules()
        {
            Console.WriteLine("Single instance object");
        }
 
        private class BusinessRulesManagerImpl
        {
            static BusinessRulesManagerImpl()
            {
 
            }
 
            internal static readonly BusinessRulesManager instance = new BusinessRulesManager();
        }
    }
```

+ При последната стъпка добавяме малко код, за да тестваме дизайна и самата имплементация на шаблона.

```cs
	private static void Singleton()
    {
        var configurationManager = ConfigurationManager.GetInstance;
        configurationManager.DisplayConfiguration();
 
        var businessRulesManager = BusinessRulesManager.GetInstance;
        businessRulesManager.DisplayRules();
 
        Console.ReadKey();
    }
```