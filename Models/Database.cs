
using System.Collections.Generic;

namespace dojeopardy
{

        public class Pet
        {
            public static int count=0;
            public int PetId {get; set;}
            public string Name {get; set;}
            public string Type { get; set; }
            // public int NumberOfTimesBryannaUsedAsAnExampleAndYouAllAreSickOfIt {get; set;}
            public int TimesUsedInDemos {get; set;}


            public Pet(string name, string type, int num)
            {
                count++;
                PetId=count;
                Name = name;
                Type = type;
                TimesUsedInDemos = num;
            }

        }


    
}

