using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<PersonInformationCard> cards = new List<PersonInformationCard>();
    [SerializeField]
    List<GameObject> PlayAreaCards = new List<GameObject>();

    [SerializeField]
    private GameObject personInfoCard;
    [SerializeField]
    private GameObject slotbutttonprefab;
    public static GameManager instance;
    private int currentCardNum = 0;

    [SerializeField]
    Transform handArea;

    [SerializeField]
    Transform slotOnePos, slotTwoPos, slotThreePos;

    int points = 0;
    [SerializeField]
    TextMeshProUGUI pointsText;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    [SerializeField]
    List<Prizes> p2 = new List<Prizes>();

    public void StartGameManager(Prizes[] p)
    {
        //spawn in each of the 10 cards
        //player has to put cards in order
        //choose a random card from these
        //if the year is between 1940 -1945 then remove it from the list
        /*
        for (int i = 0; i < p.Length; i++)
        {
            //Debug.Log(i);
            if (p[i].year == "1940" || p[i].year == "1941" || p[i].year == "1942" || p[i].year == "1943" || p[i].year == "1944" ||p[i].year == "1945" || p[i].overallMotivation != "" || p[i].overallMotivation != string.Empty)
            {
                //Debug.Log("YEar");
            }
            else
            {
                Debug.Log("ISD");
                p2.Add(p[i]);
            }
        }
        


        int[] x = new int[10];
        for (int i = 0; i < 10; i++)
        {
            x[i] = Random.Range(0,p.Length);
            //Debug.Log(x[i] + " " +p[i].year  + " " + p[i].laureates[0].surname);
        }
        for (int i = 0; i < p.Length; i++)
        {
            for (int j = 0; j < x.Length; j++)
            {
                if (i == x[j])
                {
                    //save this
                    GameObject g = Instantiate(personInfoCard);
                    g.transform.SetParent(GameObject.Find("GameCanvas").transform);
                    g.transform.localScale = Vector3.one;
                    PersonInformationCard pic = g.GetComponent<PersonInformationCard>();
                    Debug.Log(i + " " + p[i].year + p[i].overallMotivation);
                    if (p[i].laureates != null)
                    {
                        if (p[i].overallMotivation != "No Nobel Prize was awarded this year. The prize money was allocated to the Special Fund of this prize section.")
                        {
                            Debug.Log(p[i].laureates[0].firstname + " "
                                + p[i].laureates[0].surname + " " + p[i].laureates[0].motivation 
                                + " " + p[i].year);

                            pic.initialize(p[i].laureates[0].firstname + " "
                                + p[i].laureates[0].surname, p[i].laureates[0].motivation, p[i].year);

                            cards.Add(pic);
                            g.transform.position = handArea.position;
                        }
                    }

                }
            }
        }
        */

        /*
        
        //create central card
        int rnum = Random.Range(0, p.Length);
        GameObject rg = Instantiate(personInfoCard);
        rg.transform.SetParent(GameObject.Find("GameCanvas").transform);
        rg.transform.localScale = Vector3.one;
        Instantiate(rg, playArea);
        PersonInformationCard pig = rg.GetComponent<PersonInformationCard>();
        pig.initialize(p[rnum].laureates[0].firstname + " "
            + p[rnum].laureates[0].surname, p[rnum].laureates[0].motivation, p[rnum].year);

        
        */

        int[] x = new int[10];
        for (int i = 0; i < 10; i++)
        {
            x[i] = Random.Range(0, p.Length);
        }

        //find the name of the last 10 nobel prize winners
        for (int i = 0; i < 50; i++)
        {
            GameObject g = Instantiate(personInfoCard);
            g.transform.SetParent(GameObject.Find("GameCanvas").transform);
            g.transform.localScale = Vector3.one;
            PersonInformationCard pic = g.GetComponent<PersonInformationCard>();

            pic.initialize(p[i].laureates[0].firstname + " "
                + p[i].laureates[0].surname + " ", p[i].laureates[0].motivation + " ", p[i].year + " ");

            cards.Add(pic);
            g.transform.position = handArea.position;

        }
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].gameObject.SetActive(false);
        }
        //x = cos(L( 0,2 * pi) ) * 5
        //y = sin(L( 0,2 * pi) ) * 5
        currentCardNum = 0;


        createChoices();

    }

    GameObject[] tempCardSlots = new GameObject[3];

    void createChoices()
    {
        cards[currentCardNum].gameObject.SetActive(true);
        //create choices 
        int t = Random.Range(0, 3);
        GameObject first = Instantiate(slotbutttonprefab, slotOnePos);
        InteractionSlot fis = first.GetComponent<InteractionSlot>();
        fis.initialize(cards[currentCardNum].YearNum, true);


        GameObject second = Instantiate(slotbutttonprefab, slotTwoPos);
        InteractionSlot sis = second.GetComponent<InteractionSlot>();
        int fakeyearone = Random.Range(1914, 2024);
        sis.initialize(fakeyearone, true);


        GameObject third = Instantiate(slotbutttonprefab, slotThreePos);
        InteractionSlot tis = third.GetComponent<InteractionSlot>();
        int fakeyeartwo = Random.Range(1914, 2024);
        tis.initialize(fakeyeartwo, true);


        tempCardSlots[0] = first;
        tempCardSlots[1] = second;
        tempCardSlots[2] = third;
        if (t == 0)
        {
            first.transform.position = slotOnePos.position;
            second.transform.position = slotTwoPos.position;
            third.transform.position = slotThreePos.position;
        }
        else if (t == 1)
        {
            first.transform.position = slotTwoPos.position;
            second.transform.position = slotOnePos.position;
            third.transform.position = slotThreePos.position;

        }
        else
        {

            first.transform.position = slotThreePos.position;
            second.transform.position = slotTwoPos.position;
            third.transform.position = slotOnePos.position;
        }
    }
    private void Update()
    {
        pointsText.text = points.ToString();
    }
    public void playerMadeMove(bool correctchoice)
    {
        if (points >= 10 )
        {
            //change scene if current number is == to the amount of cards in deck or player has 10 points
            SceneManager.LoadScene(2);
        }
        else if (currentCardNum >= cards.Count - 1)
        {
            SceneManager.LoadScene(3);
        }
        cards[currentCardNum].gameObject.SetActive(false);
        currentCardNum++;
        //player chooses where to place card, if they choose the wrong location then they lose, if all locations are correct then they win

        //every card should have an interaction slot to the left and right of it
        if (correctchoice)
        {
            points++;
        }
        
        Destroy(tempCardSlots[0].gameObject);
        tempCardSlots[0] = null;
        Destroy(tempCardSlots[1].gameObject);
        tempCardSlots[1] = null;
        Destroy(tempCardSlots[2].gameObject);
        tempCardSlots[2] = null;
        createChoices();
    }
}
