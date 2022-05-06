using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TagLib;

public class NewEntry : MonoBehaviour
{
    private NewImport import;
    private string length;
    public ArrayData songLocations;
    public string songDirect;
    public Text artistText;
    public Text titleText;
    public Text lengthText;
    public string artist;
    public string title;
    public RawImage cover;
    //private IPicture pic;

    void Awake()
    {
        import = GameObject.Find("Black Fade").GetComponent<NewImport>();
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