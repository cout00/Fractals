using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandelbrotSetWF.Fractals
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class FractalNameAttribute :Attribute
    {
        readonly string positionalString;

        public FractalNameAttribute(string positionalString)
        {
            this.positionalString = positionalString;
        }

        public string PositionalString { get { return positionalString; } }
    }
}
