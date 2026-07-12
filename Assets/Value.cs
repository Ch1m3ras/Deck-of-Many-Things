using UnityEngine;

public class Value : MonoBehaviour
{
    private GameObject creator;
    private string value;
    private bool isTop = false;

    public Sprite aceSprite;
    public Sprite kingSprite;
    public Sprite queenSprite;
    public Sprite jackSprite;
    public Sprite twoSprite;
    public Sprite jokerSprite;
    
    
    // Technically unused for now, may be used later.
    public Sprite tenSprite;
    public Sprite nineSprite;
    public Sprite eightSprite;
    public Sprite sevenSprite;
    public Sprite sixSprite;
    public Sprite fiveSprite;
    public Sprite fourSprite;
    public Sprite threeSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteStuff();
        //Debug.Log(value);
    }

    // Update is called once per frame
    void Update()
    {
        if (creator.GetComponent<Card>().isHeld())
        {
            Vector2 mouseVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (isTop)
            {
                transform.position = new Vector3(mouseVector.x - (float)1.7, mouseVector.y + (float)2.35, -1);
            }
            else
            {
                transform.position = new Vector3(mouseVector.x + (float)1.7, mouseVector.y - (float)2.35, -1);
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

    public bool getIsTop()
    {
        return isTop;
    } 

    public void setIsTop(bool inputTop)
    {
        isTop = inputTop;
    }

    public string getValue()
    {
        return value;
    }

    public void setValue(string newValue)
    {
        value = newValue;
    }

    void spriteStuff()
    {
        if (value.Equals("A"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = aceSprite;
        }
        else if (value.Equals("K"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = kingSprite;
        }
        else if (value.Equals("Q"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = queenSprite;
        }
        else if (value.Equals("J"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = jackSprite;
        }
        else if (value.Equals("Joker"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = jokerSprite;
        }
        else if (value.Equals("2"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = twoSprite;
        }

        if (!isTop)
        {
            transform.localScale = new Vector3(-transform.localScale.x, -1 * transform.localScale.y, transform.localScale.z);
        }
    }
}
