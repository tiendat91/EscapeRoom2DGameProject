using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public string tagTarget = "Player";
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    public Collider2D col;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            detectedObjs.Add(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tagTarget)
        {
            detectedObjs.Remove(collision);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
