using UnityEngine;
using TMPro;

namespace PorteCalcul
{
    public class CalculSystem : MonoBehaviour
    {
        int firstInt = 0;
        int secondInt = 0;
        int result = 0;
        int fakeResult = 0;
        bool isAddition;
        string operationSign;


        [Header("Objects")]
      
        [SerializeField] Transform[] doors;

        [Header("Display")]
        [SerializeField] TextMeshPro resultDoorText;
        [SerializeField] TextMeshPro fakeResultDoorText;
        [SerializeField] TextMeshPro operationText;

        public static CalculSystem instance;
        private void Awake()
        {
            if (instance != null)
            {
                Debug.LogError("Il y a plus d'une instance de GameManager_PorteCalcul dans la sc�ne");
                return;
            }
            instance = this;


        }
        void Start()
        {
            LaunchOperation();
        }

        void ChooseOperation()
        {
            firstInt = Random.Range(0, 10);
            secondInt = Random.Range(0, 10);
            isAddition = GetRandomBoolean();

            if (isAddition)
            {
                operationSign = " + ";
                result = firstInt + secondInt;
                fakeResult = result + Random.Range(0, 4);

            }
            else
            {
                operationSign = " - ";
                
                if (firstInt < secondInt)
                {
                    int temp = firstInt;
                    firstInt = secondInt;
                    secondInt = temp;
                }
                result = firstInt - secondInt;
                fakeResult = result - Random.Range(0, 4);
            }

            if (result == fakeResult)
            {
                fakeResult++;
            }

            DisplayOperation();

        }

        public void LaunchOperation()
        {
            PlaceObject();
            ChooseOperation();
        }

        void PlaceObject()
        {
            PlacePair(doors, 5.15f, GetRandomBoolean());
         
        }

        void PlacePair(Transform[] objects, float xOffset, bool rightSide)
        {
            objects[0].position = new Vector3(rightSide ? xOffset : -xOffset, objects[0].position.y, objects[0].position.z);
            objects[1].position = new Vector3(rightSide ? -xOffset : xOffset, objects[1].position.y, objects[1].position.z);
        }

        bool GetRandomBoolean()
        {
            return Random.value > 0.5f;
        }

        void DisplayOperation()
        {
            resultDoorText.text = result.ToString();
            fakeResultDoorText.text = fakeResult.ToString();
            operationText.text = firstInt.ToString() + operationSign + secondInt;
        }

        


    } 
}
