using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trajectory : MonoBehaviour
{
    private Scene _simulationScene;
    private PhysicsScene2D _physicsScene;
    [SerializeField] private Transform _obstacleParent;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private int _maxIteration;
    [SerializeField] private Transform _slingshotParent;
    [SerializeField] private List<Rigidbody2D> _sjs = new List<Rigidbody2D>();
    private List<Rigidbody2D> installedSjs = new List<Rigidbody2D>();

    private void Start()
    {
        //_simulationScene = SceneManager.CreateScene("Simulation", new CreateSceneParameters(LocalPhysicsMode.Physics2D));
        //_physicsScene = _simulationScene.GetPhysicsScene2D();

        //foreach (Transform child in _obstacleParent)
        //{
        //    GameObject newObject = Instantiate(child.gameObject, child.transform.position, child.transform.rotation);
        //    //newObject.GetComponent<Renderer>().enabled = false; 
        //    SceneManager.MoveGameObjectToScene(newObject, _simulationScene);
        //}

        //foreach (Rigidbody2D sj in _sjs)
        //{
        //    GameObject newSjGo = Instantiate(sj.gameObject, sj.transform.position, sj.transform.rotation);
        //    SceneManager.MoveGameObjectToScene(newSjGo, _simulationScene);
        //    installedSjs.Add(newSjGo.GetComponent<Rigidbody2D>());  
        //}
    }

    public void Simulate(Chip chip)
    {
        //SpingShot ss = null;
        //GameObject newObj = null;
        //foreach (Transform child in _slingshotParent)
        //{
        //    newObj = Instantiate(child.gameObject, child.transform.position, child.transform.rotation);
        //    //newObject.GetComponent<Renderer>().enabled = false; 
        //    SceneManager.MoveGameObjectToScene(newObj, _simulationScene);
        //    if (child.TryGetComponent(out ss)) ;
        //}

        GameObject newChipGo = Instantiate(chip, chip.transform.position, chip.transform.rotation).gameObject;
        ////newChipGo.GetComponent<Renderer>().enabled = false;   
        SceneManager.MoveGameObjectToScene(newChipGo, _simulationScene);
        newChipGo.GetComponent<Rigidbody2D>().AddForce(newChipGo.transform.forward);
        //Chip newChip = ss.Chip;

        //newChip.Spingshot = null;
        //newChip.InteractOff(false);

        _line.positionCount = _maxIteration;
        //float releasDelay = newChip.ReleaseDelay;
        for (int i = 0; i < _maxIteration; i++)
        {
            //if (releasDelay <= 0)
            //{
            //    newChip.Releas();
            //}

            //else
            //{
            //    releasDelay -= Time.fixedDeltaTime;
            //}

            _physicsScene.Simulate(Time.fixedDeltaTime);
            //Debug.Log(newChipGo.transform.position);
            _line.SetPosition(i, newChipGo.transform.position);
        }

        Destroy(newChipGo);
    }
}
