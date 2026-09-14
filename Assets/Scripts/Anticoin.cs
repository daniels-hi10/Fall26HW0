using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.VFX;

public class Anticoin : MonoBehaviour
{
    public float Timer;
    public int spawns;
    public GameObject anticoin;

    void Start()
    {
        Timer = 4f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetBumped()
    {
        float Xspawn = Random.Range(-6f, 6f);
        float Yspawn = Random.Range(-2.5f, 2.5f);
        gameObject.transform.position = new Vector3(Xspawn, Yspawn, 0f);
    }

    void Spawn()
    {
        float Xspawn = Random.Range(-6f, 6f);
        float Yspawn = Random.Range(-2.5f, 2.5f);
        Instantiate(anticoin, new Vector3(Xspawn, Yspawn, 0f), Quaternion.identity);
    }


    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0) 
        {
            Spawn();
            Timer = 4f;
        }
    }
}
