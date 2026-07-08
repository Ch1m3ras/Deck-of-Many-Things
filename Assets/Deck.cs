using UnityEngine;

public class Deck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private double width;
    private double height;
    private float xLocation;
    private float yLocation;
    public GameObject cardPrefab;
    public static int cardCount;
    public static string[] sortedDeck;
    public static string[] randomDeck;


    void Start()
    {
        deckSetup();
        width = 250 * 2.3;
        height = 350 * 2.3;
        xLocation = Camera.main.WorldToScreenPoint(transform.localPosition).x;
        yLocation = Camera.main.WorldToScreenPoint(transform.localPosition).y;
        // Debug.Log("THIS CODE COMPILES");
        // Debug.Log("Width: " + width);
        // Debug.Log("Height: " + height);
        // Debug.Log("X Location: " + xLocation);
        // Debug.Log("Y Location: " + yLocation);
    }

    // Update is called once per frame
    void Update()
    {
        if (checkCollision())
        {
            // Debug.Log("Hovering Over the deck");
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("I'm clicking on the deck");
                Instantiate(cardPrefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity);
                cardCount--;
                //Debug.Log("Cards Left: " + cardCount);

                if(cardCount == 0)
                {
                    Destroy(gameObject);
                }

            }
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

    public void deckSetup()
    {
        string[] cardValues = {"A", "K", "Q", "J", "2"};
        string[] cardSuits = {"Spades", "Hearts", "Diamonds", "Clubs"};
        cardCount = 22;
        sortedDeck = new string[cardCount];
        randomDeck = new string[cardCount];
        int counter = 0;
        for(int num = 0; num < 5; num++)
        {
            for(int num2 = 0; num2 < 4; num2++)
            {
                sortedDeck[counter] = cardValues[num] + cardSuits[num2];
                counter++;
            }
        }
        sortedDeck[20] = "SColor";
        sortedDeck[21] = "SNoColor";
        
        // string outputString1 = "";
        // for(int num = 0; num < cardCount; num++)
        // {
        //     outputString1 = outputString1 + " " + sortedDeck[num];
        // }
        // Debug.Log(outputString1);

        int counter2 = 0;
        while (counter2 < 22)
        {
            int selectedIndex = Random.Range(0, 22 - counter2);
            //Debug.Log(sortedDeck[selectedIndex]);
            randomDeck[counter2] = sortedDeck[selectedIndex];
            string placeholderString = sortedDeck[21 - counter2];
            sortedDeck[21 - counter2] = sortedDeck[selectedIndex];
            sortedDeck[selectedIndex] = placeholderString;
            counter2++;
        }

        // string outputString = "";
        // for(int num = 0; num < cardCount; num++)
        // {
        //     outputString = outputString + " " + randomDeck[num];
        // }
        // Debug.Log(outputString);
    }
}
