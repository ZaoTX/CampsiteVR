using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System;

public class csvReader : MonoBehaviour
{
    public List<Campsite> Campsites { get; set; } = new List<Campsite>();
    private List<string> stringList;
    //public int[] highresolutionList;
    //public string path = "C:\\Users\\ZiyaoHe\\Documents\\BirdImmersive\\white storks\\Blacky\\Blacky.csv";
    // Start is called before the first frame update
    string data_name = "data";
    void Start()
    {

        ReadCSVFile();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void ReadCSVFile()
    {
        //from Resources folder load data
        TextAsset Campsite_data = Resources.Load<TextAsset>(data_name);
        //string[] data = Campsite_data.text.Split(new string[] { "!!!!"+'"'},StringSplitOptions.RemoveEmptyEntries);//split for each line…...
        string[] data = Campsite_data.text.Split(new char[] { '\n' });
        TextAsset excerpt_data = Resources.Load<TextAsset>("excerpt");
        string[] excerpt = excerpt_data.text.Split(new string[] { "!!!!"+'"'}, StringSplitOptions.RemoveEmptyEntries);//split for each line…...
        /*StreamReader inp_stm = new StreamReader("Assets/Resorces/data.csv");
        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();

            stringList.Add(inp_ln);
        }

        inp_stm.Close();

        parseList();*/
        Debug.Log(excerpt[2]);
        for (int i = 0; i < data.Length - 1; i++)//when there is no header i=0
        {
            Campsite campsite = new Campsite();
            string[] row = data[i].Split(new char[] { ',' }, 4);
            //string[] row = stringList[i].Split(new char[] { ',' });
            campsite.lat = row[0];
            campsite.lng = row[1];
            float.TryParse(row[2], out campsite.rating);
            Campsites.Add(campsite);
            //Debug.Log('1');

        }
        for (int i = 0; i < excerpt.Length - 1; i++)//when there is no header i=0
        {
            Campsite campsite = Campsites[i];
            campsite.excerpt = excerpt[i];
            //Debug.Log(campsite.excerpt);

        }
    }
    void parseList() {
       /* for (int i = 0; i < stringList.Count - 1; i++)//when there is no header i=0
        {
            Campsite campsite = new Campsite();
            string[] row = stringList[i].Split(new char[] { ';' });
            campsite.lat = row[0];
            campsite.lng = row[1];
            float.TryParse(row[2], out campsite.rating);
            campsite.excerpt = row[3];
            Campsites.Add(campsite);
        }*/
    }
}
