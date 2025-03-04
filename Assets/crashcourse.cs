using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crashcourse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 30; i++)
        {
            string toPrint = "Regular Shot";
            if (i % 3 == 0 && i % 5 == 0)
            {
                toPrint = "Super Shot";
            }
            else if (i % 3 == 0)
            {
                toPrint = "Flaming Shot";
            }
            else if (i % 5 == 0)
            {
                toPrint = "Electronic shot";
            }
            toPrint = i + ". " + toPrint;
            Debug.Log(toPrint);
        }

        //------if language------
        //int time = 0;
        //string toPrint;

        //if (time % 2 ==0)
        //{
        //    toPrint = "Tick!";
        //}
        //else
        //{
        //    toPrint = "Tock!";
        //}
        //Debug.Log(toPrint);

        //------string concatination------
        //string text;
        //text = "perfume";
        //text = "The "+ text + " 3000!";
        //Debug.Log(text);

        //string text;
        //text = "Hello World!";
        //Debug.Log(text);

        // Debug.Log("Hello World!"); --same above

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
