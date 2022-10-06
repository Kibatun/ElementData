using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemData
{
    internal class AppViewModel     //Связь данных с интерфейсом пользователя
    { 
        public ObservableCollection<ParamProps> Parameters { get; set; }    //на эту коллекцию ссылается XAML. В Parameters = null пока что
        public AppViewModel()
        {
            Parameters = new ObservableCollection<ParamProps> { };  //Создание экземпляра коллекции. Выделение под объект Parameters область в памяти
        }
    }
}
