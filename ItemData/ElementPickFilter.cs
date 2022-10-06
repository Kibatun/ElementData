using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemData
{
    public class ElementPickFilter : ISelectionFilter       //Фильтр выбора элемента
    {
        public bool AllowElement(Element elem)
        {
            return true;        //Нет условия, т.к. нас устроит любой элемент
        }
        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
