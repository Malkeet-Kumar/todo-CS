using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace todoCli
{

    class MyTodo
    {
        TodoDataContext context;
        public MyTodo()
        {
            context = new TodoDataContext();
        }
        public void printAllTodos()
        {
            var data = from x in context.Todos select x;
            foreach (var a in data)
            {
                string status;
                if (a.status == 1)
                    status = "Done";
                else
                    status = "Pending";
                Console.WriteLine($"id->{a.todoId}    task->{a.task}    status->{status}");
            }
        }

        public string createTodo(string task)
        {
            try
            {
                Todo todo = new Todo() { task = task, status = 0 };
                context.Todos.InsertOnSubmit(todo);
                context.SubmitChanges();
                return "Saved";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string markTodo(int todoId)
        {
            try
            {
                Todo todo = new Todo();
                todo = context.Todos.Single(t => t.todoId == todoId);
                if (todo.status == 0)
                {
                    todo.status = 1;
                }
                else
                {
                    return "Todo already marked done !";
                }
                context.SubmitChanges();
                return "Todo Marked Done";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string deleteTodo(int todoId)
        {
            try
            {
                Todo todo = new Todo();
                todo = context.Todos.Single(t => t.todoId == todoId);
                context.Todos.DeleteOnSubmit(todo);
                context.SubmitChanges();
                return "Todo Deleted Successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    class Helper
    {
        public Helper() { }
        public int getChoice()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public void clearConsole() {
            Console.ReadKey();
            Console.Clear();
           // Console.WriteLine("---Menu---\n1. Add Todo\n2. Mark Todo Done\n3. Delete a Todo\n4. Show Todos\n0. Exit");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper h = new Helper();
            Console.WriteLine("-----Welcome to Todo List----");
            Console.WriteLine("---Menu---\n1. Add Todo\n2. Mark Todo Done\n3. Delete a Todo\n4. Show Todos\n0. Exit");
            int choice = h.getChoice();               
            MyTodo todo = new MyTodo();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter task:");
                        string task = Console.ReadLine();
                        Console.WriteLine(todo.createTodo(task));
                        h.clearConsole();
                        break;
                    case 2:
                        Console.WriteLine("Enter TodoId to mark done:");
                        int todoId = h.getChoice();
                        if (todoId >= 0)
                            Console.WriteLine(todo.markTodo(todoId));
                        else
                            Console.WriteLine("Enter a valid number");
                        h.clearConsole();
                        break;
                    case 3:
                        Console.WriteLine("Enter TodoId to delete");
                        int todo_Id = h.getChoice();
                        if (todo_Id > 0)
                            Console.WriteLine(todo.deleteTodo(todo_Id));
                        else
                            Console.WriteLine("Enter a valid number");
                        h.clearConsole();
                        break;
                    case 4:
                        Console.WriteLine("List of Todos...");
                        todo.printAllTodos();
                        h.clearConsole();
                        break;
                    default:
                        Console.WriteLine("Please Enter a valid Choice !");
                        break;
                }
                Console.WriteLine("---Menu---\n1. Add Todo\n2. Mark Todo Done\n3. Delete a Todo\n4. Show Todos\n0. Exit");
                choice = h.getChoice();
            }
            Console.Write("Exiting.....");
        }
    }
}
