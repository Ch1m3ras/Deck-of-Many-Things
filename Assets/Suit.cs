using UnityEngine;

public class Suit : MonoBehaviour
{
    private GameObject creator;
    private string suit;
    private bool isTop = false;

    public Sprite spadeSprite;
    public Sprite heartSprite;
    public Sprite diamondSprite;
    public Sprite clubSprite;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteStuff();
        // Debug.Log(suit);
    }

    // Update is called once per frame
    void Update()
    {
        if (creator.GetComponent<Card>().isHeld())
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

    public GameObject getCreator()
    {
        return creator;
    }
    public void setCreator(GameObject creatorInput)
    {
        creator = creatorInput;
    }
    
    public string getSuit()
    {
        return suit;
    }

    public void setSuit(string suitInput)
    {
        suit = suitInput;
    }

    public bool getIsTop()
    {
        return isTop;
    } 

    public void setIsTop(bool inputTop)
    {
        isTop = inputTop;
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
