// See https://aka.ms/new-console-template for more information
using Azure;
using Entity_Framework;
using Entity_Framework.Models;
using System.ComponentModel.DataAnnotations;

using var db = new AppDbContext();


// update
/*
var stu = new Student()
{
    Id = 4,
    Name = "Student_new_2",
    Email = "Sud@email.com",
    Age = 23,
    Grade = 99,
    Birthdate = DateTime.Now,
    departmentId = 7

};
//db.Students.Update(stu);
db.Entry(db.Students.Find(4)).CurrentValues.SetValues(stu);
db.Entry(db.Students.Find(4)).Property(p => p.Name).IsModified = false;
db.SaveChanges();
*/

var departments2 = new List<Department>()
{
    new Department()
    {   
         Id = 10,
         Name = "edit list 1",
         desc = "edit list 1 description",
         Students = new List<Student>()
         {
             new Student() {Id = 6,Name = "edit 2 Student1.li1", Email = "S@s.com", Age = 10 , Grade = 10, Birthdate =DateTime.Now},
             new Student() {Id = 7, Name = "edit 2 Student2.li1", Email = "S2@s.com", Age = 11 , Grade = 11, Birthdate = DateTime.Now }
         }
    },
    new Department()
    {
        Id = 11,
        Name = "edit list 2",
        desc = "edit list 2 description",
        Students = new List<Student>()
        {
            new Student() {Id = 5, Name = "edit 2 Student1.li2", Email = "S@s.com", Age = 10 , Grade = 10, Birthdate =DateTime.Now},
            new Student() {Id = 2, Name = "edit 2 Student2.li2", Email = "S2@s.com", Age = 11 , Grade = 11, Birthdate = DateTime.Now }
        }
    }
};

db.Departments.UpdateRange(departments2);
db.SaveChanges();

// errors
/*
//var department = new Department()
//{
//    Name = "students",
//    desc = "decs Studs"
//};

//var context = new ValidationContext(department);
//var errors = new List<ValidationResult>();
//if (!Validator.TryValidateObject(department, context, errors, true))
//{
//    foreach (var error in errors)
//        Console.WriteLine(error);
//}
//else
//{
//    db.Departments.Add(department);

//    db.SaveChanges();
//}





//var department = db.Departments.Find(1);
//if (department != null)
//{
//    // edit
//    //department.Name = "First Class";
//    // db.SaveChanges();

//    // delete
//    db.Departments.Remove(department);
//    db.SaveChanges();
//}
//else
//    Console.WriteLine("Not Found");





//var studnets = db.Students.ToList();
//var studnets1 = db.Students.SingleOrDefault( x => x.Grade == 49);

*/


// add
/*
var departments = new List<Department>()
{
    new Department() {Name = "Dept1", desc = "Dept1 description"},
    new Department() {Name = "Dept2", desc = "Dept2 description"}
};
var department = new Department()
{
    Name = "Dept4",
    desc = "Dept4 description",
    Students = new List<Student>()
    {
        new Student() {Name = "Student1", Email = "S@s.com", Age = 10 , Grade = 10, Birthdate =DateTime.Now},
        new Student() { Name = "Student2", Email = "S2@s.com", Age = 11 , Grade = 11, Birthdate = DateTime.Now }
    }
};

var departments2 = new List<Department>()
{
    new Department()
    {
         Name = "list 1",
         desc = "list 1 description",
         Students = new List<Student>()
         {
             new Student() {Name = "Student1.li1", Email = "S@s.com", Age = 10 , Grade = 10, Birthdate =DateTime.Now},
             new Student() { Name = "Student2.li1", Email = "S2@s.com", Age = 11 , Grade = 11, Birthdate = DateTime.Now }
         }
    },
    new Department()
    {
        Name = "list 2",
        desc = "list 2 description",
        Students = new List<Student>()
        {
            new Student() {Name = "Student1.li2", Email = "S@s.com", Age = 10 , Grade = 10, Birthdate =DateTime.Now},
            new Student() { Name = "Student2.li2", Email = "S2@s.com", Age = 11 , Grade = 11, Birthdate = DateTime.Now }
        }
    }
};

db.Departments.AddRange(departments2); // or Add() for one 
db.SaveChanges();

*/

