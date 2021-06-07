using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TagLib;

public class SongEntry : MonoBehaviour
{
    private MusicImport import;
    private string length;
    [HideInInspector] public ArrayData songLocations;
    [HideInInspector] public string songDirect;
    [HideInInspector] public Text artistText;
    [HideInInspector] public Text titleText;
    [HideInInspector] public Text lengthText;
    [HideInInspector] public string artist;
    [HideInInspector] public string title;
    [HideInInspector] public RawImage cover;
    //private IPicture pic;

    void Awake()
    {
        import = GameObject.Find("Black Fade").GetComponent<MusicImport>();
        songDirect = songLocations.songAddresses[import.songNum];
        TagLib.File tfile = TagLib.File.Create(songDirect);
        title = tfile.Tag.Title;
        artist = tfile.Tag.FirstAlbumArtist;
        length = tfile.Properties.Duration.ToString();
        titleText.text = title;
        artistText.text = artist;
        int index = length.LastIndexOf(".");
        if (index > 0) { length = length.Substring(0, index); }
        lengthText.text = length;
        //pic = tfile.Tag.Pictures[0];
        
        //string search = tfile.Tag.Album.Replace(" ", "_");
        //StartCoroutine(FindCover(search));
    }

    IEnumerator FindCover(string coverName)
    {
        string escName = WWW.EscapeURL(coverName);
        Texture2D texture = new Texture2D(1,1);
        WWW www = new WWW("https://api.spotify.com/v1/search?q=" + escName + "&type=artist");
        yield return www;
        www.LoadImageIntoTexture(texture);
        cover.texture = texture;
        print(escName);
    }
}