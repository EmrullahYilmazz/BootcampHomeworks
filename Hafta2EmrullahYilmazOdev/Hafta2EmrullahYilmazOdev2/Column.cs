using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hafta2EmrullahYilmazOdev2
{
    public class Column : Attribute
    {
        private string name;
        private string type;
        private bool isrequired;

        public Column(string n, string t,bool i)
        {
            name = n;
            type = t;
            isrequired = i;
        } 
        public static void AttributeDisplay(Type classType)
        {
            Console.WriteLine("Table Name: {0}", classType.Name);
            MethodInfo[] methods = classType.GetMethods();

            for (int i = 0; i < methods.GetLength(0); i++)
            { 

                object[] attributesArray = methods[i].GetCustomAttributes(true);

                foreach (Attribute item in attributesArray)
                {
                    if (item is Column)
                    {     
                        Column attributeObject = (Column)item;
                        Console.WriteLine("{0} - {1}, {2}, {3} ", methods[i].Name,
                         attributeObject.name, attributeObject.type,attributeObject.isrequired);
                    }
                }
            }
        }
    }
    class Student
    {

        
        int id;
        string name;

        
        public Student(int i, string n)
        {
            id = i;
            name = n;
        }

        [Column("int", "Student Id",true)]
        public int getId()
        {
            return id;
        }

        [Column("string", "Student Name",true)]
        public string getName()
        {
            return name;
        }
    }


    
}
