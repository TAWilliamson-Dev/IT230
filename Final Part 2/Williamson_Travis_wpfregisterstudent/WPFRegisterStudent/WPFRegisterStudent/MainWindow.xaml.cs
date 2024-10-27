using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFRegisterStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Course choice;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Course course1 = new Course("IT 145");
            Course course2 = new Course("IT 200");
            Course course3 = new Course("IT 201");
            Course course4 = new Course("IT 270");
            Course course5 = new Course("IT 315");
            Course course6 = new Course("IT 328");
            Course course7 = new Course("IT 330");


            this.comboBox.Items.Add(course1);
            this.comboBox.Items.Add(course2);
            this.comboBox.Items.Add(course3);
            this.comboBox.Items.Add(course4);
            this.comboBox.Items.Add(course5);
            this.comboBox.Items.Add(course6);
            this.comboBox.Items.Add(course7);


            this.textBox.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            choice = (Course)(this.comboBox.SelectedItem);

            //Obtain the current number of registered credit hours.
            int.TryParse(this.textBox.Text, out int creditHours);

            /*
             *  If the user is not already registered for this course and is not already registered for three classes,
             *  then add the class to the users list of registered courses. Print a message confirming successful registration.
             *  
             *  If the user is registered for 9 credit hours, then do not register the user for the class and print an error message.
             *  
             *  If the user is already registered for the course, do not register the user for the course again and print an error message.
             * 
             */
            if (choice != null)
            {
                if (!choice.IsRegisteredAlready() && creditHours < 9)
                {
                    Register(choice);
                    Message(Brushes.Black, "Successfully registered for " + choice.ToString());
                    AddHours(creditHours);
                }
                else if (choice.IsRegisteredAlready())
                {
                    Message(Brushes.Red, "Already registered for this course.");
                }
                else
                {
                    Message(Brushes.Red, "Unable to register for more than 9 credit hours.");
                }
            }
            else
            {
                Message(Brushes.Red, "Please select a course.");
            }
        }
        
        // Set course to registered and add to the listbox containing all registered courses.
        private void Register(Course choice)
        {
            choice.SetToRegistered();
            this.listBox.Items.Add(choice);
        }

        // Update content of label3 to represent the latest message, color coded by nature of the message. Black for successful execution of the last request, Red for failure / error.
        private void Message(Brush color, string message)
        {
            label3.Foreground = color;
            label3.Content = message;
        }

        //Update textBox to show latest registered hours.
        private void AddHours(int creditHours)
        {
            creditHours += 3;
            this.textBox.Text = "" + creditHours;
        }

    }

}
