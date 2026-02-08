using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace TaskC_01
{
    internal class Feature
    {
        public readonly int MinApp = 1;
        public bool IsEnabled { get; set; }
        public int MinVersion { get; set; }
        public Feature(bool enabled, int minVersion)
        {
            IsEnabled = enabled;
            MinVersion = minVersion;
        }
    }
    class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }
    }
    struct UserSnapShot
    {
        public string SnapName { get; set; }
        public UserSnapShot(string snapName)
        {
            SnapName = snapName;
        }
    }
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }
    class PaymentTimeoutException : Exception
    {
        public PaymentTimeoutException(string message) : base(message) { }
    }
    internal class Program
    {
        public const int MinLogin = 2;
        public const int MinExport = 0;
        public const int MinAdminPanel = 2;
        static void Main(string[] args)
        {
            #region 1- Runtime Environment Analyzer
            //Console.WriteLine(RuntimeInformation.OSArchitecture);
            //Console.WriteLine(RuntimeInformation.ProcessArchitecture);
            //var version = RuntimeInformation.FrameworkDescription;
            //Console.WriteLine(version);
            //if (version.Contains(".NET") || version.Contains(".NET Core"))
            //    Console.WriteLine("Modern .NET Runtime");
            //else
            //    Console.WriteLine("Legacy Runtime"); 
            #endregion

            #region 2- Feature Toggle System
            //Feature login = new Feature(true, MinLogin);
            //Feature export = new Feature(true, MinExport);
            //Feature adminPanel = new Feature(true, MinAdminPanel);

            //if (login.IsEnabled && login.MinVersion > login.MinApp)
            //    Console.WriteLine("Login Is Running");
            //else
            //    Console.WriteLine("Login Is Not Running");

            //string ExportResult = (export.IsEnabled && export.MinVersion > export.MinApp) ? "Export Is Running" : "Export Isn't Running";
            //Console.WriteLine(ExportResult);
            #endregion

            #region 3- Number Classification Engine

            //List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //NumberClassifiaction(numbers);


            //static void NumberClassifiaction(List<int> numbers)
            //{
            //    var oddList = new List<int>();
            //    var evenList = new List<int>();
            //    var praimaryList = new List<int>();
            //    foreach (int num in numbers)
            //    {
            //        if (IsEven(num))
            //            evenList.Add(num);
            //        else
            //            oddList.Add(num);
            //        if (IsPrimary(num))
            //            praimaryList.Add(num);
            //    }
            //    Console.WriteLine("Even Numbers : ");
            //    foreach (int num in evenList) Console.Write($"{num} ");
            //    Console.WriteLine("\nodd Numbers : ");
            //    foreach (int num in oddList) Console.Write($"{num} ");
            //    Console.WriteLine("\nPrimary Numbers : ");
            //    foreach (int num in praimaryList) Console.Write($"{num} ");
            //}
            //static bool IsEven(int num) => num % 2 == 0;
            //static bool IsPrimary(int num)
            //{
            //    if (num < 2) return false;
            //    if (num == 2) return true;
            //    if (num % 2 == 0) return false;
            //    for (int i = 3; i < num - 1; i += 2)
            //    {
            //        if (num % i == 0) return false;
            //    }
            //    return true;

            //}
            #endregion

            #region 4- Memory Behavior Test

            //User user = new User("Youssef");
            //UserSnapShot userSnap = new UserSnapShot("Youssef");

            //WithOutRef(user, userSnap);
            //Console.WriteLine(user.Name); // CSharp
            //Console.WriteLine(userSnap.SnapName); // Youssef
            ////With out Reference 
            //// ف الكلاس احنا بنبعت الاوبجيت ف بيعدل عليه عادي 
            ////  انما ف الاستراكت احنا بنبعت نسخه من الاوبجيكت ف مهما يعدل فيه مش بياثر علي الاصل 

            //WithRef(ref user, ref userSnap);
            //Console.WriteLine(user.Name); // CSharp 
            //Console.WriteLine(userSnap.SnapName); // CSharp
            //// With Reference 
            //// نفس الكلام هيحصل ف الكلاس 
            //// انما ف الاستراكت احنا بنبعت المكان بتاع الاوبجيكت ف يقدر يعدل عليه والقيمه الاصليه تتغير

            //static void WithOutRef(User user, UserSnapShot userSnap)
            //{
            //    user.Name = "CSharp";
            //    userSnap.SnapName = "CSharp";
            //}
            //static void WithRef(ref User user, ref UserSnapShot userSnap)
            //{
            //    user.Name = "CSharp";
            //    userSnap.SnapName = "CSharp";
            //} 
            #endregion

            #region 5- Payment Exception Design
            //static void PaymentSystem(decimal balance, decimal amount, bool timeout)
            //{
            //    if (balance < amount)
            //        throw new InsufficientBalanceException("Balance is not Enough");
            //    else
            //        Console.WriteLine("Balance is enough to pay");
            //    if (!timeout)
            //        throw new PaymentTimeoutException("Payment Time Out.");
            //    else
            //        Console.WriteLine("time is enough ");
            //}

            //try
            //{
            //PaymentSystem(0, 10,true);
            //}
            //catch (InsufficientBalanceException ex)
            //{
            //    Console.WriteLine($"InsufficientBalanceException : {ex.Message}");
            //}
            //catch (PaymentTimeoutException ex)
            //{
            //    Console.WriteLine($"PaymentTimeoutException : {ex.Message}");
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"General Exception : {ex.Message}");
            //}
            //finally
            //{
            //    Console.WriteLine("Payment system is finished");
            //}           
            #endregion

            #region Longest Commom Prefix

            //string[] strs = ["flower", "flow", "flight"];
            //string result = LongestCommonPrefix(strs);
            //Console.WriteLine(result);
            //static string LongestCommonPrefix(string[] strs)
            //{

            //    if (strs == null || strs.Length == 0) return "";

            //    string Reference = strs[0];
            //    int LengthOfString = Reference.Length;

            //    for (int i = 1; i < strs.Length; i++)
            //    {
            //        int j = 0;
            //        string OrderStr = strs[i];
            //        while (j < LengthOfString && j < strs[i].Length)
            //        {
            //            if (Reference[j] == OrderStr[j])
            //                j++;
            //            else
            //                break;
            //        }

            //        LengthOfString = j;

            //        if (LengthOfString == 0) return "";
            //    }
            //    return Reference.Substring(0, LengthOfString);
            //} 
            #endregion

            #region 217. Contains Duplicate
            //public class Solution
            //{
            //public bool ContainsDuplicate(int[] nums)
            //{
            //    HashSet<int> hashset = new HashSet<int>();
            //    foreach (int num in nums)
            //    {
            //        if (hashset.Contains(num))
            //            return true;
            //        hashset.Add(num);
            //    }
            //    return false;
            //}
            //}
            #endregion

            #region 242. Valid Anagram
            //bool IsAnagram(string s, string t)
            //{
            //    if (s.Length != t.Length)
            //        return false;
            //    char[] arrs = s.ToCharArray();
            //    Array.Sort(arrs);
            //    string sorteds = new string(arrs);
            //    char[] arrt = t.ToCharArray();
            //    Array.Sort(arrt);
            //    string sortedt = new string(arrt);
            //    if (sortedt == sorteds)
            //        return true;
            //    return false;
            //}
            #endregion
        }
    }
}

