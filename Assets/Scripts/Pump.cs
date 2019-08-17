using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pump : MonoBehaviour
{
    private Animator anim;
    public GameObject bulletPrefab;
    public GameObject bulletPos;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Pumpanim();
        }
    }
   public void Pumpanim()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.one);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Pump")
            {
              anim=  hit.transform.gameObject.GetComponent<Animator>();
                SetAnim("Pump");
            }
        }
    }

    void SetAnim(string action)
    {
        anim.SetTrigger(action);
    }


    public void SpawnBullet()
    {
      GameObject bullet=  Instantiate(bulletPrefab, bulletPos.transform.position, Quaternion.identity);

        Destroy(bullet, 10f);
    }
}
