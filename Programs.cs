using System;
using System.Collections.Generic;
using System.Linq;

#region Models

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int CourseId { get; set; }
}

class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
}

#endregion

#region Managers

class StudentManager
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
        Console.WriteLine("Student added successfully.");
    }

    public void ViewStudents()
    {
        Console.WriteLine("\n--- Student List ---");
        foreach (var s in students)
        {
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}, Course ID: {s.CourseId}");
        }
    }

    public void UpdateStudent(int id, string name, int age, int courseId)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            student.Name = name;
            student.Age = age;
            student.CourseId = courseId;
            Console.WriteLine("Student updated successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public void DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    public List<Student> GetStudentsAboveAge(int age)
    {
        return students.Where(s => s.Age > age).ToList();
    }

    public List<Student> GetStudentsByCourse(int courseId)
    {
        return students.Where(s => s.CourseId == courseId).ToList();
    }
}

class CourseManager
{
    private List<Course> courses = new List<Course>();

    public void AddCourse(Course course)
    {
        courses.Add(course);
        Console.WriteLine("Course added successfully.");
    }

    public void ViewCourses()
    {
        Console.WriteLine("\n--- Course List ---");
        foreach (var c in courses)
        {
            Console.WriteLine($"Course ID: {c.CourseId}, Course Name: {c.CourseName}");
        }
    }
}

#endregion

#region Main Program

class Program
{
    static void Main()
    {
        StudentManager studentManager = new StudentManager();
        CourseManager courseManager = new CourseManager();

        courseManager.AddCourse(new Course { CourseId = 1, CourseName = "Computer Science" });
        courseManager.AddCourse(new Course { CourseId = 2, CourseName = "Mathematics" });

        courseManager.ViewCourses();

        studentManager.AddStudent(new Student { Id = 1, Name = "Afrin", Age = 26, CourseId = 1 });
        studentManager.AddStudent(new Student { Id = 2, Name = "Rahul", Age = 22, CourseId = 2 });
        studentManager.AddStudent(new Student { Id = 3, Name = "Afrah", Age = 28, CourseId = 1 });

        studentManager.ViewStudents();

        studentManager.UpdateStudent(2, "Salman", 23, 1);

        studentManager.DeleteStudent(1);

        studentManager.ViewStudents();

        Console.WriteLine("\nStudents above age 25:");
        var aboveAge = studentManager.GetStudentsAboveAge(25);
        foreach (var s in aboveAge)
        {
            Console.WriteLine($"{s.Name} - Age: {s.Age}");
        }

        Console.WriteLine("\nStudents in Course ID 1:");
        var byCourse = studentManager.GetStudentsByCourse(1);
        foreach (var s in byCourse)
        {
            Console.WriteLine($"{s.Name} - Course ID: {s.CourseId}");
        }
    }
}

#endregion
