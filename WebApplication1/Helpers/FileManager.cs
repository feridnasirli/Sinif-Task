using System.Xml.Linq;

namespace WebApplication1.Helpers
{
    public static class FileManager
    {
        public static string SaveFile(string pathroot,string folder,IFormFile formFile)
        {
            string name = formFile.FileName;
            name= name.Length>64?name.Substring(name.Length-64,64) : name; 
            name =Guid.NewGuid().ToString() +name;
            string savepath = Path.Combine(pathroot, folder,name);
            using (FileStream fs = new FileStream(savepath,FileMode.Create))
            {
                formFile.CopyTo(fs);
            }
            return name;
        }
        public static void DeleteFile(string pathroot, string folder, string formFile)
        {
            string deletePath= Path.Combine(pathroot, folder, formFile);
            if(System.IO.File.Exists(deletePath))
            {
                System.IO.File.Delete(deletePath);
            };
        }
    }
}
