int integerValue = default; //0
bool boolValue = default; //false
double doubleValue = default; //0
string stringValue = default; //null

bool? nullableBoolean = default; //null
List<string> stringsList = default; //null
List<int> intsList = default;
char charValue = default;

string stringType = stringValue == null ? "string" : stringValue.GetType().Name;


Console.WriteLine($"Value: {integerValue} - Type: {integerValue.GetType()} - {integerValue.GetType().Name}");
Console.WriteLine($"Value: {boolValue} - Type: {boolValue.GetType()} - {boolValue.GetType().Name}");
Console.WriteLine($"Value: {doubleValue} - Type: {doubleValue.GetType()} - {doubleValue.GetType().Name}");
Console.WriteLine($"Value: {charValue} - Type: {charValue.GetType()} - {charValue.GetType().Name}");
Console.WriteLine($"Value: {stringValue} - Type: {stringType}");
Console.WriteLine($"Value: {nullableBoolean} - IsNull: {nullableBoolean == null}");
Console.WriteLine($"Value: {stringsList} - Isnull: {stringsList == null}");
Console.WriteLine($"Value: {intsList} - Isnull: {intsList == null}");

var newListOfStrings = CreateList<string>(5, "Hi");
var newListOfDoubles = CreateList<double>(7);
var emptyList = CreateList<int>(0);

Console.ReadLine();

List<T> CreateList<T>(int numOfItems, T initialValue = default)
{
    if(numOfItems <= 0)
    {
        return default; //null -> null is default for List<T>
    }
    List<T> list = new List<T>();
    for(int i =0; i < numOfItems; i++)
    {
        list.Add(initialValue);
    }
    return list;
}