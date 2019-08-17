using UnityEngine;

public class Rope : MonoBehaviour {

	public Rigidbody2D hook;

	public GameObject linkPrefab;

	public Weight weigth;

	public int links = 7;
    GameObject link;
    LineRenderer lr;
    Color color;
    float t = 1;
    [HideInInspector]
    public bool isCut;
    void Start () {

        lr = GetComponent<LineRenderer>();
		GenerateRope();
    }

    private void Update()
    {

        if (weigth)
        Linerender();
        if (isCut)
            FadeTheRope();
    }

    void GenerateRope ()
	{
		Rigidbody2D previousRB = hook;
		for (int i = 0; i < links; i++)
		{
			 link = Instantiate(linkPrefab, transform);
			HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
			joint.connectedBody = previousRB;
            
            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                weigth.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
               
            }
            link.transform.parent= transform.GetChild(0).transform;

        }
    }


    void Linerender()
    {
        lr.SetPosition(0, gameObject.transform.localPosition);
        lr.SetPosition(1, weigth.transform.localPosition);
    }


    void FadeTheRope()
    {
        t = t - Time.deltaTime;
        //  Material mat = lr.material;

        lr.startColor = ColorFade();
        lr.endColor = ColorFade();
        if (lr.startColor.a < 0.1f && lr.endColor.a<0.1f)
        {
            if (transform.GetChild(0).gameObject.transform.childCount>0)
            {
                Destroy(transform.GetChild(0).gameObject);
                transform.GetComponent<LineRenderer>().enabled = false;
                transform.GetComponent<Rope>().enabled = false;
            }

        }

      
      //  mat.color= ColorFade();
        // mat.SetColor("_TintColor", color1);



    }

    Color ColorFade()
    {
        if (t > 0)
        {
            color = new Color(1, 1, 1, Mathf.Clamp(t, 0, 1));
            //print(color + " " + t);
        }
        return color;
    }

}// class
