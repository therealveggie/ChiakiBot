using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChiakiBot.Utilities
{

    class TaskList
    {
        public static List<CustomEvents> _TaskList = new List<CustomEvents>();
        private string filepath = "tasks.txt";
        public static  Boolean _LoadedFromFile = false;
        public int counter = 0;
        public void readFromFileAsync()
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);
            string[] data;
            foreach (string line in lines)
            {
                data = line.Split();
                _TaskList.Add(new CustomEvents(data[0], data[1], data[2]));
            }
            _LoadedFromFile = true;
        }

        public void writeToFileAsync()
        {
            if(!_LoadedFromFile)
            {
                readFromFileAsync();
            }
            //clear contents of the file
            System.IO.File.WriteAllText(filepath, String.Empty);
            List<string> lines = new List<string>();
            foreach (CustomEvents ce in _TaskList)
            {
                lines.Add(ce.toString());
            }
            System.IO.File.WriteAllLines(filepath, lines);
        }

        public void createTask(string date, string title, string description)
        {
            if (!_LoadedFromFile)
                readFromFileAsync();
            if (_TaskList.Count == 0)
                _TaskList = new List<CustomEvents>();
            _TaskList.Add(new CustomEvents(date, title, description));
        }

        public Boolean deleteTask(int index)
        {
            try
            {
                _TaskList.RemoveAt(index);
            }
            catch(Exception )
            {
                return false;
            }
            return true;
        }

        public Boolean updateTask(int index, string date, string title, string description)
        {
            try
            {
                _TaskList[index] = new CustomEvents(date, title, description);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
