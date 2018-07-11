using UnityEngine;
using UnityEngine.SceneManagement;
using bType;

public class KillMe : MonoBehaviour {

    public GameObject winText;
    private Timer tim = new Timer();

    private void Start()
    {
        PlayerPrefs.SetInt("won", 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            if (!tim.IsSet())
            {
                winText.SetActive(true);
                tim.Start(2000);
                PlayerPrefs.SetInt("won", 1);
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void Update()
    {
        if(tim.Passed())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
