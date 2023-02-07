﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Logger.Tests;

[TestClass]
public class StorageTests
{
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    Storage storage;
    
    Book book = new Book("Princess Bride");
    Employee employee = new Employee(new FullName("Inigo", "Montonoya"));
    Student student = new Student(new FullName("Prince", "Humperdinck"));

    [TestInitialize]
    public void testInit()
    {
        storage = new Storage();
        storage.Add(book);
        storage.Add(employee);
        storage.Add(student);
    }

    [TestMethod]
    public void Storage_Get_Returns_Expected_ID()
    {

    }

    [TestMethod]
    public void Storage_Add_Adds_Entity()
    {
        Book new_book = new Book("Princess Bride 2: On the Knife's Edge");

        storage.Add(new_book);

        Assert.IsTrue(storage.Contains(new_book));
    }

    [TestMethod]
    public void Storage_Remove_Removes_Entity()
    {
        storage.Remove(book);

        Assert.IsFalse(storage.Contains(book));
    }

    [TestMethod]
    public void Storage_Contains_Returns_Expected_Item()
    {
        Assert.IsTrue(storage.Contains(book));
    }
}