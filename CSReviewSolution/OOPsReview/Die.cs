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
         public int Side
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
                }
                else
                {
                    throw new Exception("Die cannot have space " + value.ToString() + " sides! Die can have 6 to 20 sides.");
                }
            }
        }

         //Auto implemented property



    
    }
}
