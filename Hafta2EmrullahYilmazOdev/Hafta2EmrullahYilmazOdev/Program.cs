using Hafta2EmrullahYilmazOdev;

//Extension Geliştirin
DateTime dtnow = DateTime.Now;
DateTime dtbefore = new DateTime(2022, 5, 12, 2, 5, 8);

string result = dtnow.GetDate(dtbefore); // call extension

Console.WriteLine(result);
Console.ReadKey();
