using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicImport : MonoBehaviour
{
    private const string MusicFolder = "C:/Users/colli/Music/Music/";
    private AudioClip audioClip;
    private string[] artistNames;
    private string[] albumNames;
    private string[] songNames;
    private string selectedPath;
    private string selectedName;
    private string searchTerm;
    public Animator fade;
    public AudioSource source;
    public InputField textBox;
    public Slider volumeBar;
    public Slider timeBar;
    public bool loopBool = false;
    public bool muteBool = false;

    public void Update()
    {
        searchTerm = textBox.text;
        source.volume = volumeBar.value;
        
        timeBar.value = source.time;
        
        source.loop = loopBool;
        source.mute = muteBool;

        if (Input.GetKeyDown("return"))
        {
            print("SearchTerm is: " + searchTerm);
            FindSongs();
            StartCoroutine(LoadAudio());
        }
    }

    void FindSongs()
    {
        print("Loading Songs...");
        artistNames = System.IO.Directory.GetDirectories(MusicFolder);
        foreach (string artist in artistNames)
        {
            songNames = System.IO.Directory.GetFiles(artist, "*.mp3");
            selectedPath = artist + "\\";
            foreach (string song in songNames)
            {
                print("Checking Singles...");
                selectedName = song.Replace(artist + "\\", "");
                if (selectedName.ToLower() == searchTerm.ToLower() + ".mp3")
                {
                    print("SelectedName: " + selectedName);
                    return;
                }
            }
            albumNames = System.IO.Directory.GetDirectories(artist);
            foreach (string album in albumNames)
            {
                songNames = System.IO.Directory.GetFiles(album, "*.mp3");
                selectedPath = album + "\\";
                foreach (string song in songNames)
                {
                    print("Checking Albums...");
                    selectedName = song.Replace(album + "\\", "");
                    if (selectedName.ToLower() == searchTerm.ToLower() + ".mp3")
                    {
                        print("SelectedName: " + selectedName);
                        return;
                    }
                }
            }
        }
        if (selectedName.ToLower() != searchTerm.ToLower() + ".mp3")
        {
            print("ERROR: NO SONG BY THAT NAME");
            selectedName = null;
        }
    }
    
    //  \/https://www.youtube.com/watch?v=9gAHZGArDgU\/
    private IEnumerator LoadAudio()
    {
        WWW request = GetAudioFromFile(selectedPath, selectedName);
        yield return request;
        
        if (selectedName != null)
        {
            audioClip = request.GetAudioClip();
            audioClip.name = selectedName.Replace(".mp3", "");
        
            print("Playing: " + audioClip);
            source.clip = audioClip;
            timeBar.maxValue = source.clip.length;
            source.Play();
        }
    }

    private WWW GetAudioFromFile(string path, string filename)
    {
        string audioToLoad = string.Format(path + "{0}", filename);
        WWW request = new WWW(audioToLoad);
        return request;
    }

    public void PlayToggle()
    {
        if (source.isPlaying)
        {
            source.Pause();
        }
        else
        {
            source.Play();
        }
    }

    public void MuteToggle()
    {
        muteBool = !muteBool;
    }
    public void LoopToggle()
    {
        loopBool = !loopBool;
    }

    public void ExitScene()
    {
        StartCoroutine(ExitMusic());
    }

    public IEnumerator ExitMusic()
    {
        volumeBar.value = 0;
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.75f);
        SceneManager.LoadScene("Main Menu");
    }
}