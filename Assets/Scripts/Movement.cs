using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] GameObject[] shapePrefab;
    [SerializeField] float speed = 2;
    [SerializeField] float sensitivity;

    private Touch touch;
    private GameObject shapeInt;
    private int randval;

    private PolygonCollider2D shape2dCol;

    void Start()
    {

        instanceShape();

    }

    void Update()
    {
        forwardMovement();
        sideWaysMovement();
    }

    void forwardMovement()
    {
        transform.Translate(0f, 0f, speed * Time.deltaTime);
    }
    void sideWaysMovement()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            float xSlide = Mathf.Clamp(transform.position.x + touch.deltaPosition.x * sensitivity, -0.8f, 0.8f);
            float ySlide = Mathf.Clamp(transform.position.y + touch.deltaPosition.y * sensitivity, -2.5f, 1.5f);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(xSlide, ySlide, transform.position.z);
                return;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                instanceShape();
            }
        }
    }

    public void instanceShape()
    {
        //randval = getNumber(randval);

        shapeInt = Instantiate(shapePrefab[0], transform.position, Quaternion.identity) as GameObject;
        shapeInt.transform.parent = transform;
        shapeInt.tag = "Shape";

        make2dto3dCol();
    }

    int getNumber(int n)
    {
        randval = Random.Range(0, shapePrefab.Length);

        while (n == randval)
        {
            randval = Random.Range(0, shapePrefab.Length);
        }

        return randval;
    }

    void make2dto3dCol()
    {
        shape2dCol = shapeInt.GetComponentInChildren<PolygonCollider2D>();

        shapeInt.GetComponent<MeshCollider>().sharedMesh = shape2dCol.CreateMesh(true, true);
    }

}
