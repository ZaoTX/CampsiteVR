using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Examples;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
//Campsite
public class Processor : MonoBehaviour
{
    public SpawnOnMap MySpawnMap;
    public AbstractMap map;
    // A Timer from changeView method
    private float timer = 0.0f;

    public float campScale = 10f;
    public float pointScale = 5f;
    //read data from 
    private csvReader reader;
    //count how many time the code ist aufgurufen.
    private int num = 0;
    //initialize 2 list contain the lat lng information
    private List<string> locations = new List<string>();
    private List<float> ratings= new List<float>();
    private List<string> excerpts = new List<string>();
    public bool mode;//1 for overview 0 for vr
    Vector3 PlayerPos;

    //view of physical location = string(mean(lat))+string(mean(lng))=string(latsum/size_of_List)+string(lngsum/size_of_List)
    //second idea is to initialize the view with the first data point position
    //1.
    private string initial_pos;
    //1.private float latsum = 0f;
    //1.private float lngsum = 0f;
    //1.private int size_of_List;

    void Start()
    {
        reader = gameObject.GetComponent(typeof(csvReader)) as csvReader;
        loadData();
    }
    // Update is called once per frame
    void Update()
    {
       // timer += Time.deltaTime;
       // PlayerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //GameObject.FindGameObjectWithTag("Player").transform.position=new Vector3 (PlayerPos.x,10,PlayerPos.z);
        /*//update every 6 seconds
        if (timer > 6)
        {
            changeViewPos();
            timer = 0f;
        }*/

        rescale();
    }
    void loadData()
    {
        //int count = 0;
        foreach (Campsite campsite in reader.Campsites)
        {
            string cp_lat = campsite.lat;
            string cp_lng = campsite.lng;
            float cp_rating = campsite.rating;
            string cp_excerpt = campsite.excerpt;

            //Debug.Log(cp_excerpt);
            //if (count == 0)
            //{
            //    count++;
            //    initial_pos = id_lat + ',' + id_lng;
            //}

            ratings.Add(cp_rating);
            if (cp_rating >=5) {

                locations.Add(cp_lat + ',' + cp_lng);

                excerpts.Add(cp_excerpt);
            }
            //Debug.Log(id_lat + ',' + id_lng);
        }

        string[] loc_array = locations.ToArray();
        string[] exc_array = excerpts.ToArray();
        //Debug.Log(locations);
        //float[] ratings_array = ratings.ToArray();
        MySpawnMap._locationStrings = loc_array;
        MySpawnMap._excerptStrings = exc_array;




    }
    void rescale()
    {
        //user can rescale the bird and point
        if (MySpawnMap != null)
        {
            MySpawnMap.SpawnScale = campScale;
            //MySpawnMap.Point_SpawnScale = pointScale;
        }
    }
    // Through this method I want the map updates automatically when the view is changed
    void changeViewPos() {

        var OldLatLon = Conversions.StringToLatLon(map._options.locationOptions.latitudeLongitude);
        
        //Debug.Log(PlayerPos);
        //PlayerPos = new Vector3(PlayerPos.x, 0, PlayerPos.z);

        var newMapPos = map.WorldToGeoPosition(PlayerPos);
        //Debug.Log(newMapPos);
        //PlayerPos = new Vector3(PlayerPos.x+20, 10, PlayerPos.z);

        //newMapPos = map.WorldToGeoPosition(PlayerPos);
        //Debug.Log(newMapPos);
        //Debug.Log(LatLon.GetType());
        if (OldLatLon != newMapPos)
        {
            map.UpdateMap(newMapPos, map.Zoom);
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, 10, 0);
        }


    }
    
}