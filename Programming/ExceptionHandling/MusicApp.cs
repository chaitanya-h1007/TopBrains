namespace ExceptionHandling
{

    public class Song
    {
        public string SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int PlayCount { get; set; }

        public Song(string id, string t, string a, string g)
        {
            SongId = id;
            Title = t;
            Artist = a;
            Genre = g;
            PlayCount = 0;
        }
    }

    public class MusicManager
    {
        public static List<Song> songs = new List<Song>();
        static int counter = 1;

        public void AddSong(string title, string artist, string genre)
        {
            songs.Add(new Song("S" + counter++, title, artist, genre));
        }

        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            Dictionary<string, List<Song>> dict = new Dictionary<string, List<Song>>();

            foreach (var s in songs)
            {
                if (!dict.ContainsKey(s.Genre))
                    dict.Add(s.Genre, new List<Song>());

                dict[s.Genre].Add(s);
            }
            return dict;
        }
    }

    public class MusicApp
    {
        public static void Main(string[] args)
        {
            MusicManager mm = new MusicManager();
            mm.AddSong("Believer", "Imagine Dragons", "Rock");
            mm.AddSong("Shape of You", "Ed Sheeran", "Pop");

            var grouped = mm.GroupSongsByGenre();
            foreach (var g in grouped)
            {
                Console.WriteLine("Genre: " + g.Key);
                foreach (var s in g.Value)
                    Console.WriteLine(s.Title);
            }
        }
    }

    
}