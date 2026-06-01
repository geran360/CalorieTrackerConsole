using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrackerData
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Calorias { get; set; }

        private bool _isSelected = false;
        [NotMapped]
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Ingrediente(string nombre, int calorias)
        {
            this.Nombre = nombre;
            this.Calorias = calorias;
        }
    }
}
