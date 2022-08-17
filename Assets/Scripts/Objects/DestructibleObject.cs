using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int points = 10;
    
    // This method is called when the object is interacted with
    public void OnPointerClick()
    {
        Score.Instance.AddScore(this.points);   // Add points to score
        this.gameObject.SetActive(false);   // Disable the object
    }
}
