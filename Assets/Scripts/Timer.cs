using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timertext;
    [SerializeField] float remainingTime;

    //Gameobjet to link to pannel
    public GameObject death;

    //variable time saver
    public static float finalTime;

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int min = Mathf.FloorToInt(remainingTime / 60);
        int sec = Mathf.FloorToInt(remainingTime % 60);
        
        //if for letting time drop to 00:00
        if (remainingTime >= 0)
        {
            timertext.text = string.Format("{0:00} : {1:00}", min, sec);
        }
        
        //death Screen activation
        if(remainingTime <= 0)
        {
            death.SetActive(true);
        }
    }
<<<<<<< HEAD
    public void SaveTime()
    {
        finalTime = remainingTime;
=======
    public void AddTime(float timeToAdd)
    {
        remainingTime += timeToAdd;
>>>>>>> 3a888ec1d66a1253ae7de95f00d91b2230189a40
    }
}
