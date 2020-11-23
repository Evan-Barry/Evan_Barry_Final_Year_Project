using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGeneratorPrototype : MonoBehaviour {
    public GameObject wallModel;
    public GameObject doorModel;
    public GameObject windowModel;

    public float wallHeightMin = 0.00f;
    public float wallHeighMax = 0.00f;
    public float wallWidthMin = 0.00f;
    public float wallWidthMax = 0.00f;

    /*public float doorHeightMin = 0.00f;
    public float doorHeighMax = 0.00f;
    public float doorWidthMin = 0.00f;
    public float doorWidthMax = 0.00f;

    public float windowHeightMin = 0.00f;
    public float windowHeighMax = 0.00f;
    public float windowWidthMin = 0.00f;
    public float windowWidthMax = 0.00f;*/

    // Use this for initialization
    void Start () {
        /*for(int i = 1; i <= 20; i++)
        {
            CreateWall(new Vector3(Random.Range(wallWidthMin, wallWidthMax), Random.Range(wallHeightMin, wallHeighMax), 0.1f), new Vector3(0, 0, i*2), ("Generated Wall " + i));
        }*/
        CreateRoom(new Vector3(0,0,0) , "Room 1");
    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public GameObject CreateWall(Vector3 size, Vector3 position, Vector3 rotation, string name)
    {
        GameObject wall = Instantiate(wallModel, new Vector3(0, 0, 0), Quaternion.Euler(rotation.x, rotation.y, rotation.z));
        wall.name = name;
        wall.transform.localScale = size;
        wall.transform.position = position;

        return wall;
    }

    public GameObject CreateDoor(Vector3 size, Vector3 position, string name)
    {
        GameObject door = Instantiate(doorModel, new Vector3(0, 0, 0), Quaternion.identity);
        door.name = name;
        door.transform.localScale = size;
        door.transform.position = position;

        return door;
    }

    public GameObject CreateWindow(Vector3 size, Vector3 position, string name)
    {
        GameObject window = Instantiate(windowModel, new Vector3(0, 0, 0), Quaternion.identity);
        window.name = name;
        window.transform.localScale = size;
        window.transform.position = position;

        return window;
    }

    public void CreateRoom(Vector3 position, string name)
    {
        float ww = Mathf.Round(Random.Range(wallWidthMin, wallWidthMax));
        float wh = Mathf.Round(Random.Range(wallHeightMin, wallHeighMax));

        GameObject[] room = new GameObject[9];


        room[0] = CreateWall(new Vector3(ww, wh, 0.1f), new Vector3(0, 0, 0), new Vector3(0, 0, 0), ("Generated Wall 1"));
        room[1] = CreateWall(new Vector3(ww, wh, 0.1f), new Vector3((ww / 2) - 0.05f, 0, ww / 2), new Vector3(0, 90, 0), ("Generated Wall 2"));
        room[2] = CreateWall(new Vector3(ww, wh, 0.1f), new Vector3((-ww / 2) + 0.05f, 0, ww / 2), new Vector3(0, 90, 0), ("Generated Wall 3"));
        room[3] = CreateWall(new Vector3(ww, wh, 0.1f), new Vector3(0, 0, ww), new Vector3(0, 0, 0), ("Generated Wall 4"));
        room[4] = CreateDoor(new Vector3(1 , wh * 0.75f, 0.11f), new Vector3(0, -wh * 0.125f, 0), "Entrance Door");
        room[5] = CreateWindow(new Vector3(wh * 0.35f, wh * 0.35f, 0.12f), new Vector3(Random.Range(((-ww / 2) + 0.05f) + (wh * 0.35f), ((ww / 2) - 0.05f) - (wh * 0.35f)), Random.Range(0 + (wh * 0.35f), (wh / 2) - (wh * 0.35f)), 0), "Window 1");
        print((wh/2) - (wh * 0.35f));
    }



}
