using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace ActionResults.Models 
{
    [DataContract]
    public class Character
    {
        [DataMember]
        public string Name = "Jessica Rabbit";

        [DataMember]
        public int Level = 25;

        [DataMember]
        public int HealthPoints = 100;

        [DataMember]
        public Dictionary<string, int> Attributes = new Dictionary<string,int>(){
                {"IQ", 24},
                {"ME", 10},
                {"MA", 16},
                {"PS", 8},
                {"PP", 20},
                {"PE", 3},
                {"Pb", 30},
                {"Spd", 5}
        };

        public override string ToString()
        {
            string temp = " ";
            foreach(KeyValuePair<string,int> att in Attributes){
                temp += "[" + att.Key + ": " + att.Value + "]";
            }

            return "[Name: " + Name + "] [Level: " + Level + "] [Health Points: " + HealthPoints + "] [Attributes: " + temp + " ]" ;
        }

       

    }
}