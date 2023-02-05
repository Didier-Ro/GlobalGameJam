using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController2 : MonoBehaviour
{
    [SerializeField] private float cost = 800;

    void Update()
    {
        if (RoundManager.RoundInstance._roundLeft > 5)
        {
            if (GameManager.Instance.Player2Gold < cost)
            {
                gameObject.GetComponent<Button>().enabled = false;
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 125);
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = true;
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
        else
        {
            if (GameManager.Instance.Player1Gold < cost)
            {
                gameObject.GetComponent<Button>().enabled = false;
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 125);
            }
            else
            {
                gameObject.GetComponent<Button>().enabled = true;
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }
}
