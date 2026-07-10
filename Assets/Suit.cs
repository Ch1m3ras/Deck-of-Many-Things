using UnityEngine;

public class Suit : MonoBehaviour
{
    public GameObject creator;
    public string suit;
    public bool isTop = false;

    public Sprite spadeSprite;
    public Sprite heartSprite;
    public Sprite diamondSprite;
    public Sprite clubSprite;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        suit = creator.GetComponent<Card>().cardSuit;
        spriteStuff();
        // Debug.Log(suit);
    }

    // Update is called once per frame
    void Update()
    {
        if (creator.GetComponent<Card>().beingHeld)
        {
            Vector2 mouseVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (isTop)
            {
                transform.position = new Vector3(mouseVector.x - (float)1.7, mouseVector.y + (float)1.67, -1);
            }
            else
            {
                transform.position = new Vector3(mouseVector.x + (float)1.7, mouseVector.y - (float)1.67, -1);
            }
        }
    }

    void spriteStuff()
    {
        //Suit Rendering
        if (suit.Equals("Spades"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spadeSprite;
        }
        else if (suit.Equals("Clubs"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = clubSprite;
        }
        else if (suit.Equals("Hearts"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = heartSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = diamondSprite;
        }


        //Top and Bottom Rendering
        if (!isTop)
        {
            transform.localScale = new Vector3(-transform.localScale.x, -1 * transform.localScale.y, transform.localScale.z);
        }

    }

}
