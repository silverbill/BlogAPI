using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public interface IClassroom {
    void add(Student s); // CREATE
    IEnumerable<Student> getAll(); // READ
    Student get(int id); // READ
    Student update(int id, Student s); // UPDATE
    void delete(int id); // DELETE
}

public class Student {
    public int StudentId {get; set;}
    public string Name {get; set;}
    public bool IKnowCSharp {get; set;} = false;

    public Student(){
        StudentId = new Random().Next();
    }
}

public class Classroom : IClassroom {

    private List<Student> students = new List<Student>();

    public Classroom(){
        students.Add(new Student { StudentId = 1, Name = "Pip", IKnowCSharp = true });
        students.Add(new Student { StudentId = 2, Name = "Damien" });
    }

    public void add(Student s){
        students.Add(s);
    }
    public IEnumerable<Student> getAll(){
        return students;
    }
    public Student get(int id){
        return students.First(s => s.StudentId == id);
    }
    public Student update(int id, Student s){
        Student toUpdate = students.First(x => x.StudentId == id);
        if(toUpdate != null){
            students.Remove(toUpdate);
            students.Add(s);
            return s;
        }
        return null;
    }
    public void delete(int id){
        Student s = students.First(x => x.StudentId == id);
        if(s != null){
            students.Remove(s);
        }
    }
}