using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScrollList : MonoBehaviour
{
    public SongPlayer song;
    private Vector3 endPos;
    private Vector3 startPos;
    private float speed = 20f;
    private float distance = 0.975f, baseDist = 2.7777777f;
    private int time;
    public GameObject selectSq;
    private InputMaster controls;

    private void Start()
    {
        startPos = new Vector3(0, 0, 0);
        controls = new InputMaster();
        controls.User.Enable();
        //controls.User.Up.performed += GoUp;
        //controls.User.Down.performed += GoDown;
        //controls.User.Select.performed += Selected;
    }

    void Update()
    {
        if (song.source.isPlaying) {time++;}
    }

    IEnumerator Move()
    {
        while (transform.position != endPos)
        {
            transform.position = Vector3.Lerp(transform.position,endPos, speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            if (Mathf.Abs(transform.position.y - endPos.y) < 0.05f)
            {
                startPos = endPos;
                transform.position = endPos;
            }
        }
    }

    public void GoUp() //InputAction.CallbackContext context
    {
        TimeReset(true);
        endPos = new Vector3(0, startPos.y - (baseDist * distance), 0);
        if (endPos.y < -baseDist)
        {
            endPos.y = -baseDist;
        }
        StartCoroutine(Move());
    }

    public void GoDown()
    {
        TimeReset(true);
        endPos = new Vector3(0, startPos.y + (baseDist * distance), 0); //2.77777f
        StartCoroutine(Move());
    }

    public void Selected()
    {
        if (time == 1200)
        {
            TimeReset(false);
        }
    }

    public void TimeReset(bool mode)
    {
        if (mode) {time = 0;}
        selectSq.SetActive(mode);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(mode);
        }
    }
}