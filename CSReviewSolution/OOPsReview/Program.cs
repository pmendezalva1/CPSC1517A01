using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    class Program
    {
        static void Main(string[] args)
        {

            //new: causes an instance (occurance) of the specified
            //   class to be created and placed in the
            //   receiving variable
            //the variable is a pointer address to the actual
            //   physical memory location of the instance


            //declaring an instance (occurance) of the specified
            //   class will not create a physical instance, just a 
            //   a pointer which can hold a physical instance
            Turn theTurn; //will not work because instead of creating a physical instance, you just created an area in memory that is null.
            //where the address OF an instance can be place.
            List<Turn> Rounds = new List<Turn>(); //Create the physical List<T>

            //new: causes the constructor of a class to execute
            //   and a physical instance to be created
            Die Player1 = new Die();
            //It takes the address of where the object sits in memory and saves the pointer.
            //Here, the default constructor is used because there's nothing in the brackets. If there was anything, the overloaded
            //constructor would be used. It knows by the signature what you want to call.
            Die Player2 = new Die(6,"green");
            //This grabs the greedy constructor.

            //Player1.Sides = 6;
            //Player1.Colour = "white";
            //This would be the same as declaring it empty, in that you're directly changing the value.

            string menuChoice = "";
            do
            {
                //Console is a static class
                Console.WriteLine("\nMake a choice\n");
                Console.WriteLine("A) Roll");
                Console.WriteLine("B) Set number of dice sides");
                Console.WriteLine("C) Display Current Game Stats");
                Console.WriteLine("X) Exit\n");
                Console.Write("Enter your choice:\t");
                menuChoice = Console.ReadLine();

                //user friendly error handling
                try
                {
                    switch (menuChoice.ToUpper())
                    {
                        case "A":
                            {
                                //Turn is a non-static class
                                //Since it's non static, we need to create a new instance to use to store data in.
                                theTurn = new Turn(); //creates the physical instance

                                //generate a new FaceValue
                                Player1.Roll();
                                //generate a new FaceValue
                                Player2.Roll();
                                // save the roll 
                                //Lefthand side of the equal sign is the set, right is get.
                                //      set     =       get
                                theTurn.Player1 = Player1.FaceValue;
                                theTurn.Player2 = Player2.FaceValue;

                                //display the round results
                                Console.WriteLine("Player 1 rolled {0}, player 2 rolled {2}.", Player1.FaceValue, theTurn.Player2);
                                //This will be the same as saying Player2.FaceValue.
                                if (Player1.FaceValue > Player2.FaceValue)
                                {
                                    Console.WriteLine("Player 1 wins!");
                                }
                                else if(Player2.FaceValue > Player1.FaceValue)
                                {
                                    Console.WriteLine("Player 2 wins!");
                                }
                                else
                                {
                                    Console.WriteLine("It's a draw!");
                                }
                                //track the round
                                //Remember, create lists outside the loop so we can keep the values for later!
                                Rounds.Add(theTurn);
                                break;
                            }
                        case "B":
                            {
                                string inputSides = "";
                                int sides = 0;

                                Console.Write("Enter your number of desired sides (greater than 1):\t");
                                inputSides = Console.ReadLine();

                                //using the conversion try version of parsing
                                // TryParse has two parameters
                                // one: in string to convert
                                // two: the output conversion value if the string can be
                                //      converted
                                // successful conversion returns a true bool
                                // failed conversion returns a false bool
                                if (int.TryParse(inputSides, out sides)) //TryParse checks if it's true or false, then will put the value into sides
                                {
                                    //validation of the incoming value
                                    if (sides > 1)
                                    {
                                        //set the die instance Sides
                                        //Player1.Sides = sides;
                                        //Player2.Sides = sides;
                                        //OR
                                        Player2.Sides = Player1.Sides = sides;
                                        //Values are assigned right to left.
                                    }
                                    else
                                    {
                                        throw new Exception("You did not enter a numeric value greater than 1.");
                                    }
                                }
                                else
                                {
                                    throw new Exception("You did not enter a numeric value.");
                                }
                                break;
                            }
                        case "C":
                            {
                                //Display the current players' stats
                                DisplayCurrentPlayerStats(Rounds);
                                break;
                            }
                        case "X":
                            {
                                //Display the final players' stats
                                DisplayCurrentPlayerStats(Rounds);
                                Console.WriteLine("\nThank you for playing.");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Your choice was invalid. Try again.");
                                break;
                            }
                    }//eos
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: " + ex.Message);
                    Console.ResetColor();
                }
            } while (menuChoice.ToUpper() != "X");
        }//eomain

        public static void DisplayCurrentPlayerStats(List<Turn> Rounds)
        {

            int wins1 = 0;
            int wins2 = 0;
            int draws = 0;

            //travser the List<Turn> to calculate wins, losses, and draws
            foreach(Turn item in Rounds)
            {
                if (item.Player1 > item.Player2)
                {
                    wins1 = wins1 + 1;
                }
                else if (item.Player2 > item.Player1)
                {
                    wins2 += 1;
                }
                else
                {
                    draws++;
                }
            }
            //Foreach needs a placeholder and to know where it's coming from. Var instead of Turn works too. 
            //But var isn't set until it executes for the first time. Timing is the diff.
            //display the results
            Console.WriteLine("\n Total Rounds: " + (wins1 + wins2 + draws).ToString());
            Console.WriteLine("\nPlayer1: Wins: {0}  Player2: Wins: {1}  Total Draws: {2}",
                wins1, wins2, draws);

        }
    }
}

