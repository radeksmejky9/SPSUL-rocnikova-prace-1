using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject EdgeColliderPrefab;
    public List<GameObject> BottomColliders = new List<GameObject>();
    public List<GameObject> FrontColliders = new List<GameObject>();
    public BoxCollider box;

    public Animator animator;
    public bool RunRight;
    public bool RunLeft;
    public bool Jump;

    private Rigidbody rigid;
    public Rigidbody RIGID_BODY
    {
        get
        {
            if (rigid == null)
            {
                rigid = GetComponent<Rigidbody>();
            }
            return rigid;
        }
    }

    private void Awake()
    {
        float front = box.bounds.center.z + box.bounds.extents.z;
        float back = box.bounds.center.z - box.bounds.extents.z;
        float top = box.bounds.center.y + box.bounds.extents.y;
        float bottom = box.bounds.center.y - box.bounds.extents.y;

        GameObject bottomFront = CreateEdgeCollider(new Vector3(box.bounds.center.x, bottom, front));
        GameObject bottomBack = CreateEdgeCollider(new Vector3(box.bounds.center.x, bottom, back));
        GameObject topFront = CreateEdgeCollider(new Vector3(box.bounds.center.x, top, front));


        bottomFront.transform.parent = this.transform;
        bottomBack.transform.parent = this.transform;
        topFront.transform.parent = this.transform;


        BottomColliders.Add(bottomFront);
        BottomColliders.Add(bottomBack);

        float sectionBottom = (bottomFront.transform.position - bottomBack.transform.position).magnitude / 15f;

        for (int i = 0; i < 14; i++)
        {
            Vector3 pos = bottomBack.transform.position + (Vector3.forward * sectionBottom * (i + 1));
            GameObject obj = CreateEdgeCollider(pos);
            obj.transform.parent = this.transform;
            BottomColliders.Add(obj);
        }








        FrontColliders.Add(topFront);

        float sectionFront = (topFront.transform.position - bottomFront.transform.position).magnitude / 50f;

        for (int i = 3; i < 40; i++)
        {
            Vector3 pos = bottomFront.transform.position + (Vector3.up * sectionFront * (i + 1));
            GameObject obj = CreateEdgeCollider(pos);
            obj.transform.parent = this.transform;
            FrontColliders.Add(obj);
        }


    }

    public GameObject CreateEdgeCollider(Vector3 pos)
    {
        GameObject obj = Instantiate(EdgeColliderPrefab, pos, Quaternion.identity);
        return obj;
    }
}
