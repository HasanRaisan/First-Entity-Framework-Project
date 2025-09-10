// See https://aka.ms/new-console-template for more information
using Azure;
using Entity_Framework;
using Entity_Framework.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using var db = new AppDbContext();
int i = 0;

 using var transaction = db.Database.BeginTransaction();
//try
//{
//    db.Departments.Add(new Department { Name = "tarna 33", desc = "edc1" });
//    db.SaveChanges();
//    db.Departments.Add(new Department { Name = "tarna 22", desc = "edcjjghghghg" });
//    db.SaveChanges();
//    transaction.Commit();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//    transaction.Rollback();
//}


try
{
    db.Departments.Add(new Department { Name = "tarna qqq", desc = "edc" , nume = "123"});
    db.SaveChanges();
    db.Departments.Add(new Department { Name = "tarna qq2", desc = "edc412366955452331", nume = "123" });
    db.SaveChanges();
    transaction.CreateSavepoint("data_ok");
    db.Departments.Add(new Department { Name = "tarna 33", desc = "edc1" });
    db.SaveChanges();
    db.Departments.Add(new Department { Name = "tarna 22", desc = "edcjjghghghg" });
    db.SaveChanges();
    transaction.Commit();
}
catch (Exception ex)
{
    Console.WriteLine("11111111111111" + ex.Message + "\n\n");
    //transaction.Rollback();
    try
    {
        transaction.RollbackToSavepoint("data_ok");
        transaction.Commit();
    }
    catch (Exception l2Ex)
    {
        transaction.Rollback();
        Console.WriteLine("22222222222222" + l2Ex.Message + "\n\n");


    }
}




// lazy 
/*
var stu = db.Students.SingleOrDefault(s => s.Id == 1);
Console.WriteLine(stu.department.Name);
foreach ( var bo in stu.Books)
{
    Console.WriteLine("stuID:" + bo.studentId); // from include [Books]
    Console.WriteLine("Book name: " + bo.book.Name); // from then include [StuBook]

}
*/
i++;
//Explicit Loading of Related Data
/*
var stu = db.Students.SingleOrDefault(s => s.Id == 1);
db.Entry(stu).Reference(d => d.department).Load();
Console.WriteLine(stu.department.Name);

//db.Entry(stu).Collection(st => st.Books).Load(); // The property 'Student.Books' is being accessed using the 'Reference' method, but is defined in the model as a collection navigation. Use the 'Collection' method to access collection navigations.'
db.Entry(stu).Collection(st => st.Books).Query().Where(x => x.Id == 1).ToList();
// .Query() + .ToList() = تنفيذ مباشر
// → ما تحتاجش Load().
stu.Books.ToList().ForEach
(StuBook =>
{
    Console.WriteLine(StuBook.Id);
    db.Entry(StuBook).Reference(d => d.book).Load();
    Console.WriteLine(StuBook.book.Name);
}

);
*/
i = 0;

// Eagar Data Lodaing
/*
var stu = db.Students.Include(StuBook => StuBook.department).
    Include(b => b.Books).ThenInclude(sb => sb.StuBook)
    .SingleOrDefault(s => s.Id == 1);
Console.WriteLine(stu.department.Name);
foreach ( var bo in stu.Books)
{
    Console.WriteLine("stuID:" + bo.studentId); // from include [Books]
    Console.WriteLine("Book name: " + bo.StuBook.Name); // from then include [StuBook]

}
*/

i = 0;
// tracking
 /*
    //var dep = db.Departments.FirstOrDefault(x => x.Id == 4);
    //dep.desc = "traking test 2";


    // all tables with db is not traking
    //db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; 
    // .AsNoTracking()
    var dep = db.Departments.FirstOrDefault(x => x.Id == 4);
    // as no tracking is faster than with tracking, 30% faster
    dep.desc = "traking test 9";

    var track = db.ChangeTracker.Entries();
    foreach (var t in track)
    {
        Console.WriteLine($" track 1 {t.Entity.ToString()} - {t.State}");
        t.State = EntityState.Detached;
    }
    if (track.Any())
    {
        foreach (var t in track)
        {
            Console.WriteLine($" track 2 {t.Entity.ToString()} - {t.State}");
        }
    }
    else Console.WriteLine("not tarck ");

    */
 i = 0;

// delete
/*
    var stu = db.Students.Find(3);
    db.Students.Remove(stu); // check nuallable

    var list = db.Students.Where(x=> x.departmentId == 4).ToList();
    db.Students.RemoveRange(list);

    */

 i = i = 0;
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
*/

i = i + 1;
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

i = i + 2;
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

