using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDE_Class ide = new IDE_Class();
            ide.Languages.Add(new Java());
            ide.Languages.Add(new CS());
            ide.Languages.Add(new C());
            ide.WorkingWithLanguages();
            Console.ReadKey();
        }
    }
    //IDE Class interacts with languages
    //It never knows what languages are present
    class IDE_Class
    {
        public List<ILanguage> Languages { get; set; } = new List<ILanguage>();
        public void WorkingWithLanguages()
        {
            foreach(ILanguage language in Languages)
            {
                Console.WriteLine(language.GetName());
                Console.WriteLine(language.GetUnit());
                Console.WriteLine(language.GetParadigm());
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
    interface ILanguage
    {
        string GetUnit();
        string GetParadigm();
        string GetName();
    }
    abstract class OOLanguage : ILanguage
    {
        public virtual string GetUnit()
        {
            return "Class";
        }
        public virtual string GetParadigm()
        {
            return "Object Oriented";
        }
        public abstract string GetName();
    }
    abstract class ProceduralLanguage : ILanguage
    {
        public virtual string GetUnit()
        {
            return "Function";
        }
        public virtual string GetParadigm()
        {
            return "Procedural";
        }
        public abstract string GetName();
    }
    class CS : OOLanguage
    {
        public override string GetName()
        {
            return "C#";
        }
    }
    class Java : OOLanguage
    {
        public override string GetName()
        {
            return "Java";
        }
    }
    class C : ProceduralLanguage
    {
        public override string GetName()
        {
            return "C";
        }
    }
}
