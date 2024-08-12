using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OOCManager : MonoBehaviour
{
    private AudioManager theAudio;
    public string key_sound;
    public string cancel_sound;
    public string enter_sound;

    public GameObject up_Panel;
    public GameObject down_Panel;

    public Text up_Text;
    public Text down_Text;

    public bool activated;
    private bool result = true;
    private bool keyInput;
    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
    }

    private void Selected()
    {
        theAudio.Play(key_sound);
        result = !result;

        if (result)
        {
            up_Panel.gameObject.SetActive(true);
            down_Panel.gameObject.SetActive(false);
        }
        else
        {
            up_Panel.gameObject.SetActive(false);
            down_Panel.gameObject.SetActive(true);
        }
    }
    public void ShowChoice(string _upText, string _downText)
    {
        activated = true;
        result = true;
        up_Text.text = _upText;
        down_Text.text = _downText;

        up_Panel.gameObject.SetActive(true);
        down_Panel.gameObject.SetActive(false);

        StartCoroutine(ShowChoiceCoroutine());
    }

    public bool GetResult()
    {
        return result;
    }

    IEnumerator ShowChoiceCoroutine()
    {
        yield return new WaitForSeconds(0.01f);

        keyInput = true;
    }

    void Update()
    {
        if (keyInput)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                Selected();
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow)){
                Selected();
            }
            else if (Input.GetKeyDown(KeyCode.Z)){
                //use item
                theAudio.Play(enter_sound);
                keyInput = false;
                activated = false;
            }
            else if (Input.GetKeyDown(KeyCode.X)){
                //cancel choice
                theAudio.Play(cancel_sound);
                result = false;
                activated = false;
                keyInput = false;
            }
        }
    }
}
