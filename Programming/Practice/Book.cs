// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;

public class HelloWorld
{
    public class Book{
        public string Id {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public int Price{get; set;}
        public int Stock{get; set;}
    }
    
    public class BookUtility{
        //this would help me store the book;
        public static List<Book> bookRepo = new List<Book>();
        public void AddBook(Book book){
            bookRepo.Add(book);
        }
        public void GetBookDetails(){
            //print the book details;
            Console.WriteLine($"Details: BookId     Title   Price   Stock");
            foreach(var item in bookRepo){
                Console.WriteLine($"     {item.Id}   {item.Title}    {item.Price}    {item.Stock}");
            }
        }
        
        public void UpdateBookPrice(int newPrice, string Id){
            foreach(var item in bookRepo){
                if(item.Id == Id){
                    item.Price = newPrice;
                }
            }
            Console.WriteLine($"Updated Price: {newPrice}");    
        }
        
        public void UpdateBookStock(int newStock, string Id){
             foreach(var item in bookRepo){
                if(item.Id == Id){
                    item.Stock = newStock;
                }
            }
            Console.WriteLine($"Updated Stock: {newStock}");
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the inital entry of book");
        string input = Console.ReadLine();
        Book book1 = new Book();
        BookUtility bu = new BookUtility();
        string[] split = input.Split(" ");
        book1.Id = split[0];
        book1.Title = split[1];
        book1.Price = int.Parse(split[2]);
        book1.Stock = int.Parse(split[3]);
        bu.AddBook(book1);
        
        int choice;
        do{
            choice = int.Parse(Console.ReadLine());
            switch(choice){
                case 1:
                    bu.GetBookDetails();
                    break;
                case 2: 
                    int newPrice = int.Parse(Console.ReadLine());
                    string bokId = Console.ReadLine();
                    bu.UpdateBookPrice(newPrice, bokId);
                    break;
                case 3:
                    int newStock = int.Parse(Console.ReadLine());
                    bokId = Console.ReadLine();
                    bu.UpdateBookStock(newStock, bokId);
                    break;
                case 4:
                    Console.WriteLine("Thank You");
                    break;
            }
            
        }while(choice != 4);
        
        
    }
}