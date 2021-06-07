using System.Collections;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;

public class MenuiNavi : MonoBehaviour
{
    public ListPositionCtrl menu;
    public Animator fade;
    private Animator select;
    private string sceneName;
    public AudioSource moveSound;
    public AudioSource selectSound;
    private string programPath;
    private int contentID;
    public GameObject[] icons;
    private GameObject currentIcon;

    private void Start()
    {
        currentIcon = icons[0];
    }

    void Update()
    {
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down"))
        {
            moveSound.Play();
            menu.MoveOneUnitUp();
        }
        else if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
        {
            moveSound.Play();
            menu.MoveOneUnitDown();
        }
        
        contentID = menu.GetCenteredContentID();
        
        if (Input.GetKeyDown("space") || Input.GetKeyDown("return"))
        {
            if (contentID == 0) //MAME
            {
                programPath = "C:/Games/StepMania 5/Program/StepMania.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 1) //StepMania
            {
                programPath = "C:/Games/StepMania 5/Program/StepMania.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 2) //Space Defence
            {
                //sceneName = "Space";
                //StartCoroutine(LoadGame());
            }
            else if (contentID == 3) //Jukebox
            {
                sceneName = "Jukebox";
                StartCoroutine(LoadGame());
            }
            else if (contentID == 4) //Options
            {
                sceneName = "Options"; 
                StartCoroutine(LoadGame()); 
            }
        }

        currentIcon.SetActive(false);
        currentIcon = icons[contentID];
        currentIcon.SetActive(true);
    }

    IEnumerator LoadGame()
    {
        menu.selectFlash.SetTrigger("Select");
        selectSound.Play();
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.75f);
        SceneManager.LoadScene(sceneName);
    }
    
    IEnumerator LoadProgram()
    {
        menu.selectFlash.SetTrigger("Select");
        selectSound.Play();
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.75f);
        Process process = Process.Start(programPath);
        yield return new WaitForSeconds(0.5f);
        fade.SetTrigger("FadeIn");
    }
}