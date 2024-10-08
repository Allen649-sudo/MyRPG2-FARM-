using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturesPool : MonoBehaviour
{
    public List<GameObject> listCreatures = new List<GameObject>();
    public List<GameObject> listCreaturesBullet = new List<GameObject>();

    public void CreatureAddList(GameObject creature)
    {
        listCreatures.Add(creature);
    }

    public void CreatureBulletAddList(GameObject bullet)
    {
        listCreaturesBullet.Add(bullet);
    }

    public void ActivateCreatures(GameObject creaturesSO, Vector3 position)
    {
        bool foundInactive = false;
        foreach (GameObject creaturesVar in listCreatures)
        {
            if (creaturesVar != null && !creaturesVar.activeInHierarchy)
            {

                foundInactive = true;
                creaturesVar.GetComponent<DataCreatures>().Active();
                break;
            }
        }

        if (!foundInactive)
        {
            GameObject creatures = Instantiate(creaturesSO, position, Quaternion.identity);
            CreatureAddList(creatures);
        }
    }

    public void ActivateCreaturesBullet(GameObject bullet, GameObject master, GameObject playerPos, Quaternion currentRotation)
    {
        bool foundInactive = false;
        foreach (GameObject bull in listCreaturesBullet)
        {
            if (bull != null && !bull.activeInHierarchy)
            {
                foundInactive = true;
                bull.GetComponent<ChickBullet>().Activate();
                bull.GetComponent<ChickBullet>().Fire(master, playerPos);
                bull.transform.rotation = currentRotation;
                break;
            }
        }

        if (!foundInactive)
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.GetComponent<ChickBullet>().Fire(master, playerPos);
            CreatureBulletAddList(newBullet);
        }
    }
}
