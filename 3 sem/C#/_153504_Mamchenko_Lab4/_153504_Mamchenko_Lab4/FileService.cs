﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _153504_Mamchenko_Lab4
{
    internal class FileService<T> : IFileService<T>
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    yield return (T)Activator.CreateInstance(typeof(T), reader.ReadString());
                }

            }
            
        }
        
        public void SaveData(IEnumerable<T> data, string fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate)))
            {
                foreach (var item in data)
                {
                    writer.Write(item.ToString());                
                }
            }
            Console.WriteLine("File has been written");
        }
    }
}
