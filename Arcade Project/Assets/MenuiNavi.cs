using System.Collections;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MenuiNavi : MonoBehaviour
{
    private Animator select;
    private string sceneName;
    private string programPath;
    private int contentID;
    private GameObject currentIcon;
    private bool counting, disabledInput;
    private int i;
    private InputMaster controls;
    public ListPositionCtrl menu;
    public Animator fade;
    public AudioSource moveSound;
    public AudioSource selectSound;
    public GameObject[] icons;
    public Text count;
    public GameObject countdown;

    private void Start()
    {
        currentIcon = icons[0];
        controls = new InputMaster();
        controls.User.Enable();
        //controls.User.Up.performed += GoUp;
        //controls.User.Down.performed += GoDown;
        //controls.User.Select.performed += Selected;
        //controls.User.Back.performed += Undo;
    }

    void Update()
    {
        contentID = menu.GetCenteredContentID();
        //currentIcon.SetActive(false);
        currentIcon = icons[contentID];
        //currentIcon.SetActive(true);
    }

    public void GoUp() //InputAction.CallbackContext context
    {
        if (!disabledInput)
        {
            moveSound.Play();
            menu.MoveOneUnitDown();
        }
    }
    public void GoDown()
    {
        if (!disabledInput)
        {
            moveSound.Play();
            menu.MoveOneUnitUp();
        }
    }
    public void Selected()
    {
        if (!disabledInput)
        {
            disabledInput = true;
            if (contentID == 0) //MAME
            {
                programPath = "C:/Program Files (x86)/EmulationStation/emulationstation.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 1) //StepMania
            {
                programPath = "C:/Games/StepMania 5/Program/StepMania.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 2) //CloneHero
            {
                programPath = "C:/Users/User/Documents/clonehero-win64/Clone Hero.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 3) //Jukebox
            {
                sceneName = "Jukebox";
                StartCoroutine(LoadGame());
            }
            else if (contentID == 4) //Shut Down
            {
                menu.selectFlash.SetTrigger("Select");
                selectSound.Play();
                countdown.SetActive(true);
                counting = true;
                i = 5;
                StartCoroutine(ShutDown()); 
            }
        }
    }
    public void Undo()
    {
        if (counting)
        {
            counting = false;
            countdown.SetActive(false);
            disabledInput = false;
        }
    }


    IEnumerator LoadGame()
    {
        menu.selectFlash.SetTrigger("Select");
        selectSound.Play();
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.75f);
        disabledInput = false;
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
        disabledInput = false;
    }

    IEnumerator ShutDown()
    {
        while (i >= 0)
        {
            count.text = i.ToString();
            yield return new WaitForSeconds(1f);
            i--;
            if (!counting)
            {
                yield break;
            }
            if (i == 0)
            {
                disabledInput = false;
                var psi = new ProcessStartInfo("shutdown","/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
        }
    }
}