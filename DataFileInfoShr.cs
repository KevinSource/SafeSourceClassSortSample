using System;
using System.Collections.Generic;
using System.IO;
public struct DataFileInfoStruct
{
    public string DataPath;
    public string Site;
    public int CorrespondingTargetFileIdx;
    public FileInfo FileData;
}
namespace SafeSourceClassSortSample
{
    public class DataFileInfoCls : IComparable<DataFileInfoCls> 
    {  
        // Nested class to do ascending sort on year property.
        // Implement IComparable CompareTo to provide default sort order.
        public DataFileInfoStruct DataFileInfo;
        public int CompareTo(DataFileInfoCls c)
        {
            int ret = String.Compare(this.DataFileInfo.FileData.Name, c.DataFileInfo.FileData.Name);
            return ret;
        }

        public class SortDescendingFileName : IComparer<DataFileInfoCls>
        {
            int IComparer<DataFileInfoCls>.Compare(DataFileInfoCls d1, DataFileInfoCls d2)
            {
                int ret = String.Compare(d2.DataFileInfo.FileData.Name, d1.DataFileInfo.FileData.Name);
                return ret;
            }
        }
        public class SortDescendingTargetID : IComparer<DataFileInfoCls>
        {
            int IComparer<DataFileInfoCls>.Compare(DataFileInfoCls d1, DataFileInfoCls d2)
            {
                int ret =0;
                if (d1.CorrespondingTargetFileIdx > d2.CorrespondingTargetFileIdx)
                    ret = -1;
                else if (d1.CorrespondingTargetFileIdx < d2.CorrespondingTargetFileIdx)
                    ret = 1;
                else
                    ret=0;

                return ret;
            }
        }
        public class SortDescendingDataPath : IComparer<DataFileInfoCls>
        {
            int IComparer<DataFileInfoCls>.Compare(DataFileInfoCls d1, DataFileInfoCls d2)
            {
                int ret = String.Compare(d2.DataFileInfo.DataPath, d1.DataFileInfo.DataPath);
                return ret;
            }
        }
        public string Site
        {
            get { return DataFileInfo.Site; }
            set { DataFileInfo.Site = value; }
        }

        public string DataPath
        {
            get { return DataFileInfo.DataPath; }
            set { DataFileInfo.DataPath = value; }
        }
        public int CorrespondingTargetFileIdx
        {
            get { return DataFileInfo.CorrespondingTargetFileIdx; }
            set { DataFileInfo.CorrespondingTargetFileIdx = value; }
        }
        public FileInfo FileData
        {
            get { return DataFileInfo.FileData; }
            set { DataFileInfo.FileData = value; }
        }
    }
}
