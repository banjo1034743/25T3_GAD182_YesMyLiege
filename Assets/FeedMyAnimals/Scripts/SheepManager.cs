using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace DirtPoorPeasants.FeedMyAnimals
{
    public class SheepManager : MonoBehaviour
    {
        #region Variables

        [Header("Scripts")]

        [SerializeField] private List<SheepAppleEater> _sheepList = new List<SheepAppleEater>();

        [Header("Events")]

        [SerializeField] private UnityEvent OnAllSheepFed = new UnityEvent();

        #endregion

        #region Methods

        public void RemoveSheep(GameObject sheepToRemove)
        {
            // We create a local list var and set the contents to
            // _sheepList so we avoid an error caused with updating
            // the list while going through it
            List<SheepAppleEater> tempList;
            tempList = _sheepList;

            for (int i = 0; i < tempList.Count; i++)
            {
                if (tempList[i].GetHasEatenApple())
                {
                    tempList.Remove(tempList[i]);
                    Destroy(sheepToRemove);
                }
            }

            _sheepList = tempList;

            if (_sheepList.Count == 0)
            {
                OnAllSheepFed.Invoke();
            }
        }

        #endregion
    }
}