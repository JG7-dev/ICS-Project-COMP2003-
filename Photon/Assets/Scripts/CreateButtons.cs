using UnityEngine;
using UnityEngine.UI;

public class CreateButtons : MonoBehaviour
{
    public int numberofbuttons;
    public GameObject canvas;

    public GameObject button;

    // Start is called before the first frame update
    private void Start()
    {
        if (numberofbuttons > 0)
        {
            var distance = 200;
            var startpos = (int) (distance * -((numberofbuttons - 0.5f) / 2));
            for (var i = 0; i < numberofbuttons; i++)
            {
                var newButton = Instantiate(button);
                newButton.transform.SetParent(canvas.transform);
                var heightdiv2 = canvas.GetComponent<RectTransform>().rect.height / 2;
                var widthdiv2 = canvas.GetComponent<RectTransform>().rect.width / 2;
                newButton.transform.position = newButton.transform.position +
                                               new Vector3(startpos + widthdiv2 + i * distance, heightdiv2, 0);
                newButton.GetComponentInChildren<Text>().text = i.ToString();
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}