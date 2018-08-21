using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] shoot;
    private AudioClip shootClip;

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public GameObject shot2;
    public GameObject shotSpawn;
    public GameObject[] shotSpawns;
    public GameObject[] shotSpawnz;
    public GameObject projectile;
    public float fireRate;

    private float nextFire;

    public Text questionDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
    private static List<QuestionData> unansweredQuestions;

    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        ShowQuestion();

    }


    private void ShowQuestion()
    {

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questionPool.ToList();
        }

        RemoveAnswerButtons();
        int questionIndex = Random.Range(0, unansweredQuestions.Count);
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }


    IEnumerator Rapidfirez()
    {
        yield return new WaitForSeconds(0.15f);
        foreach (var shotSpawn in shotSpawnz)
        {
            projectile = Instantiate(shot2) as GameObject;
            projectile.transform.position = shotSpawn.transform.position;
            Debug.Log("CORRECT!");

        }

        shootClip = shoot[1];
        audioSource.clip = shootClip;
        audioSource.Play();

        SP.special = 10;
    }

    IEnumerator Rapidfire()
    {

        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.15f);
            foreach (var shotSpawn in shotSpawns)
            {
                projectile = Instantiate(shot) as GameObject;
                projectile.transform.position = shotSpawn.transform.position;
                Debug.Log("CORRECT!");

            }

            shootClip = shoot[2];
            audioSource.clip = shootClip;
            audioSource.Play();

        }
        SP.special = 10;
    }


    public void AnswerButtonClicked(bool isCorrect)
    {


        if (isCorrect && Time.time > nextFire && SP.special == 0)
        {
            StartCoroutine(Rapidfire());
            ShowQuestion();
        }


        if (isCorrect && Time.time > nextFire)
        {

            shootClip = shoot[0];
            audioSource.clip = shootClip;
            audioSource.Play();


            projectile = Instantiate(shot) as GameObject;
            nextFire = Time.time + fireRate;
            projectile.transform.position = shotSpawn.transform.position;
            Debug.Log("CORRECT!");

            ShowQuestion();
        }

        else
        {
            Debug.Log("WRONG!");
            ShowQuestion();
        }


    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) && SP.special <= 4 && SP.special >= 0)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(Rapidfirez());
            ShowQuestion();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;

        GetComponent<Rigidbody>().position = new Vector3
        (
        Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 0.0f, Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);

    }



}

