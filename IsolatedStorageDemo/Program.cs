﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IsolatedStorageFile userStorage = IsolatedStorageFile.GetUserStoreForAssembly();

            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStorage);

            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs");
            userWriter.Close();

            string[] files = userStorage.GetFileNames("UserSettings.set");
            if (files.Length == 0)
            {
                Console.WriteLine("No such file");
            }
            else
            {
                IsolatedStorageFileStream openStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStorage);
                StreamReader userReader = new StreamReader(openStream);
                string contents = userReader.ReadToEnd();
                Console.WriteLine(contents);
                Console.ReadLine();
            }

        }
    }
}
