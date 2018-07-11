using UnityEngine;
using bType;

public class ReRotate : MonoBehaviour {

    private Timer tim = new Timer();

	void Start ()
    {
        tim.Start(1000);
	}
	
	void Update ()
    {
        Vector2 dir = gameObject.GetComponent<Rigidbody2D>().velocity;
        float angle = 0;
        bool anchor = Mathf.Abs(dir.x) > Mathf.Abs(dir.y);
        float sway = dir.y / Mathf.Abs(dir.y);
        if (dir.x < 0)
        {
            angle = 180;
            if (anchor)
            {
                if (sway == -1)
                {
                    angle += (Mathf.Abs(dir.y) / Mathf.Abs(dir.x)) * 45;
                }
                else
                {
                    angle -= (Mathf.Abs(dir.y) / Mathf.Abs(dir.x)) * 45;
                }
            }
            else
            {
                if (sway == -1)
                {
                    angle += 90;
                    angle -= (Mathf.Abs(dir.x) / Mathf.Abs(dir.y)) * 45;
                }
                else
                {
                    angle -= 90;
                    angle += (Mathf.Abs(dir.x) / Mathf.Abs(dir.y)) * 45;
                }
            }
        }
        else
        {
            if (anchor)
            {
                if (sway == -1)
                {
                    angle -= (Mathf.Abs(dir.y) / Mathf.Abs(dir.x)) * 45;
                }
                else
                {
                    angle += (Mathf.Abs(dir.y) / Mathf.Abs(dir.x)) * 45;
                }
            }
            else
            {
                if (sway == -1)
                {
                    angle -= 90;
                    angle += (Mathf.Abs(dir.x) / Mathf.Abs(dir.y)) * 45;
                }
                else
                {
                    angle += 90;
                    angle -= (Mathf.Abs(dir.x) / Mathf.Abs(dir.y)) * 45;
                }
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
