using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] GameObject[] shapePrefab;

    private Touch touch;
    private GameObject shapeInt;

    void Start()
    {
        shapeInt = Instantiate(shapePrefab[], transform.position, Quaternion.identity) as GameObject;
        shapeInt.transform.parent = transform;
        shapeInt.tag = "Shape";
    }

    void Update()
    {
        
    }
}
