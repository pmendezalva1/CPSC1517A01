using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Die
        //Namespaces let us organize our classes.
        //The default is private otherwise.
    {
        //If we didn't have the using System.Collections.Generic, we'd have to put them before the command over and over again. It's a fully qualified name/datatype.
        //Anytime we have to include the namespace, that's what we call it.

        //Use the System.Random class for the RNG calc! Make sure the instance is static so all instances of Die will use the same generator.
        //The instance of Random will be created when the first instance of Die is created and be destroyed when the last instance of Die is.
        public static Random _rnd = new Random(); //New causes a class instance to be created.

        /*Data members:
         * It's the physical storage area for data values. These are usually private. 
         */

        //Can't change this once it's private. When it's public though, it can be changed. The only way to access private from public is through a property.

        private int _Sides;
        private string _Colour;
        private int _FaceValue;
        private List<int> listofnumbers;
        //private SomeOtherClass myclass; Won't work cus it doesn't have a dt.
        //private List<SomeOtherClass> myGroupofInstances;  
        //We have tp keep an eye on the type of data we store. So in this case, we can use a string to record the information we get.

        //Properties
        /*Properties are public, and are used as an interface for the class user to access a data member. 
         * Accessing a data member can include a get and set. 
         * A get returns the value of a data member to the user. A set accepts a value and assigns it to the data member. 
         * A property returns a specific data type. It DOES NOT have a parameter list!
         * 2 types:*/

         //Fully implemented property
         public int Sides
        {//If you put a ? after the data type, it becomes nullable or nothing. So int? is valid!
            //This means Sides = ""; is not the same as null (tho it is nothing), so in the ? case, Sides = null;
            get
            {
                //returns the current value of the data member
                return _Sides;
            }
            //It's called a recursive calls if you have it return the property. But you need to make sure it doesn't endlessly loop its calculations or it crashes.
            set
            {
                //can be private tho it's usually public. It accepts a value and assigns it to the data member. The value is stored in a key word: value.
                //The datatype of value is the return datatype of the property.
                //We can do validation here.
                if (value >= 6 && value <= 20)
                {
                    _Sides = value;
                    Roll(); //Gives us a valid face value for whatever number of sides we assign to the dice.
                }
                else
                {
                    throw new Exception("Die cannot have space " + value.ToString() + " sides! Die can have 6 to 20 sides.");
                }
            }
        }

         //Auto implemented property
         /*There is no defined data member for this type of property! Instead, the system creates an internal storage area of the property data type and manages the area for your code.
         Typically, this type of property is commonly used when no validation is required for the data.*/

        public int FaceValue { get; private set; }
        //It's a fast way of coding a property. It just hangs onto the data. Just use this when you don't need validation.
        //Private set means the computer determines it from inside the class, not the user. 

        public string Colour
        {
            get
            {
                return _Colour;
            }
            set
            {
                //value == "" would test an empty string.
                //value == null would test if no string exists.
                //string.IsNullOrEmpty(value) would test for both of these.
                //WhiteSpace will check if there's a bunch of spaces instead of Empty.
                //Could've also done value.Trim() to get rid of empty spaces.
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Colour is invalid! You must have a colour. Please try again.");
                }
                else
                {
                    _Colour = value;
                }
            }
        }

        //Constructors
        /*Optional. If you do not include a constructor for your class,
         then when an instance of the class is created, the system will assign
         the normal default values of that data type to the appropriate data member.
         * If you declare an instance of a constructor within your class definition,
         then you are responsible for all constructors for the class!
         They are NOT called directly by the user of the class! It isn't like a method.
         The constructor will be called when you ask the system to create an instance of the class.*/

        //2 types:
        //Default constructor
        /*This is similar to having a system constructor. It replaces them.
         *It has no parameters. So we assign the default info.
         * Headers = properties, calling statements = arguments*/
         //syntax: Public Classname([list of parameters]) {coding body} [This is optional]
         public Die()
        {
            //With no code, this is the same as the system using the default constructor. Ints = 0, everything else would be set to null. Would have to code if you want a greedy constructor.
            //Could also be altered to put in our own values.
            //Typically this constructor will have no code. We could assign our own defaults.
            _Sides = 6;
            Colour = "Red"; //Can use our property to define this!
            Roll();
        }

        //Greedy constructor
        /*Takes in values for each of our data members/auto properties, which allows the outside 'user' to specify values at time of creation for the instance.
         * There's a way to create the instance (the argument) and have the program use the constructor (parameters) and set them right away. That's what the greedy constructor does.*/
        public Die(int sides, string colour)
        {
            //This is info coming from the user! Validate that info!
            Sides = sides;
            Colour = colour;
            Roll();
            //This is a memory pointer assigned to each instance, saying that it is that value. It's implied, not coded. So we could've used this.Sides here.
            //Could then use this.Sides = Sides. This points to the data member of the class. Without it, it interprets the others Sides as the parameter in the class (local variable).
        }
        //The last component we have are behaviours/methods. They interact with the data.
        /*A method allows the user to:
        A. Manipulate the data of the instance
        B. Use the data of the instance to generate some other info.*/
        
        public void Roll()
        {
            //Will generate a random value for FaceValue.
            FaceValue = _rnd.Next(1, Sides + 1);
        }       
        
    }
}
