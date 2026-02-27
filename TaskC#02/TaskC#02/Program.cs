using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskC_02
{
    record Product(int Id, string Name, decimal Price, string Category);
    record Employee(string Name, string Department, decimal Salary);
    record Course(string Title, List<string> Students);

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Question Number 1

            //// The query should return all even numbers greater than 10, ordered descending.
            //List<int> numbers = [3, 18, 7, 42, 10, 5, 29, 14, 6, 100];

            //// TODO: Write the query using Query Syntax
            //var result = from n in numbers
            //             where n > 10 && n % 2 == 0
            //             orderby n descending
            //             select n;

            //// TODO: Write the same query using Fluent Syntax
            //var result1 = numbers.Where(n => n > 10 && n % 2 == 0).OrderByDescending(n => n);
            //// Expected output: 100, 42, 18, 14
            //foreach (var n in result1)
            //    Console.WriteLine(n);
            #endregion

            #region Question Number 2
            List<Product> products = [
                                    new(1,"Laptop", 1200m,"Electronics"),
                                    new(2,"Phone", 800m,"Electronics"),
                                    new(3,"Desk", 350m,"Furniture"),
                                    new(4,"Chair", 150m,"Furniture"),
                                    new(5,"Headphones", 200m,"Electronics")
                                    ];
            //// First or FirstOrDefault
            //try
            //{
            //    var first = products.First();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //// if Not Found Element will throw Excption (InvalidOperationException)
            //var firstOrDefualt = products.FirstOrDefault();
            //// if not found element will return null not throw Exception

            //// Last or LastOrDefault 
            //try
            //{
            //    var last = products.Last();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //// if Not Found Element will throw Excption (InvalidOperationException)
            //var lastOrDefualt = products.LastOrDefault();
            //// if not found element will return null not throw Exception

            //// Single or SingleOrDefualt 
            //try
            //{
            //    var single = products.Single(/* Condition */);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //// if Condition match more than one will throw Exception 
            //// if not match any one will thrwo Exception too 
            //// must condition match one element
            //var singleOrDefault = products.SingleOrDefault(/* Condition */);
            //// if Condition match more than one will throw Exception 
            //// if not match any one will return null 
            //// must condition match one element

            //// ElementAt
            //try
            //{
            //    var elementAt = products.ElementAt(1);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            // if index grater than count of element in List will throw Exception (ArgumentOutOfRangeException)

            //// 1. Get the first Electronics product
            //try
            //{
            //    var firstOnly = products.First(P => P.Category == "Electronics");
            //    Console.WriteLine(firstOnly);
            //}catch(Exception ex)
            //{
            //    Console.WriteLine($"Exception : {ex.Message}");
            //}

            //var firstElectronicsProduct = products.FirstOrDefault(P => P.Category == "Electronics");
            //Console.WriteLine(firstElectronicsProduct);


            //// 2. Get the last product with Price > 1000 (use OrDefault — handle null)
            //try
            //{
            //    var lastOnly = products.Last(P => P.Price > 1000);
            //    Console.WriteLine(lastOnly);
            //}
            //catch (Exception ex) 
            //{
            //    Console.WriteLine($"Exception : {ex.Message}");
            //}

            //var lastProduct = products.LastOrDefault(P => P.Price > 1000);
            //Console.WriteLine(lastProduct);


            //// 3. Get the single Furniture item with Price > 300 (what if >1 match?)
            //var singleFunrniture = products.Single(P => P.Category == "Furniture" && P.Price > 300);
            //Console.WriteLine(singleFunrniture);
            //// if > 1 or == 0 throw Exception (InvalidOperationException)


            // 4. Get the element at index 3
            //var elementAt = products.ElementAt(3);
            //Console.WriteLine(elementAt);
            // if index grater than count of element in list will throw Exception (ArgumentOutOfRangeException)
            #endregion

            #region Question Number 3

            ////1. Are ALL products priced above 100? → bool
            //bool allProducts = products.All(P => P.Price > 100);
            //Console.WriteLine(allProducts);

            ////2. Is THERE ANY product in the "Gaming" category? → bool
            //bool InGamingCategory = products.Any(P => P.Category == "Gaming");
            //Console.WriteLine(InGamingCategory);

            ////3. Does the collection CONTAIN a product named "Chair"?
            ////(use the default comparer on the record)
            //var ContansProduct = products.Contains(new(4, "Chair", 150m, "Furniture"));
            //Console.WriteLine(ContansProduct);

            ////4. Are ALL Electronics products priced above 500? → bool
            //var allElectronics = products.Where(P => P.Category == "Electronics").All(P => P.Price > 500);
            //Console.WriteLine(allElectronics);

            ////5. Is there ANY product cheaper than 200? → bool
            //bool productCheaperThan200 = products.Any(P => P.Price < 200);
            //Console.WriteLine(productCheaperThan200);
            #endregion

            #region Question Number 4
            //// 1.Convert to Array
            //var ToArray = products.ToArray();


            //// 2.Convert to Dictionary keyed by Id
            //var ToDictionary = products.ToDictionary(P => P.Id);
            //Console.WriteLine(ToDictionary[2]);


            //// 3.Convert to HashSet of product Names
            //HashSet<string> ToHashSet = products.Select(P => P.Name).ToHashSet();
            //Console.WriteLine("==================");
            //foreach (var item in ToHashSet)
            //{
            //    Console.WriteLine(item);
            //}


            //// 4.Convert to Lookup keyed by Category
            ////      → lookup["Electronics"] should return all electronics products
            //var ToLookup = products.ToLookup(P => P.Category);
            //var ElectronicsCategory = ToLookup["Electronics"];
            //Console.WriteLine("==================");
            //foreach(var item in ElectronicsCategory)
            //{
            //    Console.WriteLine(item);
            //}


            // What exception does ToDictionary throw if keys are duplicated?
            // ans : will throw Exception ( ArgumentException )

            // How does ToLookup handle duplicate keys differently ?
            // ans : ToLookup Not Throw Exception but Group All Element Shared With Same Key
            #endregion

            #region Question Number 5
            //// Use the orders list to implement simple pagination(page size = 3), get the last 2 orders, and drop the first and last order from the list.

            //List<string> orders = ["ORD-001","ORD-002","ORD-003",
            //                       "ORD-004","ORD-005","ORD-006","ORD-007"];

            //// 1. Get Page 1 (items 1–3)
            //var page1 = orders.Take(3);
            //foreach (var item in page1) Console.WriteLine(item);

            //// 2. Get Page 2 (items 4–6) ← use Skip + Take
            //var page2 = orders.Skip(3).Take(3);
            //foreach (var item in page2) Console.WriteLine(item);
            //Console.WriteLine("================");


            //// 3. Get the last 2 orders using TakeLast
            //var last2Orders = orders.TakeLast(2);
            //foreach (var item in last2Orders) Console.WriteLine(item);
            //Console.WriteLine("================");


            //// 4. Drop the first and last order using Skip + SkipLast
            //var DropFirstAndLast = orders.Skip(1).SkipLast(1);
            //foreach (var item in DropFirstAndLast) Console.WriteLine(item);


            //// 5. BONUS: Write a generic Paginate(source, pageNumber, pageSize) method
            //static IEnumerable<T> GenericPagination<T>(IEnumerable<T> source, int pageNumber, int PageSize)
            //{
            //    var skipdPages = (pageNumber - 1) * PageSize;
            //    var result = source.Skip(skipdPages).Take(PageSize);
            //    return result;
            //}
            //Console.WriteLine("================");
            //var result = GenericPagination(orders, 2, 2);
            //foreach (var item in result) Console.WriteLine(item);
            #endregion

            #region Question Number 6
            //List<Employee> employees =
            //            [
            //                new("Ali","Engineering", 9000m),
            //                new("Sara","Engineering", 8500m),
            //                new("Omar","HR", 6000m),
            //                new("Mona","HR", 6200m),
            //                new("Yara","Marketing", 7000m),
            //                new("Karim","Marketing", 7500m),
            //                new("Nada","Engineering", 9500m),
            //            ];


            //// 1. Project to anonymous type: { FullName = Name.ToUpper(), Salary }
            //var anonymous = employees.Select(E => new
            //{
            //    FullName = E.Name.ToUpper(),
            //    Salary = E.Salary
            //}).ToList();

            //foreach(var emp in anonymous)
            //{
            //    Console.WriteLine(emp);
            //}


            //// 2. Project to a formatted string: "Ali works in Engineering — EGP 9,000"
            //var FormattedString = employees.
            //                      Select(E => $"{E.Name} works in {E.Department} - EGP {E.Salary}")
            //                      .ToList();
            //foreach (var emp in FormattedString)
            //{
            //    Console.WriteLine(emp);
            //}


            //// 3. Sort by Salary descending, then use indexed Select to add Rank:
            //// { Rank = index + 1, Name, Salary }
            //// Expected: { Rank=1, Name="Nada", Salary = 9500 }
            //var RandedList = employees.OrderByDescending(E => E.Salary)
            //                          .Select((emp, index) => new
            //                          {
            //                              Rank = index + 1,
            //                              emp.Name,
            //                              emp.Salary
            //                          }).ToList();
            //foreach( var emp in RandedList) Console.WriteLine(emp);


            //// BONUS: Project each employee to include a "SeniorityLevel" property: 
            //var LevelEmployee = employees.OrderByDescending(E => E.Salary)
            //                          .Select((emp, index) => new
            //                          {
            //                              Rank = index + 1,
            //                              emp.Name,
            //                              emp.Salary,
            //                              SeniorityLevel = emp.Salary >= 9000 ? "Senior" :
            //                                               emp.Salary < 9000 && emp.Salary > 7000 ? "Mid"
            //                                               : "Junior"
            //                          }).ToList();
            //foreach(var emp in LevelEmployee) Console.WriteLine(emp);

            #endregion

            #region Question Number 7
            //Given a list of scores, use TakeWhile to collect scores until one drops below 70, and SkipWhile to skip low scores and grab the rest
            //once a score ≥ 70 appears.

            //List<int> scores = [88, 92, 75, 60, 55, 80, 91, 45];
            //// 1. TakeWhile score >= 70 → expected: [88, 92, 75]
            //var takeWhile = scores.TakeWhile(S => S >= 70);
            //foreach (var item in takeWhile) Console.WriteLine(item);
            //// 2. SkipWhile score >= 70 → expected: [60, 55, 80, 91, 45]
            //var skipWhile = scores.SkipWhile(S => S >= 70);
            //foreach (var item in skipWhile) Console.WriteLine(item);
            //// 3. What is the difference between this and using Where? Explain in a comment.

            //// TakeWhile => بتمشي علي العناصر من الاول لو ترو بتضيفه ف الليسته بتكمل لعند اما توصل عند عنصر مش بيطابق الشرط ف يعمل بريك
            //// SkipWhile => بتمشي علي العناصر لو ترو بتعمله سكيب لو متلاقي عنصر فولس بتعمل بريك وتاخد من اول العنصر الفولس لعند الاخر 
            //// Where => بتعدي علي كل العناصر تعمل فلتره لو العنصر بترو بتضيفه ف الليسته لو فولس بتخش علي العنصر الي بعده وهكذا
            #endregion

            #region Question Number 8
            //List<Employee> employees =
            //            [
            //                new("Ali","Engineering", 9000m),
            //                new("Sara","Engineering", 8500m),
            //                new("Omar","HR", 6000m),
            //                new("Mona","HR", 6200m),
            //                new("Yara","Marketing", 7000m),
            //                new("Karim","Marketing", 7500m),
            //                new("Nada","Engineering", 9500m),
            //            ];


            //// 1. Group by Department, print: "Engineering → Count: 3, Avg: 9000"
            //var groupByDepartment = employees.GroupBy(E => E.Department)
            //                    .Select( Emp => new
            //                    {
            //                        Emp.Key,
            //                        Count = Emp.Count(),
            //                        Avg = Emp.Average(E => E.Salary)
            //                    });
            //foreach (var item in groupByDepartment) Console.WriteLine(item);


            //// 2. Find the department with the highest total salary budget
            //var HighestTotalSalary = employees.GroupBy(E => E.Department)
            //                         .Select(emp => new
            //                         {
            //                             emp.Key,
            //                             max = emp.Sum(E => E.Salary)
            //                         }).OrderByDescending(emp => emp.max).First();
            //Console.WriteLine(HighestTotalSalary);


            //// 3. List employees in each group ordered by Salary descending
            //var employeesDepartments = employees.GroupBy(D => D.Department)
            //                            .Select(emp => new
            //                            {
            //                                emp.Key,
            //                                Employees = emp.OrderByDescending(E => E.Salary).ToList()
            //                            });
            //foreach(var item in employeesDepartments)
            //{
            //    Console.WriteLine($"Department : {item.Key}");
            //    foreach(var employee in item.Employees)
            //        Console.WriteLine($"     {employee}");
            //}
            #endregion

            #region Question Number 9
            //List<int> nums = [1, 2, 3, 4, 5];
            //var query = nums.Where(n => n > 2); // ← query defined here
            //nums.Add(10);
            //foreach (var n in query)
            //    Console.Write(n + " ");

            //Q: What is printed? Why? =>
            // 3 , 4 , 5 ,10  
            // This is Deferred Execution  ف عشان كدا اي رقم هنعمله ادد هيظهر اثناء التنفيذ


            // Q: How would using .ToList() right after .Where(...) change the result?
            // ايوا طبعا النتيجه هتتغير عشان دي هبقا تنفيذ فوري ف اي حاجه هتحل بعدها مش هتنضاف لليسته 
            // الكود اتنفذ وقت كتابته ف مش معترف بال 10   


            // Q: Name 3 LINQ operators that trigger immediate execution.=>
            // ToList(),ToArray(), Any aggregate function
            #endregion

            #region Question Number 10

            //List<string> words = ["apple", "fig", "banana", "kiwi", "grape", "mango", "pear", "plum"];

            //// 1. Filter words longer than 4 characters
            //var WordsGreaterThan4 = words.Where(W => W.Length > 4).ToList();
            //foreach (var word in WordsGreaterThan4)
            //{
            //    Console.Write($"{word} ");
            //}


            //// 2. Filter words at even indexes (0, 2, 4, 6...) using (item, index) overload
            //var evenWords = words.Where((w, i) => i % 2 == 0).ToList();
            //foreach (var even in evenWords)
            //{
            //    Console.Write($"{even} ");
            //}


            //// 3. Filter words that are BOTH longer than 4 chars AND at an even index
            //var WordsLongerThan4AndEvenIndex = words.Where((w, i) => i % 2 == 0 && w.Length > 4);
            //foreach (var word in WordsLongerThan4AndEvenIndex)
            //{
            //    Console.Write($"{word} ");
            //}


            //// 4. What is the index of "mango" in the filtered result from step 1? 
            //// manago doesnot exist because this index is 5 not even 

            #endregion

            #region Question Number 11
            //List<Course> courses =
            //                      [
            //                      new("C# Basics",["Ali", "Sara", "Omar"]),
            //                      new("LINQ Mastery", ["Sara", "Mona", "Ali"]),
            //                      new("ASP.NET Core", ["Yara", "Omar", "Karim"]),];
            //Console.WriteLine("Question Number 11 ");


            //// 1. Flatten to a single list of ALL student names (with duplicates)
            //var Students = courses.SelectMany(S => S.Students).ToList();
            //foreach (var student in Students)
            //{
            //    Console.Write($"{student} ");
            //}


            //// 2. Get a distinct list of all student names
            //var distinctStudent = courses.SelectMany(S => S.Students).Distinct().ToList();
            //foreach (var name in distinctStudent)
            //{
            //    Console.Write($"{name} ");
            //}



            //// 3. Find students who appear in MORE THAN ONE course
            //var StudentAppearMoreThanOne = courses.SelectMany(S => S.Students)
            //                          .GroupBy(name => name)
            //                          .Where(S => S.Count() > 1)
            //                          .Select(S => S.Key)
            //                          .ToList();
            //foreach (var student in StudentAppearMoreThanOne)
            //{
            //    Console.Write($"{student} ");
            //}


            //// 4. Use SelectMany with result selector to get (CourseName, StudentName) pairs
            //var pairs = courses.SelectMany(course => course.Students,
            //                               (course, student) => new { courseName = course.Title, studentName = student })
            //                   .ToList();
            //foreach (var pair in pairs)
            //{
            //    Console.WriteLine($"courseName : {pair.courseName} , studentName : {pair.studentName}");
            //}
            #endregion

            #region Question Number 12
            List<Employee> employees =
                        [
                            new("Ali","Engineering", 9000m),
                            new("Sara","Engineering", 8500m),
                            new("Omar","HR", 6000m),
                            new("Mona","HR", 6200m),
                            new("Yara","Marketing", 7000m),
                            new("Karim","Marketing", 7500m),
                            new("Nada","Engineering", 9500m),
                        ];
            List<Course> courses =
                        [
                        new("C# Basics", ["Ali","Sara","Omar"]),
                        new("LINQ Mastery", ["Sara","Mona","Ali"]),
                        new("ASP.NET Core", ["Yara","Omar","Karim"]),
                        ];

            // 1.From employees: get the TOP 2 highest - paid employees per department.
            // → Use GroupBy +OrderByDescending + Take(2) inside each group
            // → Flatten the result with SelectMany

            //var Top2HighestEmployeesPaidPerDepartment = employees.GroupBy(D => D.Department)
            //                            .SelectMany(emp =>
            //                            emp.OrderByDescending(e => e.Salary)
            //                            .Take(2)).ToList();
            //foreach (var emp in Top2HighestEmployeesPaidPerDepartment)
            //{
            //    Console.WriteLine($"{emp.Department} - {emp.Name} - {emp.Salary}");
            //}


            //// 2.From courses: build a Dictionary<string, int> of
            //// { CourseName → StudentCount }, but only for courses with > 2 students.

            //Dictionary<string, int> CourseWithMoreThan2Students = courses
            //                                                        .Where(S => S.Students.Count() > 2)
            //                                                        .ToDictionary(
            //                                                             D => D.Title,
            //                                                             D => D.Students.Count
            //                                                         );
            //foreach (var item in CourseWithMoreThan2Students)
            //    Console.WriteLine($"{item.Key} : {item.Value}");


            //// 3.Check:
            //// ⟢ Does ANY employee in Engineering earn less than 8000 ?
            //bool EmployeeInEngEarnLessThan8000 = employees
            //                                        .Where(E => E.Department == "Engineering")
            //                                        .Any(E => E.Salary < 8000);
            //Console.WriteLine(EmployeeInEngEarnLessThan8000);

            //// ⟢ Do ALL HR employees earn more than 5500 ?
            //bool EmpInHREarnMoreThan5500 = employees
            //                                        .Where(E => E.Department == "HR")
            //                                        .Any(E => E.Salary > 5500);
            //Console.WriteLine(EmpInHREarnMoreThan5500);


            //// 4.Project the top - 2 - per - dept result into:
            //// { Rank, Name, Department, Salary, SeniorityLevel }
            //// where Rank resets per department(use indexed Select per group).

            //var Top2PerDept = employees
            //    .GroupBy(e => e.Department)
            //    .SelectMany(emp => emp
            //    .OrderByDescending(e => e.Salary)
            //    .Take(2)
            //    .Select((e, index) => new
            //    {
            //        Rank = index + 1,
            //        e.Name,
            //        e.Department,
            //        e.Salary,
            //        SeniorityLevel = e.Salary >= 9000 ? "Senior" :
            //                                             e.Salary < 9000 && e.Salary > 7000 ? "Mid"
            //                                             : "Junior"
            //    })
            //    ).ToList();
            //foreach (var item in Top2PerDept) Console.WriteLine(item);




            // 5.For each step above — is execution deferred or immediate?
            // Write your reasoning as inline comments.
            // ans : all deferred except .ToList() Immediate
            #endregion

        }

    }
}
