using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeStart = 2;
    public Text timerText;
    public bool check;
    // Start is called before the first frame update
    
    Circleslot hinge; //= gameObject.GetComponent(typeof(Circleslot)) as Circleslot;
    void Start()
    {
        timerText.text = timeStart.ToString("F2");
        //hinge = gameObject.GetComponent(typeof(Circleslot)) as Circleslot;
        //Circleslot beh = GameObject.Find("Slot for circle").GetComponent(typeof(Circleslot));
        //check = beh.check;
        //check = hinge.check;
    }

    // Update is called once per frame
    void Update()
    {
 		//hinge = gameObject.GetComponent(typeof(Circleslot)) as Circleslot;
		//Debug.Log(hinge.check);
		var position = GameObject.Find("Image").GetComponent<RectTransform>().anchoredPosition;
		Debug.Log(position.x);
		Debug.Log(position.y);
        timeStart -= Time.deltaTime;
        if (timeStart < 0)
        {
            timerText.text = (0.00).ToString("F2");
            if (position.x is > -22 and < 22 && position.y is > -28 and < 22)
            {
                Debug.Log("Success");
				SceneManager.UnloadSceneAsync ("MiniGame");
            }
            else
            {
                Debug.Log("Failure");
				SceneManager.UnloadSceneAsync ("MiniGame");
            }
        }
        else
        {
            timerText.text = timeStart.ToString("F2");  
        }
        //timerText.text = timeStart.ToString("F2");
    }
}
