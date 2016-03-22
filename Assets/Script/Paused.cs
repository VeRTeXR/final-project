using UnityEngine;
using System.Collections;

public class Paused : MonoBehaviour {

    public static bool CanPause = false;

   // GameObject[] pauseObjects;

    private GameObject pausedCanvas;
    //public GameObject pausedImage;
    // Use this for initialization
    void Start()
    {
		inSession ();
    }

	void inSession () {
		CanPause = true;
		pausedCanvas = GameObject.Find("PausedCanvas");
		pausedCanvas.SetActive(true);
		//pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		//Invoke("hidePaused",0);
		hidePaused ();
	}

	void OnLevelWasLoaded () {
		inSession ();
		hidePaused ();
	}
   

    void Update()
    {
             if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CanPause)
            {
                pausedCanvas.SetActive(true);
                Debug.Log("pause");
                Time.timeScale = 0;
                CanPause = false;
                // showPaused();
                
            }
            else
            {
                Time.timeScale = 1;
                CanPause = true;
                //hidePaused();
                pausedCanvas.SetActive(false);
                //pausedImage.SetActive(false);
            }
        }
    }

   /* void HideLevelImage()
    {
        //pausedImage.SetActive(false);
       
    }*/

    /*public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }*/


    public void hidePaused()
    {
        pausedCanvas.SetActive(false);
    }

}
