using System;
using T_Api_Time.Models;


namespace T_Api_Time.Services
{
    public static class StudentService
    {
        //static StudentService()
        //{
        //}

        static List<Student> Students { get; } = null!;

        public static List<Student> GetAll() => Students;

        public static Student? Get(int id) => Students.FirstOrDefault(p => p.Id == id);

        public static void Add(Student student)
        {
            //student.Id = nextId++;
            Students.Add(student);
        }

        public static void Delete(int id)
        {
            var student = Get(id);
            if (student is null)
                return;

            Students.Remove(student);
        }

        public static void Update(Student student)
        {
            var index = Students.FindIndex(p => p.Id == student.Id);
            if (index == -1)
                return;

            Students[index] = student;
        }


    }
}

