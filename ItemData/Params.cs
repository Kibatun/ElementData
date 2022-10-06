using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemData
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Params : IExternalCommand
    {
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Получить объекты приложений и документов
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            try
            {
                Reference pickedRef = null;     //Создаётся ссылка на элемент с пустым значением
                Selection select = uiapp.ActiveUIDocument.Selection;        //Выбранный ползователем элемент
                ElementPickFilter selectFilter = new ElementPickFilter();       //Создаётся фильтр выбора
                pickedRef = select.PickObject(ObjectType.Element, selectFilter, "Пожалуйста выберите элемент");     //выбор элемента пользователем + фильтр
                Element elem = doc.GetElement(pickedRef); //получение выбранного элемента из файла
                ParameterSet set = elem.Parameters; //Cписок всех параметров
                AppViewModel appViewModel = new AppViewModel();     //Экземпляр класса
                foreach(Parameter p in set)     //Перебор всех параметров
                {
                    string pName = p.Definition.Name;
                    string pValue = "Пусто";     //Присваивание каждому параметру тип string 
                    if (p.StorageType == StorageType.String)
                        pValue = p.AsString();
                    /*else if (p.StorageType == StorageType.None)
                        pValue = "Пусто"; */
                    else pValue = p.AsValueString();
                    ParamProps paramProps = new ParamProps();       //Экземпляр класса, где хранятся/заносятся value и name
                    paramProps.Name = pName;
                    paramProps.Value = pValue;
                    appViewModel.Parameters.Add(paramProps);
                }
                UserWindow ui = new UserWindow();
                ui.DataContext = appViewModel;
                ui.ShowDialog();
            }
            catch (Exception ex)
            {
                TaskDialog.Show("title", ex.Message + ex.StackTrace);
                message = ex.Message;
            }
            return Result.Succeeded;
        }

    }
}
