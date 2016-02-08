using UnityEngine;
using System.Collections;

public class SpBarController : MonoBehaviour {


    public GameObject healthBar;
    public float curSp;
    public float maxSP = 10;
    public float miinSp;
    public float chargeTime;

    // Use this for initialization
    void Start () {

        curSp = maxSP;
	
	}
	
	// Update is called once per frame
	

    public void decreseBar() {

        curSp -= 5;

        float calSpBar = curSp / maxSP;

        seSpbar(calSpBar);


    }

    public void increseBar() {

        curSp += 2;

        float calSpBar = curSp / maxSP;

        seSpbar(calSpBar);

    }

    public void seSpbar(float a)
    {

        healthBar.transform.localScale = new Vector3(a, transform.localScale.y, transform.localScale.z);



    }

    void Update()
    {

        if (curSp < maxSP)
        {

            chargeTime += Time.deltaTime;

        }

        if (chargeTime == 3)
        {

            increseBar();

            chargeTime = 0;

        }






    }

}
