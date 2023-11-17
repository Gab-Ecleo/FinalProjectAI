using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AI_Types
{
    Archer,
    Warrior,
    Mage,
    Ninja
}

public class NewAiBehaviour : MonoBehaviour
{
    Dictionary<AI_Types, int> aiModelIndices = new Dictionary<AI_Types, int>()
    {
        { AI_Types.Archer, 0 },
        { AI_Types.Warrior, 1 },
        { AI_Types.Mage, 2 },
        { AI_Types.Ninja, 3 }
    };

    [Header("State")] public string currentState;
    public AI_Types aiTypes;
    [Header("References")] public List<GameObject> aiModel;
    public Animator animator;
    public NavMeshAgent agent;
    [Header("AttackRange")] public float range;
    [Header("EnemyValues")] public float health;
    public float damage;
    public new string tag = "Team1";
    [Header("VFX")] public GameObject Arrow;
    public Transform spawnArcherFX;

    private string _projectileTag;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        ArrowBehaviour _archerDamage = new ArrowBehaviour();

        

        Action<AI_Types> activateAiModel = (AI_Types aiType) =>
        {
            aiModel[aiModelIndices[aiType]].SetActive(true);
            animator = aiModel[aiModelIndices[aiType]].GetComponent<Animator>();
        };
        activateAiModel(aiTypes);

        switch (aiTypes)
        {
            case AI_Types.Archer:
                health = GameManager.Instance.archerHealth;
                range = GameManager.Instance.archerRange;
                damage = GameManager.Instance.archerDamage;
                if (tag == "Team2")
                    _projectileTag = "Team2_Projectile";
                if (tag == "Team1")
                    _projectileTag = "Team1_Projectile";
                break;
            case AI_Types.Warrior:
                health = GameManager.Instance.warriorHealth;
                range = GameManager.Instance.warriorRange;
                damage = GameManager.Instance.warriorDamage;
                break;
            case AI_Types.Mage:
                health = GameManager.Instance.mageHealth;
                range = GameManager.Instance.mageHealth;
                damage = GameManager.Instance.mageDamage;
                break;
            case AI_Types.Ninja:
                health = GameManager.Instance.ninjaHealth;
                range = GameManager.Instance.ninjaRange;
                damage = GameManager.Instance.ninjaDamage;
                break;
            default:
                break;
        }

    }

    private void Update()
    {
        if (health <= 0)
        {
            animator.SetBool("isDead", true);
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (animator != null)
        {
            AnimationClip currentClip = GetCurrentAnimatorClip(animator, 0);
            // Store the animation name as a string
            if (currentClip != null)
            {
                currentState = currentClip.name;
            }
            else
            {
                currentState = "No animation playing";
            }
        }
        else
        {
            currentState = "Animator reference not set";
        }
    }

    private AnimationClip GetCurrentAnimatorClip(Animator anim, int layer)
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(layer);
        return anim.GetCurrentAnimatorClipInfo(layer)[0].clip;
    }

    private void OnCollisionEnter(Collision collision)
    {
        NewAiBehaviour _enemyAI = collision.gameObject.GetComponent<NewAiBehaviour>();

        if (collision.gameObject.CompareTag("Team1_Projectile" ) || collision.gameObject.CompareTag("Team2_Projectile" ))
        {
            health -= GameManager.Instance.archerDamage;
            Debug.Log("Enemy Damaged");
        }
    }
}
