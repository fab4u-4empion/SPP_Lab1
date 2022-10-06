using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Example.Writer
{
    internal class FileWriter : IWriter
    {
        private string _path;

        public void Write(string value)
        {
            using (StreamWriter sw = new(_path, false))
            {
                sw.WriteLine(value);
            }
        }

        public FileWriter(string path)
        {
            _path = path;
        }
    }
}
