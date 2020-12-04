namespace Mapbox.Examples
{
    using UnityEngine.UI;
    using UnityEngine;
    using Mapbox.Utils;
    using Mapbox.Unity.Map;
    using Mapbox.Unity.MeshGeneration.Factories;
    using Mapbox.Unity.Utilities;
    using System.Collections.Generic;

    public class SpawnOnMap : MonoBehaviour
    {
        [SerializeField]
        AbstractMap _map;

        [SerializeField]
        [Geocode]
        public string[] _locationStrings;
        public string[] _excerptStrings;
        Vector2d[] _locations;


        public float SpawnScale;

        [SerializeField]
        GameObject _markerPrefab;

        List<GameObject> _spawnedObjects;
        GameObject canvasPrefab;

        void Start()
        {
            float Zoom = _map.Zoom;

            //Debug.Log("Yes");
            _locations = new Vector2d[_locationStrings.Length];
            _spawnedObjects = new List<GameObject>();
            for (int i = 0; i < _locationStrings.Length; i++)
            {

                //canvasPrefab = Resources.Load("Label") as GameObject;
                var locationString = _locationStrings[i];
                //Debug.Log(locationString);
                _locations[i] = Conversions.StringToLatLon(locationString);
                var instance = Instantiate(_markerPrefab);
                instance.transform.localPosition = _map.GeoToWorldPosition(_locations[i], false);
                instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, 0, instance.transform.localPosition.z);
                instance.transform.localScale = new Vector3(SpawnScale, SpawnScale, SpawnScale);
                //System.Type MyScriptType = System.Type.GetType("mo_function" + ",Assembly-CSharp");//attach the mouse over function for icons
                
                _spawnedObjects.Add(instance);
                //instance.transform.GetChild(0).gameObject.AddComponent(MyScriptType);
                GameObject myGO;
                GameObject myText;
                Canvas myCanvas;
                Text text;
                RectTransform rectTransform;
                // Canvas
                myGO = new GameObject();
                myGO.name = "Canvas";
                myGO.AddComponent<Canvas>();
                
               

                myCanvas = myGO.GetComponent<Canvas>();
                myCanvas.renderMode = RenderMode.ScreenSpaceCamera;
                myGO.AddComponent<CanvasScaler>();
                myGO.AddComponent<GraphicRaycaster>();
                myGO.transform.parent = instance.transform;
                // Text
                myText = new GameObject();
                myText.transform.parent = myGO.transform;
                myText.name = "Text";

                text = myText.AddComponent<Text>();
                //text.font = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                text.font = Resources.Load<Font>("ThaleahFat");
                text.text = _excerptStrings[i];
                text.fontSize = 10;
                text.color = Color.black;
                text.enabled = false;

                // Text position
                rectTransform = text.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(instance.transform.localPosition.x, 10, instance.transform.localPosition.z);
                rectTransform.sizeDelta = new Vector2(20, 20);
            }


        }

        private void Update()
        {
            float Zoom = _map.Zoom;

            //Debug.Log("Yes");
            int count = _spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = _spawnedObjects[i];
                var location = _locations[i];
                spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, false);
                spawnedObject.transform.localPosition = new Vector3(spawnedObject.transform.localPosition.x, 0, spawnedObject.transform.localPosition.z);
                spawnedObject.transform.localScale = new Vector3(SpawnScale, SpawnScale, SpawnScale);
            }


        }

    }
}