using System;
using System.Collections.Generic;
using System.IO;
/************************************************************************************************************
* Sample program with various ways to sort lists of Strings, Ints and structures
************************************************************************************************************/
namespace SafeSourceClassSortSample
{
    public class Example
    {
        public static void Main()
        {

            List<DataFileInfoCls> SharedFileData = new List<DataFileInfoCls>();

            /************************************************************************************************************
            * Load and write the data
            ************************************************************************************************************/
            string LockConfigDir = $@"C:\Users\BeastMstr\Documents\TestFiles";
            DirectoryInfo d = new DirectoryInfo(LockConfigDir);
            FileInfo[] Files = d.GetFiles("*.txt*"); //Getting Text files
            int  fctr = 0;
            foreach (FileInfo file in Files)
            {
                fctr++;
                SharedFileData.Add(new DataFileInfoCls()
                {
                    DataPath = $"Test Path {(10 - fctr).ToString("00")}",
                    Site = $"site {fctr.ToString("00")}",
                    CorrespondingTargetFileIdx = fctr + 10,
                    FileData = file
                });
            }

            // Write out the Files in the list. This will call the overridden
            // ToString method in the Part class.
            Console.WriteLine("\nBefore sort:");
            foreach (DataFileInfoCls Finfo  in SharedFileData)
            {
                Console.WriteLine($"{Finfo.Site}, {Finfo.FileData.Name}");
            }

            /************************************************************************************************************
            * Ascending using sort method in the class
            ************************************************************************************************************/
            // Call Sort on the list. This will use the
            // default comparer, which is the Compare method
            // implemented on Part.
            SharedFileData.Sort();
            //            List<DataFileInfoCls> x = new Isort();

            Console.WriteLine("\nAfter ascending sort in the class by FileData.Name:");
            foreach (DataFileInfoCls Finfo in SharedFileData)
            {
                Console.WriteLine($"{Finfo.Site}, {Finfo.FileData.Name}");
            }

            /************************************************************************************************************
            * Descending using sort method in the class
            ************************************************************************************************************/
            // Call Sort on the list. This will use the
            // default comparer, which is the Compare method
            // implemented on Part.
            SharedFileData.Sort(new DataFileInfoCls.SortDescendingFileName());

            Console.WriteLine("\nAfter descending sort in the class by FileData.Name:");
            foreach (DataFileInfoCls Finfo in SharedFileData)
            {
                Console.WriteLine($"{Finfo.Site}, {Finfo.FileData.Name}");
            }

            /************************************************************************************************************
            * Ascending using a delegate sort method NOT in the class
            ************************************************************************************************************/
            // This shows calling the Sort(Comparison(T) overload using
            // an anonymous method for the Comparison delegate.
            // This method treats null as the lesser of two values.
            SharedFileData.Sort(delegate (DataFileInfoCls x, DataFileInfoCls y)
            {
                if (x.DataPath == null && y.DataPath == null) return 0;
                else if (x.DataPath == null) return -1;
                else if (y.DataPath == null) return 1;
                else return x.DataPath.CompareTo(y.DataPath);
            });

            Console.WriteLine("\nAfter sort ascending with delegate by DataPath:");
            foreach (DataFileInfoCls Finfo in SharedFileData)
            {
                Console.WriteLine($"{Finfo.DataPath}, {Finfo.FileData.Name}" );
            }

            /************************************************************************************************************
            * Descending using a delegate sort method NOT in the class
            ************************************************************************************************************/
            SharedFileData.Sort(delegate (DataFileInfoCls x, DataFileInfoCls y)
            {
                if (x.DataPath == null && y.DataPath == null) return 0;
                else if (x.DataPath == null) return -1;
                else if (y.DataPath == null) return 1;
                else return y.DataPath.CompareTo(x.DataPath);
            });

            Console.WriteLine("\nAfter sort descending with sort not in class by DataPath:");
            foreach (DataFileInfoCls Finfo in SharedFileData)
            {
                Console.WriteLine($"{Finfo.DataPath}, {Finfo.FileData.Name}");
            }
            /************************************************************************************************************
            * Descending using a method in the class
            ************************************************************************************************************/
            SharedFileData.Sort(new DataFileInfoCls.SortDescendingDataPath());

            Console.WriteLine("\nAfter sort descending with sort in class by DataPath:");
            foreach (DataFileInfoCls Finfo in SharedFileData)
            {
                Console.WriteLine($"{Finfo.DataPath}, {Finfo.FileData.Name}");
            }
            /************************************************************************************************************
            * Descending on CorrespondingTargetFileIdx using a method in the class
            ************************************************************************************************************/
            SharedFileData.Sort(new DataFileInfoCls.SortDescendingTargetID());

            Console.WriteLine("\nAfter sort descending on CorrespondingTargetFileIdx with sort in class");
            foreach (DataFileInfoCls Finfo in SharedFileData)
            {
                Console.WriteLine($"{Finfo.FileData.Name}, {Finfo.CorrespondingTargetFileIdx.ToString()}");
            }
        }
    }
}
