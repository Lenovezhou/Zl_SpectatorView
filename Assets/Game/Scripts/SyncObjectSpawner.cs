//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
//

using UnityEngine;
using HoloToolkit.Sharing.Spawning;
using HoloToolkit.Unity.InputModule;

namespace HoloToolkit.Sharing.Tests
{
    /// <summary>
    /// Class that handles spawning sync objects on keyboard presses, for the SpawningTest scene.
    /// </summary>
    public class SyncObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        private PrefabSpawnManager spawnManager;

        [SerializeField]
        [Tooltip("Optional transform target, for when you want to spawn the object on a specific parent.  If this value is not set, then the spawned objects will be spawned on this game object.")]
        private Transform spawnParentTransform;

        [SerializeField]
        private WorldSpaceUI spaceUI;

        //≤‚ ‘
        public TextMesh testtext;

        private void Awake()
        {
            if (spawnManager == null)
            {
                Debug.LogError("You need to reference the spawn manager on SyncObjectSpawner.");
            }

            // If we don't have a spawn parent transform, then spawn the object on this transform.
            if (spawnParentTransform == null)
            {
                spawnParentTransform = transform;
            }

            spaceUI.e_tap += SpawnCustomSyncObject;
        }


        private void OnDestroy()
        {
            spaceUI.e_tap -= SpawnCustomSyncObject;
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetMouseButtonDown(2))
            {
                SpawnBasicSyncObject();
               
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                SpawnCustomSyncObject("Yucca");
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
               // SpawnCustomSyncObject();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                DeleteSyncObject();
            }
        }
#endif


        public void SpawnBasicSyncObject()
        {
            Vector3 position = Random.onUnitSphere * 2;
            Quaternion rotation = Random.rotation;

            var spawnedObject = new SyncSpawnedObject();

            spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnedObject", false);
        }

        public void SpawnCustomSyncObject(string name)
        {
            Vector3 position = Camera.main.transform.forward * 2;
            Quaternion rotation = Quaternion.identity;

            SyncSpawnedObject spawnedObject = null;

            //testtext.text = name ;

            switch (name)
            {
                case "Vase1":
                    spawnedObject = new Vase1();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 90));
                    break;
                case "Vase2":
                    spawnedObject = new Vase2();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 90));
                    break;
                case "Vase3":
                    spawnedObject = new Vase3();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 90));
                    break;
                case "Yucca":
                    spawnedObject = new Yucca();
                    rotation = Quaternion.Euler(new Vector3(-90,119,0));
                    break;
                case "Pothos":
                    spawnedObject = new Pothos();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;



                case "Barcelona":
                    spawnedObject = new Barcelona();
                    rotation = Quaternion.Euler(new Vector3(-90, 90, 0));
                    break;
                case "Barcelona_Daybed":
                    spawnedObject = new Barcelona_Daybed();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "Barcelona_Footrest":
                    spawnedObject = new Barcelona_Footrest();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "Bath_Bathtub":
                    spawnedObject = new Bath_Bathtub();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "Bath_Tap":
                    spawnedObject = new Bath_Tap();
                    rotation = Quaternion.Euler(new Vector3(-90, -180, 0));
                    break;
                case "Bed1":
                    spawnedObject = new Bed1();
                    rotation = Quaternion.Euler(new Vector3(-90, -90, 0));
                    break;
                case "Bedside":
                    spawnedObject = new Bedside();
                    rotation = Quaternion.Euler(new Vector3(-90, -90, 0));
                    break;
                case "Console_Classic":
                    spawnedObject = new Console_Classic();
                    rotation = Quaternion.Euler(new Vector3(-90, -90, 0));
                    break;
                case "Console_Round":
                    spawnedObject = new Console_Round();
                    rotation = Quaternion.Euler(new Vector3(-90, -90, 0));
                    break;
                case "Desk":
                    spawnedObject = new Desk();
                    rotation = Quaternion.Euler(new Vector3(-90, -90, 0));
                    break;
                case "Febo":
                    spawnedObject = new Febo();
                    rotation = Quaternion.Euler(new Vector3(-90, 90, 0));
                    break;
                case "Fireplace":
                    spawnedObject = new Fireplace();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "FK_Chair":
                    spawnedObject = new FK_Chair();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;


                case "LampCeiling":
                    spawnedObject = new LampCeiling();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "LampFloor":
                    spawnedObject = new LampFloor();
                    rotation = Quaternion.Euler(new Vector3(-90, 75, 0));
                    break;
                case "LampFloor2":
                    spawnedObject = new LampFloor2();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "LampWall":
                    spawnedObject = new LampWall();
                    rotation = Quaternion.Euler(new Vector3(-90, -90, 0));
                    break;
                case "LampWall2":
                    spawnedObject = new LampWall2();
                    rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                    break;
                case "Leukon_Low":
                    spawnedObject = new Leukon_Low();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "MrChair":
                    spawnedObject = new MrChair();
                    rotation = Quaternion.Euler(new Vector3(-90, 90, 0));
                    break;
                case "MrChaiseLounge":
                    spawnedObject = new MrChaiseLounge();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "Puff":
                    spawnedObject = new Puff();
                    rotation = Quaternion.Euler(new Vector3(-90, 90, 0));
                    break;
                case "Recipio":
                    spawnedObject = new Recipio();
                    rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
                    break;
                case "Thronos":
                    spawnedObject = new Thronos();
                    rotation = Quaternion.Euler(new Vector3(-90, 180, 0));
                    break;
                default:
                //    testtext.text += "Œ¥∂®“Â";
                break;
            }

            // spawnedObject.TestFloat.Value = Random.Range(0f, 100f);
            if (spawnedObject != null)
            {
                spawnManager.Spawn(spawnedObject, position, rotation, spawnParentTransform.gameObject, "SpawnTestSphere", false);
            }
        }

        /// <summary>
        /// Deletes any sync object that inherits from SyncSpawnObject.
        /// </summary>
        public void DeleteSyncObject()
        {
            GameObject hitObject = GazeManager.Instance.HitObject;
            if (hitObject != null)
            {
                var syncModelAccessor = hitObject.GetComponent<DefaultSyncModelAccessor>();
                if (syncModelAccessor != null)
                {
                    var syncSpawnObject = (SyncSpawnedObject)syncModelAccessor.SyncModel;
                    spawnManager.Delete(syncSpawnObject);
                }
            }
        }
    }
}
