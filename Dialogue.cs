using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Dialogue : MonoBehaviour
{
    public Animator transition;
    public AudioSource exitSound;
    public AudioSource typingSound;
    public string[] scentences;
    public float speed;
    public float scentenceSpeed;
    public string currentDialogue;
    [Space]
    public int mainSceneIndex;
    public float loadAnimationLength = 5;
    bool play;
    private void Start()
    {
        play = true;
        StartCoroutine(dialogueDisplay());
    }
    private void Update()
    {
        GetComponent<TextMeshProUGUI>().SetText(currentDialogue);
    }
    IEnumerator dialogueDisplay()
    {
        while (play)
        {
            for (int i = 0; i < scentences.Length; i++)
            {
                for (int y = 0; y < scentences[i].Length; y++)
                {
                    yield return new WaitForSeconds(speed);
                    typingSound.Play();
                    currentDialogue = currentDialogue.Insert(currentDialogue.Length, scentences[i].ToCharArray()[y].ToString());

                }
                yield return new WaitForSeconds(scentenceSpeed);
                currentDialogue = currentDialogue.Insert(currentDialogue.Length, "\n");
                if (i == scentences.Length - 1)
                    StartCoroutine(loadMainScene());
            }

        }
        yield return null;
    }
    IEnumerator loadMainScene()
    {
        play = false;
        transition.SetTrigger("Play");
        exitSound.Play();
        yield return new WaitForSeconds(loadAnimationLength);
        SceneManager.LoadScene(mainSceneIndex);
    }
}
