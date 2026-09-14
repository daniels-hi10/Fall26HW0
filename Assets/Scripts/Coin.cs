using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetBumped()
    {
        float Xspawn = Random.Range(-6f, 6f);
        float Yspawn = Random.Range(-2.5f, 2.5f);
        gameObject.transform.position = new Vector3(Xspawn, Yspawn, 0f);
    }
}
