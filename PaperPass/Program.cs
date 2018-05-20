using System;
using System.IO;

// **author**
// naer (http://github.com/naer2/)

namespace PaperPass
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			DateTime date = DateTime.Now;
			int a = 1;
		again:
			Console.WriteLine("password length:");
			string passwordLength = Console.ReadLine();
			int num = -1;
			if (!int.TryParse(passwordLength, out num))
			{
				goto again;
			}
			var chars = "abcdefghjkmnpqrstuvwxyzABCDEFGHJKMNPQRSTUVWXYZ1234567890";
			var aChars = new char[int.Parse(passwordLength)];
			var rnd = new Random();
			for (int i = 0; i < int.Parse(passwordLength); i++)
			{
				aChars[i] = chars[rnd.Next(chars.Length)];
			}
			var gPass = new String(aChars);
			string filePath = "pass-" + date.ToString("yyyy-MM-dd-HHmmss")+".txt";
			StreamWriter streamWriter = new StreamWriter(filePath, true);
			streamWriter.WriteLine(a+". "+gPass);
			Console.WriteLine(gPass);
			a++;
			streamWriter.Close();
		repeat:
			Console.WriteLine("one more pass? (y/n)");
			string ans = Console.ReadLine();
			switch (ans)
			{
				case "y": goto again;  
				case "n": 
					Console.WriteLine("keep the pass.txt? (y/n)");
					string keepans = Console.ReadLine();
                    if (keepans=="n")
					{
						File.Delete(filePath);
					}
                    else if(keepans=="y")
					{
						Console.WriteLine("find in "+Path.GetFullPath(filePath));
					}
					break;//continue
				default: goto repeat;
			}
         
		}
	}
}
	

