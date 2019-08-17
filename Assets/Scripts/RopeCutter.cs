using UnityEngine;

public class RopeCutter : MonoBehaviour
{

    public static RopeCutter instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update () {
		if (Input.GetMouseButton(0))
		{
            CutTheRope();
            print("down");
		}
	}

    public void CutTheRope()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.one);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Link")
            {
                Rope rope = hit.transform.GetComponentInParent<Rope>();
                rope.isCut = true;
                Destroy(hit.collider.gameObject);
            }
        }
    }



}// class

















