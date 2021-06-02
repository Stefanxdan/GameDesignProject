using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeModel : MonoBehaviour
{
    public Sprite Image1;
    public Sprite Image2;
    public GameObject findPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCharacter(string ImageName)
    {
        if (ImageName == "player")
            findPlayer.GetComponent<SpriteRenderer>().sprite = Image1;
        else
            findPlayer.GetComponent<SpriteRenderer>().sprite = Image2;
    }
}
