// See https://aka.ms/new-console-template for more information
using Entity_Framework;
using Entity_Framework.Models;

Console.WriteLine("Hello, World!");

using var db = new AppDbContext();

//var department = new Department()
//{
//    Name = "Teachers"
//};

//db.Departments.Add(department);
var department = db.Departments.Find(1);
if (department != null)
{
    // edit
    //department.Name = "First Class";
    // db.SaveChanges();

    // delete
    db.Departments.Remove(department);
    db.SaveChanges();
}
else
    Console.WriteLine("Not Found");




