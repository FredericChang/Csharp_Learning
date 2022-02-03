using System;
/**
base 關鍵字是用來存取衍生類別中基底類別的成員︰
對已由另一個方法覆寫的基底類別來呼叫方法。
指定應該在建立衍生類別的執行個體時呼叫的基底類別建構函式。
僅允許在建構函式、執行個體方法或執行個體屬性存取子中進行基底類別存取。
從靜態方法使用 base 關鍵字是錯誤的。
所存取的基底類別是類別宣告中所指定的基底類別。 例如，如果您指定 class ClassB : ClassA，則不論 ClassA 的基底類別為何，都會從 ClassB 存取 ClassA 成員。
**/ 
namespace base_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Employee E = new Employee();
            E.GetInfo();
        }

    }

    public class Person
    {
        protected string ssn = "111-222";
        protected string name = "Frederic";

        public virtual void GetInfo()
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("SSN: {0}", ssn);

        }
    }
    
    class Employee : Person
    {
        public string id = "asd";

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine("Employee ID: {0}", id);
        }

    }
}