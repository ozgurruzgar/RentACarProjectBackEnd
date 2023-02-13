using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Contants
{
    public class Messages
    {
        public static string CarAdded = "Araba Eklendi.";
        public static string DailyPriceInValid = "Aracın Günlük Fiyatı Geçersiz.";
        public static string CarNameInValid = "Araç İsmi Geçersiz.";
        public static string CustomerAdded="Müşteri Eklendi.";
        public static string CustomerNameOrUserId="Müşteri ismi en az 2 karakter olmalır ve UserId 0'dan büyük olmalıdır.";
        public static string UserAdded="Kullanıcı Eklendi.";
        public static string UserFNameLNameOrPassword="Kullanıcı İsmi,Soyismi ve şifresi 2 harften büyük olmalı";
        public static string RentalAdded="Kiralama Eklendi.";
        public static string RentalIdCarIdOrCustomerId="Rental Id, CarId ve Customer Id 0'dan büyük olmalı";
        public static string BrandAdded="Marka Eklendi.";
        public static string ColorAdded="Renk Eklendi.";
        public static string BrandIdBigFromZero="Brand Id'si 0'dan büyük olmalı.";
        public static string ColorIdBigFromZero = "Color Id'si 0'dan büyük olmalı.";
        public static string CustomerListed="Müşteriler Listelendi";
        public static string BrandListed="Markalar Listelendi.";
        public static string CarListed="Arabalar Listelendi.";
        public static string ColorListed="Renkler Listelendi.";
        public static string RentalListed="Kiralamalar Listelendi";
        public static string UserListed="Kullanıcılar Listelendi.";
        public static string CarImageAdded="Yeni Araç Resmi Eklendi.";
    }
}
