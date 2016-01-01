taskName = "JavaScript Literals";

function Main(bufferElement) {

    var booleanType = true;
    WriteLine("Bool: " + booleanType);

    var integer = 5;
    WriteLine("Integer: " + integer);

    var doubleNumber = 8.75;
    WriteLine("Double: " + doubleNumber);

    var charSymbol = 'a';
    WriteLine(Format("Char: '{0}'", charSymbol));

    var text = "Hello, World!";
    WriteLine("String: " + text);

    WriteLine();

    var undefinedType;
    WriteLine("Undefined: " + undefinedType);

    var nullableType = null;
    WriteLine("Null: " + nullableType);

    WriteLine();

    var integerObject = Number(5);
    WriteLine("Integer object: " + integerObject);
}