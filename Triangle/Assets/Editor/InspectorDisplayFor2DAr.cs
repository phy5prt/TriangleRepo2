using System.Collections;

using UnityEditor;
using UnityEngine;

/*https://www.youtube.com/watch?v=mxqD1B2e4ME  */

    //ive tried changing array size and making the array elements spread out with width and height

    //now we want a square grid instead of the colour pickers being rectangle
    //now we want adjustable as our array size will change through game, and dont want to keep track with seperate integer
    //if we were really clever and could change the colour pickers to triangles that would be cool

[CustomPropertyDrawer(typeof(Inspector2DArVis2))]
public class InspectorDisplayFor2DAr: PropertyDrawer
{
    private int squareArSize = 10;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);// auto appeared so maybe interface may need to put this in insted of what ive got later
       EditorGUI.PrefixLabel(position, label);
        Rect newPosition = position;
        newPosition.y += 18f;

        SerializedProperty rows = property.FindPropertyRelative("rows");

        

        for (int i = 0; i < squareArSize; i++)
        {

            SerializedProperty row = rows.GetArrayElementAtIndex(i).FindPropertyRelative("row");
            newPosition.height = 20; //was 20

            if (row.arraySize != squareArSize) //are we setting the grid size here if so would be nice if it were adjustable
                row.arraySize = squareArSize;
            newPosition.width = 70; //was 70

            for (int j = 0; j < squareArSize; j++)
            {
                EditorGUI.PropertyField(newPosition, row.GetArrayElementAtIndex(j), GUIContent.none); //is this where we could preset color to gray
                newPosition.x += newPosition.width;

            }

            newPosition.x = position.x;
            newPosition.y += 20; //was 20
        }
    }

    //this just places the add component button
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 20 * 12;
    }
    
}
