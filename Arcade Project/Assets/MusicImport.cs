using UnityEngine;

public class MusicImport : MonoBehaviour
{
    private string[] artistNames;
    private string[] albumNames;
    private string[] songNames;
    private float listPos = 0f;
    private string musicFolder;
    private GameObject button;
    public GameObject listSled;
    public GameObject listPrefab;
    public ArrayData songLocations; //, coverLocations
    public StringData userName;
    public int songNum, coverNum;

    private void Start()
    {
        musicFolder = "C:/Users/colli/Music/Music/";
        FindSongs();
    }
    
    public void FindSongs()
    {
        songLocations.Clear();
        songNum = 0;
        print("Loading Songs...");
        artistNames = System.IO.Directory.GetDirectories(musicFolder);
        foreach (string artist in artistNames)
        {
            songNames = System.IO.Directory.GetFiles(artist, "*.mp3");
            foreach (string song in songNames)
            {
                print("Checking Singles...");
                songNum++;
                songLocations.songAddresses[songNum] = song;
                CreateList();
            }
            albumNames = System.IO.Directory.GetDirectories(artist);
            foreach (string album in albumNames)
            {
                songNames = System.IO.Directory.GetFiles(album, "*.mp3");
                foreach (string song in songNames)
                {
                    print("Checking Albums...");
                    songNum++;
                    songLocations.songAddresses[songNum] = song;
                    CreateList();
                }
            }
        }
    }

    /*
    public void FindCovers()
    {
        coverLocations.Clear();
        coverNum = 0;
        print("Loading Covers...");
        artistNames = System.IO.Directory.GetDirectories(musicFolder);
        foreach (string artist in artistNames)
        {
            songNames = System.IO.Directory.GetFiles(artist, "*.png");
            foreach (string song in songNames)
            {
                print("Checking Singles Covers...");
                songNum++;
                songLocations.songAddresses[songNum] = song;
                CreateList();
            }
            albumNames = System.IO.Directory.GetDirectories(artist);
            foreach (string album in albumNames)
            {
                songNames = System.IO.Directory.GetFiles(album, "*.png");
                foreach (string song in songNames)
                {
                    print("Checking Album Covers...");
                    songNum++;
                    songLocations.songAddresses[songNum] = song;
                    CreateList();
                }
            }
        }
    }
*/
    
    void CreateList()
    {
        var newSong = Instantiate(listPrefab, new Vector3(0,listPos,0), Quaternion.identity);
        newSong.transform.SetParent(listSled.transform, false);
        listPos += -300;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        button = other.gameObject.transform.GetChild(0).gameObject;
        button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        button = other.gameObject.transform.GetChild(0).gameObject;
        button.SetActive(false);
    }
}