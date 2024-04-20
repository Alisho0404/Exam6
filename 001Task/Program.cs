using _001Task;
using _001Task.Data;

await using var dataContext = new DataContext();


Console.WriteLine(" Good look 😊😊😊 ");

//1
//Напишите запрос LINQ, чтобы получить всех людей, живущих в городе с населением более 3 милион человек.
//Write a LINQ query to retrieve all the people who live in a city with a population greater than 3 
var people=(from p in dataContext.Peoples 
           join c in dataContext.Cities on p.CityId equals c.Id
           where c.Population>3000000 
           select new
           {
               Name=p
           }).ToList();
//foreach (var p in people)
//{
//    Console.WriteLine(p.Name.FirstName);
//    Console.WriteLine();
//}


//2
//Получите все города со средней численностью населения в соответствующей стране
//Retrieve all cities with their respective country's average population
var average = from c in dataContext.Cities
              join ctr in dataContext.Countries on c.CountryId equals ctr.Id
              let averageInCtr = dataContext.Cities.Average(x => x.Population)
              select new
              {
                  
                  City=c
              };
//foreach (var item in average)
//{
//    Console.WriteLine($"{item.City.Name}");
//}
//3
//Получите города с самым высоким населением в каждой стране
//Retrieve the cities with the highest population in each country
var cities = from c in dataContext.Cities
             join ctr in dataContext.Countries on c.CountryId equals ctr.Id
             let MaxPopulation = dataContext.Cities.Max(c => c.Population)
             select new
             {
                 Country = ctr,
                 City = c

             };
//foreach (var c in cities)
//{
//    Console.WriteLine($"Country: {c.Country.Name} City with max population:{c.City.Name}");
//}
//4
//Получите среднее население городов в каждой стране
//Retrieve the average population of cities in each country
var averagePolpulation = from c in dataContext.Cities
                         join ctr in dataContext.Countries on c.CountryId equals ctr.Id                        
                         select new
                         {
                             City = c,
                             CountryPopulation = ctr.Cities!.Average(c => c.Population),

                         };
//foreach (var c in averagePolpulation)
//{
//    Console.WriteLine($"City:{c.City.Name} Average population:{c.CountryPopulation}");
//}
//5
//Получить все города, в которых есть человек по имени "Марк".
//Retrieve all cities that have a person with by name "Mark"
var mark = from c in dataContext.Cities
           join p in dataContext.Peoples on c.Id equals p.CityId
           where p.FirstName == "Mark"
           select new
           {
               City = c
           };
//foreach (var item in mark)
//{
//    Console.WriteLine(item.City.Name);
//}

//6
//Получить всех людей вместе с соответствующими названиями городов и стран
//Retrieve all people along with their associated city and country names
var peoples = from p in dataContext.Peoples
              join c in dataContext.Cities on p.CityId equals c.Id
              join ctr in dataContext.Countries on c.CountryId equals ctr.Id
              select new
              {
                  People = p,
                  City = c,
                  Country = ctr
              };
//foreach (var item in peoples)
//{
//    Console.WriteLine($"Name:{item.People.FirstName} City:{item.City.Name} Country:{item.Country.Name}");
//}


//7
//Получите все города вместе с соответствующими названиями стран, используя свойство навигации
//Retrieve all cities along with their associated country names using a navigation property
var city = from c in dataContext.Cities
           join ctr in dataContext.Countries on c.CountryId equals ctr.Id
           select new
           {
               Country = ctr,
               City = c,
           };
//foreach (var item in city)
//{
//    Console.WriteLine($"City:{item.City.Name} Country:{item.Country.Name}");
//}
//8
//Получить всех людей вместе с связанными с ними городом и страной.
//Retrieve all people along with their associated city and country 
var odamon = from p in dataContext.Peoples
              join c in dataContext.Cities on p.CityId equals c.Id
              join ctr in dataContext.Countries on c.CountryId equals ctr.Id
              select new
              {
                  People = p,
                  City = c,
                  Country = ctr
              };
//foreach (var item in odamon)
//{
//    Console.WriteLine($"Name:{item.People.FirstName} City:{item.City.Name} Country:{item.Country.Name}");
//}

//9
//Получить всех людей, живущих в "USA".
//Retrieve all people living in  "USA".
var amerikanci = from p in dataContext.Peoples
                 join c in dataContext.Cities on p.CityId equals c.Id
                 join ctr in dataContext.Countries on c.CountryId equals ctr.Id
                 where ctr.Name == "USA"
                 select new
                 {
                     Person = p
                 };
//foreach (var item in amerikanci)
//{
//    Console.WriteLine($"Name: {item.Person.FirstName}");
//}

//10
//Получить всех людей вместе с соответствующим населением города и страны
//Retrieve all people along with their associated city and country populations 
var chelovek = from p in dataContext.Peoples
               join c in dataContext.Cities on p.CityId equals c.Id
               join ctr in dataContext.Countries on c.CountryId equals ctr.Id               
               
               select new
               {
                   CityPopulation =c.Population,
                   Person = p,
                   City=c, 
                   CountryPopulation=ctr.Cities!.Sum(c=>c.Population),
                   Country=ctr
               };
//foreach (var item in chelovek)
//{
//    Console.WriteLine($"Name:{item.Person.FirstName} City:{item.City.Name} " +
//        $"Population:{item.CityPopulation} Country:{item.Country.Name} C-y population:{item.CountryPopulation}");
//};




