using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace stack
{
    class Program
    {
        static void Main(string[] args)
        {
            //the path to the folder;
            string path = @"D:\PT2016";
            //info about folder;
            DirectoryInfo dir = new DirectoryInfo(path);
            //count the files;
            int cnt = dir.GetFiles().Length;
            //outputs the number of file
            Console.WriteLine(cnt + " files are located in " + dir.FullName);

            //creating stack;
            Stack<DirectoryInfo> items = new Stack<DirectoryInfo>();

            //run through thefolder;
            foreach (DirectoryInfo ndir in dir.GetDirectories())
            {
                //folders inside array added to stack;
                items.Push(ndir);
            }

            ;
            while (true)
            {
                //untill stack is empty;
                if (items.Count > 0)
                {
                    //tkes the elemeny at the top;
                    DirectoryInfo npopDir = items.Pop();
                    //count the number of elements and counts it;
                    cnt = npopDir.GetFiles().Length;
                    Console.WriteLine(cnt + " files are located in " + npopDir.FullName);

                    //write inside array the number of folder that was deleted;
                    DirectoryInfo[] npopDirItems = npopDir.GetDirectories();
                    //run through array;
                    foreach (DirectoryInfo npopDirIt in npopDirItems)
                    {
                        //run through folders and files and adds them to the stack;
                        items.Push(npopDirIt);
                    }
                }
            }

        }
        static void Search(DirectoryInfo dir)
        {
            //create a variable which counts the number of files in folder;
            int cnt = dir.GetFiles().Length;
            //outputs info about folder;
            Console.WriteLine(cnt + " files are located in " + dir.FullName);
            //runs through the folder;
            foreach (DirectoryInfo ndir in dir.GetDirectories())
            {
                //for searching;
                Search(ndir);
            }

        }
    }
}