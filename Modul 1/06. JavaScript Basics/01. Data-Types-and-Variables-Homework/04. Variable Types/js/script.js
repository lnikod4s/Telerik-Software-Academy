taskName = "typeof null and undefined";

function Main(bufferElement) {

    var undefinedType;
    WriteLine("Undefined: " + typeof(undefinedType));

    WriteLine();

    var nullableType = null;
    WriteLine("Null: " + typeof(nullableType));
    WriteLine("null instanceof Object: " + (null instanceof Object));
}