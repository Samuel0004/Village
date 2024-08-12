using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
            Destroy(this.gameObject);
        theStat = FindObjectOfType<PlayerStat>();
    }
    #endregion Singleton
    static public DatabaseManager instance;

    //
    public string[] var_name;
    public float[] var;

    //to track which events occured in-game
    public string[] switch_name;
    public bool[] switches; 
    
    [Header("Data Structures")]
    public List<Item> itemList = new List<Item>(); //list that contains all items in game

    [Header("References")]
    public GameObject parent;
    private PlayerStat theStat;

    void Start()
    {
        //USE
        itemList.Add(new Item(10001, "����", "�̽��� ������. ���ø� ü���� ȸ���� �� �ִ�", Item.ItemType.Use));
        itemList.Add(new Item(10002, "����", "��ó�� ���ϰ� ���� ���̴�. ���ø� ���� ������", Item.ItemType.Use));
        itemList.Add(new Item(10003, "����", "�� ���� �����.", Item.ItemType.Use));
        itemList.Add(new Item(10004, "��", "���� �ٻ��ϰ� ���� ������ ���̴�", Item.ItemType.Use));
        //ETC
        itemList.Add(new Item(20001, "������","������ �����̴�.",Item.ItemType.ETC));
        itemList.Add(new Item(20002, "������ ��", "�������� ���п��� 90%�� �����ϴ� ������ ��ü��", Item.ItemType.ETC));
        itemList.Add(new Item(20003, "��", "��ε��� ���� �ڿ��� �������� ������� ���̴�", Item.ItemType.ETC));
        itemList.Add(new Item(20004, "���� ����", "��Ÿ�� �� �̱۰Ÿ��� ���Ŵ�", Item.ItemType.ETC));
        itemList.Add(new Item(20005, "��Ȳ ����", "�Ƹ��ٿ� ���������� ������ ���Ŵ�", Item.ItemType.ETC));
        //QUEST
        itemList.Add(new Item(30003, "�ݵ���", "���� ������ ������ �ݵ����̴�", Item.ItemType.Quest, "������ �Ż翡 ��ģ��", "��ġ�� �ʴ´�"));
        itemList.Add(new Item(30004, "����", "���� ¤�̱� ������ �����̴�", Item.ItemType.Quest, "������ ȭ�ξȿ� �ִ´�", "���� �ʴ´�"));
        itemList.Add(new Item(30005, "�����", "�̽��� ������", Item.ItemType.Quest, "����⸦ ���� ���� �÷��д�","�ƹ� �͵� ���� �ʴ´�"));
        itemList.Add(new Item(30006, "ö ����", "ȭ������ ������ ���� �����̴�", Item.ItemType.Quest, "ö�� ��翡 ��ģ��", "��ġ�� �ʴ´�"));
        itemList.Add(new Item(30007, "�عٶ��", "�¾簰�� ���� �վ�� ���̴�", Item.ItemType.Quest, "�عٶ�⸦ ���ø���", "�ƹ� �͵� ���� �ʴ´�"));
        itemList.Add(new Item(30008, "���� ���", "�ڽ��� ���ؼ� ����ϴ� ������ �ٶ󺸴� ������ ��� ����̴�", Item.ItemType.Quest, "", ""));
        itemList.Add(new Item(30009, "������ ���", "�ڽ��� ���ؼ� ����ϴ� ���� �ٶ󺸴� ������ ��� ����̴�", Item.ItemType.Quest, "", ""));


    }
    public int LookFor(int itemId)
    {
        ///recursively look for item with given itemID
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemId == itemList[i].itemID)
                return i;
        }
        return 0;
    }

    public void UseItem(int _itemID)
    {
        switch (_itemID)
        {
            case 10001: //milk
                theStat.Heal_HP(1);
                break;
            case 10002: //red_potion
                theStat.StaminaBuff(10);
                break;
            case 10003://strawberry
                theStat.Heal_HP(1);
                theStat.Heal_Stamina(200);
                break;
            case 10005://bread
                theStat.Heal_HP(3);
                theStat.Heal_Stamina(300);
                break;
            default:
                break;
        }
    }

}
