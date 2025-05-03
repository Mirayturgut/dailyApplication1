
using Daily_Application1;

List<UserHelper> gunlukList = new List<UserHelper>();
while (true)
{
    Console.Clear();
    Console.WriteLine("----GÜNLÜĞÜNE HOŞGELDİN----");
    Console.WriteLine();
    var inputSecim = Helper.AskOption("Yapmak istediğiniz işlemi seçin:",
        ["Yeni kayıt ekle", "Kayıtları listele", "Tüm kayıtları sil", "Çıkış"]);
    
    if (inputSecim == 1)
    {
        Console.Clear();
        Console.WriteLine("----Yeni Günlük Kaydı----");
        
        var inputTarih = Helper.Ask("Tarih giriniz (örn:02/05/2025)");
        var inputIçerik = Helper.Ask("Günlüğünü yaz:");
        
        var yeniKayit = new UserHelper(inputTarih, inputIçerik);
        gunlukList.Add(yeniKayit);
        Console.WriteLine("Kayıt başarıyla eklendi!");
        UserHelper.SaveToTxt(gunlukList);
        Helper.ShowSuccessMsg("Kaydedildi.");
    }
    else if (inputSecim == 2)
    {
        Console.Clear();
        Console.WriteLine("---Günlük Kayıtları---");
        if (gunlukList.Count == 0)
        {
            Console.WriteLine("Henüz hiç kayıt yok.");
        }
        else
        {
            foreach (var kayit in gunlukList)
            {
                Console.WriteLine($"Tarih: {kayit.Tarih}");
                Console.WriteLine($"İçerik: {kayit.Içerik}");
                Console.WriteLine("-----------------------");
            }
        }
    }
    else if (inputSecim == 3)
    {
        Console.Clear();
        Console.WriteLine("Tüm Kayıtları silmek istediğinize emin misiniz?(e/h)");
        var inputSilmek = Console.ReadLine()?.ToLower();
        if (inputSilmek == "e")
        {
            gunlukList.Clear();
            File.WriteAllText("gunluk.txt", string.Empty);

            Helper.ShowSuccessMsg("Tüm kayıtlar silindi.");
            
        }else if (inputSilmek == "h")
        {
            Console.WriteLine("Silme işlemi iptal edildi.");
        }

    } else if (inputSecim == 4)
    {
      Console.Clear();
      Console.WriteLine("Programdan çıkılıyor... Hoşçakal!");
      Thread.Sleep(1000);
      break;
    }
    Console.WriteLine("\n Menüye dönmek için bir tuşa basınız.");
    Console.ReadKey(true);
}