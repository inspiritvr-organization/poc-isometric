using System;
using UnityEngine;
using Newtonsoft.Json;
public class IsometricSceneHandler : MonoBehaviour
{
    public Action<GameObject> OnCharactersReach;
    public IsometricCharacterController character;
    public static IsometricSceneHandler Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance == null)
            {
                instance = value;
            }
        }
    }
    private static IsometricSceneHandler instance;

    [SerializeField] public InputManager inputManager;
    [SerializeField] private UIHandler uIHandler;
    [SerializeField] private GameObject interactableParent;
    [SerializeField] private InteractionItem interactionItemPrefab;

    private void OnEnable()
    {
        OnCharactersReach += WithinInteractionZone;
        inputManager.OnMoveUpdate += character.Move;
    }
    private void OnDisable()
    {
        OnCharactersReach -= WithinInteractionZone;
        inputManager.OnMoveUpdate -= character.Move;
    }
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

//    private void Start()
//    {
//#if UNITY_EDITOR
//        EditorTest();
//#endif
//        //interactableParent.SetActive(true);
//    }

    private void WithinInteractionZone(GameObject intearctionObject)
    {
        if (intearctionObject == null)
        {
            uIHandler.SetStateEnterRectTransform(false);
        }
        else
        {
            uIHandler.SetStateEnterRectTransform(true);

        }
    }

    [ContextMenu("Test Spawn Interactables")]
    public void EditorTest()
    {
        if (System.IO.File.Exists(Application.dataPath + "/test.json"))
        {
            SpawnInteractables(System.IO.File.ReadAllText(Application.dataPath + "/test.json"));
        }
        else
        {
            Debug.LogWarning("No Test json found");
        }
    }

    public void SpawnInteractables(string jsonString)
    {
        InteractionPoints interactionPoints = JsonConvert.DeserializeObject<InteractionPoints>(jsonString);
        foreach (InteractionObject interactionObject in interactionPoints.InteractionObjects)
        {
            InteractionItem interactionItem = Instantiate(interactionItemPrefab, interactableParent.transform);
            interactionItem.transform.position = new Vector3(interactionObject.objectTransform.position[0], interactionObject.objectTransform.position[1], interactionObject.objectTransform.position[2]);
            interactionItem.transform.eulerAngles = new Vector3(interactionObject.objectTransform.rotation[0], interactionObject.objectTransform.rotation[1], interactionObject.objectTransform.rotation[2]);
            interactionItem.transform.localScale = new Vector3(interactionObject.objectTransform.scale[0], interactionObject.objectTransform.scale[1], interactionObject.objectTransform.scale[2]);
            interactionItem.transform.name = interactionObject.objectLabel;
            interactionItem.UpdateLabelText(interactionObject.objectLabel);
            interactionItem.UpdateThumbnail(interactionObject.objectThumbnailURL);
        }
        interactableParent.SetActive(true);
    }

    public void SetInputManagerState(bool state)
    {
        inputManager.enabled = state;
    }
}
