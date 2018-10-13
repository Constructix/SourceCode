using System.Linq;

namespace BridgeDesignPattern
{
    public class FolderManager
    {
        public string FileName { get; set; }
        public string FolderName { get; set; }
        public string Drive { get; set; }

        public string ToString()
        {
            return string.Concat(Drive, $":\\{FolderName}\\{FileName}");
        }
        public void Create()
        {
            CreateFileFolder(string.Concat(GetDefaultDrive, $"\\{this.FolderName}"));
        }


        private  void CreateFileFolder(string folderName)
        {
            System.IO.Directory.CreateDirectory(folderName);
        }


        private  string GetDefaultDrive
        {
            get { return System.IO.DriveInfo.GetDrives().FirstOrDefault(d => d.Name.StartsWith(Drive))?.Name; }


        }
    }
}