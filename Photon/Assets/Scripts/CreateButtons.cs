using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public int numberofbuttons;
    public GameObject canvas;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        if (numberofbuttons > 0){
            int distance = 200;
            int startpos = (int)(distance * -((numberofbuttons-0.5f)/2));
            for (int i = 0; i < numberofbuttons; i++){
                GameObject newButton = Instantiate(button) as GameObject;
                newButton.transform.SetParent(canvas.transform);
                float heightdiv2 = canvas.GetComponent<RectTransform>().rect.height / 2;
                float widthdiv2 = canvas.GetComponent<RectTransform>().rect.width / 2;
                newButton.transform.position = newButton.transform.position + new Vector3(startpos + widthdiv2+(i*distance),heightdiv2,0);
                newButton.GetComponentInChildren<Text>().text = i.ToString();
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}
