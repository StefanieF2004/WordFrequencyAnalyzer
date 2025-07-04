namespace WinFormsApp5 //deklaracija na prostor so iminja kade sto se naoga nasata aplikacija
{
    public partial class Form1 : Form //ovaa klasa ja pretstavuva glavnata forma vo aplikacijata
    {
        public Form1()  //konstruktor na klasata
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)  //metoda koja se povikuva pri klik na kopceto Procesiraj>>
        {
            string tekst = textBox1.Text.ToLower(); //aplikacijata ne e casesensitiv pa zatoa gi pretvarame golemite vo mali bukvi i site presmetki podolu se pravat vrz zborovi od mali bukvi
            string[] redovi = tekst.Split('\n');    //go dellime tekstot od textBox1 na redovi

            List<string> siteZborovi = new List<string>();  //ova e lista kade ke se cuvaat site zborovi
            List<string> vekjeObraboteni = new List<string>();  //lista so vekje obraboteni zborovvi
            List<int> frekvencii = new List<int>(); //lista za frekfencii koi podocna ke gi upotrebuvame za da gi sporedime i da gi ispiseme vo textBox2

            foreach (string red in redovi)  //zimame gi site zborovi od site redovi
            {
                string[] zboroviVoRed = red.Split(' '); //gi delime redovite i kako elementi gi imame zborovite od redovite

                foreach (string zborVoRed in zboroviVoRed)  //zemame zbor po zbor od zborovite vo daden red
                {
                    string zbor = zborVoRed.Trim(new char[] { '.', ',', '?', '!' }); //gi trgame interpukciskite znaci kako tocka, zapirka , prasalnik i izvicnik

                    if (zbor != "") //proveruvame dali zborot ne e prazno mesto
                    {
                        siteZborovi.Add(zbor);  //dokolku ne e prazno mesto zborot se dodava vo siteZborovi preku funkcionalnosta Add koja ja imaat Listite
                    }
                }
            }
            foreach (string zbor in siteZborovi)    //minuva po site zborovi
            {
                if (!vekjeObraboteni.Contains(zbor))    //ako vekjeObraboteni ne go sodrzi zborot koj e element na ispituvanje
                {
                    int brojac = 0;

                    foreach (string z in siteZborovi)   //minuva po site zborovi
                    {
                        if (z == zbor) //sporedba dali se ednakvi zborovite  
                        {
                            brojac++;  //dokolku uslovot e tocen brojot na isti zborovi se zgolemuva
                        }
                    }

                    vekjeObraboteni.Add(zbor);  //vo listata na vekjeObraboteni se dodava zborot za koj stanuvalo zbor ovaa iteracija
                    frekvencii.Add(brojac);    //a vo listata frekfencii se dodava brojacot
                }
            }

            for (int i = 0; i < frekvencii.Count - 1; i++)//odi od prviot do posledniot
            {
                for (int j = i + 1; j < frekvencii.Count; j++)  //pocnuva od slednata frekfencija
                {
                    if (frekvencii[j] > frekvencii[i])
                    {
                        int tempBroj = frekvencii[i];
                        frekvencii[i] = frekvencii[j];
                        frekvencii[j] = tempBroj;   //menuva vrednosti dokolku j-tata frekfencija e pogolema od i-tata

                        string tempZbor = vekjeObraboteni[i];
                        vekjeObraboteni[i] = vekjeObraboteni[j];
                        vekjeObraboteni[j] = tempZbor;  //menuva gi zborovite
                    }
                }
            }

            textBox2.Clear();   //go cisti textBox2
            for (int i = 0; i < vekjeObraboteni.Count; i++) //gi mine site obraboteni
            {
                textBox2.Text += vekjeObraboteni[i] + "\t" + frekvencii[i].ToString() + "\r\n"; 
                    //go dodavame sekoj zbor i negovata frekfencija vo no vred

            }
        }
    }
}
