using System;
using System.Collections.Generic;
using System.Linq;
using Balta.ContentContext;
using Balta.NotificationContext;
using Balta.SharedContext;

namespace Balta
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var articles = new List<Article>();

            articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
            articles.Add(new Article("Artigo sobre C#", "csharp"));

            /*
            foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            }
            */

            var courses = new List<Course>();

            var courseOOP = new Course("Fundamentos OOP", "fundamentos-oop");
            var courseCsharp = new Course("Fundamentos C#", "fundamentos-csharp");

            courses.Add(courseOOP);
            courses.Add(courseCsharp);

            var carrers = new List<Carrer>();

            var beginnerCarrer = new Carrer("Especialista .NET", "especialis-dotnet");

            var carrerItem = new CarrerItem(1, "Comece por aqui", "", courseCsharp);
            var carrerItem2 = new CarrerItem(2, "Aprenda OOP", "", courseOOP);

            beginnerCarrer.Courses.Add(carrerItem2);
            beginnerCarrer.Courses.Add(carrerItem);

            
            carrers.Add(beginnerCarrer);

            foreach (var carrer in carrers)
            {
                Console.WriteLine(carrer.Title);
                foreach (var item in carrer.Courses.OrderBy(x => x.Order))
                {
                    Console.WriteLine($"{item.Order} - {item.Title}");
                    Console.WriteLine(item.CourseCarrer.Title);
                    Console.WriteLine(item.CourseCarrer.Level);

                    foreach (var notification in item.Notifications)
                    {
                        Console.WriteLine($"{notification.Property} - {notification.Message}");
                    }
                }
            }



        }
    }
}