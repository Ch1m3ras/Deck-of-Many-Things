using UnityEngine;

public class Card : MonoBehaviour
{
    private bool beingHeld;
    private double width;
    private double height;
    private float xLocation;
    private float yLocation;
    public Sprite newSprite;
    public string cardValue;
    public string cardSuit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardInitialization();
        width = 250 * 2.3;
        height = 350 * 2.3;
        xLocation = Camera.main.WorldToScreenPoint(transform.localPosition).x;
        yLocation = Camera.main.WorldToScreenPoint(transform.localPosition).y;
        beingHeld = true;
    }

    // Update is called once per frame
    void Update()
    {
        xLocation = Camera.main.WorldToScreenPoint(transform.localPosition).x;
        yLocation = Camera.main.WorldToScreenPoint(transform.localPosition).y;

        if (Input.GetMouseButtonUp(0) & beingHeld)
        {
            //Debug.Log("Card is put down!");
            beingHeld = false;
        }
        else if(beingHeld)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (!beingHeld & checkCollision() & Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Card is picked up");
            beingHeld = true;
        }

        if(checkCollision() & Input.GetKeyUp("f"))
        {
            changeSprite();
        }
    }

    public double getWidth()
    {
        return width;
    }
    public double setWidth(double changedWidth)
    {
        width = changedWidth;
        return width;
    }

    public double getHeight()
    {
        return height;
    }
    public double setHeight(double changedHeight)
    {
        height = changedHeight;
        return height;
    }
    
    public float getX()
    {
        return xLocation;
    }
    public float setX(float changedX)
    {
        xLocation = changedX;
        return xLocation;
    }

    public float getY()
    {
        return yLocation;
    }
    public float setY(float changedY)
    {
        yLocation = changedY;
        return yLocation;
    }

    public bool checkCollision()
    {
        return Input.mousePosition.x > (getX() - (getWidth() / 2)) & Input.mousePosition.x < (getX() + (getWidth() / 2)) & Input.mousePosition.y > (getY() - (getHeight() / 2)) & Input.mousePosition.y < (getY() + (getHeight() / 2));
    }

    public void changeSprite()
    {
        Sprite placeholderSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        //Debug.Log("Sprite Change Attempt");
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        newSprite = placeholderSprite;
    }

    public void cardInitialization()
    {
        if(Deck.randomDeck[21 - Deck.cardCount].Substring(0, 1).Equals("S"))
        {
            cardValue = "Joker";
        }
        else
        {
            cardValue = Deck.randomDeck[21 - Deck.cardCount].Substring(0,1);
        }
        cardSuit = Deck.randomDeck[21 - Deck.cardCount].Substring(1);
        //Debug.Log("I'm a(n) " + cardValue + " of " + cardSuit);
    }
}
