using UnityEngine;
using TMPro;
using bType;

public class Shoot : MonoBehaviour {
    public float strength = 5f;
    public GameObject bullet;
    public GameObject timerText;
    public GameObject loseText;
    private bool shot = false;
    private Timer tim = new Timer();

    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        if(!shot && Input.GetMouseButtonDown(0))
        {
            GameObject bull =  Instantiate(bullet, transform.position, transform.rotation);
            bull.transform.position = new Vector3(bull.transform.position.x, transform.position.y, 0);
            Vector3 dir = transform.InverseTransformDirection(new Vector3(1, 0, 0));
            dir.y = -dir.y;
            bull.GetComponent<Rigidbody2D>().AddForce(dir * strength);
            shot = true;
            tim.Start(10000);
        }
        if (PlayerPrefs.GetInt("won") != 1)
        {
            if (tim.IsSet())
            {
                timerText.SetActive(true);
                timerText.GetComponent<TextMeshProUGUI>().text = System.Math.Round(tim.Seconds(), 2).ToString() + " S";
            }

            if (tim.Passed())
            {
                loseText.SetActive(true);
            }
        }
    }
}
