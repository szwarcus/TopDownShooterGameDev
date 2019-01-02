using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MyRangeLevelString))]
public class MyRangeLevelStringDrawer : PropertyDrawer
{
    string level;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var rangeAttribute = (MyRangeLevelString)base.attribute;

        // Now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
        if (property.propertyType == SerializedPropertyType.Integer)
        {
            switch (property.intValue)
            {
                case 1:
                    level = "Very Easy";
                    break;
                case 2:
                    level = "Easy";
                    break;
                case 3:
                    level = "Normal";
                    break;
                case 4:
                    level = "Hard";
                    break;
                case 5:
                    level = "Impossibru";
                    break;
            }
            EditorGUI.IntSlider(position, property, rangeAttribute.min, rangeAttribute.max, level);
        }
        else
            EditorGUI.LabelField(position, label.text, "Use MyRange with float.");
    }
}
