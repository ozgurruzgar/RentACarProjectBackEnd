using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utitlities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName(); //Benzersiz isimde 0 baytlık geçiçi bir dosya oluşturup, bu doysanın adresini sourcePath değişkenine atmış oluyoruz
            if (file.Length > 0) //Burada Ekleyeceğimiz dosyanın uzunluğunu bayt ile hesaplıyoruz ve Gerçekten dosya gelmiş mi gelmemiş mi diye kontrol yapıyoruz.
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create)) // Filestream sınıfı bizim dosya okuma,yazma,atlama işlemlerini yapıyor. FileMode.Create Dosya oluşturuyor veya varsa üzerine yazıyor.
                {
                    file.CopyTo(stream); //Dosyamızı sourcePath'teki oluşturduğumuz dosya üzerine yazıyoruz.
                }
            }
            FileInfo fileInfo = new FileInfo(file.FileName); //Dosyamızın adını fileInfo değişkenine aktardık. FileInfo sınıfı Dosya yolu işlemleri için kullanılan sınıftır.
            string fileExtension = fileInfo.Extension; //Dosya adını ve uzantısını fileExtension değişkenine aktardık. 
            var path = Guid.NewGuid().ToString() + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;
            //Guid.NewGuid().ToString() ifadesi bize eşsiz, benzersiz bir isim oluşturdu ve stringe çevirdi.

            var result = NewPath(path); //Burda yeni bir dizin oluşturduk.
            File.Move(sourcePath, result); //Dosyamızı yeni oluşturğumuz dizine aktardık.
            return path;
        }

        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string Update(string oldPath, IFormFile file)
        {
            Delete(oldPath);
            return Add(file);
        }

        private static string NewPath(string file)
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\Uploads\images"; //Burda yeni dizin =  mevcuttaki dizin + @"\wwwroot\Uploads\images" demiş olduk. Biraz daha türkçeleştirirsem burası WebAPI katmanında wwwroot klasörünün içinde Uplaods klasöründe Images klasörü oluşturur ve resimlerimiz orda kaydolur. 

            string result = $@"{path}\{file}";
            return result;
        }
    }
}
