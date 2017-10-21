using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useItem : MonoBehaviour {
    public GameObject bunShield;
    public GameObject kcanon;
    player p;
    CircleCollider2D c;
    LineRenderer lr;
    Vector3 lrDir;
    Quaternion lrRot;
    public Material red;
	// Use this for initialization
	void Start () {
        p = GetComponent<player>();
        lr = gameObject.AddComponent<LineRenderer>();
        lr.enabled = false;
    }
	void useItemPlz()
    {
        //check the top of the list
        //you get a power based on whats there
        if (p.heldItems.Count != 0)
        {
			bool used_item = false;
            if (p.heldItems[p.heldItems.Count-1].id==0|| p.heldItems[p.heldItems.Count - 1].id == 6)
            {
                //debug
                GameObject cloneBun = Instantiate(bunShield);
                cloneBun.transform.position = transform.position;
                cloneBun.transform.SetParent(p.ren.transform);
				used_item = true;
            }else if (p.heldItems[p.heldItems.Count - 1].id == 5)
            {
                //debug
                GameObject cloneCanon = Instantiate(kcanon);
				cloneCanon.GetComponent<eventCanon> ().myPlayer = this.gameObject;
                cloneCanon.transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
                cloneCanon.transform.Rotate(new Vector3(0, 0, -90));
                cloneCanon.transform.position = transform.position;
                cloneCanon.transform.localScale = new Vector3(30, 10, 0);
				cloneCanon.transform.SetParent(p.ren.transform);
				used_item = true;
            }else if (p.heldItems[p.heldItems.Count - 1].id == 1|| p.heldItems[p.heldItems.Count - 1].id == 4)
            {
                //bun abil
                //transform.parent.transform.localScale = new Vector3(20f,20f,1);
            }
			if (used_item) {
				p.heldItems.RemoveAt (p.heldItems.Count - 1);
			}
        }
    }
    bool use;
    public IEnumerator fatty()
    {
        yield return new WaitForSeconds(2f);
        transform.localScale = new Vector3(8, 8, 8);
        p.ren.transform.localScale = new Vector3(8, 8, 8);

    }
    public IEnumerator kcanonEnum()
    {
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<LineRenderer>().enabled = false;
        GameObject cloneCanon = Instantiate(kcanon);
        cloneCanon.GetComponent<eventCanon>().myPlayer = this.gameObject;
        cloneCanon.transform.rotation = new Quaternion(0, 0, lrRot.z, lrRot.w);
        cloneCanon.transform.Rotate(new Vector3(0, 0, -90));
        cloneCanon.transform.position = transform.position;
        cloneCanon.transform.localScale = new Vector3(50, 10, 0);
        cloneCanon.transform.SetParent(p.ren.transform);
    }
    // Update is called once per frame
    public static bool timeStop=false;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeStop == true)
            {
                timeStop = false;
            }else if (timeStop == false)
            {
                timeStop = true;
            }
        }
        if (Input.GetButtonDown("A" + p.id)&&timeStop!=true)
        {
            Debug.Log(p.id);
            //useItemPlz();
            //bun shield
            int ind = 0;
            for(int i = 0; i < p.heldItems.Count; i++)
            {
                //go through entire list
                if (p.heldItems[i].id == 0 || p.heldItems[i].id == 6)
                {
                    //you got some buns to use
                    use = true;
                    ind = i;
                }
            }
            if (use)
            {
                GetComponent<player>().isBunShielding = true;
                GameObject cloneBun = Instantiate(bunShield);
                cloneBun.GetComponent<killBun>().myPlayer = this.gameObject;
                cloneBun.transform.position = transform.position;
                cloneBun.transform.SetParent(p.ren.transform);
                p.heldItems.RemoveAt(ind);
                use = false;
            }

        }
        if (Input.GetButtonDown("Right_Button" + p.id)&&GetComponent<player>().formEnabled== false&&timeStop != true)
        {
            Debug.Log(p.id);

            //useItemPlz()
            //bun shield
            int ind = 0;
            for (int i = 0; i < p.heldItems.Count; i++)
            {
                //go through entire list
                if (p.heldItems[i].id == 5)
                {
                    //you got some buns to use
                    use = true;
                    ind = i;
                }
            }
            if (use)
            {
                //laser logic
                float width = 0.1f;
                lr.enabled = true;
                lrDir = -transform.up;
                lrRot = transform.rotation;
                lr.material = red;
                lr.startWidth = width;
                lr.endWidth = width;
                lr.sortingOrder = 55;
                StartCoroutine(kcanonEnum());
                p.heldItems.RemoveAt(ind);
                use = false;
            }

        }
        else if(Input.GetButtonDown("Right_Button" + p.id) && GetComponent<player>().formEnabled == true && GetComponent<player>().spriteIndex == 2)
        {

            Debug.Log("this is being held");
            if (timeStop == false)
            {
                //stop time

                timeStop = true;

            }
            else if (timeStop == true)
            {
                //reinstate time
                timeStop = false;
                Debug.Log("TIME STOP OVER");
                //make the form disapear after the power is used
            }
            //stop time

        }
        float line_len = 50;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position + lrDir*line_len);
        if (Input.GetButtonDown("X" + p.id)&&timeStop != true)
        {
            Debug.Log(p.id);
            //useItemPlz();
            //bun shield
            int ind = 0;
            for (int i = 0; i < p.heldItems.Count; i++)
            {
                //go through entire list
                if (p.heldItems[i].id == 1|| p.heldItems[i].id == 4)
                {
                    //you got some buns to use
                    use = true;
                    ind = i;
                }
            }
            if (use)
            {
                //patty logic
                //expand
                transform.localScale = new Vector3(20, 20, 20);
                p.ren.transform.localScale = new Vector3(20,20,20);
                //p.blowBack = true;
                StartCoroutine(fatty());
                p.heldItems.RemoveAt(ind);
                use = false;
            }
        }
    }
}
