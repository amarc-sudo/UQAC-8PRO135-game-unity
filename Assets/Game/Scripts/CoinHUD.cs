using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = "Remaining Coin : " + GameObject.FindGameObjectsWithTag("Coin").Length.ToString();;
    }
}
