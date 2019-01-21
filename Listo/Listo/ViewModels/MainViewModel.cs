using System;
using System.Collections.Generic;
using System.Text;

namespace Listo.ViewModels
{
    public class MainViewModel
    {
        #region ViewModel
        public CategoryViewModel Category { get; set; }

        public HogarViewModel Hogar { get; set; }

        public ProfesionalViewModel Profesional { get; set; }

        public SaludViewModel Salud { get; set; }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            //this.Category = new CategoryViewModel();
            this.Salud = new SaludViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion
    }
}
