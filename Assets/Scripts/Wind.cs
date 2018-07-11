using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Wind : MonoBehaviour {
    public string taggedAs = "Bullet";
    public float strength = 1;
    private float maxStrength = 3000;
    private SpriteRenderer rndrr;

    private void Awake()
    {
        rndrr = GetComponent<SpriteRenderer>();
        rndrr.color = new Color(strength / maxStrength, (maxStrength - strength) / maxStrength, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == taggedAs)
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right*strength);
        }
    }
}
