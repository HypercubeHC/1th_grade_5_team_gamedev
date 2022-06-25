using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GeneralController : MonoBehaviour
{
    GameObject[] electric;
    GameObject[] fire;
    GameObject[] veryDangerous;
    public GameObject[] modules;
    public GameObject[] people;
    Image heightbar;
    Image overheatbar;
    Image coolbar;
    Image healthbar;
    Image oxygenbar;
    private GameObject hints;
    public Image fuelbar;
    public bool is_Paused = true;

    bool timeToProblem = false;
    float timer = 1;
    float timeProblem = 30f;
    public bool gasProb = false;

    // Start is called before the first frame update
    void Start()
    {
        electric = GameObject.FindGameObjectsWithTag("Electric");
        fire = GameObject.FindGameObjectsWithTag("Fire");
        veryDangerous = GameObject.FindGameObjectsWithTag("VeryDangerous");
        modules = GameObject.FindGameObjectsWithTag("Module");
        people = GameObject.FindGameObjectsWithTag("Person");
        for (int i = 0; i < 10; i++)
        {
            if (modules[i].name != "Module M-01")
            {
                for (int j = 0; j < 3; j++)
                {
                    modules[i].transform.GetChild(j).gameObject.SetActive(false);
                }
                modules[i].SetActive(false);
            }
        }

        heightbar = GameObject.Find("Heightbar").GetComponent<Image>();
        overheatbar = GameObject.Find("Overheatbar").GetComponent<Image>();
        coolbar = GameObject.Find("Coolbar").GetComponent<Image>();
        healthbar = GameObject.Find("Healthbar").GetComponent<Image>();
        oxygenbar = GameObject.Find("Oxygenbar").GetComponent<Image>();
        fuelbar = GameObject.Find("Fuelbar").GetComponent<Image>();
        hints = GameObject.Find("Hints");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (hints.activeSelf == false)
            {
                is_Paused = true;
                hints.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                is_Paused = false;
                hints.SetActive(false);
                Time.timeScale = 1;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.X))
            SceneManager.LoadScene("Cutscene_deadly_gas");
        if (Input.GetKeyDown(KeyCode.Z))
            SceneManager.LoadScene("Cutscene_Open doors");
        if (Input.GetKeyDown(KeyCode.C))
            GameObject.Find("SoundBeep").GetComponent<AudioSource>().Play();

        Paramaters();

        checkProblems();
        newProblems();
        solutionOfProblems();
    }

    void Paramaters()
    {
        if (Input.GetKey(KeyCode.R))
        {
            heightbar.fillAmount += 1 / 30f * Time.deltaTime;
            fuelbar.fillAmount -= 1 / 90f * Time.deltaTime;
        }
        else if (heightbar.fillAmount <= 0)
            SceneManager.LoadScene("Cutscene_too_low");
        else if (heightbar.fillAmount >= 1)
            SceneManager.LoadScene("Cutscene_too_high");
        else
        {
            heightbar.fillAmount -= 1 / 240f * Time.deltaTime;
            fuelbar.fillAmount += 1 / 70f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            coolbar.fillAmount -= 1 / 40f * Time.deltaTime;
            overheatbar.fillAmount += 1 / 40f * Time.deltaTime;
            fuelbar.fillAmount -= 1 / 200f * Time.deltaTime;
        }
        else if (coolbar.fillAmount <= 0)
            SceneManager.LoadScene("Cutscene_hot_station");
        else if (coolbar.fillAmount >= 1)
            SceneManager.LoadScene("Cutscene_Frozen_station");
        else
        {
            coolbar.fillAmount += 1 / 300f * Time.deltaTime;
            overheatbar.fillAmount -= 1 / 300f * Time.deltaTime;
        }
    }

    void checkProblems()
    {
        int electricCount = 0, fireCount = 0, dangerCount = 0;

        for (int i = 0; i < electric.Length; i++)
        {
            if (electric[i].activeSelf)  ++electricCount;
            if (fire[i].activeSelf)  ++fireCount;
            if (veryDangerous[i].activeSelf)  ++dangerCount;
        }

        if (healthbar.fillAmount <= 0)
            SceneManager.LoadScene("Cutscene_non_working_station");
        else if (electricCount > 0)
            healthbar.fillAmount -= electricCount / 180f * Time.deltaTime;
        else
            healthbar.fillAmount += 1/ 240f * Time.deltaTime;

        if (oxygenbar.fillAmount <= 0 && dangerCount > 0)
            SceneManager.LoadScene("Cutscene_deadly_gas");
        else if (oxygenbar.fillAmount <= 0)
            SceneManager.LoadScene("Cutscene_non_working_station");
        else if (fireCount > 0 || dangerCount > 0)
            oxygenbar.fillAmount -= (fireCount + dangerCount*0.75f) / 150f * Time.deltaTime;
        else
            oxygenbar.fillAmount += 1 / 70f * Time.deltaTime;

        if (dangerCount > 0)
            fuelbar.fillAmount -= 1 / 240f * Time.deltaTime;
    }

    void newProblems()
    {
        if (timeToProblem)
        {
            int start = Random.Range(0, 10);
            Debug.Log(timeToProblem);
            bool add = false;
            
            for (int i = start + 1; i != start && !add; i++)
            {
                if (i >= modules.Length)
                    i = -1;
                else if (modules[i].name == "Module M-01")
                    continue;
                else if (modules[i].activeSelf)
                {
                    int start2 = Random.Range(0, 2);
                    for (int j = start2 + 1; j != start2 && !add; j++)
                    {
                        if (j >= 3)
                            j = -1;
                        else if (j == 2 && !gasProb)
                            continue;
                        else if (!modules[i].transform.GetChild(j).gameObject.activeSelf)
                        {
                            add = true;
                            modules[i].transform.GetChild(j).gameObject.SetActive(true);
                        }
                    }
                }
            }

            timeProblem = Random.Range(15, 25);
            timeToProblem = false;
        }
        else
        {
            timer -= 1 / timeProblem * Time.deltaTime;
            if (timer <= 0)
            {
                timer = 1;
                timeToProblem = true;
            }
        }
    }

    void solutionOfProblems() 
    {
        int temp;
        foreach (var item in modules)
        {
            if (item.activeSelf && item.name != "Module M-01")
            {
                if(item.transform.GetChild(2).gameObject.activeSelf)
                {
                    for (int i = 0; i < people.Length; i++)
                    {
                        if (people[i].activeInHierarchy && people[i].GetComponent<SelectAndMove>().isChemist && !people[i].GetComponent<SelectAndMove>().move)
                        {
                            if (inModule(item,people[i]) && !people[i].GetComponent<SelectAndMove>().broken) 
                            {
                                temp = Random.Range(0, 101);
                                if (people[i].GetComponent<SelectAndMove>().chance >= temp)
                                    item.transform.GetChild(2).gameObject.SetActive(false);
                                else 
                                {
                                    people[i].GetComponent<SpriteRenderer>().sprite = people[i].GetComponent<SelectAndMove>().red;
                                    people[i].GetComponent<SelectAndMove>().broken = true; 
                                }
                            }
                        }
                    }
                }
                if (item.transform.GetChild(0).gameObject.activeSelf)
                {
                    for (int i = 0; i < people.Length; i++)
                    {
                        if (people[i].activeInHierarchy && !people[i].GetComponent<SelectAndMove>().move && !people[i].GetComponent<SelectAndMove>().isMedic)
                        {
                            if (inModule(item, people[i]) && !people[i].GetComponent<SelectAndMove>().broken)
                            {
                                temp = Random.Range(0, 101);
                                if (people[i].GetComponent<SelectAndMove>().chance >= temp)
                                    item.transform.GetChild(0).gameObject.SetActive(false);
                                else if (!people[i].GetComponent<SelectAndMove>().isMedic)
                                {
                                    people[i].GetComponent<SpriteRenderer>().sprite = people[i].GetComponent<SelectAndMove>().red;
                                    people[i].GetComponent<SelectAndMove>().broken = true;
                                }
                            }
                        }
                    }
                }
                if (item.transform.GetChild(1).gameObject.activeSelf)
                {
                    for (int i = 0; i < people.Length; i++)
                    {
                        if (people[i].activeInHierarchy && !people[i].GetComponent<SelectAndMove>().move && !people[i].GetComponent<SelectAndMove>().isMedic)
                        {
                            if (inModule(item, people[i]) && !people[i].GetComponent<SelectAndMove>().broken)
                            {
                                temp = Random.Range(0, 101);
                                if (people[i].GetComponent<SelectAndMove>().chance >= temp)
                                    item.transform.GetChild(1).gameObject.SetActive(false);
                                else if (!people[i].GetComponent<SelectAndMove>().isMedic)
                                {
                                    people[i].GetComponent<SpriteRenderer>().sprite = people[i].GetComponent<SelectAndMove>().red;
                                    people[i].GetComponent<SelectAndMove>().broken = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    bool inModule(GameObject modul, GameObject person)
    {
        if (person.transform.position.x < (modul.GetComponent<SpriteRenderer>().bounds.size.x / 2 + modul.transform.position.x))
            if (person.transform.position.x > (modul.transform.position.x - modul.GetComponent<SpriteRenderer>().bounds.size.x / 2))
                if (person.transform.position.y < (modul.GetComponent<SpriteRenderer>().bounds.size.y / 2 + modul.transform.position.y))
                    if (person.transform.position.y > (modul.transform.position.y - modul.GetComponent<SpriteRenderer>().bounds.size.y / 2))
                        return true;
        return false;
    }

    public void toMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
