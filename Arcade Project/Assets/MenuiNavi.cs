using System.Collections;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

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
    public Text count;
    private bool counting, disabledInpt;
    public GameObject countdown;
    private int i;
    private InputMaster controls;

    private void Start()
    {
        currentIcon = icons[0];
        controls = new InputMaster();
        controls.User.Enable();
        controls.User.Up.performed += GoUp;
        controls.User.Down.performed += GoDown;
        controls.User.Select.performed += Selected;
        controls.User.Back.performed += Undo;
    }

    void Update()
    {
        contentID = menu.GetCenteredContentID();
        currentIcon.SetActive(false);
        currentIcon = icons[contentID];
        currentIcon.SetActive(true);
    }

    private void GoUp(InputAction.CallbackContext context)
    {
        if (!disabledInpt)
        {
            moveSound.Play();
            menu.MoveOneUnitDown();
        }
    }
    private void GoDown(InputAction.CallbackContext context)
    {
        if (!disabledInpt)
        {
            moveSound.Play();
            menu.MoveOneUnitUp();
        }
    }
    private void Selected(InputAction.CallbackContext context)
    {
        if (!disabledInpt)
        {
            if (contentID == 0) //MAME
            {
                disabledInpt = true;
                programPath = "C:/Program Files (x86)/EmulationStation/emulationstation.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 1) //StepMania
            {
                disabledInpt = true;
                programPath = "C:/Games/StepMania 5/Program/StepMania.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 2) //CloneHero
            {
                disabledInpt = true;
                programPath = "C:/Users/User/Documents/clonehero-win64/Clone Hero.exe";
                StartCoroutine(LoadProgram());
            }
            else if (contentID == 3) //Jukebox
            {
                disabledInpt = true;
                sceneName = "Jukebox";
                StartCoroutine(LoadGame());
            }
            else if (contentID == 4) //Shut Down
            {
                disabledInpt = true;
                menu.selectFlash.SetTrigger("Select");
                selectSound.Play();
                countdown.SetActive(true);
                counting = true;
                i = 5;
                StartCoroutine(ShutDown()); 
            }
        }
    }
    private void Undo(InputAction.CallbackContext context)
    {
        if (counting)
        {
            counting = false;
            countdown.SetActive(false);
            disabledInpt = false;
        }
    }


    IEnumerator LoadGame()
    {
        menu.selectFlash.SetTrigger("Select");
        selectSound.Play();
        fade.SetTrigger("FadeOut");
        yield return new WaitForSeconds(2.75f);
        disabledInpt = false;
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
        disabledInpt = false;
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
                disabledInpt = false;
                var psi = new ProcessStartInfo("shutdown","/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
        }
    }
}