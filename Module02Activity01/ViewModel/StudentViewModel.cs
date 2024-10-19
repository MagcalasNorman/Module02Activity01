using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module02Activity01.Model;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Module02Activity01.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        private Student _student;

        private string _fullName; 
        public StudentViewModel()
        {
           
            _student = new Student { FirstName = "Bernie", LastName = "Fernando", Age = 23 };
            //UI Thread Management
            LoadStudentDataCommand = new Command(async () => await LoadStudentDataAsync());

            Students = new ObservableCollection<Student>
            {
                new Student {FirstName="Norman", LastName="Magcalas", Age=22 },
                new Student {FirstName="Ingram", LastName="Manuel", Age=23 },
                new Student {FirstName="Calvin", LastName="Pamandanan", Age=24},

            };

        }

        public ObservableCollection<Student> Students { get; set; }


    public string FullName
        {
            get => _fullName;
            set
            {
                if(_fullName != value) 
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        
        public ICommand LoadStudentDataCommand { get;}

        private async Task LoadStudentDataAsync()
        {
            await Task.Delay(1000);
            FullName = $"{_student.FirstName} {_student.LastName}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
