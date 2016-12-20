using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using INotifyPropertyChangedDemo.Annotations;

namespace INotifyPropertyChangedDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.PropertyChanged += P_PropertyChanged;
            p.FirstName = "Richard";
            p.FirstName = "Bill";

            Console.WriteLine();


        }

        private static void P_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine($"\t{e.PropertyName} has changed value.");
        }
    }


    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;

                OnPropertyChanged("FirstName");
                //PropertyChanged?.Invoke(null, new PropertyChangedEventArgs("FirstName"));

            }
        }


        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
