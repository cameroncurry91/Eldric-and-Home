using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heartscript: MonoBehaviour
{
    public int Health;
    public int numofHearts;
    public Image[] Hearts;
    public Sprite fullheart;
    public Sprite emptyheart;



    private void Update()
    {

        if (Health > numofHearts)
        {
            Health = numofHearts;
        }
        for (int i = 0; i < Hearts.Length; i++)
        {   if (i < Health)

            {
                Hearts[i].sprite = fullheart;
            }
            else 
            {
                Hearts[i].sprite = emptyheart;
            }


            if (i < numofHearts)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
             }
                         
            
        }

        
    }
}
 


