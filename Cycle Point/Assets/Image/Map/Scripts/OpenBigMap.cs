using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenBigMap : MonoBehaviour
{
	[SerializeField]
	//GameObject map;
	//GameObject map2;
	public GameObject MainEnd;
	public GameObject[] ArrayOfGameObjectsICareAbout;
    // Start is called before the first frame update

	/*private void Awake()
	{
		ArrayOfGameObjectsICareAbout = new GameObject[2];
     	ArrayOfGameObjectsICareAbout[0] = GameObject.Find("Image");
		ArrayOfGameObjectsICareAbout[1] = GameObject.Find("MapTexture");
	}*/

    void Start()
    {
        //map = GameObject.Find("Image");
		//map2 = GameObject.Find("MapTexture");
		ArrayOfGameObjectsICareAbout = new GameObject[3];
     	ArrayOfGameObjectsICareAbout[0] = GameObject.Find("Image");
		ArrayOfGameObjectsICareAbout[1] = GameObject.Find("MapTexture");
		ArrayOfGameObjectsICareAbout[2] = GameObject.Find("hot_keys_for_radar");
		ArrayOfGameObjectsICareAbout[0].SetActive(false);
		ArrayOfGameObjectsICareAbout[1].SetActive(false);
		ArrayOfGameObjectsICareAbout[2].SetActive(false);
		
		MainEnd = GameObject.Find("Main End");
		MainEnd.SetActive(false);
	}

    // Update is called once per frame
	//UnityEngine.UI.MaskableGraphic map = GetComponent<UnityEngine.UI.Image>();
	//[SerializeField]
	//GameObject map = GameObject.Find("Image");
	//GameObject map2 = GameObject.Find("MapTexture");
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
			Debug.Log("click");
			Debug.Log(ArrayOfGameObjectsICareAbout.Length);
			if(ArrayOfGameObjectsICareAbout[0].activeSelf == true) 
			{
				Debug.Log("true");
				//map.enabled = false;
				ArrayOfGameObjectsICareAbout[0].SetActive(false);
				ArrayOfGameObjectsICareAbout[1].SetActive(false);
				ArrayOfGameObjectsICareAbout[2].SetActive(false);
			}
			else
			{
				Debug.Log("false");
				ArrayOfGameObjectsICareAbout[0].SetActive(true);
				//map.enabled = true;
				ArrayOfGameObjectsICareAbout[1].SetActive(true);
				ArrayOfGameObjectsICareAbout[2].SetActive(true);
			}
		}
        /*if (Input.GetKeyDown(KeyCode.E))
        {
	        SceneManager.LoadScene("MiniGame", LoadSceneMode.Additive);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
	        SceneManager.UnloadSceneAsync ("MiniGame");
        }*/
    }

	public void mainEnd()
    {
		SceneManager.LoadScene("Cutscene_main_ending");
    }
}
