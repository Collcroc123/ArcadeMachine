using System.Collections;
using UnityEngine;

public class ScrollList : MonoBehaviour
{
    private Vector3 endPos;
    private Vector3 startPos;
    private float speed = 20f;
    private float distance = 1;
    private int time;
    public GameObject selectSq;

    private void Start()
    {
        startPos = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetAxis("Mouse ScrollWheel") > 0f) //Forward
        {
            GoUp();
        }
        else if (Input.GetKeyDown("down") || Input.GetAxis("Mouse ScrollWheel") < 0f) //Back
        {
            GoDown();
        }

        if (!Input.anyKey) {time++;}
        else
        {
            time = 0;
            selectSq.SetActive(true);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        if (time == 2400)
        {
            selectSq.SetActive(false);
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
        }
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

    public void GoUp()
    {
        time = 0;
        selectSq.SetActive(true);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        endPos = new Vector3(0, startPos.y - (2.7777777f * distance), 0);
        if (endPos.y < 0f)
        {
            endPos.y = 0f;
        }
        StartCoroutine(Move());
    }

    public void GoDown()
    {
        time = 0;
        selectSq.SetActive(true);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        endPos = new Vector3(0, startPos.y + (2.7777777f * distance), 0); //2.77777f
        StartCoroutine(Move());
    }
}