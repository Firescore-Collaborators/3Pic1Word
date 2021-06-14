using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] GameObject[] letters;
    [SerializeField] Animator transition;
    [SerializeField] GameObject glitterEffect;
    [SerializeField] Animator[] objects;
    [SerializeField] GameObject[] inputCharacters;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject correctText;
    [SerializeField] AudioClip typingSound;
    [SerializeField] GameObject stars;
    [SerializeField] GameObject correct;
    [SerializeField] GameObject guessText;

    [SerializeField] AudioClip[] objectSound;

    [SerializeField] GameObject levelNum;

    [SerializeField] Animator letterAnimator;

    int currIndex;

    TextMeshProUGUI answerText;

    int numObjects = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(letters.Length);
        currIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(currIndex >= letters.Length)
        {
            StartCoroutine(WinScreen());

        }

        if(Input.GetKeyDown("s"))
        {
            StartCoroutine(StartFlip());
           
            
        }
    }

    private IEnumerator StartFlip()
    {
        levelNum.SetActive(true);
        guessText.SetActive(true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Flip());
    }

    private IEnumerator Flip()
    {
        foreach(Animator animator in objects)
        {
            numObjects++;
            GameObject obj = animator.gameObject;
            obj.SetActive(true);
            animator.SetTrigger("Pop");

            AudioSource.PlayClipAtPoint(objectSound[numObjects - 1], Camera.main.transform.position);

            yield return new WaitForSeconds(0.6f);
            if(numObjects >= objects.Length)
            {
                foreach(GameObject gameObject in inputCharacters)
                {
                    gameObject.SetActive(true);
                }
            }
        }
    }

    private IEnumerator WinScreen()
    {
        transition.SetTrigger("Start");
        letterAnimator.SetTrigger("Letter");
        yield return new WaitForSeconds(1f);
        continueButton.SetActive(true);
        stars.SetActive(true);
        correct.SetActive(true);
        //correctText.SetActive(true);
       // glitterEffect.SetActive(true);
    }

    public void ReceiveInput(char character)
    {
        AudioSource.PlayClipAtPoint(typingSound, Camera.main.transform.position);
        answerText = letters[currIndex].transform.Find("Character").transform.
        gameObject.GetComponent<TextMeshProUGUI>();

        GameObject diamond = letters[currIndex].transform.Find("Diamond").transform.gameObject;
        diamond.SetActive(false);

        answerText.text = character.ToString();
        currIndex++;
    }
}
