using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    public int scoreValue;
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == "Player")
        {
            HP.health -= 1;
            Destroy(gameObject);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
        }

        if (other.tag == "Player" && HP.health == 0)
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            gameController.GameOver();
        }


        if (other.tag == "Shot")
        {

            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
            SP.special -= 1;
        }

        if (other.tag == "shot2")
        {

            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(gameObject);
            gameController.AddScore(scoreValue);
            SP.special -= 1;
        }

    }
           

    }


