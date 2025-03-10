﻿using Library.Janvas1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Janvas1.Database
{
    public static class FakeDatabase
    {
        private static List<Person> people = new List<Person>();
        private static List<Course> courses = new List<Course>();
        private static List<Assignment> assignments = new List<Assignment>();
        private static List<Module> modules = new List<Module>();

        public static List<Person> People { get { return people; } }
        public static List<Course> Courses { get {  return courses; } }
        public static List <Assignment> Assignments { get {  return assignments; } }
        public static List<Module> Modules { get { return modules; } }
    }
}
