using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ParkCity.Class.Command;
using WpfAppEvents_11.Model;

namespace WpfAppEvents_11
{
   public class Main:INotifyPropertyChanged
    {


        public Main()
        {
            PersonSelect = Getinfo();

        }


        private Person personSelect { get; set; }
        public Person PersonSelect
        {
            get { return personSelect; }
            set
            {

                personSelect = value;
                OnPropertyChanged("PersonSelect");

            }
        }



        public  Person Getinfo()
        {
            return new Person(){Id = 1,FullName = "Иванов Иван Иванович"};

        }

        //сохранение новой фио
        public RelayCommand Rel_ShowForm;
        public RelayCommand RelShowForm
        {
            get
            {
                return Rel_ShowForm ??
                       (Rel_ShowForm = new RelayCommand(obj =>
                       {
                           if (Visible==Visibility.Visible)
                           {
                               Visible = Visibility.Collapsed;
                           }
                           else
                           {
                               Visible = Visibility.Visible;
                           }
                          

                       }));
            }
        }


        private Visibility visible { get; set; } = Visibility.Collapsed;
        public Visibility Visible
        {
            get { return visible; }
            set
            {

                visible = value;
                OnPropertyChanged("Visible");

            }
        }

        //сохранение новой фио
        public RelayCommand Rel_SaveNewFio;
        public RelayCommand RelSaveNewFio
        {
            get
            {
                return Rel_SaveNewFio ??
                       (Rel_SaveNewFio = new RelayCommand(obj =>
                       {
                           if (obj != null)
                           {
                               var newfio = (string)obj;
                               if (!string.IsNullOrEmpty(newfio))
                               {
                                   PersonSelect = new Person() { Id = 1, FullName = newfio };
                                   Visible = Visibility.Collapsed;
                               }
                               else
                               {
                                   MessageBox.Show("Вы не указали новое ФИО", "Внимание");
                               }
                               
                             
                           }
                           
                       }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
