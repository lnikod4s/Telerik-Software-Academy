# FacadePattern
___

## Име на шаблона за дизайн:
FacadePattern

## Кратко описание:
Шаблонът за дизайн "FacadePattern" предоставя универсален интерфейс на група от интерфейси в дадена структурна подсистема.

## Употреба:
Този шаблон е често използван, изключително удобен, поради факта, че предоставя различни гледни точки на високо ниво на подсистеми, чиито имплементационни детайли са скрити от клиента.

## Ниво на сложност:
1/5

## UML класова диаграма:
![FacadePattern UML Class Diagram](https://i-msdn.sec.s-msft.com/dynimg/IC400938.png "FacadePattern UML Class Diagram")

## Подробно обяснение

+ Ще разгледаме пример за имплементация на шаблона от реалния живот.
+ Нека предположим, че задачата, която трябва да изпълним, е да изключим компютъра. Тази задача може да бъде осъществена чрез изпълнение на следните подзадачи:
1. Запазвам всички промени до текущия момент и избирам от менюто старт "Shut Down Windows".
2. Изключвам монитора.
3. Изключвам UPS.
+ T.e. налице са три подсистеми и програмата съдържа три класа със съотвените им интерфейси.

```cs
	// Class with Shutdown windows funcion    
	public class clsShutDownWindows
    {
        public string ShutDownWindow()
        {
            return "Work Saved and Windows has been Shutdown";
        }
    }


	// Class with Monitor Off Function
    public class clsMonitorOff
    {
        public string TurnOffMonitor()
        {
            return "Monitor Turned Off";
        }
    }


	// Class with UPS off Function
    public class clsUPSOff
    {
        public string TurnOffUPS()
        {
            return "UPS Turned Off";
        }
    }
```

+ По-долу е клиентският код, който първоначално не използва шаблона за дизайн "Facade".
```cs
			// Here we have created 3 objects of 3 different classes and call 
			// their respective method for our task
            clsShutDownWindows ObjPCShutDown = new clsShutDownWindows();
            string sOutput = ObjPCShutDown.ShutDownWindow();

            clsMonitorOff ObjMonitorOff = new clsMonitorOff();
            sOutput = sOutput + "," + ObjMonitorOff.TurnOffMonitor();

            clsUPSOff ObjUPSOff = new clsUPSOff();
            sOutput = sOutput + " and Finally, " + ObjUPSOff.TurnOffUPS();
```

+ Очевидно е, че би било доста по-лесно и удобно клиента да извика един метод, който изпълнява автоматично и трите подзадачи. Ето как би изглеждала една примерна имплементация чрез шаблона за дизайн "Facade".

```cs
	// Class that hides all the sub systems from client
	public class clsTurnOffDesktop
    {
        public string TurnOffDesktop()
        {
            clsShutDownWindows ObjPCShutDown = new clsShutDownWindows();
            string sResult = ObjPCShutDown.ShutDownWindow();

            clsMonitorOff ObjMonitorOff = new clsMonitorOff();
            sResult = sResult + "," + ObjMonitorOff.TurnOffMonitor();

            clsUPSOff ObjUPSOff = new clsUPSOff();
            sResult = sResult + " and Finally, " + ObjUPSOff.TurnOffUPS();

            return sResult;
        }
    }
```

+ В последната стъпка е добавен код, който тества софтуерния дизайн на шаблона.

```cs
	clsTurnOffDesktop ObjTurnOffDesktop = new clsTurnOffDesktop();
	string sOutput= ObjTurnOffDesktop.TurnOffDesktop();
```