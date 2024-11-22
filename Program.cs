using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _tep_avec_list
{
    /* Bienvenue dans KOTA V2 avec |  List  | */
    internal class Program
    {

        public static List<string> TitresFilmo = new List<string>();
        public static List<int> CoteFilmo = new List<int>();
        public static string? GlobalUserChoice;
        public static bool OperationContinue = true;
        public const int STOCKMAX = 20;
        public static int TrackerLetatPoutDetails = 0;
        

        static void Main(string[] args)
        {
            
            do
            {
                TrackerLetatPoutDetails++;

                AfficherManuelUser();
                Console.WriteLine(" ");
                LeChoixDuUser("Entrez votre choix : ");

                switch (GlobalUserChoice)
                {
                    case "1":
                        /* Ajouter Un Film Avec sa Cote */
                        AjouterFimAvecCote(TitresFilmo, CoteFilmo);
                        break;
                    case "2":
                        /* Afficher Le resultat du film */
                        AfficherToutLesCotes(TitresFilmo, CoteFilmo);
                        break;
                    case "3":
                        ModifierUniquementLacoteDuFilm(TitresFilmo, CoteFilmo);
                        break;
                    case "4":
                        TrouvelerLeFilmMieuxNoterEtMoisNote(TitresFilmo, CoteFilmo);
                        break;
                    case "5":
                        LaCoteMoyens(CoteFilmo);
                        break;
                    case "6":
                        OperationContinue = false;
                        break;
                    default:
                        Console.WriteLine($" Desole mais le choix {GlobalUserChoice} " +
                        $"n'existe pas !!!");

                        break;
                }

            } while (OperationContinue == true);






        }


        /* ************************** Logic Principal ici  ** START ***************************************** */

        // |  Ajouter Film avec cote ici  | 
        public static void AjouterFimAvecCote(List<string> FilmNomo, List<int> CoteFilmo)
        {
            bool DemandeEncore = false;
            string? FilmoData;

            do
            {
                // Ajouter Le tritre du film
                Console.WriteLine("Entrez le titre du film:");
                FilmoData = Console.ReadLine();
                Console.WriteLine("Entrez la cote du film (sur 10) :");
                string? CoteAttempt = Console.ReadLine();

                bool Convertion = int.TryParse(CoteAttempt, out int CoteData);
                if(Convertion != true)
                {
                    Console.WriteLine($"Desole mais {CoteAttempt} n'est pas valide");
                }
                else
                {
                    if (FilmoData?.Length >= 1 && CoteData >= 0 && CoteData <= 10)
                    {

                        // Ajouter Le film dans le pagner ici
                        FilmNomo.Add(FilmoData);
                        DemandeEncore = false;
                        // Ajoutons le resultat dans le pagner
                        CoteFilmo.Add(CoteData);
                        Console.WriteLine("Film ajouté avec succès !");
                    }else if(CoteData < 0 && CoteData > 10)
                    {
                        Console.WriteLine("Desole mais la cote est trop grand");
                    }
                    else
                    {
                        DemandeEncore = true;
                        Console.WriteLine("Desole mais vous devez dabord ajouter un titre  ");
                    }
                }



                // Ajouter La cote du film
              
                
            } while (DemandeEncore == true && FilmoData?.Length <= 1);


           

        }

        // Voir tout les cote du film
        public static void AfficherToutLesCotes(List<string> FilmNomo, List<int> CoteFilmo)
        {
            //Bon ici c'est simple on affiche le resultat tanque 
            // La list n'est == 0 mais is vrai alor affiche un 
            // message d'erreur .

            if(VerificationSiListVide(FilmNomo, CoteFilmo))
            {
                Console.WriteLine("Erreur : Desole maisn vous devez dabord ajouter un niv film. ");
            }
            else
            {
                Console.WriteLine("   - Liste des films :");
                Console.WriteLine(" ");
                for (int i = 0; i < FilmNomo.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {FilmNomo[i]} - {CoteFilmo[i]}/10 ");
                }
            }

        }
        /* @Developpeurs M.r SOH ACHILLE ET M.r SIM FRED */
        public static bool VerificationSiListVide(List<string> FilmNomo, List<int> CoteFilmo)
            => FilmNomo.Count == 0 && CoteFilmo.Count == 0;// returne moi un vrai/ou/faux



        // Modifier La Cote du film
        public static void ModifierUniquementLacoteDuFilm(List<string> FilmNomo, List<int> CoteFilmo)
        {
            if(CoteFilmo.Count > 0)
            {
                /* Ok Demandons a notre user d'entre l'index du film a modifier */
                Console.WriteLine("Entrez l'index du film à modifier (1 à 1) :");
                string? NouvelIndexString = Console.ReadLine();
                // Fait moi vite une verification ici
                if (int.TryParse(NouvelIndexString, out int IndexMatch))
                {
                    // Si la verification est correct alors fait moi ceci tres vite
                    int Index = IndexMatch - 1; // voici l'index
                    Console.WriteLine("Entrez la nouvelle cote :");
                    string? TryNouvelleCote = Console.ReadLine();
                    if (int.TryParse(TryNouvelleCote, out int NouvelleCote))
                    {
                        if (VerificationDe0A10(NouvelleCote))
                        {
                            Console.WriteLine("Desole mais la cote doit varier entre | 0 ET 10 | ");
                        }
                        CoteFilmo[Index] = NouvelleCote;
                        Console.WriteLine("Cote mise à jour avec succès !");
                    }


                }
                else
                {
                    // si conversion == false
                    Console.WriteLine(" Il y a eu un probleme l'hors de la conversion");
                }
            }
            else
            {
                Console.WriteLine("Desole mais il y a pas encoroe de Cote Ajouter d'abord");
            }


        }
        public static bool VerificationDe0A10(int NouvelleCote)
        { // retourne moi ceci si condition 
            return  NouvelleCote < 0 || NouvelleCote > 10 ? true : false; // Operator T:~
        }

        public static void TrouvelerLeFilmMieuxNoterEtMoisNote(List<string> FilmNomo, List<int> CoteFilmo)
        {
            if(CoteFilmo.Count <= 0)
            {
                Console.WriteLine("Desole mais il y a rien dans le pagner des cotes");
            }
            else
            {
                int MaxNumber = CoteFilmo[0];
                int MinNumber = CoteFilmo[0];

                // Trouve moi l'index en question
                int IndexMax = 0;
                int IndesMin = 0;

                for (int i = 0; i < CoteFilmo.Count; i++)
                {
                    if (CoteFilmo[i] > MaxNumber)
                    {
                        MaxNumber = CoteFilmo[i];
                        IndexMax = i;
                    }
                    if (CoteFilmo[i] < MinNumber)
                    {
                        MinNumber = CoteFilmo[i];
                        IndesMin = i;

                    }
                }

                // Afficher moi le resultat ettendu ici mon pot

                Console.WriteLine($"Film le mieux noté : {FilmNomo[IndexMax]} - {MaxNumber}/10");
                Console.WriteLine($"Film le Moins noté : {FilmNomo[IndesMin]} - {MinNumber}/10");

            }



        }
        public static void LaCoteMoyens(List<int> CoteFilmo)
        {
            if(CoteFilmo.Count == 0)
            {
                Console.WriteLine("Desole mais il y a rien dans le pagner des cotes");
            }
            else
            {
                int Somme = 0;
                int Moyenne = 0;



                foreach (int Cote in CoteFilmo)
                {
                    Somme = Somme + Cote;
                }
                // Cote Moyenne
                Moyenne = Somme / CoteFilmo.Count;

                Console.WriteLine($"La cote moyenne des films est de : {Moyenne}.0/10");
            }


        }
     


        /* ************************** Logic Principal ici ** FIN ***************************************** */

















        /*  ***************************** DETAIL AVEC MANUEL ********** SOH TAGNE ACHILLE **************** ET ********* SIM FRED*************************** */


        public static void AfficherManuelUser()
        {
            // Petite informations  -> | * @Developpeur SOH ACHILLE ET SIM FRED   *  |  <-
            if( TrackerLetatPoutDetails <= 1 )
            {
                PetitieInformation();
            }
           
            Console.WriteLine("  ");
            Console.WriteLine(" ");
            Console.WriteLine("Menu :");
            Console.WriteLine(" ");
            Console.WriteLine("1. Ajouter des films et leurs cotes");
            Console.WriteLine("2. Afficher tous les films et leurs cotes");
            Console.WriteLine("3. Modifier la cote d'un film");
            Console.WriteLine("4. Trouver le film le mieux et le moins bien noté");
            Console.WriteLine("5. Calculer la cote moyenne des films");
            Console.WriteLine("6. Quitter");
        }
        public static void PetitieInformation()
        {
            DateTime Aujourd = DateTime.Now;
            Console.WriteLine("|**| Bienvenue dans |*| KOTA");
            Console.WriteLine($"|**| Stock Limit |*| {STOCKMAX}");
            Console.WriteLine($"|**| Jour : {Aujourd} *");
            Console.WriteLine("  ");
            /* J'appelle le Logo ici ___ @developpeur  SOH TAGNE ACHILLE ET FIN */

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            Logo();
            Console.WriteLine(" ");

            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

            Console.WriteLine(" ");
            Console.WriteLine(" ");

        }

        public static void Logo()
        {
            Console.WriteLine(@"_______________________________ _________     _____ _____________________  ._.   ____  __.________________________    ._. 
\__    ___/\_   _____/\_   ___ \\_   ___ \   /  _  \\______   \__    ___/  | |  |    |/ _|\_____  \__    ___/  _  \   | | 
  |    |    |    __)_ /    \  \//    \  \/  /  /_\  \|       _/ |    |     |_|  |      <   /   |   \|    | /  /_\  \  |_| 
  |    |    |        \\     \___\     \____/    |    \    |   \ |    |     |-|  |    |  \ /    |    \    |/    |    \ |-| 
  |____|   /_______  / \______  /\______  /\____|__  /____|_  / |____|     | |  |____|__ \\_______  /____|\____|__  / | | 
                   \/         \/        \/         \/       \/             |_|          \/        \/              \/  |_| ");
        }


        public static string LeChoixDuUser(string UserChoice)
        {
            Console.WriteLine(UserChoice);

            GlobalUserChoice = Console.ReadLine();
            return UserChoice;



        }
    }
}
