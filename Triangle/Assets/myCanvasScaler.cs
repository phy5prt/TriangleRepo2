using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//code doesnt seem necessary since childed to camera not sure why
public class myCanvasScaler : MonoBehaviour
{

    private RectTransform rectTransform;

    [Tooltip("isn't set to update on value change only runs on start")]
    public int widthLevel, heightLevel;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        //position central to camera start it centre bottom - later

        //set the grid image pivot to match in rect transform <--not doing at moment just using transform but the rect would be better

        rectTransform.sizeDelta = new Vector2((float)widthLevel, (float)heightLevel);

        //half a world unit so get middle of the 0,0 square grid space, then divide by world unit width, then if height adjust for scale

        Vector2 pivots = new Vector2((float)((1 * rectTransform.localScale.x) / (0.5 * widthLevel)), (float)((1 * rectTransform.localScale.y) / (0.5 * heightLevel)));
        rectTransform.pivot = pivots;




    }
}
