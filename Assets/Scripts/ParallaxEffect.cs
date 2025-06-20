using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] Transform cam; //Main Camera
    Vector3 camStartPos;
    public float distance;

    GameObject[] backgrounds;
    Material[] mat;
    float[] backSpeed;

    float farthestBack;

    [Range(0.1f, 2f)]
    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        camStartPos = cam.position;
        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }

        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++) //find the farthest background
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++) //set the speed of bacground
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    private void Update()
    {
        distance += Time.deltaTime * parallaxSpeed;

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i];
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance * speed, 0));
        }
    }
}