// See https://aka.ms/new-console-template for more information
using Entity_Framework;
using Entity_Framework.Models;
using System.ComponentModel.DataAnnotations;

using var db = new AppDbContext();

var department = new Department()
{
    Name = "students",
    desc = "decs Studs"
};

var context = new ValidationContext(department);
var errors = new List<ValidationResult>();
if (!Validator.TryValidateObject(department, context, errors, true))
{
    foreach (var error in errors)
        Console.WriteLine(error);
}
else
{
    db.Departments.Add(department);

    db.SaveChanges();
}





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



//var book = new Book()
//{
//    Name = "Psychology",
//    Author = "Bank Clinet",
//    Created = DateTime.Now,
//};

//db.Books.Add(book);
var uniform = new Uniform()
{
    Name = "light blue",
    Created = DateTime.Now
};
db.Uniforms.Add(uniform);
db.SaveChanges();

