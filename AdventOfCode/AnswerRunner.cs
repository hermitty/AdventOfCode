using AOC.Helper;
using System;
using System.Linq;
using System.Collections.Generic;
using Y21 = AOC._2021;

namespace AdventOfCode
{
    public class AnswerRunner
    {
        private readonly IAnswer answer;
        private readonly IList<IDependency> dependecies = new List<IDependency>() { new Y21.Dependency() };
        private readonly string year = DateTime.Now.Year.ToString();
        private readonly string day = DateTime.Now.Day.ToString();

        public AnswerRunner()
        {
            answer = GetAnswerForDate();
        }

        public AnswerRunner(int day)
        {
            this.day = day.ToString();
            answer = GetAnswerForDate();
        }

        public AnswerRunner(int day, int year) 
        {
            this.year = year.ToString();
            answer = GetAnswerForDate();
        }

        public object Task1() => answer.Task1();
        public object Task2() => answer.Task2();

        private IAnswer GetAnswerForDate()
        {
            var type = typeof(IAnswer);
            var typeAssembly = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p)
                && p.IsClass 
                && p.FullName.Contains(year) 
                && p.FullName.Contains("Day" + day)).FirstOrDefault();
            var instance = (IAnswer)Activator.CreateInstance(typeAssembly.Assembly.FullName, typeAssembly.FullName).Unwrap();
            return instance;
        }
    }
}
