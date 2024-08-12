using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    public Text text;
    private PlayerManager thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            thePlayer.characterName = text.text;
            Destroy(this.gameObject);
        }
    }
}
