using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabCreator
{
    class NotasTab
    {
        public static string Texto;
        public static string[] c1;
        public static string[] c2;
        public static string[] c3;
        public static string[] c4;
        public static string[] c5;
        public static string[] c6;

        FrmTabs tabs = new FrmTabs("");
        public NotasTab(string texto)
        {
            Texto = texto;
        }

        public NotasTab(string[] corda1, string[] corda2, string[] corda3, string[] corda4, string[] corda5, string[] corda6)
        {
            c1 = corda1;
            c2 = corda2;
            c3 = corda3;
            c4 = corda4;
            c5 = corda5;
            c6 = corda6;
        }

        public NotasTab()
        {

        }

        public string returnNotas()
        {
            if (Texto == null)
                Texto = tabs.txtTab.Text;
            return Texto;
        }

        public string[] corda1()
        {
            return c1;
        }
        public string[] corda2()
        {
            return c2;
        }
        public string[] corda3()
        {
            return c3;
        }
        public string[] corda4()
        {
            return c4;
        }
        public string[] corda5()
        {
            return c5;
        }
        public string[] corda6()
        {
            return c6;
        }
    }
}
