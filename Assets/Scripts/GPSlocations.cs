using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSlocations : MonoBehaviour {

    public static GPSlocations currentGPS { set; get; }

    float longitude;
    float latitude;

    public float[] latRange = { 55.86368f, 55.86368f };
    public float[] longRange = { -4.218225f, -4.218180f };
    
    public Text longT;
    public Text latT;
    public GameObject CarButton;

    public GameObject carModel;

    // Use this for initialization
    void Start () {
        //InvokeRepeating("GPS", 0f, 8f);
	}

    void GPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS not enabled");
        }
        else
        {
            Input.location.Start();

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determine device location");
            }
            else
            {
                longitude = Input.location.lastData.longitude;
                latitude = Input.location.lastData.latitude;
            }
        }
        currentGPS = this;
    }

    public void GetGPS()
    {
        GPS();
    }

    public void CreateCar()
    {
        Destroy(GameObject.FindGameObjectWithTag("Car"));
        GameObject car = Instantiate(carModel);
    }

    IEnumerator FindLocation()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("GPS not enabled");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait <= 0)
        {
            Debug.Log("Timed Out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        longitude = Input.location.lastData.longitude;
        latitude = Input.location.lastData.latitude;
    }
	
	// Update is called once per frame
	void Update () {
        latT.text = "Latitude: " + latitude.ToString();
        longT.text = "Longitude: " + longitude.ToString();

        if(longitude  < longRange[0] || longitude > longRange[1])
        {
            //CarButton.SetActive(false);
        }
        else
        {
            CarButton.SetActive(true);
        }
	}
}
