using Listo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Listo.ViewModels
{
    public class GroupViewModel : ObservableCollection<Contact>, INotifyPropertyChanged
    {
        #region Attributes
        public bool expanded;
        #endregion

        #region Properties
        public string Title { get; set; }

        public string TitleWithItemCount
        {
            get { return string.Format("{0} ({1})", Title, CCount); }
        }

        public string ShortName { get; set; }

        public bool Expanded
        {
            get { return expanded; }
            set
            {
                if (expanded != value)
                {
                    expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public string StateIcon
        {
            get { return Expanded ? "drop_arrow.png" : "arrow_left.png"; }
        }

        public int CCount { get; set; }

        public static ObservableCollection<GroupViewModel> All { private set; get; }

        public static ObservableCollection<GroupViewModel> AllH { private set; get; }

        public static ObservableCollection<GroupViewModel> AllP { private set; get; }
        #endregion

        #region Constructor
        public GroupViewModel(string title, string shortName, bool expanded = true)
        {
            Title = title;
            ShortName = shortName;
            Expanded = expanded;
        }

        static GroupViewModel()
        {
            // Groups Salud
            ObservableCollection<GroupViewModel> Groups = new ObservableCollection<GroupViewModel>{
                new GroupViewModel("Cardiologos","C"){
                    new Contact { Name = "Romeo Santo", Description = "20 años de experiencia",  Icon="people.png", Phonenumber="76021703" },
                    new Contact { Name = "Jose Luis P", Description = "15 años de experiencia", Icon="people.png", Phonenumber="76021703" },
                },
                new GroupViewModel("Ginecologos","G"){
                    new Contact { Name = "Martha Azurduy", Description = "5 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Felipa Dominguez", Description = "4 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                },
                new GroupViewModel("Pediatras","P"){
                    new Contact { Name = "Brian Matador", Description = "6 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Kevin Peligroso", Description = "2 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                },
                new GroupViewModel("Urologos","U"){
                    new Contact { Name = "Milko Reyes", Description = "30 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Max Aluiarte", Description = "2 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                } };
            All = Groups;

            // Groups Profesional
            ObservableCollection<GroupViewModel> Groupp = new ObservableCollection<GroupViewModel>{
                new GroupViewModel("Arquitectos","A"){
                    new Contact { Name = "Romeo Santo", Description = "20 años de experiencia",  Icon="people.png", Phonenumber="1" },
                    new Contact { Name = "Jose Luis P", Description = "15 años de experiencia", Icon="people.png", Phonenumber="2" },
                },
                new GroupViewModel("Ing. Civiles","C"){
                    new Contact { Name = "Martha Azurduy", Description = "5 años de experiencia", Icon="people.png", Phonenumber="3"},
                    new Contact { Name = "Felipa Dominguez", Description = "4 años de experiencia", Icon="people.png", Phonenumber="4"},
                },
                new GroupViewModel("Industriales","I"){
                    new Contact { Name = "Brian Matador", Description = "6 años de experiencia", Icon="people.png", Phonenumber="5"},
                    new Contact { Name = "Kevin Peligroso", Description = "2 años de experiencia", Icon="people.png", Phonenumber="6"},
                },
                new GroupViewModel("Jueces","J"){
                    new Contact { Name = "Milko Reyes", Description = "30 años de experiencia", Icon="people.png", Phonenumber="7"},
                    new Contact { Name = "Max Aluiarte", Description = "2 años de experiencia", Icon="people.png", Phonenumber="8"},
                } };
            AllP = Groupp;

            // Groups Hogar
            ObservableCollection<GroupViewModel> Grouph = new ObservableCollection<GroupViewModel>{
                new GroupViewModel("Albañiles","A"){
                    new Contact { Name = "Romeo Santo", Description = "20 años de experiencia",  Icon="people.png", Phonenumber="76021703" },
                    new Contact { Name = "Jose Luis P", Description = "15 años de experiencia", Icon="people.png", Phonenumber="76021703" },
                },
                new GroupViewModel("Electricista","E"){
                    new Contact { Name = "Martha Azurduy", Description = "5 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Felipa Dominguez", Description = "4 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                },
                new GroupViewModel("Fontaneros","F"){
                    new Contact { Name = "Brian Matador", Description = "6 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Kevin Peligroso", Description = "2 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                },
                new GroupViewModel("Jardineros","J"){
                    new Contact { Name = "Milko Reyes", Description = "30 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Max Aluiarte", Description = "2 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                } };
            AllH = Grouph;
        }
        #endregion

        #region Methods
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 
        #endregion
    }
}
