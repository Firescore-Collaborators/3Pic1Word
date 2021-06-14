using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class Character : MonoBehaviour
{

    TextMeshProUGUI inputText;
    GameSession gameSession;
    //[SerializeField] Sprite sprite;


    Texture texture;
    // Start is called before the first frame update
    void Start()
    {
        inputText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
        //texture = transform.parent.transform.gameObject.GetComponent<RawImage>().texture;
    }

    // Update is called once per frame


    public void SendInput()
    {
        char ch = inputText.text[0];
        gameSession.ReceiveInput(ch);
        inputText.text = null;
        GameObject gameObject = inputText.gameObject.transform.parent.gameObject;
        gameObject.GetComponent<RawImage>().enabled = false;
        //GameObject afterinp = inputText.gameObject.transform.parent.gameObject.transform.Find("After Input").gameObject;
       // afterinp.SetActive(true);
    }
}
