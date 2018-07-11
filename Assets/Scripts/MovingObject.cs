/*
	Copyright Benedikt Aron Sigurthorsson 2018.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using bType;

public class MovingObject : MonoBehaviour 
{
    public Vector3 moveDir;
    public uint duration;
    public float speed;
    public bool returnToStart = true;
	private Timer tim = new Timer();
    private short mult = 1;

    private void Start()
    {
        tim.Start(duration);
    }

    void Update () 
	{
		if(tim.Passed() && returnToStart)
        {
            mult *= -1;
            tim.Reset();
        }
        if(!tim.Passed())
            transform.position += (speed * moveDir * Time.deltaTime * mult);
	}
}
