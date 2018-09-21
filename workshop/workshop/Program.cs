using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop
{
    //said pepe team
    public class BussinessLogic {
               
        public float sum(float num1, float num2)
        {
            
            float suma = 0;

            suma = num1 + num2;
            return suma;
        }     

    }


    public class Repository {
        WORKSHOPEntities _context; //Esta es la conexion con la base de datos

        public Repository() { //Con todo y el constructor
            _context = new WORKSHOPEntities(); //Inicializando
        }
        
        public void RegisterUser( ) //Parametro de tipo user siempre no 
        {            
            User user = new User();
            var u = _context.Users.ToList();

            user.Id = u.Count();

            Console.WriteLine("Please Enter Name:");
            user.Name = Console.ReadLine();

            Console.WriteLine("Please Enter Last Name:");
            user.LastName = Console.ReadLine();

            Console.WriteLine("Please Enter Position:");
            user.Position = Console.ReadLine();

            _context.Users.Add(user);
            _context.SaveChanges();

            Console.WriteLine("Your Changes have been saved");
            Console.WriteLine("");
            Console.WriteLine("Please press <ENTER> to continue");
            Console.ReadLine();
            

                                                  

        }

        public List<User> GetAllUsers() // Lista 
        {
            return _context.Users.ToList(); //Traer todo de la base de datos

        }
    }

    class Program
    {
            
        static void Main(string[] args) //--------------------------------------------------------------- M   A  I  N
        {
            Repository _repo = new Repository();
            BussinessLogic _b = new BussinessLogic();

            int again = 1;
            while (again == 1)
            {
                
                Console.WriteLine("=========== M E  N  U ===========");
                Console.WriteLine("Press 1. To register an user");
                Console.WriteLine("Press 2. To sum 2 numbers");
                Console.WriteLine("Press 3. To see registered users");
                Console.WriteLine("Press 4. Exit");
                Console.WriteLine("=================================");
                Console.WriteLine("");
                Console.WriteLine("Select an option : ");
                string opcion = Console.ReadLine();
                int x = int.Parse(opcion);
                Console.Clear();

                switch (x)
                {
                    case 1:
                        Console.WriteLine("===========> Option 1");
                        _repo.RegisterUser();


                        break;
                    case 2:
                        Console.WriteLine("===========> Option 2");

                        Console.WriteLine("Number 1:");
                        string numuno = Console.ReadLine();
                        float num1 = float.Parse(numuno);
                        Console.WriteLine("Number 2:");
                        string numdos = Console.ReadLine();
                        float num2 = float.Parse(numdos);
                        float lasuma = _b.sum(num1, num2);
                        Console.WriteLine("The result is  [ " + lasuma + " ]");
                        
                        Console.WriteLine("Please press <ENTER> to continue");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("===========> Option 3");
                        var users = _repo.GetAllUsers();
                        foreach (var user in users)
                        {
                            Console.WriteLine("User: {0} {1}", user.Name, user.LastName);
                            Console.WriteLine("Position {0}", user.Position);
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Please press <ENTER> to continue");
                        Console.ReadLine();
                        break;
                    case 4:
                        again = 2;
                        break;

                    default:
                        Console.WriteLine("Otro numero pls :3");
                        break;
                }
                Console.Clear();
            }
           
            

        }
    }
}
