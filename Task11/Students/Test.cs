using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    [Serializable]
    public class Test : ICloneable
    {
        private int mark;

        public string Name { get; set; }

        public int Mark
        {
            get
            {
                return mark;
            }
        }
        public Test(string name, int mark)
        {
            if (name == null)
                throw new ArgumentNullException();
            if (mark < 0 || mark > 10)
                throw new ArgumentException();
            Name = name;
            this.mark = mark;
        }

        public object Clone()
        {
            return new Test(this.Name, this.mark);
        }
    }
}
