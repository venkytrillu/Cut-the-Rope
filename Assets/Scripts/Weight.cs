using UnityEngine;

public class Weight : MonoBehaviour
{

	public float distanceFromChainEnd, speedtoMove = 0.6f;
    Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void ConnectRopeEnd (Rigidbody2D endRB)
	{
		HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
		joint.autoConfigureConnectedAnchor = false;
		joint.connectedBody = endRB;
		joint.anchor = Vector2.zero;
		joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="RopeTrigger")
        {
            collision.transform.GetComponent<Rope>().enabled = true;
        }
        if (collision.tag == "Bubble")
        {
            anim= collision.transform.GetChild(0).GetComponent<Animator>();
            anim.SetTrigger("Collide");
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.transform.parent = collision.transform;
            gameObject.transform.localPosition = Vector3.zero;
            BubbleFly(collision.transform.gameObject);
        }

        if (collision.tag == "Bullet")
        {
            rb.velocity = new Vector2(speedtoMove, 0);
            Destroy(collision.transform.gameObject);
        }

        if (collision.tag == "Frog")
        {
            anim= collision.transform.GetComponent<Animator>();
            anim.SetTrigger("Eat");
            GameOver();

        }

        if (collision.tag == "Star")
        {
            UIController.instance.satrCount++;
            UIController.instance.EnableStarts(UIController.instance.satrCount);
            Destroy(collision.transform.gameObject);
        }

        if (collision.tag == "Finish")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        UIController.instance.GameOver();
        Destroy(gameObject.transform.parent.gameObject);
    }

    void BubbleFly(GameObject obj)
    {
        obj.AddComponent<Rigidbody2D>();
        obj.GetComponent<Rigidbody2D>().mass = 0f;
        obj.GetComponent<Rigidbody2D>().gravityScale = -0.1f;
    }


    public void RopeCut()
    {
        RopeCutter.instance.CutTheRope();
    }

}// class
