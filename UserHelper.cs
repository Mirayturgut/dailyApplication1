namespace Daily_Application1;

public class UserHelper
{
    public string Tarih  { get; set; }
    public string Içerik  { get; set; }

    public UserHelper(string tarih, string ıçerik)
    {
        Tarih = tarih;
        Içerik = ıçerik;
    }
    public static void SaveToTxt(List<UserHelper>gunlukList)
    {
        using (var writer = new StreamWriter("dailys.txt")) // streamWriter en baştan yazar kaldığınız yerden yazmaz
        {
            foreach (var userHelper in gunlukList)
            {
                writer.WriteLine($"{userHelper.Tarih};{userHelper.Içerik}");
            }
            writer.Close();
        }
        
    }
}