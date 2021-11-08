using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    //30 degrees counts as one full move e.g. from 12 to 1 etc
    //there are 5 indents on a normal watch between these two
    //meaning the minute and second hand should move 6 degs
    Transform hourHand; 
    Transform minuteHand;
    Transform secondHand;
    DateTime time;
    string stringTime;
    string hours;
    string mins;
    string seconds;   
    int n_hours;
    int n_mins;
    int n_seconds;
    public float inc = 0f;
    float timer = 0f;
    void Start() 
    {
        hourHand = this.transform.GetChild(1).GetComponent<Transform>();
        minuteHand = this.transform.GetChild(2).GetComponent<Transform>();
        secondHand = this.transform.GetChild(3).GetComponent<Transform>();
        // print(DateTime.Now); //example output: 11/03/2021 19:27:48
        //Getting the current time as an int for each section
        time = DateTime.Now;
        stringTime = time.ToString();

        seconds = stringTime.Substring(stringTime.Length-2, 2);
        n_seconds = int.Parse(seconds);

        mins = stringTime.Substring(stringTime.Length-5, 2);
        n_mins = int.Parse(mins);

        hours = stringTime.Substring(stringTime.Length-8, 2);
        n_hours = int.Parse(hours);
        if (n_hours > 12) { n_hours -= 12; } // 24 hour conversion

        //Using the current time ints to set the starting rotation to the current time
        //Second hand set
        rotateHand(secondHand, n_seconds * 6);
        //Minute hand set
        rotateHand(minuteHand, n_mins * 6);
        rotateHand(hourHand, n_hours * 30);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            timer = 0f;
            rotateHand(secondHand,6);
            if (inc % 60 == 0 && inc != 0) //The time is divisable by 60 so we have passed a mintue
            {
                rotateHand(minuteHand, 6);
            }
            if (inc >= 3600) // This is how many seconds are in an hour
            {
                inc = 0;
                rotateHand(hourHand, 30);
            }
            inc++;
        }
 
    }

    void rotateHand(Transform hand, int rotateAmount)
    {
        hand.Rotate(hand.transform.rotation.x + rotateAmount, 0.0f, 0.0f, Space.Self);
    }
}
