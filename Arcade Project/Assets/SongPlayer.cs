using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SongPlayer : MonoBehaviour
{
    private Animator fade;
    public AudioSource source;
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
    private GameObject button;
    private InputMaster controls;

    private void Awake()
    {
        source = GameObject.Find("Black Fade").GetComponent<AudioSource>();
        fade = GameObject.Find("Black Fade").GetComponent<Animator>();
        //background.SetActive(false);
        controls = new InputMaster();
        controls.User.Enable();
        controls.User.Left.performed += GoLeft;
        controls.User.Right.performed += GoRight;
        controls.User.Select.performed += Selected;
        controls.User.Back.performed += PlayToggle;
    }

    public void Update()
    {
        timeBar.value = source.time;
    }

    private void GoLeft(InputAction.CallbackContext context)
    {
        scroll.GoUp(context);
        StartCoroutine(LoadAudio());
    }
    private void GoRight(InputAction.CallbackContext context)
    {
        scroll.GoDown(context);
        StartCoroutine(LoadAudio());
    }
    private void Selected(InputAction.CallbackContext context)
    {
        if (button.tag == "Enemy")
        {
            StartCoroutine(ExitMusic());
        }
        else
        {
            StartCoroutine(LoadAudio());
        }
    }

    private IEnumerator LoadAudio()
    {
        yield return new WaitForSeconds(0.5f);
        scroll.TimeReset(false);
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
        //background.SetActive(true);
    }
    
    private WWW GetAudioFromFile(string path)
    {
        string audioToLoad = string.Format(path); // + "{0}", filename
        WWW request = new WWW(audioToLoad);
        return request;
    }

    public void PlayToggle(InputAction.CallbackContext context)
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

    public IEnumerator ExitMusic()
    {
        fade.SetTrigger("FadeOut");
        source.Pause();
        yield return new WaitForSeconds(2.75f);
        SceneManager.LoadScene("Main Menu");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        button = other.gameObject;
        currentEntry = other.gameObject.GetComponent<SongEntry>();
    }
}
