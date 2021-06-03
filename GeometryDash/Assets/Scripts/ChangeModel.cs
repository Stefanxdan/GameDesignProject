using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImageName(string ImageName)
    {
        string path = "D:/Facultate/GD/GameDesignProject/GeometryDash/playerImageName.txt";
        // Debug.Log(path);
        if (!File.Exists(path))
        {
           // Debug.Log("Nu exista fisierul");
        }
        else
        {

           // Debug.Log("Suprascriu fisier cu: " + ImageName);
            File.WriteAllText(path, ImageName);
        }
    }
}
