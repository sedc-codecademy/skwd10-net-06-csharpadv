using PatterMatching;

Console.WriteLine(CalculateArea(new Square(2)));
//Console.WriteLine(CalculateArea(new Rectangle()
//{
//    SideA = 2,
//    SideB = 3
//}));

Console.WriteLine(AnotherCalculateArea(new Square(2)));

static double CalculateArea(object shape)
{
    if(shape is Square)
    {
        Square square = (Square)shape;
        return square.Side * square.Side;
    }
    else if(shape is Circle)
    {
        Circle circle = (Circle)shape;
        return Math.PI * circle.Radius * circle.Radius;
    }
    throw new ArgumentException("shape is not of valid type");
}

static double AnotherCalculateArea(object shape)
{
    if(shape is Square square)
    {
        return square.Side * square.Side;
    }
    else if(shape is Circle circle)
    {
        return Math.PI * circle.Radius * circle.Radius;
    }
    throw new ArgumentException("shape is not of valid type");
}
