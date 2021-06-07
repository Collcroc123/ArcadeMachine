using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongPlayer : MonoBehaviour
{
    private Animator fade;
    private AudioSource source;
    private AudioClip clip;
    private SongEntry currentEntry;
    //private int currentSongNum;
    [HideInInspector]public Slider timeBar;
    [HideInInspector] public bool loopBool;
    [HideInInspector] public bool muteBool;
    //[HideInInspector] public ArrayData songLocations;
    [HideInInspector] public ScrollList scroll;
    [HideInInspector] public Text currentArtist;
    [HideInInspector] public Text currentSong;
    //[HideInInspector] public Image currentBackground;
    public GameObject background;

    private void Awake()
    {
        source = GameObject.Find("Black Fade").GetComponent<AudioSource>();
        fade = GameObject.Find("Black Fade").GetComponent<Animator>();
        background.SetActive(false);
    }

    public void Update()
    {
        timeBar.value = source.time;
        
        if (Input.GetKeyDown("return"))
        {
            StartCoroutine(LoadAudio());
        }
        if (Input.GetKeyDown("left"))
        {
            scroll.GoUp();
            StartCoroutine(LoadAudio());
        }
        if (Input.GetKeyDown("right"))
        {
            scroll.GoDown();
            StartCoroutine(LoadAudio());
        }
    }

    private IEnumerator LoadAudio()
    {
        yield return new WaitForSeconds(0.25f);
        WWW request = GetAudioFromFile(currentEntry.songDirect);
        yield return request;
        
        clip = request.GetAudioClip();
        clip.name = "Current Song!";
        print("Playing: " + clip);
        source.clip = clip;
        timeBar.maxValue = source.clip.length;
        source.Play();
        currentArtist.text = currentEntry.artist;
        currentSong.text = currentEntry.title;
        //currentBackground = currentEntry.cover;
        background.SetActive(true);
    }
    
    private WWW GetAudioFromFile(string path)
    {
        string audioToLoad = string.Format(path); // + "{0}", filename
        WWW request = new WWW(audioToLoad);
        return request;
    }

    public void PlayToggle()
    {
        if (source.isPlaying) {source.Pause();}
        else {source.Play();}
    }

    public void MuteToggle()
    {
        muteBool = !muteBool;
        source.mute = muteBool;
    }
    public void LoopToggle()
    {
        loopBool = !loopBool;
        source.loop = loopBool;
    }

    public void ExitScene()
    {
        StartCoroutine(ExitMusic());
    }
    
    public IEnumerator ExitMusic()
    {
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.75f);
        SceneManager.LoadScene("Main Menu");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        currentEntry = other.gameObject.GetComponent<SongEntry>();
    }
}
