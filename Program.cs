using System.Diagnostics;

class SayaTubeVideo
{
    private int id, playCount;
    private string title;

    public SayaTubeVideo(string title)
    {
        Debug.Assert(title != null, "Judul video tidak boleh null.");
        Debug.Assert(title.Length <= 100, "Judul video tidak boleh lebih dari 100 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 100000);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count > 0 && count <= 10000000, "Penambahan play count harus antara 1 hingga 10.000.000.");

        try
        {
            checked
            {
                this.playCount += count;
            }
        } catch (OverflowException e)
        {
            Console.WriteLine("Error: Play count melebihi batas integer.");
            Console.WriteLine(e.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("ID: " + this.id);
        Console.WriteLine("Title: " + this.title);
        Console.WriteLine("Play Count: " + this.playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        SayaTubeVideo sayaTubeVideo = new SayaTubeVideo("Tutorial Design By Contract – Muhammad Zhafran Ilham");
        sayaTubeVideo.PrintVideoDetails();

        // Uji pre-kondisi judul null
        //try
        //{
        //    SayaTubeVideo videoInvalid = new SayaTubeVideo(null);
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Terdapat error: " + e.Message);
        //}

        // Uji pre-kondisi judul lebih dari 100 karakter
        //try
        //{
        //    SayaTubeVideo videoInvalid = new SayaTubeVideo(new string('A', 101));
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Terdapat error: " + e.Message);
        //}

        // Uji playCount hingga overflow
        try
        {
            sayaTubeVideo.IncreasePlayCount(100000000);
        }
        catch (Exception e)
        {
            Console.WriteLine("Terdapat error: " + e.Message);
        }
    }
}