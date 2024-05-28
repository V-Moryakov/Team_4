using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject tutorialPanel;
    public Text tutorialText;
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        sentences = new Queue<string>();
        if (currentSceneIndex == 1)
        {
            StartDialogue();
        }
        //message[0] = "Здравствуй колдунья! Тебе предстоит зачистить три лагеря, добывая с врагов необходимые для зелий ингредиенты или собирая их в лесу (клавиша E).";
        //message[1] = "Поначалу будет сложнл, но чтобы облегить свой путь, используй ctrl, что позволит тебе подкрадываться к врагам незаметно.";
        //message[2] = "Ты повысишь свои шансы на успех, создавая разнообразные зелья в инвенатре (клавиша I). Чтобы создать их, используй рецепты, которые откроются тебе по мере прохождения.";
        //message[3] = "Чтобы поменять зелье, нажми на соответствующую цифру, но для этого потребуется вновь потратить необходимые для его создания ингредиенты.";
        //message[4] = "Убив боссов всех трех лагерей и собрав все необходимые зелья, отправляйся к врагу у реки, защищающему вход в пещеру на другом берегу, чтобы сразиться с настоящим злом.";
    }

    public void StartDialogue()
    {
        Time.timeScale = 0f;
        tutorialPanel.SetActive(true);
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            tutorialPanel.SetActive(false);
            Time.timeScale = 1f;
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        tutorialText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            tutorialText.text += letter;
            yield return null;
        }
    }
}
