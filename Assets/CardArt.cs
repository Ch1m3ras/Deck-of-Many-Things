using UnityEngine;

public class CardArt : MonoBehaviour
{
    //Basic Intialization Stuff
    private GameObject creator;
    private string suit;
    private string value;

    //Sprite Details Here
    public Sprite jokerNoColorSprite;
    public Sprite jokerColorSprite;
    public Sprite twoDiamondsSprite;
    public Sprite twoClubsSprite;
    public Sprite twoHeartsSprite;
    public Sprite twoSpadesSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteStuff();
        Debug.Log("From CardArt, this is a " + value + " of " + suit);
    }

    // Update is called once per frame
    void Update()
    {
        if (creator.GetComponent<Card>().isHeld())
        {
            Vector2 mouseVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseVector.x, mouseVector.y, -1);
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


    public string getValue()
    {
        return value;
    }

    public void setValue(string newValue)
    {
        value = newValue;
    }

    public string getSuit()
    {
        return suit;
    }

    public void setSuit(string suitInput)
    {
        suit = suitInput;
    }

    public void spriteStuff()
    {
        if (value.Equals("2"))
        {
            if (suit.Equals("Diamonds"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = twoDiamondsSprite;
            }
            else if (suit.Equals("Clubs"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = twoClubsSprite;
            }
            else if (suit.Equals("Hearts"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = twoHeartsSprite;
            }
            else if (suit.Equals("Spades"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = twoSpadesSprite;
            }
        }
    }
}
