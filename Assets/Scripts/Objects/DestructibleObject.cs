using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public int points = 10;
    public float soundTimeout = 0.35f;
    public AudioClip destructionSound;
    private AudioSource audioSource;
    private bool objectToBeDisabled = false;    // Flag to allow the balloons not to be popped twice

    void Awake()
    {
        this.audioSource = GetComponent<AudioSource>();
    }

    // This method is called when the object is interacted with
    public void OnPointerClick()
    {
        if (!this.objectToBeDisabled)
        {
            this.objectToBeDisabled = true;
            Score.Instance.AddScore(this.points);   // Add points to score
            StartCoroutine(this.DisableObject());   // Need to wait until sound is over to disable
            if (this.audioSource != null && this.destructionSound != null)
            {
                this.audioSource.PlayOneShot(this.destructionSound, 1f);
            }
        }
    }

    private IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(this.soundTimeout);
        this.objectToBeDisabled = false;
        this.gameObject.SetActive(false);   // Disable the object
    }
}
