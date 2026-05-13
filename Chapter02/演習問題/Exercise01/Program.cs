
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //2.1.3
            //var songs = new Song[] {
            //    new Song("Let it be", "The Beatles", 243),
            //    new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
            //    new Song("Close To You", "Carpenters", 276),
            //    new Song("Honesty", "Billy Joel", 231),
            //    new Song("I Will Always Love You", "Whitney Houston", 273),
            //};
            

            var songs = new List<Song>();
            while (true) {
                Console.Write("曲名：");
                string? title = Console.ReadLine();

                if (title == "end") {
                    Console.Write("おわり");
                    break;
                } else {                  
                    Console.Write("アーティスト名：");
                    string? srtistname = Console.ReadLine();

                    Console.Write("演奏時間（秒）：");
                    int length = int.Parse(Console.ReadLine());
                    Song song = new Song(title, srtistname, length);
                    songs.Add(song);
                }
                
            }




           
            PrintSongs(songs);

        }
        public static void PrintSongs(IEnumerable<Song> songs) {
            foreach (var Song in songs) {
                //  new PrintSongs(@"Title\ArttistName\Length");
                
                int mm = Song.Length / 60;
                int ss = Song.Length % 60;
                Console.WriteLine($"{Song.Title},{Song.ArtistName},{mm}:{ss:00}");
            }
        }

    }
}
