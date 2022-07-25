using SCADABepTuDongWPFV3.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SCADABepTuDongWPFV3.ViewModel
{
    public class IngredientViewModel
    {
        private ObservableCollection<Ingredient> _List;
        public ObservableCollection<Ingredient> List { get => _List; set { _List = value; OnPropertyChanged(); } }

        private Ingredient _SelectedItem;
        public Ingredient SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
                if (SelectedItem != null)
                {
                    DisplayName = SelectedItem.DisplayName;
                }
            }
        }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IngredientViewModel()
        {
            List = new ObservableCollection<Ingredient>(DataProvider.Ins.DB.Ingredients);
        }
    }
}
