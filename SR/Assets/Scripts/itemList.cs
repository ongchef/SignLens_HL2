using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemList : MonoBehaviour
{
    private List<string> basketlist = new List<string>();
    private int cheeseCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<string> getList()
    {
        return basketlist;
    }
    public void additem(string name)
    {
        basketlist.Add(name);
    }
    public void removeitem(string name)
    {
        basketlist.Remove(name);
    }
    public int getCount()
    {
        return cheeseCount;
    }
    public void increase()
    {
        cheeseCount += 1;
    }
    public void decrease()
    {
        cheeseCount -= 1;
    }
}
