using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

#if UNITY_EDITOR
using UnityEditor;
#endif

[Serializable]
public class ColliderEvent : UnityEvent { }

[AddComponentMenu("UI/Collider")]
public class Collider : MonoBehaviour
{
    public enum ColliderState 
    { 
        Trigger,
        Collision
    }

    public enum EventState
    {
        Enter,
        Exit,
        Stay,
        EnterExit,
        EnterStay,
        ExitStay,
        EnterExitStay,
    }

    public EventState eventState;
    public ColliderState colliderState;

    public string[] enterTags;
    public ColliderEvent enterEvent;

    public string[] exitTags;
    public ColliderEvent exitEvent;

    public string[] stayTags;
    public ColliderEvent stayEvent;

    public bool destroyTrigger;
    public Sprite spr_Trigger, spr_Collision;

    private void Awake()
    {
       gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

	#region Trigger
	private void OnTriggerEnter2D(Collider2D col)
    {
        if (canInteract(EventState.Enter) && colliderState == ColliderState.Trigger)
        {
            if (enterTags.Contains(col.gameObject.tag) && enterTags != null)
            {
                enterEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
            else if (enterTags == null)
            {
                enterEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (canInteract(EventState.Exit) && colliderState == ColliderState.Trigger)
        {
            if (exitTags.Contains(col.gameObject.tag) && exitTags != null)
            {
                exitEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
            else if (exitTags == null)
            {
                exitEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (canInteract(EventState.Stay) && colliderState == ColliderState.Trigger)
        {
            if (stayTags.Contains(col.gameObject.tag) && stayTags != null)
            {
                stayEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
            else if (stayTags == null)
            {
                stayEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
    #endregion

    #region Collision
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (canInteract(EventState.Enter) && colliderState == ColliderState.Collision)
        {
            if (enterTags.Contains(col.gameObject.tag) && enterTags != null)
            {
                enterEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
            else if (enterTags == null)
            {
                enterEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (canInteract(EventState.Exit) && colliderState == ColliderState.Collision)
        {
            if (exitTags.Contains(col.gameObject.tag) && exitTags != null)
            {
                exitEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
            else if (exitTags == null)
            {
                exitEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (canInteract(EventState.Stay) && colliderState == ColliderState.Collision)
        {
            if (stayTags.Contains(col.gameObject.tag) && stayTags != null)
            {
                stayEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
            else if (stayTags == null)
            {
                stayEvent.Invoke();
                if (destroyTrigger)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
#endregion

    //Check
    private bool canInteract(EventState state)
    {
        if (state == EventState.Enter)
        {
            if (eventState == EventState.Enter || eventState == EventState.EnterExit || eventState == EventState.EnterStay || eventState == EventState.EnterExitStay)
            {
                return true;
            }
        }
        else if (state == EventState.Stay)
        {
            if (eventState == EventState.Stay || eventState == EventState.EnterExitStay || eventState == EventState.EnterStay || eventState == EventState.ExitStay)
            {
                return true;
            }
        }
        else if (state == EventState.Exit)
        {
            if (eventState == EventState.Exit || eventState == EventState.ExitStay || eventState == EventState.EnterExit || eventState == EventState.EnterExitStay)
            {
                return true;
            }
        }
        return false;
    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(Collider))]
public class ColliderEditor : Editor
{
    SerializedProperty enterEvent;
    SerializedProperty exitEvent;
    SerializedProperty stayEvent;

    SerializedProperty enterTags;
    SerializedProperty exitTags;
    SerializedProperty stayTags;

    SerializedProperty spr_Trigger, spr_Collision;

    private void OnEnable()
    {
        enterEvent = serializedObject.FindProperty("enterEvent");
        exitEvent = serializedObject.FindProperty("exitEvent");
        stayEvent = serializedObject.FindProperty("stayEvent");

        enterTags = serializedObject.FindProperty("enterTags");
        exitTags = serializedObject.FindProperty("exitTags");
        stayTags = serializedObject.FindProperty("stayTags");

        spr_Trigger = serializedObject.FindProperty("spr_Trigger");
        spr_Collision = serializedObject.FindProperty("spr_Collision");
    }

    override public void OnInspectorGUI()
    {
        var myScript = target as Collider;
        //Collider Sprites
        EditorGUILayout.ObjectField(spr_Trigger);
        EditorGUILayout.ObjectField(spr_Collision);
        GUILayout.Space(20);
        //Collider Options
        myScript.destroyTrigger = GUILayout.Toggle(myScript.destroyTrigger, "Destroy Collider");
        GUILayout.Space(20);
        myScript.colliderState = (Collider.ColliderState)EditorGUILayout.EnumPopup("Collider Type",myScript.colliderState);
        GUILayout.Space(5);
        myScript.eventState = (Collider.EventState)EditorGUILayout.EnumPopup("Collider Events",myScript.eventState);
        GUILayout.Space(10);

        SpriteRenderer spriteRenderer = myScript.gameObject.GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = myScript.gameObject.GetComponent<BoxCollider2D>();

		#region Collider State
		if (myScript.colliderState == Collider.ColliderState.Trigger)
		{
            spriteRenderer.sprite = myScript.spr_Trigger;
            boxCollider2D.isTrigger = true;
        }
        else if (myScript.colliderState == Collider.ColliderState.Collision)
		{
            spriteRenderer.sprite = myScript.spr_Collision;
            boxCollider2D.isTrigger = false;
        }
		#endregion

		#region Event State
		if (myScript.eventState == Collider.EventState.Enter)
        {
            EditorGUILayout.PropertyField(enterTags);
            EditorGUILayout.PropertyField(enterEvent);
        }
        else if (myScript.eventState == Collider.EventState.Exit)
        {
            EditorGUILayout.PropertyField(exitTags);
            EditorGUILayout.PropertyField(exitEvent);
        }
        else if (myScript.eventState == Collider.EventState.Stay)
        {
            EditorGUILayout.PropertyField(stayTags);
            EditorGUILayout.PropertyField(stayEvent);
        }
        else if (myScript.eventState == Collider.EventState.EnterExit)
        {
            EditorGUILayout.PropertyField(enterTags);
            EditorGUILayout.PropertyField(enterEvent);
            EditorGUILayout.PropertyField(exitTags);
            EditorGUILayout.PropertyField(exitEvent);
        }
        else if (myScript.eventState == Collider.EventState.EnterStay)
        {
            EditorGUILayout.PropertyField(enterTags);
            EditorGUILayout.PropertyField(enterEvent);
            EditorGUILayout.PropertyField(stayTags);
            EditorGUILayout.PropertyField(stayEvent);
        }
        else if (myScript.eventState == Collider.EventState.ExitStay)
        {
            EditorGUILayout.PropertyField(exitTags);
            EditorGUILayout.PropertyField(exitEvent);
            EditorGUILayout.PropertyField(stayTags);
            EditorGUILayout.PropertyField(stayEvent);
        }
        else if (myScript.eventState == Collider.EventState.EnterExitStay)
        {
            EditorGUILayout.PropertyField(enterTags);
            EditorGUILayout.PropertyField(enterEvent);
            EditorGUILayout.PropertyField(exitTags);
            EditorGUILayout.PropertyField(exitEvent);
            EditorGUILayout.PropertyField(stayTags);
            EditorGUILayout.PropertyField(stayEvent);
        }
		#endregion

		serializedObject.ApplyModifiedProperties();
    }
}
#endif