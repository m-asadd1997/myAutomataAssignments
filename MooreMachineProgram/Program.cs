using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooreMachineProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-*-*-*-*-*-*-*-*-*-*-*-* MOORE MACHINE FOR MODULUS -*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine();
            //for mod m, taking "m" as input!
            Console.WriteLine("Enter mod 'm' (Number Of States) : ");
            int m = Convert.ToInt32(Console.ReadLine());


            int[,] state_information = new int[m, 3];
            //storing states information
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("Enter transition for 0 at state " + i + " : ");
                        state_information[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                    else if (j == 1)
                    {
                        Console.Write("Enter transition for 1 at state " + i + " : ");
                        state_information[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                        //output at each state 3rd column of our table
                    else if (j == 2)
                        state_information[i, j] = i;


                }
            }
            Console.Clear();

            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-* TRANSITION TABLE FOR MODULUS MOORE MACHINE *-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine();
            Console.WriteLine("{ Q }{  0  }{  1  }{Output}");
            Console.WriteLine("...........................");
            for (int i = 0; i < m; i++) {
                Console.Write("{ " +i+" }");
                
                for (int j = 0; j < 3; j++) {
               
                    Console.Write("{  " + state_information[i,j] + "  }");
                
                }
                Console.WriteLine();
            
            
            
            }

            Console.WriteLine();
            again:
            Console.WriteLine("Enter any Number: ");
            int num = Convert.ToInt32(Console.ReadLine());

            //converting number in binary
            string num_in_binary=Convert.ToString(num, 2);

            Console.WriteLine(" Your Number in binary is: {0}",num_in_binary);


            int output = OutputGenerator(num_in_binary, state_information);
            Console.WriteLine("Output Remainder is: {0}", output);

            goto again;

            Console.Read();

        }
        public static int OutputGenerator(string str, int[,] state_info) {

            int currentState = 0, output=0;
            //traversing through states on the basis of binary string
            for (int i = 0; i < str.Length; i++) {

                currentState = state_info[currentState, Convert.ToInt32(str[i])-48];
                output = state_info[currentState, 2];
            }
            //returning output remainder here
            return output;
        }
    }
}
