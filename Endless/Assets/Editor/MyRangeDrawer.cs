using UnityEditor;
using UnityEngine;

// Tell the MyRangeDrawer that it is a drawer for properties with the MyRangeAttribute.
[CustomPropertyDrawer(typeof(MyRangeAttribute))]
internal sealed class MyRangeDrawer : PropertyDrawer
{
    private int value;
    private float valueF;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var rangeAttribute = (MyRangeAttribute)base.attribute;

        // Now draw the property as a Slider or an IntSlider based on whether it's a float or integer.
         if (property.propertyType == SerializedPropertyType.Float)
        {
            EditorGUI.Slider(position, property, rangeAttribute.min, rangeAttribute.max, label);
            valueF = Mathf.Ceil(property.floatValue / rangeAttribute.step) * rangeAttribute.step;
            property.floatValue = valueF;
        }
        else
            EditorGUI.LabelField(position, label.text, "Use MyRange with float.");
    }
}
