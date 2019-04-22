using UnityEngine;

public class Tiling : MonoBehaviour
{
    public int offsetX = 2;

    //To check if we have to instantiate objects 
    public bool hasARightBuddy = false;


    public float platformWidth = 0f; //the width of our element
    private Camera cam;
    private Transform myTransform;

    public Transform leftBound;
    public Transform rightBound;
    private void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }
    void Start()
    {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        //spriteWidth = sRenderer.sprite.bounds.size.x;
        platformWidth = rightBound.position.x - leftBound.position.x;
    }

    void Update()
    {
        //does it need buddies? If not do nothing
        if (hasARightBuddy == false)
        {
            //It will calculate the position of camera from center of the player
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            //calculate the x position where the camera can see the edge of the sprite(element)
            float edgeVisiblePositinOnRight = (myTransform.position.x + platformWidth / 2) - camHorizontalExtend;

            //Checking if we need new buddy
            if (cam.transform.position.x >= edgeVisiblePositinOnRight && hasARightBuddy == false)
            {
                MakeNewBuddy();
                hasARightBuddy = true;
            }
        }
    }

    void MakeNewBuddy()
    {
        //calculating the position of our new buddy
        Vector3 newPosition = new Vector3(myTransform.position.x + platformWidth, myTransform.position.y, myTransform.position.z);
        Transform newBuddy = Instantiate(myTransform, newPosition, myTransform.rotation) as Transform;
        newBuddy.parent = myTransform.parent;
    }
}
