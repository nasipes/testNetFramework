using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using ProgressForm;
using Autodesk.Revit.UI;

namespace TestLibrary
{
    public class Class1
    {

        public static void ProgressStart()
        {
            ProgressForm.ProgressForm form1 = new ProgressForm.ProgressForm();
            int max = 10;
            form1.progressBar1.Maximum = max;
            form1.Show();
            int i = 1;
            //this is here just to represent doing some kind of task.
            while (i < max+1)
            {
                form1.ProgressUpdate("Performing Step" +  i, i);
                i++;
                //this is here to simulate the program doing something that takes time.
                Thread.Sleep(3000);
            }
            //this is so you can see it before it closes.
            Thread.Sleep(5000);
            form1.Dispose();
        }
        public static IList<Element> FilterElementsByBuiltinCategory(IList<Element> elements, BuiltInCategory[] categories, bool includeCategories, bool includeNull)
        {
            IList<Element> result = new List<Element>();
            foreach (Element element in elements)
            {
                if (element.Category == null)
                {
                    if (includeNull)
                    { result.Add(element); }
                }
                else
                {
                    BuiltInCategory ElementCatBuiltIn;


#if !RELEASE2024
                    try
                    {
                        ElementId categoryId = element.Category.Id;
                        ElementCatBuiltIn = (BuiltInCategory)categoryId.IntegerValue;
                    }
                    catch (Exception ex)
                    {
                        TaskDialog.Show("ERROR", "Error getting the builtin category");
                        ElementCatBuiltIn = BuiltInCategory.INVALID;
                    }
#else

                    //this only work in R23 and later
                    ElementCatBuiltIn = element.Category.BuiltInCategory;
#endif

                    if (includeCategories)
                    {
                        if (categories.Contains(ElementCatBuiltIn))
                        { result.Add(element); }
                    }
                    else
                    {
                        if (!categories.Contains(ElementCatBuiltIn))
                        {
                            result.Add(element);
                        }
                    }
                }
            }
            return result;
        }
    }
}
