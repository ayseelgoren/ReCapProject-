using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameCharacterLimit = "Araba eklenmedi. Araba ismi minimum 2 karakter olmalıdır.";
        public static string CarCostGreaterThanZero = "Araba eklenmedi. Araba günlük fiyatı 0'dan büyük olmalıdır.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarGetAll = "Arabalar listelendi.";

        public static string MaintenanceTime = "Bakım zamanı.";


        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandGetAll = "Markalar listelendi.";


        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorGetAll = "Renkler listelendi.";


        public static string RentalAdded = "Araba kiralandı.";
        public static string RentalAddedError = "Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string RentalDeleted = "Araba kiralanması silindi.";
        public static string RentalDeletedError = "Arabanın silinebilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string RentalUpdated = "Araba kiralanması güncellendi.";
        public static string RentalUpdatedError = "Arabanın güncellenebilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string RentalGetAll = "Kiralanan arabalar listelendi.";


        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerGetAll = "Müşteriler listelendi.";


        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserGetAll = "Kullanıcılar listelendi.";
        public static string UserRentals = "Kullancının kiraladığı araçlar.";

    }
}
