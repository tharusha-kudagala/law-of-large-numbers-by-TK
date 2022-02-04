    using System;

    namespace Gem_N_Doors
    {
        class MainClass
        {
            public static void Main(string[] args)
            {

                int gemDoor = 0;
                int selectDoor = 0;
                int possibleDoor = 0;

                int match = 0;
                int notmatch = 0;
                double percentage = 0;

                Console.Write("දොරවල් සංඛ්‍යාව : ");
                int noOfDoors = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nවාර සංඛ්‍යාව : ");
                int rounds = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nවට සංඛ්‍යා​ව : ");
                int noOfSets = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nතේරීම වෙනස් කල යුතුද ? (1 ඔව්, 0 නැහැ) : ");
                int needSwitch = Convert.ToInt32(Console.ReadLine());

                bool isSwitched = false;

                if (needSwitch == 1)
                    isSwitched = true;
                else
                    isSwitched = false;

                for (int i = 0; i < noOfSets; i++)
                {

                    for (int j = 0; j < rounds; j++)
                    {
                        gemDoor = PutGemToDoor();
                        selectDoor = SelectRandomDoor();
                        possibleDoor = PossibleDoor(selectDoor);

                        if (possibleDoor == gemDoor)
                        {
                            match++;
                        }
                        else
                        {
                            notmatch++;
                        }
                    }
                }

            
                string answer = String.Empty;

                if (isSwitched)
                {
                    percentage = (Convert.ToDouble(notmatch / noOfSets) / Convert.ToDouble((match + notmatch) / noOfSets) * 100);
                    answer = String.Format("‍‍\nවාර {0} බැගින් වට {1}කට පසුව, ඔබ පසුව තේරූ දොරෙහි මැණික තිබීමට හැකි සම්භාවිතාව {2} % ක් වේ.\n(මුලු වාර ගනනින් {3}/{4} යි)", rounds, noOfSets, percentage, notmatch, match + notmatch);

                }
                else
                {
                    percentage = (Convert.ToDouble(match / noOfSets) / Convert.ToDouble((match + notmatch) / noOfSets) * 100);
                    answer = String.Format("\nවාර {0} බැගින් වට {1}කට පසුව, මැණික මුලින්ම තේරූ දොරේ තිබීමට හැකි සම්භාවිතාව {2} % ක් වේ.\n(මුලු වාර ගනනින් {3}/{4} යි)", rounds, noOfSets, percentage, match, match + notmatch);

                }


                Console.WriteLine(answer);

                int PutGemToDoor()
                {
                    Random ran = new Random();
                    return ran.Next(1, noOfDoors + 1);
                }

                int SelectRandomDoor()
                {
                    Random ran = new Random();
                    return ran.Next(1, noOfDoors + 1);
                }

                int PossibleDoor(int OpenedDoor)
                {
                    int door = 0;
                    Random ran = new Random();
                    door = ran.Next(1, noOfDoors + 1);
                    while (door == OpenedDoor)
                    {
                        door = PossibleDoor(OpenedDoor);
                    }
                    return door;
                }

            }
        }
    }
