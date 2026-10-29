using Exercise03;

var service = new Take20Service();
var processor = new TextFileProcessor(service);
Console.WriteLine("パスの入力");
Console.WriteLine("C:\\Users\\infosys\\source\\repos\\OOP2026\\Chapter15\\演習問題\\Exercise03\\枕草子.txt");
processor.Run(Console.ReadLine());