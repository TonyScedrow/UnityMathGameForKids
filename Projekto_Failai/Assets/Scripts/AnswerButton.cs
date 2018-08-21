using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class AnswerButton : MonoBehaviour {

    public Text answerText;

    private AnswerData answerData;
    private PlayerController playerController;

    // Use this for initialization
    void Start () {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }


    public void HandleClick()
    {
        playerController.AnswerButtonClicked(answerData.isCorrect);
    }
}
