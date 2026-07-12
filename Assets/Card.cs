using UnityEngine;

public class Card : MonoBehaviour
{
    public bool beingHeld;
    private double width;
    private double height;
    private float xLocation;
    private float yLocation;
    private float trueXLocation;
    private float trueYLocation;
    public Sprite newSprite;
    public Sprite openCard;
    public string cardValue;
    public string cardSuit;
    public GameObject suitPrefab;
    public GameObject valuePrefab;
    public GameObject cardArtPrefab;
    private GameObject bottomSuitObject;
    private GameObject topSuitObject;
    private GameObject topValueObject;
    private GameObject bottomValueObject;
    private GameObject cardArtObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cardInitialization();
        width = 250 * 2.3;
        height = 350 * 2.3;
        xLocation = Camera.main.WorldToScreenPoint(transform.localPosition).x;
        yLocation = Camera.main.WorldToScreenPoint(transform.localPosition).y;
        trueXLocation = transform.position.x;
        trueYLocation = transform.position.y;
        beingHeld = true;

        // Debug.Log(trueXLocation);
        // Debug.Log(trueYLocation);
    }

    // Update is called once per frame
    void Update()
    {
        xLocation = Camera.main.WorldToScreenPoint(transform.localPosition).x;
        yLocation = Camera.main.WorldToScreenPoint(transform.localPosition).y;

        trueXLocation = transform.position.x;
        trueYLocation = transform.position.y;
        //Debug.Log(trueXLocation);
        //  Debug.Log(trueYLocation);

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
            cardAssetManager();
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

    public float getTrueX()
    {
        return trueXLocation;    
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

    public float getTrueY()
    {
        return trueYLocation;
    }

    public string getCardValue()
    {
        return cardValue;
    }

    public string getCardSuit()
    {
        return cardSuit;
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
        Debug.Log("I'm a(n) " + cardValue + " of " + cardSuit);
    }

    public void cardAssetManager()
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite.Equals(openCard))
        {
            bottomSuitObject = Instantiate(suitPrefab, new Vector3(trueXLocation + (float)1.7, trueYLocation - (float)1.67, (float)-1), Quaternion.identity);
            bottomSuitObject.GetComponent<Suit>().setCreator(gameObject);
            bottomSuitObject.GetComponent<Suit>().setIsTop(false);
            bottomSuitObject.GetComponent<Suit>().setSuit(cardSuit);

            topSuitObject = Instantiate(suitPrefab, new Vector3(trueXLocation - (float)1.7, trueYLocation + (float)1.67, (float)-1), Quaternion.identity);
            topSuitObject.GetComponent<Suit>().setCreator(gameObject);
            topSuitObject.GetComponent<Suit>().setIsTop(true);
            topSuitObject.GetComponent<Suit>().setSuit(cardSuit);

            bottomValueObject = Instantiate(valuePrefab, new Vector3(-1, -1, 0), Quaternion.identity);
            bottomValueObject.GetComponent<Value>().setCreator(gameObject);
            bottomValueObject.GetComponent<Value>().setIsTop(false);
            bottomValueObject.GetComponent<Value>().setValue(cardValue);

            topValueObject = Instantiate(valuePrefab, new Vector3(1, 1, 0), Quaternion.identity);
            topValueObject.GetComponent<Value>().setCreator(gameObject);
            topValueObject.GetComponent<Value>().setIsTop(true);
            topValueObject.GetComponent<Value>().setValue(cardValue);

            cardArtObject = Instantiate(cardArtPrefab, new Vector3(-1, -1, 0), Quaternion.identity);
            cardArtObject.GetComponent<CardArt>().creator = gameObject;

            // Debug.Log("I'm face side up!");
            
        }
        else
        {
            Destroy(bottomSuitObject);
            Destroy(topSuitObject);
            Destroy(topValueObject);
            Destroy(bottomValueObject);
            Destroy(cardArtObject);
            //Debug.Log("I'm not face side up!");
        }
    }
}
