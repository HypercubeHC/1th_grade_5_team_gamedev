using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
		var position = GameObject.Find("Cirle").GetComponent<RectTransform>().anchoredPosition;
		Debug.Log(position.x);
		Debug.Log(position.y);
        timeStart -= Time.deltaTime;
        if (timeStart < 0)
        {
            timerText.text = (0.00).ToString("F2");
            if (position.x is > -22 and < 22 && position.y is > -28 and < 22)
            {
                Debug.Log("Success");
                int index = GameObject.Find("mapreference").GetComponent<MapObjects>().ind + 1;
                foreach (var item in GameObject.Find("Controller").GetComponent<GeneralController>().modules)
                {
                    if (nameEqual(item, GameObject.Find("mapreference").GetComponent<MapObjects>().ArrayOfGameObjects[index]))
                    {
                        item.SetActive(true);
                        breakOverlap(item);
                        Pathfinding.AstarData.active.Scan();
                        GameObject.Find("mapreference").GetComponent<MapObjects>().ArrayOfGameObjects[index].SetActive(false);
                        List<GameObject> tmp1 = new List<GameObject>(GameObject.Find("mapreference").GetComponent<MapObjects>().ArrayOfGameObjects);
                        tmp1.RemoveAt(index);
                        GameObject.Find("mapreference").GetComponent<MapObjects>().ArrayOfGameObjects = tmp1.ToArray();
                        List<double> tmp2 = new List<double>(GameObject.Find("mapreference").GetComponent<MapObjects>().destinations);
                        tmp2.RemoveAt(index - 1);
                        GameObject.Find("mapreference").GetComponent<MapObjects>().destinations = tmp2.ToArray();
                        /*GameObject.Find("mapreference").GetComponent<MapObjects>().ArrayOfGameObjects.ToList().RemoveAt(index);
                        GameObject.Find("mapreference").GetComponent<MapObjects>().destinations.ToList().RemoveAt(index - 1);
                        GameObject.Find("mapreference").GetComponent<MapObjects>().ArrayOfGameObjects.ToArray();
                        GameObject.Find("mapreference").GetComponent<MapObjects>().destinations.ToArray();*/
                        break;
                    }
                }

                GameObject.Find("mapreference").GetComponent<MapObjects>().check = false;
                SceneManager.UnloadSceneAsync ("MiniGame");
            }
            else
            {
                Debug.Log("Failure");
                GameObject.Find("mapreference").GetComponent<MapObjects>().check = false;
				SceneManager.UnloadSceneAsync ("MiniGame");
            }
        }
        else
        {
            timerText.text = timeStart.ToString("F2");  
        }
        //timerText.text = timeStart.ToString("F2");
    }

    bool nameEqual(GameObject o1, GameObject o2)
    {
        string s1 = o1.name;
        string s2 = o2.name;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                return false;
            }
        }
        return true;
    }

    void breakOverlap(GameObject newObject)
    {
        if (newObject.name == "Module R-01")
            GameObject.Find("Between R01 M01").SetActive(false);
        else if (newObject.name == "Module E-04")
            GameObject.Find("Between E04 L01").SetActive(false);
        else if (newObject.name == "Module L-01")
            GameObject.Find("Between L01 M01").SetActive(false);
        else if (newObject.name == "Module E-02")
            GameObject.Find("Between M01 E02").SetActive(false);
        else if (newObject.name == "Module E-03")
            GameObject.Find("Between E02 E03").SetActive(false);
        else if (newObject.name == "Module R-02")
            GameObject.Find("Between E03 R02").SetActive(false);
        else if (newObject.name == "Module E-01")
            GameObject.Find("Between M01 E01").SetActive(false);
        else if (newObject.name == "Module S-02")
            GameObject.Find("Between E02 S02").SetActive(false);
        if (newObject.name == "Module M-02")
            GameObject.Find("Between E01 M02").SetActive(false);
    }
}
