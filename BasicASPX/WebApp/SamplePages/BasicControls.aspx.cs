using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //We could retrieve data from a stored variable that is part of the webpage saved under the ViewState.
        //ViewState exists only while the page does. It takes the data with it to the browser and brings data back. 
        //Compressed version of what is on the form. When you change pages, ViewState becomes empty.
        //So instead, we'll use a static List<T> for this example. Normally, your data would be coming from the db.

        public static List<DDLClass> DataCollection;

        protected void Page_Load(object sender, EventArgs e)
        {
            //This method is executed automatically on EACH and EVERY pass of the page.
            //This method is executed BEFORE ANY EVENT method on this page.


            //clear any old messages
            OutputMessage.Text = "";
            //This method is an excellent place to do page initialization. 
            //You can test the postback of the page (Razor IsPost) by checking the Page.IsPostBack property.
            if (!Page.IsPostBack)
            {
                //The first time the page is proccessed.

                //Create an instance of the list of T.
                DataCollection = new List<DDLClass>();

                //Load the collection with a series of DDLClass instances. Create the instances using the greedy constructor.
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(3, "DMIT2018"));
                DataCollection.Add(new DDLClass(4, "DMIT1508"));
                //When we use db's, this is the only thing that will be replaced.

                //Use the List<T> method called .Sort to sort the contents of the list.
                //(x,y) the x and y represent any 2 instances at any time in your collection. 
                //x.field compared to y.field (ascending)
                //y.field compared to x.field (descending)
                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));
                //=> is a Lambda expression, don't mix it up with >=! 
                //=> Means for X and Y, /do the following/, then specify what you want done.

                //Load your data collection to the ASP control you are interested in: DropDownList
                //Could also be done to a radio button list dynamically. 
                //A) Assign your data collection to the control.
                CollectionList.DataSource = DataCollection;

                //B) Setup any neccessary properties on your ASP control that are required to properly work.
                //The dropdownlist will generate the HTML select tag code. Thus we need 2 properties to be set.
                //i) Value property (DataValueField)
                //ii) Display property (DataTextField)
                //The properties are set up by assigning the data collection field name to the control property.
                CollectionList.DataValueField = "ValueField";
                CollectionList.DataTextField = nameof(DDLClass.DisplayField); //A way to do it without hardcoding the value.

                //C) Bind your data to the control.
                CollectionList.DataBind();

                //What about prompts? Manually place a line item at the beginning of your control.
                CollectionList.Items.Insert(0, "select ...");
            }
        }
        protected void SubmitChoice_Click(object sender, EventArgs e)
        {
            //How does one retrieve or assign data to an ASP control?
            //Retrieving or assigning data to a control is dependent on the specific control. 
            //For TextBox, Label, Literal use .Text
            //For Checkbox (boolean) use .Check
            //For positioning in a List control (DropDownList, RadioButtonList, CheckBoxList) 
            //a) .SelectedValue     for the data value
            //b) .SelectedIndex     for the physical index location in the list
            //c) .SelectedItem      for the display text

            //Most data from the controls will be strings. The exception is boolean type controls (true/false).
            string submitchoice = TextBoxNumericChoice.Text;

            //you can do any type of validation against your code
            if(string.IsNullOrEmpty(submitchoice))
            {
                OutputMessage.Text = "Enter a course choice between 1 and 4.";
            }
            else
            {
                //for the RadioButtonList we could use .SelectedIndex, .SelectedValue or .SelectedItem.
                //We want to use the associated value for the button, not the position.
                RadioButtonListChoice.SelectedValue = submitchoice;
                //Position in our list to the value x. Only use index with regards to the physical position.

                //CheckBox (boolean)
                if(submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }

                //position in the DropDownList using the value in submitchoice.
                //Remember SelectedIndex is the PHYSICAL index location of an item in the list. It is NOT the associated value.
                CollectionList.SelectedValue = submitchoice;
                //If we were gathering data, the object would be on the right side, but we're displaying it here so it's on the left.

                //Use the 3 properties for a list control as a demo.
                DisplayDataReadOnly.Text = CollectionList.SelectedItem.Text
                    + " at index " + CollectionList.SelectedIndex + " has a value of "
                    + CollectionList.SelectedValue;
            }
        }
        protected void ListSubmit_Click(object sender, EventArgs e)
        {
            //Validation: Check that a selection was made
            //Prompt is on physical row 1 (index = 0)
            string submitchoice = CollectionList.SelectedValue;

            if (CollectionList.SelectedIndex == 0)
            {
                OutputMessage.Text = "Select a course to view.";
            }
            else
            {
                RadioButtonListChoice.SelectedValue = submitchoice;

                if (submitchoice.Equals("2") || submitchoice.Equals("3"))
                {
                    CheckBoxChoice.Checked = true;
                }
                else
                {
                    CheckBoxChoice.Checked = false;
                }
                TextBoxNumericChoice.Text = submitchoice;

                DisplayDataReadOnly.Text = CollectionList.SelectedItem.Text
                    + " at index " + CollectionList.SelectedIndex + " has a value of "
                    + CollectionList.SelectedValue;
            }
        }
    }
}