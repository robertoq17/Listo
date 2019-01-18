using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Listo.Models
{
    class CGroup : ObservableCollection<Contact>, INotifyPropertyChanged
    {
        public bool expanded;

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

        public CGroup(string title, string shortName, bool expanded = true)
        {
            Title = title;
            ShortName = shortName;
            Expanded = expanded;
        }

        public static ObservableCollection<CGroup> All { private set; get; }

        static CGroup()
        {
            ObservableCollection<CGroup> Groups = new ObservableCollection<CGroup>{
                new CGroup("Cardiologos","C"){
                    new Contact { Name = "Romeo Santo", Description = "20 años de experiencia",  Icon="people.png", Phonenumber="76021703" },
                    new Contact { Name = "Jose Luis P", Description = "15 años de experiencia", Icon="people.png", Phonenumber="76021703" },
                },
                new CGroup("Ginecologos","G"){
                    new Contact { Name = "Martha Azurduy", Description = "5 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Felipa Dominguez", Description = "4 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                },
                new CGroup("Pediatras","P"){
                    new Contact { Name = "Brian Matador", Description = "6 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Kevin Peligroso", Description = "2 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                },
                new CGroup("Urologos","U"){
                    new Contact { Name = "Milko Reyes", Description = "30 años de experiencia", Icon="people.png", Phonenumber="76021703"},
                    new Contact { Name = "Max Aluiarte", Description = "2 años de experiencia", Icon="people.png", Phonenumber="76021703"},

                } };
            All = Groups;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
