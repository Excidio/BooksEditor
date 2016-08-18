using System.IO;
using System.Web;

namespace BooksEditor.MVC.Helpers
{
    public class FileHelper
    {
        public static byte[] ConvertToByteArray(HttpPostedFileBase file)
        {
            byte[] data = null;
            if (file != null)
            {
                using (var reader = new BinaryReader(file.InputStream))
                {
                    data = reader.ReadBytes(file.ContentLength);
                }
            }

            return data;
        }
    }
}