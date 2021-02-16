using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dynamite : MonoBehaviour
{

    public GameObject dynamite;
    public GameObject explosion;

    float explodeTimer = 3f;
    float explodeStartSize = 0.01f;
    float explodeEndSize = 5f;
    float explodeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        dynamite = this.gameObject;
        Explosion(0f);
    }

    private void Explosion(float timer)
    {
        timer += Time.deltaTime;
        if(timer >= explodeTimer)
        {
            Instantiate(explosion, dynamite.transform);
            timer = 0f;
            Destroy(gameObject);
        }

    }
}
