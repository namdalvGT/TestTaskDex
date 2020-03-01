using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppEvents_11.Model
{
    public class Person : INotifyPropertyChanged
    {
        private int id { get; set; }
        public int Id
        {
            get { return id; }
            set
            {

                id = value;
                OnPropertyChanged("Id");

            }
        }


        private string fullName { get; set; }
        public string FullName
        {
            get { return fullName; }
            set
            {

                fullName = value;
                OnPropertyChanged("FullName");

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
