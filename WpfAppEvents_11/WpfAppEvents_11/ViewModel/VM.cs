using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WpfAppEvents_11.Model;

namespace WpfAppEvents_11.ViewModel
{
    public class VM:INotifyPropertyChanged
    {

        private Main main { get; set; } = new Main();
        public Main Main
        {
            get { return main; }
            set
            {

                main = value;
                OnPropertyChanged("Main");

            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }
    }
}
