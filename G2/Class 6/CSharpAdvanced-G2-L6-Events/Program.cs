using CSharpAdvanced_G2_L6_Events;

string fancyMessage = "This is a very fancy message!";
Publisher publisher = new Publisher();
Subscriber1 sub1 = new Subscriber1();
Subscriber2 sub2 = new Subscriber2();

publisher.DataProcessingHandler += sub1.GetMessage;
publisher.DataProcessingHandler += sub2.GetMessage;
publisher.DataProcessingHandler += x =>
Console.WriteLine($"Special handling of message: {x}");

publisher.ProcessData(fancyMessage);
Thread.Sleep(3000);
publisher.DataProcessingHandler -= sub2.GetMessage;
publisher.ProcessData("NOVA PORAKA");
Console.ReadLine();