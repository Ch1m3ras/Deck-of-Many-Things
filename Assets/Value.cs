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
        //Debug.Log(value);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
    }
}
